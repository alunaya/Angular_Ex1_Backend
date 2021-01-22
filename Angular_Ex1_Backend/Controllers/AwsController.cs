using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Angular_Ex1_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwsController : ControllerBase
    {
        public readonly AmazonEC2Client ec2Client;

        public AwsController(AmazonEC2Client ec2Client)
        {
            this.ec2Client = ec2Client ?? throw new ArgumentNullException(nameof(ec2Client));
        }


        [HttpGet]
        public async Task<IActionResult> getInstanceTypeList()
        {
            DescribeInstanceTypeOfferingsRequest request = new DescribeInstanceTypeOfferingsRequest();
            var result = await ec2Client.DescribeInstanceTypeOfferingsAsync(request);
            return new JsonResult(result.InstanceTypeOfferings.Select(x=>x.InstanceType.Value));
        }
    }
}

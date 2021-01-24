using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.EC2;
using Amazon.EC2.Model;
using Angular_Ex1_Backend.Database.CodeFirst;
using Angular_Ex1_Backend.Business;
using Angular_Ex1_Backend.Model;

namespace Angular_Ex1_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwsController : ControllerBase
    {
        private readonly AmazonEC2Client ec2Client;
        private readonly IMonthRepo monthRepo;
        private readonly IServicesBillingRepo serviceBillingRepo;
        private readonly IReservationCoverageRepo reservedCoverageRepo;

        public AwsController(AmazonEC2Client ec2Client, IMonthRepo monthRepo, IServicesBillingRepo serviceBillingRepo, IReservationCoverageRepo reservedCoverageRepo)
        {
            this.ec2Client = ec2Client ?? throw new ArgumentNullException(nameof(ec2Client));
            this.monthRepo = monthRepo ?? throw new ArgumentNullException(nameof(monthRepo));
            this.serviceBillingRepo = serviceBillingRepo ?? throw new ArgumentNullException(nameof(serviceBillingRepo));
            this.reservedCoverageRepo = reservedCoverageRepo ?? throw new ArgumentNullException(nameof(reservedCoverageRepo));
        }

        [HttpGet("month")]
        public async Task<List<MonthModel>> GetMonth()
        {
            return monthRepo.GetAllMonths();
        }

        [HttpGet("reservation-coverage/{monthId}")]
        public async Task<List<ReservationCoverageModel>> GetReservationCoverage(string monthId) {
            return reservedCoverageRepo.GetReservationCoverage(monthId);
        }

        [HttpGet("services-bill/{monthId}")]
        public async Task<ServicesBillingModel> GetServicesBilling(string monthId)
        {
            return serviceBillingRepo.GetServiceBilling(monthId);
        }
    }
}

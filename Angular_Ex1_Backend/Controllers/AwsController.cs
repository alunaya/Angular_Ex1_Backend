﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.EC2;
using Amazon.EC2.Model;
using Angular_Ex1_Backend.Business;
using Angular_Ex1_Backend.Model;
using Microsoft.AspNetCore.Authorization;

namespace Angular_Ex1_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AwsController : ControllerBase
    {
        private readonly IMonthRepo monthRepo;
        private readonly IServicesBillingRepo serviceBillingRepo;
        private readonly IReservationCoverageRepo reservedCoverageRepo;

        public AwsController(AmazonEC2Client ec2Client, IMonthRepo monthRepo, IServicesBillingRepo serviceBillingRepo, IReservationCoverageRepo reservedCoverageRepo)
        {
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

using Angular_Ex1_Backend.Model;
using Angular_Ex1_Backend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_Ex1_Backend.Business
{
    public class ServicesBillingRepo : IServicesBillingRepo
    {
        private readonly IServiceBillingData serviceBillingData;
        private readonly IMonthData monthData;

        public ServicesBillingRepo(IServiceBillingData serviceBillingData, IMonthData monthData)
        {
            this.serviceBillingData = serviceBillingData ?? throw new ArgumentNullException(nameof(serviceBillingData));
            this.monthData = monthData ?? throw new ArgumentNullException(nameof(monthData));
        }

        public ServicesBillingModel GetServiceBilling(string monthId)
        {
            ServicesBillingModel result = new ServicesBillingModel();
            result.ServiceBills = serviceBillingData.GetServicesBill(monthId).Select(x => new ServiceBill
            {
                ServiceName = x.ServicesName,
                Cost = x.Bill,
            }).ToList();

            result.PreviousMonthCost = serviceBillingData.GetPreviousMonthBill(monthId);
            result.IsCurrentMonth = monthData.CheckIsCurrentMonth(monthId);
            result.MonthId = monthId;
            return result;
        }
    }
}

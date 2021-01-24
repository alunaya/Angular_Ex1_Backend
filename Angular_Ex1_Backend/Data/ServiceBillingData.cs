using Angular_Ex1_Backend.Database.CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_Ex1_Backend.Repository
{
    public class ServiceBillingData : IServiceBillingData
    {
        private readonly AngularTest1DbContext context;

        public ServiceBillingData(AngularTest1DbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<ServicesBill> GetServicesBill(Months month)
        {
            return context.ServicesBill.Where(x => x.Months.MonthId == month.MonthId).ToList();
        }

        public List<ServicesBill> GetServicesBill(string monthId)
        {
            return context.ServicesBill.Where(x => x.Months.MonthId.ToString() == monthId).ToList();
        }

        public decimal? GetPreviousMonthBill(string monthId) {

            var currentMonths = context.Months.Where(x => x.MonthId.ToString() == monthId).FirstOrDefault();
            if(currentMonths == null)
            {
                return null;
            }

            var previousMonth = context.Months.Where(x =>
                x.Date.AddMonths(1).Month == currentMonths.Date.Month && x.Date.AddMonths(1).Year == currentMonths.Date.Year
            ).FirstOrDefault();

            if(previousMonth == null)
            {
                return null;
            }

            return context.ServicesBill.Where(x =>
                x.Months.Date.Month == previousMonth.Date.Month && x.Months.Date.Year == previousMonth.Date.Year
            ).Sum(x => x.Bill);
        }

        
    }
}

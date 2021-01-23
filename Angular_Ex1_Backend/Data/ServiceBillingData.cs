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

        public List<ServicesBill> GetServicesBill(long monthId)
        {
            return context.ServicesBill.Where(x => x.Months.MonthId == monthId).ToList();
        }

        public decimal? GetPreviousMonthBill(long monthId) {

            var currentMonths = context.Months.Where(x => x.MonthId == monthId).FirstOrDefault();
            if(currentMonths == null)
            {
                return null;
            }

            var previousMonth = context.Months.Where(x =>
                x.Month.AddMonths(1).Month == currentMonths.Month.Month && x.Month.AddMonths(1).Year == currentMonths.Month.Year
            ).FirstOrDefault();

            if(previousMonth == null)
            {
                return null;
            }

            return context.ServicesBill.Where(x =>
                x.Months.Month.Month == previousMonth.Month.Month && x.Months.Month.Year == previousMonth.Month.Year
            ).Sum(x => x.Bill);
        }

        
    }
}

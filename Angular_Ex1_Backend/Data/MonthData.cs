using Angular_Ex1_Backend.Database.CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_Ex1_Backend.Repository
{
    public class MonthData : IMonthData
    {
        private readonly AngularTest1DbContext context;

        public MonthData(AngularTest1DbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Months> GetAllMonths()
        {
            return context.Months.ToList();
        }

        public Months GetMonth(DateTime time)
        {
            return context.Months.Where(x => time.Month == x.Month.Month && time.Year == x.Month.Year).FirstOrDefault();
        }

        public Months GetMonth(long monthId)
        {
            return context.Months.Where(x => x.MonthId == monthId).FirstOrDefault();
        }

        public bool CheckIsCurrentMonth(long monthId)
        {
            var currentMonth = context.Months.Where(x => x.MonthId == monthId).FirstOrDefault();
            if(currentMonth == null)
            {
                return false;
            }

            return currentMonth.Month.Month == DateTime.Now.Month && currentMonth.Month.Year == DateTime.Now.Year;
        }
    }
}

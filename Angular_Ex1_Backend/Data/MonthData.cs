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
            return context.Months.Where(x => time.Month == x.Date.Month && time.Year == x.Date.Year).FirstOrDefault();
        }

        public Months GetMonth(string monthId)
        {
            Guid monthGuid = Guid.Parse(monthId);
            return context.Months.Where(x => x.MonthId == monthGuid).FirstOrDefault();
        }

        public bool CheckIsCurrentMonth(string monthId)
        {
            Guid monthGuid = Guid.Parse(monthId);
            var currentMonth = context.Months.Where(x => x.MonthId == monthGuid).FirstOrDefault();
            if(currentMonth == null)
            {
                return false;
            }

            return currentMonth.Date.Month == DateTime.Now.Month && currentMonth.Date.Year == DateTime.Now.Year;
        }
    }
}

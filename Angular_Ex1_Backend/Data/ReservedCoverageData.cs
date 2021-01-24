using Angular_Ex1_Backend.Database.CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_Ex1_Backend.Repository
{
    public class ReservedCoverageData : IReservedCoverageData
    {
        private readonly AngularTest1DbContext context;

        public ReservedCoverageData(AngularTest1DbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<ReservationCoverage> GetReservationCoverage(Months month)
        {
            return context.ReservationCoverages.Where(x => x.Months.MonthId == month.MonthId).ToList();
        }

        public List<ReservationCoverage> GetReservationCoverage(string monthId)
        {
            return context.ReservationCoverages.Where(x => x.Months.MonthId.ToString() == monthId).ToList();
        }
    }
}

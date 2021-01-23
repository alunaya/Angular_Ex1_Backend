using Angular_Ex1_Backend.Database.CodeFirst;
using System.Collections.Generic;

namespace Angular_Ex1_Backend.Repository
{
    public interface IReservedCoverageData
    {
        List<ReservationCoverage> GetReservationCoverage(Months month);
        List<ReservationCoverage> GetReservationCoverage(long monthId);
    }
}
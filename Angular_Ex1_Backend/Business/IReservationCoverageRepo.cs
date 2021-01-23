using Angular_Ex1_Backend.Database.CodeFirst;
using Angular_Ex1_Backend.Model;
using System.Collections.Generic;

namespace Angular_Ex1_Backend.Business
{
    public interface IReservationCoverageRepo
    {
        List<ReservationCoverageModel> GetReservationCoverage(long monthId);
    }
}
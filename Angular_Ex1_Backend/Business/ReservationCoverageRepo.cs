using Angular_Ex1_Backend.Database.CodeFirst;
using Angular_Ex1_Backend.Model;
using Angular_Ex1_Backend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_Ex1_Backend.Business
{
    public class ReservationCoverageRepo : IReservationCoverageRepo
    {
        private readonly IReservedCoverageData reservedCoverageRepo;

        public ReservationCoverageRepo(IReservedCoverageData reservedCoverageRepo)
        {
            this.reservedCoverageRepo = reservedCoverageRepo ?? throw new ArgumentNullException(nameof(reservedCoverageRepo));
        }

        public List<ReservationCoverageModel> GetReservationCoverage(long monthId)
        {
            return reservedCoverageRepo.GetReservationCoverage(monthId).Select(x=>new ReservationCoverageModel {
                InstanceType = x.InstanceType,
                TotalHours = x.TotalHours,
                ReservedHours = x.ReservedHours,
            }).ToList();
            
        }
    }
}

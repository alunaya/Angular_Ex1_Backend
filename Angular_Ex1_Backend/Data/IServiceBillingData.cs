using Angular_Ex1_Backend.Database.CodeFirst;
using System.Collections.Generic;

namespace Angular_Ex1_Backend.Repository
{
    public interface IServiceBillingData
    {
        decimal? GetPreviousMonthBill(long monthId);
        List<ServicesBill> GetServicesBill(long monthId);
        List<ServicesBill> GetServicesBill(Months month);
    }
}
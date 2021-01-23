using Angular_Ex1_Backend.Model;

namespace Angular_Ex1_Backend.Business
{
    public interface IServicesBillingRepo
    {
        ServicesBillingModel GetServiceBilling(long monthId);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_Ex1_Backend.Model
{
    public class ServicesBillingModel
    {
        public bool IsCurrentMonth { get; set; }
        public decimal TotalCost { 
            get {
                return ServiceBills.Sum(x => x.Cost); 
            }
        }
        public decimal? PreviousMonthCost { get; set; }        
        public decimal? EstimatedCost { get {
                if (TotalCost > 0 && IsCurrentMonth) {
                    return TotalCost + 500;
                }

                return null;
            }
        }
        public decimal? ChangeFromLastMonth { 
            get {
                if (PreviousMonthCost.HasValue)
                {
                    return TotalCost - PreviousMonthCost;
                }
                return null;
            }
        }
        public List<ServiceBill> ServiceBills { get; set; }
        public ServicesBillingModel()
        {
            ServiceBills = new List<ServiceBill>();
        }
    }

    public class ServiceBill
    {
        public string ServiceName { get; set; }
        public decimal Cost { get; set; }
    }
}

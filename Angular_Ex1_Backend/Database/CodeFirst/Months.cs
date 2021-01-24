using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_Ex1_Backend.Database.CodeFirst
{
    public class Months
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MonthId { get; set; }
        public DateTime Date { get; set; }
        public List<ServicesBill> ServicesBills { get; set; }
        public List<ReservationCoverage> ReservationCoverages { get; set; }
    }
}

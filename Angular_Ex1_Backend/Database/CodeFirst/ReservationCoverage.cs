using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_Ex1_Backend.Database.CodeFirst
{
    public class ReservationCoverage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string InstanceType { get; set; }
        public float ReservedHours { get; set; }
        public float TotalHours { get; set; }
        public DateTime MonthYear { get; set; }
    }
}

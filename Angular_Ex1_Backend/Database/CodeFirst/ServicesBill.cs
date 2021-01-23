using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_Ex1_Backend.Database.CodeFirst
{
    public class ServicesBill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string ServicesName { get; set; }
        public decimal Bill { get; set; }
        public Months Months { get; set; }
    }
}

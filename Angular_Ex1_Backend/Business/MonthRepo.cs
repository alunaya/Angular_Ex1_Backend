using Angular_Ex1_Backend.Database.CodeFirst;
using Angular_Ex1_Backend.Model;
using Angular_Ex1_Backend.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_Ex1_Backend.Business
{
    public class MonthRepo : IMonthRepo
    {
        private readonly IMonthData monthRepo;

        public MonthRepo(IMonthData monthRepo)
        {
            this.monthRepo = monthRepo ?? throw new ArgumentNullException(nameof(monthRepo));
        }

        public List<MonthModel> GetAllMonths()
        {
            List<Months> months = monthRepo.GetAllMonths();
            List<MonthModel> result = new List<MonthModel>();
            foreach (var month in months)
            {
                result.Add(new MonthModel
                {
                    MonthId = month.MonthId,
                    DateString = month.Month.ToString("yyyy MMMM")
                });
            }

            return result;
        }
    }
}

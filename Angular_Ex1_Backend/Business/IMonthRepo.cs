using Angular_Ex1_Backend.Model;
using System.Collections.Generic;

namespace Angular_Ex1_Backend.Business
{
    public interface IMonthRepo
    {
        List<MonthModel> GetAllMonths();
    }
}
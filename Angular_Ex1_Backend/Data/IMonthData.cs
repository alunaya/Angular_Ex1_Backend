using Angular_Ex1_Backend.Database.CodeFirst;
using System;
using System.Collections.Generic;

namespace Angular_Ex1_Backend.Repository
{
    public interface IMonthData
    {
        bool CheckIsCurrentMonth(string monthId);
        List<Months> GetAllMonths();
        Months GetMonth(DateTime time);
        Months GetMonth(string monthId);
    }
}
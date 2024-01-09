using BudgetTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTrackerApp.DAL.Interface
{
    public interface IBudgetTrackerInterface 
    {
        IEnumerable<Budget> GetBudgets();
        Budget GetBudgetByID(int budgetId);
        Budget InsertBudget(Budget budget);
        int DeleteBudget(int budgetId);
        bool UpdateBudget(Budget budget);
        void Save();
    }
}
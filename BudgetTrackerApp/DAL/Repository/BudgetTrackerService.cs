using BudgetTrackerApp.DAL.Interface;
using BudgetTrackerApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetTrackerApp.DAL.Repository
{
    public class BudgetTrackerService : IBudgetTrackerInterface
    {
        private IBudgetTrackerRepository _repo;
        public BudgetTrackerService(IBudgetTrackerRepository repo)
        {
            this._repo = repo;
        }

        public int DeleteBudget(int budgetId)
        {
            var res= _repo.DeleteBudget(budgetId);
            return res;
        }

        public Budget GetBudgetByID(int budgetId)
        {
            return _repo.GetBudgetByID(budgetId);
        }
        public void Save()
        {
            _repo.Save();
        }


        IEnumerable<Budget> IBudgetTrackerInterface.GetBudgets()
        {
            return _repo.GetBudgets();
        }

        Budget IBudgetTrackerInterface.InsertBudget(Budget budget)
        {
            return _repo.InsertBudget(budget);
        }

        bool IBudgetTrackerInterface.UpdateBudget(Budget budget)
        {
            return _repo.UpdateBudget(budget);
        }
    }
}
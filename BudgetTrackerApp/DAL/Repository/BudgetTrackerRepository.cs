using BudgetTrackerApp.DAL.Interface;
using BudgetTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BudgetTrackerApp.DAL.Repository
{
    public class BudgetTrackerRepository : IBudgetTrackerRepository
    {
        private BudgetTrackerDbContext _context;
        public BudgetTrackerRepository(BudgetTrackerDbContext Context)
        {
            this._context = Context;
        }
        public IEnumerable<Budget> GetBudgets()
        {
             return _context.Budgets.ToList();
        }
        public Budget GetBudgetByID(int id)
        {
            return _context.Budgets.Find(id);
        }
        public Budget InsertBudget(Budget budget)
        {
            return _context.Budgets.Add(budget);
        }
        public int DeleteBudget(int budgetID)
        {
            Budget budget = _context.Budgets.Find(budgetID);
            var res= _context.Budgets.Remove(budget);
            return res.BudgetId;
        }
        public bool UpdateBudget(Budget budget)
        {
            var res= _context.Entry(budget).State = EntityState.Modified;
            return res.Equals("budget");
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

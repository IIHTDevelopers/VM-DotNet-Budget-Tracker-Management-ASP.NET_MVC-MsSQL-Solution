using BudgetTrackerApp.DAL.Interface;
using BudgetTrackerApp.DAL.Repository;
using BudgetTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BudgetTrackerApp.Controllers
{
    public class BudgetTrackerController : Controller
    {
        private readonly IBudgetTrackerInterface _Repository;
        public BudgetTrackerController(IBudgetTrackerInterface service)
        {
            _Repository = service;
        }
        public BudgetTrackerController()
        {
            // Constructor logic, if needed
        }
        // GET: BudgetTracker
        public ActionResult Index()
        {
            var budgets = from work in _Repository.GetBudgets()
                        select work;
            return View(budgets);
        }

        public ViewResult Details(int id)
        {
            Budget budget =   _Repository.GetBudgetByID(id);
            return View(budget);
        }

        public ActionResult Create()
        {
            return View(new Budget());
        }

        [HttpPost]
        public ActionResult Create(Budget budget)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _Repository.InsertBudget(budget);
                    _Repository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(budget);
        }

        public ActionResult EditAsync(int id)
        {
            Budget budget =  _Repository.GetBudgetByID(id);
            return View(budget);
        }
        [HttpPost]
        public ActionResult Edit(Budget budget)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _Repository.UpdateBudget(budget);
                    _Repository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(budget);
        }

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            Budget budget =  _Repository.GetBudgetByID(id);
            return View(budget);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Budget budget =  _Repository.GetBudgetByID(id);
                _Repository.DeleteBudget(id);
                _Repository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                   new System.Web.Routing.RouteValueDictionary {
        { "id", id },
        { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }
    }
}
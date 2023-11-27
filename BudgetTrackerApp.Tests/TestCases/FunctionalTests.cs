
using BudgetTrackerApp.DAL;
using BudgetTrackerApp.DAL.Interface;
using BudgetTrackerApp.DAL.Repository;
using BudgetTrackerApp.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace BudgetTrackerApp.Tests.TestCases
{
    public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IBudgetTrackerInterface _budgetTrackerService;
        public readonly Mock<IBudgetTrackerRepository> fitnnesstrackerservice = new Mock<IBudgetTrackerRepository>();
        private readonly Budget _budget;
        private readonly IEnumerable<Budget> budgetList;

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
            _budgetTrackerService = new BudgetTrackerService(fitnnesstrackerservice.Object);
            _output = output;
            _budget = new Budget
            {
                BudgetId = 1,
                Name = "Monthly Budget",
                Amount = 5000.00m,
                StartDate = DateTime.Now.Date,
                EndDate = DateTime.Now.Date.AddMonths(1),
                Description = "General monthly budget for expenses."
            };
             budgetList = new List<Budget>
        {
            new Budget
            {
                BudgetId = 1,
                Name = "Monthly Budget",
                Amount = 5000.00m,
                StartDate = DateTime.Now.Date,
                EndDate = DateTime.Now.Date.AddMonths(1),
                Description = "General monthly budget for expenses."
            },
            new Budget
            {
               BudgetId = 1,
                Name = "Monthly Budget",
                Amount = 5000.00m,
                StartDate = DateTime.Now.Date,
                EndDate = DateTime.Now.Date.AddMonths(1),
                Description = "General monthly budget for expenses."
            },
            // Add more Budget instances as needed
        };

        }

        [Fact]
        public async Task<bool> Testfor_Get_Budget()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                 fitnnesstrackerservice.Setup(repos => repos.GetBudgets()).Returns(budgetList);
                var result =  _budgetTrackerService.GetBudgets();
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Get_Budget_ById()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                fitnnesstrackerservice.Setup(repos => repos.GetBudgetByID(_budget.BudgetId)).Returns(_budget);
                var result = _budgetTrackerService.GetBudgetByID(_budget.BudgetId);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Update_Budget()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                fitnnesstrackerservice.Setup(repos => repos.UpdateBudget(_budget)).Returns(true);
                var result=_budgetTrackerService.UpdateBudget(_budget);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Delete_Budget()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                fitnnesstrackerservice.Setup(repos => repos.DeleteBudget(_budget.BudgetId)).Returns(1);
                var result=_budgetTrackerService.DeleteBudget(_budget.BudgetId);

                //Assertion
                if (result!= null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

    }
}
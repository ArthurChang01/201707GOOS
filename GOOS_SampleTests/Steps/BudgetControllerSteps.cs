﻿using FluentAssertions;
using GOOS_Sample.Controllers;
using GOOS_Sample.Models;
using GOOS_SampleTests.DataModelsForIntegrationTest;
using Microsoft.Practices.Unity;
using System.Linq;
using System.Web.Mvc;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GOOS_SampleTests.Steps
{
    [Binding]
    public class BudgetControllerSteps
    {
        private BudgetController _budgetController;

        [BeforeScenario()]
        public void BeforeScenario()
        {
            IBudgetService svc = Hooks.Hooks.UnityContainer.Resolve<IBudgetService>();
            this._budgetController = new BudgetController(svc);
        }


        [When(@"add a budget")]
        public void WhenAddABudget(Table table)
        {
            var model = table.CreateInstance<BudgetAddViewModel>();
            var result = this._budgetController.Add(model);

            ScenarioContext.Current.Set<ActionResult>(result);
        }


        [Then(@"ViewBag should have a message for adding successfully")]
        public void ThenViewBagShouldHaveAMessageForAddingSuccessfully()
        {
            var result = ScenarioContext.Current.Get<ActionResult>() as ViewResult;
            string message = result.ViewBag.Message;
            message.Should().Be(GetAddingSuccessfullyMessage());
        }

        private string GetAddingSuccessfullyMessage()
        {
            return "added successfully";
        }


        [Then(@"it should exist a budget record in budget table")]
        public void ThenItShouldExistABudgetRecordInBudgetTable(Table table)
        {
            using (var dbcontext = new BudgetContextForTest())
            {
                var budget = dbcontext.Budgets
                    .FirstOrDefault();
                budget.Should().NotBeNull();
                table.CompareToInstance(budget);
            }
        }

        [Then(@"ViewBag should have a message for updating successfully")]
        public void ThenViewBagShouldHaveAMessageForUpdatingSuccessfully()
        {
            var result = ScenarioContext.Current.Get<ActionResult>() as ViewResult;
            string message = result.ViewBag.Message;
            message.Should().Be(GetUpdatingSuccessfullyMessage());
        }

        private string GetUpdatingSuccessfullyMessage()
        {
            return "updated successfully";
        }

    }
}

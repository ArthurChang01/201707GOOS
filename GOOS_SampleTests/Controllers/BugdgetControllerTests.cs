using GOOS_Sample.Controllers;
using GOOS_Sample.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace GOOS_SampleTests.Controllers
{
    [TestClass]
    public class BudgetControllerTests
    {
        private BudgetController _budgetController;
        private IBudgetService _budgetService = Substitute.For<IBudgetService>();
        private IRepository<Budget> _budgetRepositoryStub = Substitute.For<IRepository<Budget>>();


        [TestMethod()]
        public void CreateTest_should_invoke_repository_one_time()
        {
            this._budgetService = new BudgetService(_budgetRepositoryStub);

            var model = new BudgetAddViewModel { Amount = 2000, Month = "2017-02" };

            var wasCreate = false;
            this._budgetService.Created += (sender, args) => { wasCreate = true; };
            this._budgetService.Create(model);

            _budgetRepositoryStub.Received()
                .Save(Arg.Is<Budget>(x => x.Amount == 2000 && x.YearMonth == "2017-02"));

            Assert.IsTrue(wasCreate);
        }


        [TestMethod()]
        public void CreateTest_when_exist_record_should_update_budget()
        {
            this._budgetService = new BudgetService(_budgetRepositoryStub);

            var budgetFromDb = new Budget { Amount = 999, YearMonth = "2017-02" };

            _budgetRepositoryStub.Read(Arg.Any<Func<Budget, bool>>())
                .ReturnsForAnyArgs(budgetFromDb);

            var model = new BudgetAddViewModel { Amount = 2000, Month = "2017-02" };

            var wasUpdated = false;
            this._budgetService.Updated += (sender, args) => { wasUpdated = true; };

            this._budgetService.Create(model);

            _budgetRepositoryStub.Received()
                .Save(Arg.Is<Budget>(x => x == budgetFromDb && x.Amount == 2000));


            Assert.IsTrue(wasUpdated);
        }
    }
}

using GOOS_SampleTests.DataModelsForIntegrationTest;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GOOS_SampleTests
{

    [Binding]
    public sealed class InsertTable
    {
        [Given(@"Budget table existed budgets")]
        public void GivenBudgetTableExistedBudgets(Table table)
        {
            //same with BudgetCreateSteps
            var budgets = table.CreateSet<Budget>();
            using (var dbcontext = new BudgetContextForTest())
            {
                dbcontext.Budgets.AddRange(budgets);
                dbcontext.SaveChanges();
            }
        }
    }
}

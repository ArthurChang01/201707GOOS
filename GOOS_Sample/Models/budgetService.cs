namespace GOOS_Sample.Models
{
    public class BudgetService : IBudgetService
    {
        private IRepository<Budget> _budgetRepositoryStub;

        public BudgetService(IRepository<Budget> budgetRepositoryStub)
        {
            _budgetRepositoryStub = budgetRepositoryStub;
        }

        public void Create(BudgetAddViewModel model)
        {
            //using (BudgetEntities ctx = new BudgetEntities())
            //{
            //    Budget bd = new Budget()
            //    {
            //        Amount = model.Amount,
            //        YearMonth = model.Month
            //    };
            //    ctx.Budgets.Add(bd);
            //    ctx.SaveChanges();
            //}

            var budget = new Budget() { Amount = model.Amount, YearMonth = model.Month };
            this._budgetRepositoryStub.Save(budget);
        }
    }
}
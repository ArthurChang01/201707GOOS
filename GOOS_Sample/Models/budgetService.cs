using System;

namespace GOOS_Sample.Models
{
    public class BudgetService : IBudgetService
    {
        private IRepository<Budget> _budgetRepositoryStub;

        public BudgetService(IRepository<Budget> budgetRepositoryStub)
        {
            _budgetRepositoryStub = budgetRepositoryStub;
        }

        public event EventHandler Created;
        public event EventHandler Updated;

        public void Create(BudgetAddViewModel model)
        {

            var budget = this._budgetRepositoryStub.Read(x => x.YearMonth == model.Month);
            if (budget == null)
            {
                this._budgetRepositoryStub.Save(new Budget() { Amount = model.Amount, YearMonth = model.Month });

                var handler = this.Created;
                handler?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                budget.Amount = model.Amount;
                this._budgetRepositoryStub.Save(budget);

                var handler = this.Updated;
                handler?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
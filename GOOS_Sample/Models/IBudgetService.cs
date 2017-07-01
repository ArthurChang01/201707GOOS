using System;

namespace GOOS_Sample.Models
{
    public interface IBudgetService
    {
        void Create(BudgetAddViewModel budgetAddViewModel);

        event EventHandler Created;
        event EventHandler Updated;
    }
}
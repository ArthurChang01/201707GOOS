namespace GOOS_Sample.Models
{
    public class BudgetService : IBudgetService
    {
        public void Create(BudgetAddViewModel model)
        {
            using (BudgetEntities ctx = new BudgetEntities())
            {
                Budget bd = new Budget()
                {
                    Amount = model.Amount,
                    YearMonth = model.Month
                };
                ctx.Budgets.Add(bd);
                ctx.SaveChanges();
            }
        }
    }
}
namespace GOOS_Sample.Models
{
    public class BudgetRepository : IRepository<Budget>
    {
        public void Save(Budget budget)
        {
            using (BudgetEntities ctx = new BudgetEntities())
            {
                ctx.Budgets.Add(budget);
                ctx.SaveChanges();
            }
        }
    }
}
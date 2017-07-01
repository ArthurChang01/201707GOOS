namespace GOOS_SampleTests.DataModelsForIntegrationTest
{
    using System.Data.Entity;

    public partial class BudgetContext : DbContext
    {
        public BudgetContext()
            : base("name=Budget")
        {
        }

        public virtual DbSet<Budget> Budgets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Budget>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Budget>()
                .Property(e => e.YearMonth)
                .IsUnicode(false);
        }
    }
}

using GOOS_Sample.Models;
using System.Web.Mvc;

namespace GOOS_Sample.Controllers
{
    public class BudgetController : Controller
    {

        // GET: Budget
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(BudgetAddViewModel model)
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

            ViewBag.Message = "added successfully";
            return View(model);
        }
    }
}
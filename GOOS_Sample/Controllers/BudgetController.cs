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
            ViewBag.Message = "added successfully";
            return View(model);
        }
    }
}
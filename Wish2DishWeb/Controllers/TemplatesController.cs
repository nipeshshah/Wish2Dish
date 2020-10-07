using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using Wish2DishWeb.Models;

namespace Wish2DishWeb.Controllers
{
  public class TemplatesController : Controller
  {
    // GET: Templates
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult Template()
    {
      WishDishDBEntities wishDishDBEntities = new Models.WishDishDBEntities();
      ObjectResult<GenerateLabel_Result> generateLabel_Result = wishDishDBEntities.GenerateLabel(7, 500);
      return View(generateLabel_Result.First());
    }
    
  }
}

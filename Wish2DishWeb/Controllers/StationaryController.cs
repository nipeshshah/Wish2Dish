using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Wish2DishWeb.Models;

namespace Wish2DishWeb.Controllers
{
  public class StationaryController : Controller
  {
    private WishDishDBEntities db = new WishDishDBEntities();
    // GET: Stationary
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult PrintList()
    {
      return View(db.CreateSharingList());
    }

    public ActionResult Stock()
    {
      ViewBag.TotalStockValue = db.StockInHand(false).Sum(t => t.StockValue);
      return View(db.StockInHand(false));
    }

    public ActionResult Costs()
    {
      return View(db.StockCosts());
    }

    public ActionResult CreateHomePrintingList()
    {
      return View(db.ProductBatches.OrderBy(t => t.Product.Category.CategoryName).ThenBy(t => t.Product.Name));
    }

    public ActionResult LowStock()
    {
      return View(db.LowStock());
    }

    public ActionResult DownLine()
    {
      return View(db.GetDownLine(10011));
    }

    public ActionResult Upline()
    {
      return View(db.GetUpLine(10012));
    }
  }

  
}

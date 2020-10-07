using System;
using System.Linq;
using System.Web.Mvc;
using Wish2DishWeb.Models;

namespace Wish2DishWeb.Controllers
{
  public class SalesController : Controller
  {
    private WishDishDBEntities db = new WishDishDBEntities();

    // GET: Sales
    public ActionResult Index()
    {
      ViewBag.Customer = new SelectList(db.Customers, "Id", "Name");

      //Customer
      return View(db.Sales.Include("Customer").ToList());
    }

    public ActionResult Create()
    {
      ViewBag.ProductBatch = new SelectList(db.GetProductBatches(), "Id", "Name");
      ViewBag.Customer = new SelectList(db.Customers, "Id", "Name");
      return View(db.Sales.Include("Customer").ToList());
    }

    public ActionResult Items(int? id)
    {
      if(id.HasValue)
      {
        Sale sale = db.Sales.Find(id);
        ViewBag.ProductBatch = new SelectList(db.GetProductBatches(), "Id", "Name");
        return View(sale);
      }
      else
      {
        return RedirectToAction("Index");
      }
    }

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Create(int Customer, string IDate, string InvNumber, decimal? DueAmount, decimal? PaidAmount, decimal? TotalAmount)
    //{
    //  db.AddNewSales(Customer, Convert.ToDateTime(IDate), InvNumber, DueAmount, PaidAmount, TotalAmount);
    //  return RedirectToAction("Index");
    //}

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Sale sale)
    {
      Sale newsale = db.Sales.Add(new Sale()
      {
        CustomerId = sale.CustomerId,
        SDate = sale.SDate.Value,
        Inv_No = sale.Inv_No
      });
      db.SaveChanges();
      //int salesId = db.AddNewSales((int)sale.CustomerId, Convert.ToDateTime(sale.SDate), sale.Inv_No, 0, 0, 0);
      foreach(var inv in sale.SalesInventories)
      {
        db.AddNewSalesItem(newsale.Id, inv.ProductBatchId, inv.Quantity);
      }
      return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult AddSaleItem(int Id, int ProductBatch, decimal Quantity)
    {
      db.AddNewSalesItem(Id, ProductBatch, Quantity);
      return RedirectToAction("Items", Id);
    }
  }
}

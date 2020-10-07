using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Wish2DishWeb.Models;

namespace Wish2DishWeb.Controllers
{
  public class PurchaseController : Controller
  {
    private WishDishDBEntities db = new WishDishDBEntities();

    // GET: Purchase
    public ActionResult Index()
    {
      return View(db.ProductBatches.OrderByDescending(t => t.BatchId));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Purchase(int Products, int Batches, decimal Cost, decimal? MRP, decimal Stock)
    {
      db.AddPurchase(Products, Cost, MRP, Batches, Stock);
      //if(ModelState.IsValid)
      //{
      //  db.Customers.Add(customer);
      //  db.SaveChanges();
      //  return RedirectToAction("Index");
      //}

      ViewBag.Products = new SelectList(db.Products, "Id", "Name");
      ViewBag.Batches = new SelectList(db.Batches.OrderByDescending(t => t.Id), "Id", "BatchNumber");

      //ViewBag.ReferredBy = new SelectList(db.Customers, "Id", "Name", customer.ReferredBy);
      return View("Purchase");
    }

    public ActionResult PurchaseEntry()
    {
      ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
      ViewBag.BatchId = new SelectList(db.Batches.OrderByDescending(t => t.Id), "Id", "BatchNumber");
      return View();
    }

    [HttpPost]
    public ActionResult PurchaseEntry(PurchaseOrder order)
    {
      if(ModelState.IsValid)
      {
        foreach(var item in order.productBatches)
        {
          db.AddPurchase(item.ProductId, item.PP, item.MRP, order.BatchId, item.Stock);
        }
      }
      return RedirectToAction(nameof(Index));
    }
  }
}

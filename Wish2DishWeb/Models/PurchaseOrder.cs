using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wish2DishWeb.Models
{
  public class PurchaseOrder
  {
  public int BatchId { get; set; }
    public List<ProductBatch> productBatches { get; set; }
  }
}

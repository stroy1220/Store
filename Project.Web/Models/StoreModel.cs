using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Web.Models
{
    public class StoreModel
    {
        public int ProductId { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string ImageName { get; set; }
        public int Inventory { get; set; }
    }
}
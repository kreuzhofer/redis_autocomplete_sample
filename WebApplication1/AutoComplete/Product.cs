using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Product
    {
        public int sku { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public double price { get; set; }
        public string upc { get; set; }
        public List<Category> category { get; set; }
        public double? shipping { get; set; }
        public string description { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public string url { get; set; }
        public string image { get; set; }
    }
}

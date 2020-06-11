using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace bedayzAPI.Resources
{
    public class ProductResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Marka { get; set; }
        public double Cost { get; set; }
        public double PreviousCost { get; set; }
        public int CategoryId { get; set; }
        public string Url { get; set; }
        public int NumberInStock { get; set; }
        public string Info { get; set; }
        public double KargoFiyatı { get; set; }
        public int ToplamSiparisSayisi { get; set; }
        public string Tag { get; set; }
        public CategoryResource Category { get; set; }
    }
}

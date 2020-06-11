using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace bedayzAPI.Resources
{
    public class ImageResource
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public ProductResource Product { get; set; }
    }
}

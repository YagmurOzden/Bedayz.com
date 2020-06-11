using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bedayzAPI.Controllers.Resources;

namespace bedayzAPI.Resources
{
    public class SepetResource
    {
        public int SepetId { get; set; }
        public DateTime SepeteKonulmaTarihi { get; set; }
        public int Adet { get; set; }
        public int UserId { get; set; }
        public int ProductID { get; set; }
        public UserResource User { get; set; }
        public ProductResource Product { get; set; }
    }
}

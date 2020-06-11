using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bedayzAPI.Controllers.Resources;

namespace bedayzAPI.Resources
{
    public class SiparisResource
    {
        public int SiparisId { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public int Adet { get; set; }
        public int UserId { get; set; }
        public int ProductID { get; set; }
        public UserResource User { get; set; }
        public ProductResource Product { get; set; }
    }
}

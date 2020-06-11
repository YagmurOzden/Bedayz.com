using System;
using System.ComponentModel.DataAnnotations;

namespace bedayzAPI.Resources
{
    public class SaveSiparisResource
    {
        public int SiparisId { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public int Adet { get; set; }
        public int UserId { get; set; }
        public int ProductID { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace bedayzAPI.Resources
{
    public class SaveSepetResource
    {
        public int SepetId { get; set; }
        public DateTime SepeteKonulmaTarihi { get; set; }
        public int Adet { get; set; }
        public int UserId { get; set; }
        public int ProductID { get; set; }
    }
}

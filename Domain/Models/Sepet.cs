using System;
using System.Collections.Generic;
using bedayzAPI.Core.Models;

namespace bedayzAPI.Domain.Models
{
    public class Sepet
    {
        public int SepetId { get; set; }
        public int UserId { get; set; }
        public DateTime SepeteKonulmaTarihi { get; set; }
        public int Adet { get; set; }
        public int ProductID { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}

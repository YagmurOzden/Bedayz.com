using System.Collections.Generic;

namespace bedayzAPI.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EMarka Marka { get; set; }
        public double Cost { get; set; }
        public double PreviousCost { get; set; }
        public int CategoryId { get; set; }
        public string Url { get; set; }
        public int NumberInStock { get; set; }
        public string Info { get; set; }
        public double KargoFiyatı { get; set; }
        public int ToplamSiparisSayisi { get; set; }
        public ProductTags Tag { get; set; }
        public Category Category { get; set; }
        public IList<Siparis> Siparisler { get; set; }

        public IList<Sepet> Sepetler { get; set; }
        public IList<Image> Images { get; set; } = new List<Image>();
    }
}

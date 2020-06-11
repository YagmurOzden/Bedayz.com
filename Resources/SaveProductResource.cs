using System.ComponentModel.DataAnnotations;

namespace bedayzAPI.Resources
{
    public class SaveProductResource
    {
        [Required]
        [MaxLength(30)]
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
    }
}

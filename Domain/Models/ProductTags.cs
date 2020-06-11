using System.ComponentModel;

namespace bedayzAPI.Domain.Models
{
    public enum ProductTags : byte
    {
        [Description("ÖneÇıkanlar")]
        ÖneÇıkanlar = 1,

        [Description("FırsatÜrünü")]
        FırsatÜrünü = 2,

        [Description("Diğer")]
        Diğer = 3
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Dtos
{
    [Table("LG_006_ItemsConvfact")]
    public class ProductItem
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal Width { get; set; }
        public string UnitSetCode { get; set; }
    }

}

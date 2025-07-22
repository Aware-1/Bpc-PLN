using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Item
{
    [Table("LG_006_ItemsConvfact")]
    public class ProductItemVM
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public double GrossWeight { get; set; }
        public double Width { get; set; }
        public string UnitSetCode { get; set; }
    }

}

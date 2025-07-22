    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities.Item;



[Table("BPC_006_22_WebRequestOrderLine")]
public class RequestOrderLine
{
    [Key]
    [Column("LogicalRef")]
    public int LogicalRef { get; set; }

    [Column("ReqOrdHeaderRef")]
    public int ReqOrdHeaderRef { get; set; }

    [Column("ItemCode")]
    public string ItemCode { get; set; }

    [Column("ItemDefinition")]
    public string ItemDefinition { get; set; }

    [Column("Usc")]
    public string Usc { get; set; }

    [Column("Amount")]
    public int Amount { get; set; }

    [ForeignKey(nameof(ReqOrdHeaderRef))]
    public RequestOrderHeader Header { get; set; }
}

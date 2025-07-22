using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Item;


[Table("BPC_006_22_WebRequestOrderHeader")]
public class RequestOrderHeader
{
    [Key]
    [Column("LogicalRef")]
    public int LogicalRef { get; set; }

    [Column("RequestNumber")]
    public string RequestNumber { get; set; }

    [Column("BranchCode")]
    public string BranchCode { get; set; }

    [Column("WareCode")]
    public string WareCode { get; set; }

    [Column("BranchName")]
    public string BranchName { get; set; }

    [Column("RequestDate")]
    public string RequestDate { get; set; }

    [Column("RequestTime")]
    public string RequestTime { get; set; }

    [Column("RequestType")]
    public string RequestType { get; set; }

    [Column("DeliveryCode")]
    public string DeliveryCode { get; set; }

    [Column("DeliveryDefinition")]
    public string DeliveryDefinition { get; set; }

    [Column("DeliveryAdd")]
    public string DeliveryAdd { get; set; }

    [Column("ConfirmStatus")]
    public string ConfirmStatus { get; set; }

    public ICollection<RequestOrderLine> Lines { get; set; }
}

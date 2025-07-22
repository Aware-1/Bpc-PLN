namespace Domain.Dtos
{
    
    public class HeaderBranchDto
    {
        public string CLIENTREF { get; set; }
        public DateTime Date { get; set; }
        public string RequestCode { get; set; }
        public string Address { get; set; }
        public string? Address2 { get; set; }
        public string DeliveryPlace { get; set; }
        public string Definition { get; set; }
        public string BranchName { get; set; } 
        public string WareCode { get; set; } 
        public string BranchCode { get; set; } 
    }


    public class ItemRowViewModel
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public double GrossWeight { get; set; }
        public double NetWeight { get; set; }
    }
    public class TotalRequest
    {
        public string Quantity { get; set; }
        public string GrossWeight { get; set; }
        public string NetWeight { get; set; }
    }


 




}

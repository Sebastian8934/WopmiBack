namespace WebApi.Models.Requests.Transaction
{
    public class TransactionRequest
    {
        //Transaction
        //public string? UserId { get; set; }
        public string? TransactionNumber { get; set; }
        public string? Status { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal BaseFee { get; set; }
        public decimal DeliveryFee { get; set; }

        //TrasactionItem
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        //Product
        public int StockQuantity { get; set; }        
    }
}

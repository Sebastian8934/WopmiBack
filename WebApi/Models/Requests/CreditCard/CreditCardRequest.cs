namespace WebApi.Models.Requests.CreditCard
{
    public class CreditCardRequest
    {
        public string? CardNumber { get; set; }
        public string? CardholderName { get; set; }
        public string? ExpirationDate { get; set; }
        public string? Cvv { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public string? TransactionNumber { get; set; }
        public string? Status { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal BaseFee { get; set; }
        public decimal DeliveryFee { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<TransactionItem> TransactionItem { get; set; }
    }
}

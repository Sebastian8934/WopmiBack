using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string? CardNumber { get; set; }
        public string? CardholderName { get; set; }
        public string? ExpirationDate { get; set; }
        public string? Cvv { get; set; }
    }
}

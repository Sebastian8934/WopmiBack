using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CreditCardDto
    {
        public int Id { get; set; }
        public string? CardNumber { get; set; }
        public string? CardholderName { get; set; }
        public string? ExpirationDate { get; set; }
        public string? Cvv { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public virtual ICollection<CreditCard> CreditCard { get; set; }
        public virtual ICollection<DeliveryInfo> DeliveryInfo { get; set; }
        public ICollection<Customer> Transaction { get; set; }
    }
}

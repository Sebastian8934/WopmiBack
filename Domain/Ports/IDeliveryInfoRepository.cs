using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports
{
    public interface IDeliveryInfoRepository
    {
        Task<IEnumerable<DeliveryInfo>> GetAllAsync();
        Task AddAsync(DeliveryInfo deliveryInfo);
    }
}

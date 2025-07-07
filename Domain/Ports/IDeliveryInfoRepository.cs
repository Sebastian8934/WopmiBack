using Domain.Entities;

namespace Domain.Ports
{
    public interface IDeliveryInfoRepository
    {
        Task<IEnumerable<DeliveryInfo>> GetAllAsync();
        Task AddAsync(DeliveryInfo deliveryInfo);
    }
}

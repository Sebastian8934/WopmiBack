using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Ports;

namespace Application.Services
{
    public class DeliveryInfoService
    {
        private readonly IDeliveryInfoRepository _repository;

        public DeliveryInfoService(IDeliveryInfoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DeliveryInfo>> GetAllDeliveryInfodAsync() => await _repository.GetAllAsync();

        public async Task AddDeliveryInfoAsync(DeliveryInfo product) => await _repository.AddAsync(product);
    }
}

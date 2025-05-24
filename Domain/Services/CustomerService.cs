using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;
using Domain.Ports;

namespace Application.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomerAsync() => await _repository.GetAllAsync();

        public async Task AddCustomertAsync(Customer product) => await _repository.AddAsync(product);
    }
}

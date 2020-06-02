using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sovos.API.Domain.Models;
using Sovos.API.Domain.Services;
using Sovos.API.Domain.Repositories;

namespace Sovos.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> ListAsync()
        {
            return await _customerRepository.ListAsync();

        }
    }
}
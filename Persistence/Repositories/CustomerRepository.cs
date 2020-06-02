using Microsoft.EntityFrameworkCore;
using Sovos.API.Domain.Models;
using Sovos.API.Domain.Repositories;
using Sovos.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sovos.API.Persistence.Repositories
{
    public class CustomerRepository: BaseRepository, ICustomerRepository
    {

        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Customer>> ListAsync()
        {
            return await _context.Customers.ToListAsync();
        }
    }
}

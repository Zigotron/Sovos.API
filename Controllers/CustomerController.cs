using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sovos.API.Domain.Models;
using Sovos.API.Domain.Services;
using Sovos.API.Resources;

namespace Sovos.API.Controllers
{
    [Route("/api/[controller]")]
    public class CustomerController : Controller
    {

        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerResource>> GetAllAsync()
        {
            var customers = await _customerService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResource>>(customers);

            return resources;
        }
    }
}


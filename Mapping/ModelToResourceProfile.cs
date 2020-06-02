using AutoMapper;
using Sovos.API.Domain.Models;
using Sovos.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sovos.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Customer, CustomerResource>();
        }
    }
}

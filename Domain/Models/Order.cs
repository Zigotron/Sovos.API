using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sovos.API.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }



    }
}

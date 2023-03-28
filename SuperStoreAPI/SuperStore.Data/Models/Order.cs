using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperStore.Data.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public double PaymentAmount { get; set; }
        public string Currency { get; set; }

        public User User { get; set; }

        public ICollection<OrderProduct> OrderProducts{ get; set;} = new List<OrderProduct>();

    }
}

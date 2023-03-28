using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperStore.Data.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public List<Payment> Payments { get; set; } = new List<Payment>();
        public List<Order> Orders { get; set; } = new List<Order>();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address Address { get; set; }
    }
}

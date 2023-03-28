using SuperStore.Data.Models;

namespace SuperStoreAPI.Views
{
    public class UserCreationView
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address Address { get; set; }
    }
}
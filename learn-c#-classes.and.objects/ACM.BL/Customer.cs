using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Customer : EntityBase , ILoggable
    {
        public Customer()
        {

        }
        public Customer(int customerId)
        {
            CustomerId = customerId;
            AddressList = new List<Address>();
        }
        public List<Address> AddressList { get; set; }
        public int CustomerId { get; private set; }
        public string EmailAddress { get; set; }



        public string FirstName { get; set; }
        public string FullName
        {
            get
            {
                string fullName = LastName;
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(fullName))
                    {
                        fullName += ", ";

                    }
                    fullName += FirstName;
                }
                return fullName;


            }
        }
        public static int InstanceCount { get; set; }
        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
        public string Log() =>
            $"{CustomerId }:{FullName}Email:{EmailAddress} Status:{EntityState.ToString()}";
        public override string ToString() => FullName;
        /*public Customer Retrieve(int customerId) Codul este deja implementat in CustomerRepository
        { 
            //Cod care returneaza clientul definit
            return new Customer();

        }
        

        public List<Customer> Retrieve()
        {
            // Code that retrieves all of the customers
            return new List<Customer>();
        }
        /// <summary>
        /// Save the current customer.
        /// </summary>
        /// <returns></returns>
        
        public bool Save()
        {
            return true;
        }*/
        public override bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(LastName)) isValid = false;
            if (string.IsNullOrWhiteSpace(EmailAddress)) isValid = false;

            return isValid;
        }

        
    }
}

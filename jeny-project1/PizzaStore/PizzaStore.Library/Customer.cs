using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class Customer
    {
        private int _id;
        private string _fname;
        private string _lname;
        private string _phoneNumber;
     

        public string FirstName
        {
            get=>_fname;
            set
            {
                if (value.Length == 0)
                {
                    
                    throw new ArgumentException("FirstName must not be empty.", nameof(value));
                }

                _fname = value;
            }
        }
        public string LastName
        {
            get => _lname;
            set
            {
                if (value.Length == 0)
                {

                    throw new ArgumentException("LastName must not be empty.", nameof(value));
                }

                _lname = value;
            }
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (value.Length == 0)
                {

                    throw new ArgumentException("FirstName must not be empty.", nameof(value));
                }

                _phoneNumber = value;
            }
        }
        public int Id { get; set; }

        public Store Fav_Store { get; set; }

        public List<PurOrder> PurOrder { get; set; } = new List<PurOrder>();

        public override string ToString()
        {
            return "Customer: " + FirstName + " " + LastName+" "+ _id;
        }
    }


}

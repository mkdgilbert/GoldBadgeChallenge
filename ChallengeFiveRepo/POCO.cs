using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFiveRepo
{
    public enum CustomerType
    {
        potential = 1,
        current,
        past,
    }
    public class Customer
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }        
        public string FullName 
        { 
            get { return FirstName + " " + LastName; }        
        }
        public string EmailMessage
        {
            get
            {
                if (TypeOfCustomer == CustomerType.potential)
                {
                    return "We currently have the lowest rates on Helicopter Insurance!";
                }
                else if (TypeOfCustomer == CustomerType.current)
                {
                    return "Thank you for your work with us.  We appreciate your loyalty.  Here's a coupon.";
                }
                else
                {
                    return "It's been a long time since we've heard from you, we want you back";
                }
            }
        }
        public CustomerType TypeOfCustomer { get; set; }
        public Customer() { }
        public Customer(string firstName, string lastName, CustomerType typeOfCustomer)
        {
            FirstName = firstName;
            LastName = lastName;
            TypeOfCustomer = typeOfCustomer;
        }
        
    }


   
}

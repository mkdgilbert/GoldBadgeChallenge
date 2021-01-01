using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFiveRepo
{   
    public class Repo
    {
        List<Customer> _listOfCustomers = new List<Customer>();
        //Create
        public void CreateCustomer(Customer customer)
        {
            _listOfCustomers.Add(customer);
        }
        //Read 
        public List<Customer> ReadListOfCustomers()
        {
            //Below utilizes a Comparison Delegate to sort 
            // _listOfCustomers.Sort(delegate (Customer c1, Customer c2) { return c1.FirstName.CompareTo(c2.FirstName); });

            //Another way is using lambda expression
            //_listCustomers.Sort((x,y) => x.FirstName.CompareTo(y.FirstName));

            _listOfCustomers.Sort();
            return _listOfCustomers;
        }
        //Update
        public bool UpdateCustomer(string userInput, Customer newInfo)
        {
            Customer oldInfo = HelperMethod(userInput);

            if (userInput != null)
            {
                oldInfo.FirstName = newInfo.FirstName;
                oldInfo.LastName = newInfo.FirstName;
                oldInfo.TypeOfCustomer = newInfo.TypeOfCustomer;                
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool DeleteCustomer(string userInput)
        {
            Customer custInfo = HelperMethod(userInput);

            if (custInfo != null)
            {
                _listOfCustomers.Remove(custInfo);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Customer HelperMethod(string fullName)
        {
            foreach (Customer person in _listOfCustomers)
            {
                if (person.FullName == fullName)
                {
                    return person;
                }
            }
            return null;
        }               
    }
}

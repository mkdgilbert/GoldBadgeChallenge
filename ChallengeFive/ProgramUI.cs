using ChallengeFiveRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFive
{
    class ProgramUI
    {
        public void Run()
        {
            SeedMethod();
            Menu();
        }
        Repo _repo = new Repo();
        
        private void Menu()
        {
        StartMenu:
            bool keepRunning = true;
            while (keepRunning)
            {               
                Console.WriteLine("Please select a menu option:\n" +
                    "1. Create a new Customer.\n" +
                    "2. View all available customers.\n" +
                    "3. Update a existing customer.\n" +
                    "4. Delete a existing customer.\n" +
                    "5. Exit from the program.");

                int menuAnswer = Convert.ToInt32(Console.ReadLine());

                switch (menuAnswer)
                {
                    case 1:
                        CreateCustomer();
                        break;
                    case 2:
                        ViewAllCustomers();
                        break;
                    case 3:
                        UpdateExistingCustomer();
                        break;
                    case 4:
                        DeleteExistingCustomer();
                        break;
                    case 5:                        
                        Console.WriteLine("Thank you for using our program.\n Goodbye.");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Sorry, {0} is not a valid input.\n please try again.", menuAnswer);
                        goto StartMenu;
                }
                Console.WriteLine("Press Any Key To Continue...");
                Console.ReadKey();
                Console.Clear();
            }            
        }
        private void CreateCustomer()
        {
            Console.Clear();

            Customer customer = new Customer();

            Console.WriteLine("Please enter the customers first name");
            string first = Console.ReadLine();
            customer.FirstName = first;

            Console.WriteLine("Please enter the customers last name");
            string last = Console.ReadLine();
            customer.LastName = last;

            Console.WriteLine("Please the customers status number.\n" +
                "1. potential\n" +
                "2. current\n" +
                "3. past");
            int type = Convert.ToInt32(Console.ReadLine());
            customer.TypeOfCustomer = (CustomerType)type;

            _repo.CreateCustomer(customer);
        }
        private void ViewAllCustomers()
        {
            Console.Clear();

            List<Customer> customers = _repo.ReadListOfCustomers();            

            foreach (Customer output in customers)
            {                                
                    Console.WriteLine($"First Name: Last Name: Customer Status: Email Message:\n" +
                    $"{output.FirstName}" +
                    $"{output.LastName} " +
                    $"{output.TypeOfCustomer} " +
                    $"{output.EmailMessage}");
            }                        
        }
        private void UpdateExistingCustomer()
        {
            //list customers
            Console.WriteLine("Here is a list of Customers.");
            ViewAllCustomers();
            //prompt user
            Console.WriteLine("Please enter the customer's full name.");
            //retrieve the information
            string response = Console.ReadLine();
            //build new object
            Console.Clear();
            Customer customer = new Customer();

            Console.WriteLine("Please enter the customers first name");
            string first = Console.ReadLine();
            customer.FirstName = first;

            Console.WriteLine("Please enter the customers last name");
            string last = Console.ReadLine();
            customer.LastName = last;

            Console.WriteLine("Please the customers status number.\n" +
                "1. potential\n" +
                "2. current\n" +
                "3. past");
            int type = Convert.ToInt32(Console.ReadLine());
            customer.TypeOfCustomer = (CustomerType)type;

            _repo.UpdateCustomer(response, customer);

        }
        private void DeleteExistingCustomer()
        {

        }
        private void SeedMethod()
        {
            Customer jSmith = new Customer("Jason", "Smith", CustomerType.current);
            Customer mJackson = new Customer("Mark", "Jackson", CustomerType.current);
            Customer jSmith2 = new Customer("John", "Smith", CustomerType.past);
            Customer mGilbert = new Customer("Mike", "Gilbert", CustomerType.potential);
            Customer jJackson = new Customer("Jasmine", "Jackson", CustomerType.current);
            Customer cFranks = new Customer("Craig", "Franks", CustomerType.current);
            Customer aMarks = new Customer("Alice", "Marks", CustomerType.past);
            Customer iFury = new Customer("Indi", "Fury", CustomerType.potential);

            _repo.CreateCustomer(jSmith);
            _repo.CreateCustomer(jSmith2);
            _repo.CreateCustomer(mGilbert);
            _repo.CreateCustomer(mJackson);
            _repo.CreateCustomer(jJackson);
            _repo.CreateCustomer(cFranks);
            _repo.CreateCustomer(aMarks);
            _repo.CreateCustomer(iFury);
        }
    }
}

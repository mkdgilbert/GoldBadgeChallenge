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
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();

                Console.WriteLine("Please select a menu option:\n" +
                    "1. Create a new Customer.\n" +
                    "2. View all available customers.\n" +
                    "3. Update a existing customer.\n" +
                    "4. Delete a existing customer.\n" +
                    "5. Exit from the program.");

                switch (switch_on)
                {
                    default:
                }
            }
        }
        private void CreateCustomer()
        {

        }
        private void ViewAllCustomers()
        {

        }
        private void UpdateExistingCustomer()
        {

        }
        private void DeleteExistingCustomer()
        {

        }
    }
}

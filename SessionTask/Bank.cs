using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionTask
{
    class Bank
    {
        public string Name;
        public string BranchCode;
        public List<Customer> customers { get; set; }
        public Bank()
        {
            Name = "Al Ahly";
            BranchCode = "1234";
            customers = new List<Customer>();
        }
        public void ShowBankDetails()
        {
            Console.WriteLine($"Bank Name:{Name} ,Branch Code:{BranchCode}");
            foreach (var c in customers)
            {
                Console.WriteLine($"Customer ID: {c.ID}");
                Console.WriteLine($"Name: {c.FullName}");
                Console.WriteLine($"National ID: {c.NationaID}");
                Console.WriteLine($"Date of Birth: {c.DateOfBirth}");
                if (c.Accounts.Count() == 0)
                    Console.WriteLine("This customer does not have any accounts");
                else
                {
                    foreach (var acc in c.Accounts)
                    {
                        Console.WriteLine($"Account Number: {acc.AccountNumber}, Balance: ${acc.Balance}");
                    }
                    Console.WriteLine($"Total Balance: ${c.ShowTotalBalance(c.ID)}");
                }
                Console.WriteLine("---------------------------------------------------");
            }
        }
        public void RemoveCustomer(int id)
        {
            Customer CustomerToRemove = null;
            bool f = true;
            foreach (var cr in customers)
            {
                if (cr.ID == id)
                {
                   CustomerToRemove = cr;
                    break;
                }
            }
            if(CustomerToRemove==null) Console.WriteLine("Customer Not Found");
            else
            {
                foreach (var acc in CustomerToRemove.Accounts)
                {
                    if (acc.Balance != 0) f = false;
                    break;
                }
            }
            if (f)
            {
                customers.Remove(CustomerToRemove);
                Console.WriteLine("Customer has been Removed Successfully");
            }
            else Console.WriteLine("Can not remove this customer ");
            
        }
        public Customer SearchCustomer(string Name)
        {
            foreach (var cus in customers)
            {
                if (cus.FullName == Name)
                {
                    return cus;
                }
            }
            return null;
        }
        public Customer SearchCustomer(int id)
        {
            foreach (var cus in customers)
            {
                if (cus.ID == id)
                {
                    return cus;
                }
            }
            return null;
        }
        public Account FindAccount(int custID, int accNum)
        {
            foreach (var cus in customers)
            {
                if (cus.ID == custID)
                {
                    foreach (var acc in cus.Accounts)
                    {
                        if (acc.AccountNumber == accNum)
                        {
                            return acc;
                        }
                    }
                    Console.WriteLine("Account not Found");
                    return null;
                }
            }
            Console.WriteLine("Account not Found");
            return null;
        }
    }
}

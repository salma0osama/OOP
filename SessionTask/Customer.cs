using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace SessionTask
{
    class Customer
    {
        public static int nextID=1;
        public int ID { get; private set; }
        public string FullName { get; set; }
        public string NationaID { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public List<Account> Accounts { get; set; } 

        public Customer(string fullName, string nationaID, DateOnly dateOfBirth)
        {
            ID = nextID++;
            FullName = fullName;
            NationaID = nationaID;
            DateOfBirth = dateOfBirth;
            Accounts = new List<Account>();
        }
        public void UpdateDetails(string newName, DateOnly NewDate)
        {
            FullName = newName;
            DateOfBirth = NewDate;
            Console.WriteLine("Information Updated Succefully!");
        }
        //public abstract void SearchCustomer(string Name);
        public decimal ShowTotalBalance(int id)
        {
            decimal Total = 0;
            foreach (var acc in Accounts)
            {
                Total += acc.Balance;
            }
            return Total;
        }


    }
}

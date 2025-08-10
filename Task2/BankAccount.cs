using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class BankAccount
    {
        public string AccountNumber { get; set; }
        public int Balance { get; set; }
        public virtual decimal CalculateInterest() => 0;
        public virtual void ShowAccountDetails()
        {
            Console.WriteLine($"Account Number :{AccountNumber}\nBalance :{Balance}");
        }     
        public BankAccount(string accNumber, int balance)
        {
            AccountNumber = accNumber;
            Balance = balance;
        }
    }
}

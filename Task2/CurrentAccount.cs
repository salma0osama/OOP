using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class CurrentAccount : BankAccount
    {
        public decimal OverdraftLimit;
        public CurrentAccount(string accNumber , int balance , decimal overdraftLimit) :base(accNumber,balance)
        {
            OverdraftLimit = overdraftLimit;
        }
        public sealed override decimal CalculateInterest() => 0;
        public override void ShowAccountDetails()
        {
            base.ShowAccountDetails();
            Console.WriteLine($"OverdraftLimit :{OverdraftLimit}");
        }
    }
}

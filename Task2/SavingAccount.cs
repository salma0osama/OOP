using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class SavingAccount : BankAccount
    {
        public decimal InterestRate;
        public SavingAccount(string accNumber , int balance,decimal interestRate) :base(accNumber,balance)
        {
            InterestRate = interestRate;
        }
        public override decimal CalculateInterest()
        {
            return (Balance * InterestRate / 100);
        }
        public override void ShowAccountDetails()
        {
            base.ShowAccountDetails();
            Console.WriteLine($"InterestRate :{InterestRate}");
        }
    }
}

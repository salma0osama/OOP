using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionTask
{
    class CurrentAccount : Account
    {
        public decimal OverdraftLimit;
        public CurrentAccount(decimal balance, DateTime dateOpened, decimal overdraftLimit) :
            base(balance, dateOpened)
        {
            OverdraftLimit = overdraftLimit;
        }
        public void DepositMoney(decimal balance)
        {
            Balance += balance;
            AddTransaction(DateTime.Now, "Deposit", balance);
            Console.WriteLine($"Money has been added successfully. Current Balane: {Balance}");
        }

        public void WithDraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                AddTransaction(DateTime.Now, "WithDraw", amount);
                Console.WriteLine($"Withdrawal successful. New balance: {Balance}");
            }
            else Console.WriteLine("You dont have the amount of money you entered");
        }

    }
}

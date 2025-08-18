using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionTask
{
    class SavingAccount : Account
    {
        public decimal InerestRate { get;private set; }

        public SavingAccount( decimal balance, DateTime dateOpened, decimal inerestRate) 
            :base( balance, dateOpened)
        {
            InerestRate = inerestRate;
        }

        public void CalculateMonthlyInterest(decimal interestRate)
        {
            decimal interest = Balance*(interestRate / 12);
            Balance += interest;
        }

        public void DepositMoney(decimal balance)
        {
            Balance += balance;
            AddTransaction(DateTime.Now,"Deposit",balance);
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

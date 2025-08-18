using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SessionTask
{
    abstract class Account
    {
        static int NextaccNum = 100;
        public int AccountNumber { get;private set; }
        public decimal Balance { get; set; }
        public DateTime DateOpened { get; set; }
        public List<string> Transactions { get; set; }

       
        protected Account( decimal balance, DateTime dateOpened)
        {
            Transactions = new List<string>();
            AccountNumber = NextaccNum++;
            Balance = balance;
            DateOpened = dateOpened;
        }
        public void AddTransaction(DateTime date , string TranType , decimal amount)
        {
            string T = $"{date} {TranType} : {amount} ,Balance after ${Balance}";
            Transactions.Add(T);
        }
        public void Transfer(Account acc1, Account acc2, decimal amount)
        {
            if (acc1.Balance >= amount)
            {
                acc1.Balance -= amount;
                acc2.Balance += amount;
                AddTransaction(DateTime.Now,"Transfer", amount);
                Console.WriteLine($"Transfer successful. Your new balance{acc1.Balance}");
            }
            else Console.WriteLine("You dont have the amount of money you entered");
        }
       
    }
}

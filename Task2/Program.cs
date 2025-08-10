namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SavingAccount Acc1 = new SavingAccount("123",5000,5);
            CurrentAccount Acc2 = new CurrentAccount("678",6000,3);

            BankAccount[] accounts = { new SavingAccount("123",5000,5), new CurrentAccount("678",6000,3) };
            foreach (BankAccount a in accounts)
            {
                a.ShowAccountDetails();
                Console.WriteLine($"Interest :{a.CalculateInterest()}");
                Console.WriteLine();
            }
        }
    }
}
using System.Data;
//show total balance
namespace SessionTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank b = new Bank();
            Console.WriteLine("Welcome to our Bank!");
            while (true)
            {
                Console.WriteLine("Choose What you want to do");
                Console.WriteLine("1: Add new Customer");
                Console.WriteLine("2: Update Customer Details");
                Console.WriteLine("3: Remove Customer");
                Console.WriteLine("4: Add account to Customer");
                Console.WriteLine("5: Show Customer Details");
                Console.WriteLine("6: Show total Balance");
                Console.WriteLine("7. Deposit Money");
                Console.WriteLine("8. Withdraw Money");
                Console.WriteLine("9: Transfer Money");
                Console.WriteLine("10: Show Bank Report");
                Console.WriteLine("11: Display Transaction History");
                Console.WriteLine("12: Exit");
                Console.WriteLine();
                Console.WriteLine();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": //Add Customer
                        Console.WriteLine("Enter your Full Name");
                        string Name = Console.ReadLine();
                        Console.WriteLine("Enter your NationalID");
                        string NID = Console.ReadLine();
                        Console.WriteLine("Enter your Date of Bith as (year,month,day)");
                        DateOnly date = DateOnly.Parse(Console.ReadLine());
                        Customer customer1 = new Customer(Name, NID, date);
                        b.customers.Add(customer1);
                        Console.WriteLine($"Customer Added Successfully with ID {customer1.ID} !");
                        Console.WriteLine();
                        break;
                    case "2": //Update Customer Details
                        Console.WriteLine("Enter your ID");
                        int id = int.Parse(Console.ReadLine());
                        Customer SearchedCutomer = b.SearchCustomer(id);
                        if (SearchedCutomer != null)
                        {
                            Console.WriteLine("Enter your New Name");
                            string newName = Console.ReadLine();
                            Console.WriteLine("Enter your new Date of Birth as (year,month,day)");
                            DateOnly newDate = DateOnly.Parse(Console.ReadLine());
                            SearchedCutomer.UpdateDetails(newName, newDate);
                            Console.WriteLine();
                        }
                        else
                            Console.WriteLine("Customer not Found");
                        Console.WriteLine();
                        break;
                    case "3": //Remove Customer
                        Console.WriteLine("Enter the Customer ID you want to remove");
                        int cid = int.Parse(Console.ReadLine());
                        b.RemoveCustomer(cid);
                        Console.WriteLine();
                        break;
                    case "4": //Add account to Customer
                        Console.WriteLine("Enter your ID");
                        int custid = int.Parse(Console.ReadLine());
                        Customer cust = b.SearchCustomer(custid);
                        if (cust != null)
                        {
                            Console.WriteLine("Choose account type 1.Saving 2.Current");
                            int i = int.Parse(Console.ReadLine());
                            if (i == 1)
                            {
                                Console.WriteLine("Enter Your initial Balance");
                                decimal balance = decimal.Parse(Console.ReadLine());
                                Console.WriteLine("Enter your interest rate");
                                decimal interest = decimal.Parse(Console.ReadLine());
                                SavingAccount acc = new SavingAccount(balance, DateTime.Now, interest);
                                cust.Accounts.Add(acc);
                                Console.WriteLine("Saving Account created");
                                Console.WriteLine();
                            }
                            else if (i == 2)
                            {
                                Console.WriteLine("Enter Your initial Balance");
                                decimal balance = decimal.Parse(Console.ReadLine());
                                Console.WriteLine("Enter your over draft limit");
                                decimal limit = decimal.Parse(Console.ReadLine());
                                CurrentAccount cacc = new CurrentAccount(balance, DateTime.Now, limit);
                                cust.Accounts.Add(cacc);
                                Console.WriteLine("Current account created");
                                Console.WriteLine();
                            }
                        }
                        break;
                    case "5": // Show Customer Details
                        Console.WriteLine("choose your searching key 1.ID  2.Name");
                        string c = Console.ReadLine();
                        if (c == "1")
                        {
                            Console.WriteLine("Enter your ID");
                            int idd = int.Parse(Console.ReadLine());
                            Customer C = b.SearchCustomer(idd);
                            if (C != null)
                            {
                                Console.WriteLine($"Customer ID: {C.ID}");
                                Console.WriteLine($"Name: {C.FullName}");
                                Console.WriteLine($"National ID: {C.NationaID}");
                                Console.WriteLine($"Date of Birth: {C.DateOfBirth}");
                                Console.WriteLine($"Total Balance: {C.ShowTotalBalance(C.ID)}");
                                Console.WriteLine($"Number of Accounts: {C.Accounts.Count}");
                                Console.WriteLine();
                            }
                            else
                                Console.WriteLine("Customer not found");
                        }

                        else if (c == "2")
                        {
                            Console.WriteLine("Enter your Name");
                            string n = Console.ReadLine();
                            Customer C = b.SearchCustomer(n);
                            if (C != null)
                            {
                                Console.WriteLine($"Customer ID: {C.ID}");
                                Console.WriteLine($"Name: {C.FullName}");
                                Console.WriteLine($"National ID: {C.NationaID}");
                                Console.WriteLine($"Date of Birth: {C.DateOfBirth}");
                                Console.WriteLine($"Total Balance: {C.ShowTotalBalance(C.ID)}");
                                Console.WriteLine($"Number of Accounts: {C.Accounts.Count}");
                                Console.WriteLine();
                            }
                            else Console.WriteLine("Customer not found");
                        }

                        else
                        {
                            Console.WriteLine("Invalid Input");
                            Console.WriteLine();
                        }
                        break;
                    
                    case "6": //Show total Balance
                        Console.WriteLine("Enter your ID");
                        int sid = int.Parse(Console.ReadLine());
                        Customer cust2 = b.SearchCustomer(sid);
                        if (cust2 != null)
                        {
                            Console.WriteLine($"Total Balance: ${cust2.ShowTotalBalance(sid)}");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Customer not found");
                            Console.WriteLine();
                        }
                        break;
                    case "7": //Deposit Money
                        Console.WriteLine("Enter your id");
                        int custtid = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Account Number");
                        int accnum = int.Parse(Console.ReadLine());

                        Account accd = b.FindAccount(custtid, accnum);
                        if (accd != null)
                        {
                            Console.Write("Enter amount to deposite");
                            decimal amm = decimal.Parse(Console.ReadLine());
                            if (accd is SavingAccount savacc)
                            {
                                savacc.DepositMoney(amm);
                            }
                            else if (accd is CurrentAccount currAcc)
                            {
                                currAcc.DepositMoney(amm);
                            }
                        }
                        Console.WriteLine();
                        break;
                    case "8"://Withdraw Money
                        Console.WriteLine("Enter Customer ID");
                        int cID = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter your account Number");
                        int acnum = int.Parse(Console.ReadLine());
                        Account accW = b.FindAccount(cID, acnum);
                        if (accW != null)
                        {
                            Console.WriteLine("Enter the amount of money you want to withdraw");
                            decimal ammount = decimal.Parse(Console.ReadLine());
                            if (accW.Balance >= ammount)
                            {
                                if (accW is SavingAccount savacc)
                                {
                                    savacc.WithDraw(ammount);
                                }
                                else if (accW is CurrentAccount currAcc)
                                {
                                    currAcc.WithDraw(ammount);
                                }
                            }
                        }
                        Console.WriteLine();
                        break;
                    case "9": //Transfer Money
                        Console.WriteLine("Enter Sender Customer ID: ");
                        int FromID = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Sender Account Number: ");
                        int fromAccNum = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Receiver Customer ID: ");
                        int ToID = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Receiver Account Number: ");
                        int toAccNum = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the amount");
                        decimal amount = decimal.Parse(Console.ReadLine());

                        Account AccFrom = b.FindAccount(FromID,fromAccNum);
                        Account AccTo = b.FindAccount(ToID,toAccNum);
                        if (AccFrom != null && AccTo!= null)
                        {
                            AccFrom.Transfer(AccFrom, AccTo, amount);
                        }
                        else Console.WriteLine("Customer not found , Transfer Canceled");
                        Console.WriteLine();
                        break;
                    case "10"://Show Bank Report
                        b.ShowBankDetails();
                        Console.WriteLine();
                        break;
                    case "11": //Display Transaction History
                        Console.WriteLine("Enter your customer ID");
                        int tid = int.Parse(Console.ReadLine());
                        Customer tcust = b.SearchCustomer(tid);
                        if (tcust != null)
                        {
                            foreach (var acc in tcust.Accounts)
                            {
                                Console.WriteLine($"Transaction for account {acc.AccountNumber}");
                                foreach (var t in acc.Transactions)
                                {
                                    Console.WriteLine(t);
                                }
                                Console.WriteLine();
                            }
                        }
                        else Console.WriteLine("Customer not Found");
                        Console.WriteLine();
                        break;
                    case "12": //Exit
                        Console.WriteLine("Thanks for using our system!");
                        Console.WriteLine();
                        return;
                    default:
                        Console.WriteLine("Invalid Option");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}

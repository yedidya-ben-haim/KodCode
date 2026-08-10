using System.Security.Principal;

namespace project
{
    class project_day_1
    {
        class BankAccount
        {
            private int _accountNumber;
            private string _ownerName;
            private double _balance;
            private string _accountType;
            private bool _isActive;
            private List<string> _transactionHistory;


            public int AccountNumber
            {
                get => _accountNumber;
            }

            public string OwnerName
            {
                get => _ownerName;

                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        _ownerName = "Unknown";
                    }
                    else
                    {
                        _ownerName = value;
                    }
                }
            }

            public double Balance
            {
                get => _balance;

                set
                {
                    if (value < 0)
                    {
                        _balance = 0;
                    }
                    else
                    {
                        _balance = value;
                    }
                }
            }


            public string AccountType
            {
                get => _accountType;

                set
                {
                    if (value == "Savings" || value == "Checking" || value == "Business")
                    {
                        _accountType = value;
                    }
                    else
                    {
                        _accountType = "Checking";
                    }
                }
            }


            public bool IsActive
            {
                get => _isActive;
                private set => _isActive = value;
            }


            public BankAccount(int accountNumber, string ownerName, double balance, string accountType)
            {
                _accountNumber = accountNumber;
                OwnerName = ownerName;
                Balance = balance;
                AccountType = accountType;
                IsActive = true;
                _transactionHistory = new List<string>();

            }


            public BankAccount(int accountNumber, string ownerName) : this(accountNumber, ownerName, 0.0, "Checking")
            {

            }


            public override string ToString()
            {
                return $"Account #[{AccountNumber}] | Owner: [{OwnerName}] | Balance: $[{Balance:F2}] | Type: [{AccountType}]";
            }


            public void Deposit(double amount)
            {
                if (IsActive)
                {
                    if (amount < 0)
                    {
                        Console.WriteLine("amount must be > 0");
                    }
                    else
                    {
                        Balance += amount;
                        _transactionHistory.Add($"Deposit ${amount}");
                    }
                }
                else
                {
                    Console.WriteLine("The account is inactive.");
                }
            }



            public bool Withdraw(double amount)
            {
                if (IsActive)
                {
                    if (amount < 0)
                    {
                        Console.WriteLine("amount must be > 0");
                        return false;
                    }
                    else
                    {
                        if (Balance < amount)
                        {
                            Console.WriteLine("Balance must be greater than amount");
                            return false;
                        }
                        else
                        {
                            Balance -= amount;
                            _transactionHistory.Add($"Withdraw ${amount}");
                            return true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The account is inactive.");
                    return false;
                }
            }


            public void ApplyInterest()
            {
                if (IsActive)
                {
                    if (AccountType == "Savings")
                    {
                        Balance *= 1.02;
                        _transactionHistory.Add("ApplyInterest 2%");
                    }
                    else
                    {
                        Console.WriteLine("Interest can only be added to a Savings account.");
                    }
                }
                else
                {
                    Console.WriteLine("The account is inactive.");
                }
            }


            public void PrintTransactionHistory()
            {
                Console.WriteLine($"===account [{AccountNumber}] Transaction===");

                foreach (string transaction in _transactionHistory)
                {
                    Console.WriteLine(transaction);
                }
            }


            public void Activate()
            {
                IsActive = true;
            }


            public void Deactivate()
            {
                IsActive = false;
            }


            public static bool Transfer(BankAccount from, BankAccount to, double amount)
            {
                if (from.IsActive && to.IsActive)
                {
                    bool withdrawSucceeded = from.Withdraw(amount);
                    if (withdrawSucceeded)
                    {
                        to.Deposit(amount);
                        return true;
                    }
                }
                Console.WriteLine("Transfer failed.");
                return false;
            }

            public static void printAllAccount(List<BankAccount> accounts)
            {
                Console.WriteLine();
                foreach (BankAccount account in accounts)
                {
                    Console.WriteLine(account.ToString());
                }
            }


        }




        static void Main()
        {
            List<BankAccount> accounts = new();

            accounts.Add(new BankAccount(1, "yedidya", 1000, "Business"));
            accounts.Add(new BankAccount(2, "", 1000, "Savings"));
            accounts.Add(new BankAccount(3, "david", -1000, "Checking"));
            accounts.Add(new BankAccount(4, "dana", 1000, "Busine"));
            accounts.Add(new BankAccount(5, "avi"));


            Console.WriteLine("\n=== Bank Account Management System ===");
            Console.WriteLine("\nCreating accounts...");

            BankAccount.printAllAccount(accounts);


            // Performs transactions
            Console.WriteLine("\nPerforms transactions");

            accounts[0].Deposit(1000);
            accounts[1].Deposit(-500);
            accounts[2].Withdraw(1000);
            accounts[3].Withdraw(-5000);

            BankAccount.printAllAccount(accounts);


            // Tests account status
            Console.WriteLine("\nTests account status");

            accounts[0].Deactivate();
            accounts[0].Deposit(1000);
            accounts[0].Withdraw(100);
            accounts[0].Activate();

            BankAccount.printAllAccount(accounts);



            // Applies interest
            Console.WriteLine("\nApplies interest");

            foreach (BankAccount account in accounts)
            {
                account.ApplyInterest();
            }

            BankAccount.printAllAccount(accounts);

            // Transfers money
            Console.WriteLine("\nTransfers money");


            // Transfer 1
            BankAccount account1 = accounts[0];
            BankAccount account2 = accounts[1];

            Console.WriteLine($"account1 Balance {account1.Balance}");
            Console.WriteLine($"account2 Balance {account2.Balance}");

            Console.WriteLine("Transfer $500 Balance from account1 to account2");
            BankAccount.Transfer(account1, account2, 500);

            Console.WriteLine($"account1 Balance {account1.Balance}");
            Console.WriteLine($"account2 Balance {account2.Balance}");

            // Transfer 2
            BankAccount account3 = accounts[2];
            BankAccount account4 = accounts[3];

            Console.WriteLine($"\naccount3 Balance {account3.Balance}");
            Console.WriteLine($"account4 Balance {account4.Balance}");

            Console.WriteLine("Transfer $500 Balance from account3 to account4");
            BankAccount.Transfer(account3, account4, 500);

            Console.WriteLine($"\naccount3 Balance {account3.Balance}");
            Console.WriteLine($"account4 Balance {account4.Balance}");


            // Displays transaction history
            accounts[0].PrintTransactionHistory();
            accounts[1].PrintTransactionHistory();


            // Displays all accounts
            BankAccount.printAllAccount(accounts);





        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Program
    {
        static Customer cus = new Customer();
        static SavingsAccount savingsAC = new SavingsAccount();
        static CurrentAccount currentAC = new CurrentAccount();
        static FixedDepositAccount fixedDepositAC = new FixedDepositAccount();
        static Account AC = new Account();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Bank App");

            getOperation();
        }

        public static void createCustomer()
        {
            string name, email, phone;
            Console.WriteLine();
            Console.WriteLine("Enter Customer's Details to Create a new Customer Account");
            Console.WriteLine();

            Console.WriteLine("Name");
            name = Console.ReadLine();

            Console.WriteLine("Email Address");
            email = Console.ReadLine();

            Console.WriteLine("Phone");
            phone = Console.ReadLine();

            var NewAddedCustomerId = cus.addCustomer(name, email, phone);
            Console.WriteLine();
            Console.WriteLine("New Customer Account Created Successfully! Customer Id is {0}", NewAddedCustomerId);
        }

        public static void getAllCustomers()
        {
            Console.WriteLine();

            var customers = cus.getCustomers();

            if (customers != null)
            {
                Console.WriteLine("List of All Registered Customers");
                Console.WriteLine();

                foreach (var customer in customers)
                {
                    Console.Write("Id: {0}, Name: {1}, Email Address: {2}, Phone: {3}", customer[0], customer[1], customer[2], customer[3]);
                    Console.WriteLine();
                }

            }
            else
            {
                Console.WriteLine("No Customer Found");
            }

        }
        public static void findCustomer()
        {
            int customerId;
            Console.WriteLine();
            Console.WriteLine("Enter Customer's Id to find Customer's Account");
            customerId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            var customer = cus.getCustomer(customerId);

            if (customer != null)
            {
                Console.WriteLine("Customer's Account Found Successfully");
                Console.Write("Name: {0}, Email Address: {1}, Phone: {2}", customer[1], customer[2], customer[3]);
            }
            else
            {
                Console.WriteLine("Customer's Account Not Found");
            }

        }


        public static void createAccount()
        {
            string accountType, AccountName;
            int customerId;
            int[] result;
            Console.WriteLine();
            Console.WriteLine("Enter The needed data to Create a new Account");
            Console.WriteLine();

            Console.WriteLine("Account Type: S = Savings, C = Current, F = Fixed Deposit");
            accountType = Console.ReadLine().ToLower();

            Console.WriteLine("Customer ID");
            customerId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Account Name");
            AccountName = Console.ReadLine();

            if (accountType == "s")
            {
                result = savingsAC.OpenAccount(customerId, AccountName);
            }
            else if (accountType == "c")
            {
                result = currentAC.OpenAccount(customerId, AccountName);
            }
            else if (accountType == "f")
            {
                result = fixedDepositAC.OpenAccount(customerId, AccountName);
            }
            else
            {
                result = AC.OpenAccount(customerId, AccountName);
            }

            if (result != null)
            {
                Console.WriteLine();
                Console.WriteLine("New Account Created Successfully! Account Id is {0} and Account Number = {1}", result[0], result[1]);
            }
            else
            {
                Console.WriteLine("Unable to create account");
            }


        }

        public static void getAllAccounts()
        {
            Console.WriteLine();

            var accounts = AC.getAccounts();

            if (accounts != null)
            {
                Console.WriteLine("List of All Registered Accounts");
                Console.WriteLine();

                foreach (var account in accounts)
                {
                    Console.WriteLine(account[1]);
                    var CustomerId = Convert.ToInt32(account[1]);
                    var customer = cus.getCustomer(CustomerId);
                    Console.Write("Id: {0}, Customer's Name: {1}, Account Name: {2}, Account Number: {3}, Account Type: {4}, Balance: {5}",
                        account[0], customer[1], account[2], account[3], account[4], account[5]);
                    Console.WriteLine();
                }

            }
            else
            {
                Console.WriteLine("No Account Found");
            }

        }
        public static void findAccount()
        {
            int accountId;
            Console.WriteLine();
            Console.WriteLine("Enter Account's Id to find Account");
            accountId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            var account = AC.getAccount(accountId);

            if (account != null)
            {
                Console.WriteLine("Account Found Successfully");
                Console.Write("Account Name: {0}, Account Number: {1}, Balance: {2}", account[1], account[2], account[5]);
            }
            else
            {
                Console.WriteLine("Account Not Found");
            }

        }

        public static void withdraw()
        {
            int accountId;
            double amount;
            Console.WriteLine();
            Console.WriteLine("Enter Account's Id to withdraw from");
            accountId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter amount to withdraw");
            amount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();

            AC.withdraw(accountId,amount);
        }

        public static void deposit()
        {
            int accountId;
            double amount;
            Console.WriteLine();
            Console.WriteLine("Enter Account's Id to deposit into");
            accountId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter amount to deposit");
            amount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();

            AC.deposit(accountId, amount);
        }

        public static void getOperation()
        {
            Console.WriteLine();
            Console.WriteLine("Enter 1 to register customer");
            Console.WriteLine("Enter 2 to view all customers");
            Console.WriteLine("Enter 3 to find a customer");
            Console.WriteLine("Enter 4 to open account");
            Console.WriteLine("Enter 5 to view all accounts");
            Console.WriteLine("Enter 6 to find an account");
            Console.WriteLine("Enter 7 to withdraw");
            Console.WriteLine("Enter 8 to deposit");

            Console.WriteLine("Enter 0 to exit");

            var op = Convert.ToInt32(Console.ReadLine());

            if (op == 1)
            {
                createCustomer();
            }
            else if (op == 2)
            {
                getAllCustomers();
            }
            else if (op == 3)
            {
                findCustomer();
            }
            else if (op == 4)
            {
                createAccount();
            }
            else if (op == 5)
            {
                getAllAccounts();
            }
            else if (op == 6)
            {
                findAccount();
            }
            else if (op == 7)
            {
                withdraw();
            }
            else if (op == 8)
            {
                deposit();
            }
            else if (op == 0)
            {
                
            }
            else
            {
                Console.WriteLine("Invalid Selection");
            }
            getOperation();
        }
    }
}


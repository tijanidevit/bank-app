using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Account
    {
        protected int CustomerId, AccountId = 0;
        protected string AccountName, AccountNumber;
        protected string AccountType = "General";
        protected double balance = 0.00;

        protected List<string[]> accounts = new List<string[]>();

        public Account()
        {
        }
        public Account(int CustomerId, string AccountName, string AccountNumber, string AccountType)
        {
            this.CustomerId = CustomerId;
            this.AccountName = AccountName;
            this.AccountNumber = AccountNumber;
            this.AccountType = AccountType;
        }

        public int[] OpenAccount(int CustomerId, string AccountName)
        {
            var AccountId = 1;
            Random rand = new Random();
            if (accounts.Count != 0)
            {
                AccountId = accounts.Count() + 1;
            }
            var AccountNumber = rand.Next(111111111, 999999999);

            string[] NewCustomer = { AccountId.ToString(), CustomerId.ToString(), AccountName, AccountNumber.ToString(), this.AccountType, this.balance.ToString() };

            accounts.Add(NewCustomer);

            int[] output = { AccountId, AccountNumber };
            return output;
        }

        public List<string[]> getAccounts()
        {
            return this.accounts;
        }
        public string[] getAccount(int AccountId)
        {
            var all_accounts = accounts.ToArray();
            try
            {
                return all_accounts[AccountId - 1];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void removeAccount(int AccountId)
        {
            accounts.RemoveAt(AccountId - 1);
            Console.WriteLine("Account Deleted Successfully");
        }

        public void deposit(int AccountId, double amount)
        {
            if (amount < 0)
            {
                withdraw(AccountId, amount);
            }
            else
            {
                var account = this.getAccount(AccountId);
                if (account == null)
                {
                    Console.WriteLine("Withdrawal Not Completed! Account Not Found");
                }
                else
                {
                    var CurrentBalance = Convert.ToDouble(account[5]);
                    var NewBalance = CurrentBalance + amount;
                    account[5] = NewBalance.ToString();
                    Console.WriteLine("Deposit Made Successfully! New Balance is #{0}", NewBalance);
                }
            }
        }

        public void withdraw(int AccountId, double amount)
        {            
            var account = this.getAccount(AccountId);
            if (account == null)
            {
                Console.WriteLine("Withdrawal Not Completed! Account Not Found");
            }
            else
            {
                var CurrentBalance = Convert.ToDouble(account[5]);
                var NewBalance = CurrentBalance - amount;

                if (NewBalance <= 200)
                {
                    Console.WriteLine("Withdrawal Not Completed! You must have at least #200 balance left in your account");
                }
                else
                {
                    account[5] = NewBalance.ToString();
                    Console.WriteLine("Withdrawal Made Successfully! New Balance is #{0}", NewBalance);
                }
            }
        }

        protected string[] getCustomer(int customerId)
        {
            Customer cs = new Customer();
            return cs.getCustomer(customerId);
        }

    }
}

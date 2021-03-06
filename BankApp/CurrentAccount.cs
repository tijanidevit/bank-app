using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class CurrentAccount:Account
    {
        new string AccountType = "Current";
        double charges = 66.25;
        public new int[] OpenAccount(int CustomerId, string AccountName)
        {
            var AccountId = 1;
            Random rand = new Random();
            if (base.accounts.Count != 0)
            {
                AccountId = base.accounts.Count() + 1;
            }
            var AccountNumber = rand.Next(111111111, 999999999);

            string[] NewCustomer = { AccountId.ToString(), CustomerId.ToString(), AccountName, AccountNumber.ToString(), this.AccountType, this.balance.ToString() };

            base.accounts.Add(NewCustomer);

            int[] output = { AccountId, AccountNumber };
            return output;
        }

        public new void withdraw(int AccountId, double amount)
        {
            var account = base.getAccount(AccountId);
            if (account == null)
            {
                Console.WriteLine("Withdrawal Not Completed! Account Not Found");
            }
            else
            {
                var CurrentBalance = Convert.ToDouble(account[5]);
                var NewBalance = CurrentBalance - amount - this.charges;

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
    }
}

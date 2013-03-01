using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestsDemo
{
    public class Account
    {
        private decimal balance;

        public void Deposit(decimal amount)
        {
            balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if(balance < amount)
                 throw new Exception("You have not funds");

            balance -= amount;
        }

        public void TransferFunds(Account destination, decimal amount)
        {
            destination.Deposit(amount);
            this.Withdraw(amount);
        }

        public decimal Balance
        {
            get { return balance; }
        }
    }
}

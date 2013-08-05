using System;

namespace UnitTestsDemo
{
    public class Account
    {
        private decimal balance;

        public decimal Balance
        {
            get { return balance; }
        }

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

            if(amount > 1000)
                throw new Exception("aaa");

            this.Withdraw(amount);
        }

     
    }
}

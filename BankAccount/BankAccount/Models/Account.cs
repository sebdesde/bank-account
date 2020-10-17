using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.Models
{
    public class Account
    {
        public Account(decimal amount = 0)
        {
            Balance = amount;
        }

        private decimal Balance { get; set; }

        public void Deposit(decimal amountToDeposit)
        {
            Balance += amountToDeposit;
        }

        public decimal GetBalance()
        {
            return Balance;
        }

        public void Retrieve(decimal amountToRetrieve)
        {
            Balance -= amountToRetrieve;
        }
    }
}

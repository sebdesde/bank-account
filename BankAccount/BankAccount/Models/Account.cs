using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.Models
{
    public class Account
    {
        private decimal Amount { get; set; }

        public void Deposit(decimal depositAmount)
        {
            Amount += depositAmount;
        }

        public decimal GetBalance()
        {
            return Amount;
        }
    }
}

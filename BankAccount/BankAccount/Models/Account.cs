using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.Models
{
    public class Account
    {
        private decimal Balance { get; set; }
        private List<Operation> Operations { get; set; }

        public Account(decimal amount = 0)
        {
            Balance = amount;
            Operations = new List<Operation>();
        }


        public void Deposit(decimal amountToDeposit)
        {
            Balance += amountToDeposit;
            Operations.Add(new Operation(OperationType.Deposit, amountToDeposit));
        }

        public decimal GetBalance()
        {
            return Balance;
        }

        public void Retrieve(decimal amountToRetrieve)
        {
            Balance -= amountToRetrieve;
        }

        public List<Operation> GetOperations()
        {
            return Operations;
        }
    }
}

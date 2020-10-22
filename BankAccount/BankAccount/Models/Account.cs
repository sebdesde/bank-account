using BankAccount.Helpers;
using System;
using System.Collections.Generic;

namespace BankAccount.Models
{
    public class Account
    {
        private decimal Balance { get; set; }
        private List<Operation> Operations { get; set; }

        private IDateTimeWrapper DateTimeWrapper;

        public Account(decimal amount = 0, IDateTimeWrapper dateTimeWrapper = null)
        {
            Balance = amount;
            Operations = new List<Operation>();
            if (dateTimeWrapper != null)
                DateTimeWrapper = dateTimeWrapper;
            else
                DateTimeWrapper = new DateTimeWrapper();
        }


        public void Deposit(decimal amountToDeposit)
        {
            Balance += amountToDeposit;
            RegisterOperation(OperationType.Deposit, amountToDeposit);
        }

        public void Retrieve(decimal amountToRetrieve)
        {
            Balance -= amountToRetrieve;
            RegisterOperation(OperationType.Retrieve, amountToRetrieve);
        }

        public decimal GetBalance()
        {
            return Balance;
        }

        public List<Operation> GetOperations()
        {
            return Operations;
        }

        private void RegisterOperation(OperationType type, decimal amount)
        {
            Operations.Add(new Operation(type, amount, Balance, DateTimeWrapper.GetDateTimeNow()));
        }

        public void ShowOperations()
        {
            foreach (Operation operation in Operations)
            {
                Console.WriteLine($"{operation.Date} / {operation.Type} / {operation.Amount} / {operation.Balance}");
            }
        }
    }
}

using BankAccount.Models;
using BankAccountUnitTests.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace BankAccountUnitTests
{
    public class DepositAccountTests
    {
        [Test]
        public void Deposit_5_euros_on_a_new_account()
        {
            Account account = new Account();
            account.Deposit(5);
            Assert.AreEqual(5, account.GetBalance());
        }

        [Test]
        public void Deposit_5_42_euros_on_a_new_account()
        {
            Account account = new Account();
            account.Deposit(5.42m);
            Assert.AreEqual(5.42m, account.GetBalance());
        }

        [Test]
        public void Deposit_5_42_euros_then_12_73_euros_on_a_new_account()
        {
            Account account = new Account();
            account.Deposit(5.42m);
            account.Deposit(12.73m);
            Assert.AreEqual(18.15m, account.GetBalance());
        }

        [Test]
        public void Retrieve_12_73_euros_on_an_account_with_18_15_euros()
        {
            Account account = new Account(18.15m);
            account.Retrieve(12.73m);
            Assert.AreEqual(5.42m, account.GetBalance());
        }

        [Test]
        public void Retrieve_5_42_euros_then_12_73_euros_on_an_account_with_27_18_euros()
        {
            Account account = new Account(27.18m);
            account.Retrieve(5.42m);
            account.Retrieve(12.73m);
            Assert.AreEqual(9.03m, account.GetBalance());
        }

        [Test]
        public void Retrieve_18_15_euros_on_an_account_with_5_42_euros()
        {
            Account account = new Account(5.42m);
            account.Retrieve(18.15m);
            Assert.AreEqual(-12.73m, account.GetBalance());
        }


        [Test]
        public void Check_Operations_on_a_new_account()
        {
            Account account = new Account();
            List<Operation> operations = account.GetOperations();
            Assert.IsEmpty(operations);
        }

        [Test]
        public void Check_Operations_on_an_account_with_only_one_Deposit()
        {
            Account account = new Account();
            account.Deposit(18.15m);
            List<Operation> operations = account.GetOperations();
            Operation expectedOperation = new Operation(OperationType.Deposit, 18.15m, 0, DateTime.Now);
            Assert.AreEqual(1, operations.Count);
            Assert.AreEqual(expectedOperation.Type, operations[0].Type);
            Assert.AreEqual(expectedOperation.Amount, operations[0].Amount);
        }


        [Test]
        public void Check_Operations_on_an_account_with_only_one_Retrieve()
        {
            Account account = new Account(18.15m);
            account.Retrieve(5.42m);
            List<Operation> operations = account.GetOperations();
            Operation expectedOperation = new Operation(OperationType.Retrieve, 5.42m, 0, DateTime.Now);
            Assert.AreEqual(1, operations.Count);
            Assert.AreEqual(expectedOperation.Type, operations[0].Type);
            Assert.AreEqual(expectedOperation.Amount, operations[0].Amount);
        }


        [Test]
        public void Check_Operations_on_an_account_with_multiple_retrieve_and_deposit()
        {
            Account account = new Account(18.15m);
            account.Deposit(18.15m);
            account.Retrieve(5.42m);
            account.Retrieve(12.73m);
            account.Deposit(5.42m);
            List<Operation> operations = account.GetOperations();
            Operation expectedFirstOperation = new Operation(OperationType.Deposit, 18.15m, 0, DateTime.Now);
            Operation expectedSecondOperation = new Operation(OperationType.Retrieve, 5.42m, 0, DateTime.Now);
            Operation expectedThirdOperation = new Operation(OperationType.Retrieve, 12.73m, 0, DateTime.Now);
            Operation expectedFourthOperation = new Operation(OperationType.Deposit, 5.42m, 0, DateTime.Now);
            Assert.AreEqual(4, operations.Count);
            Assert.AreEqual(expectedFirstOperation.Type, operations[0].Type);
            Assert.AreEqual(expectedFirstOperation.Amount, operations[0].Amount);
            Assert.AreEqual(expectedSecondOperation.Type, operations[1].Type);
            Assert.AreEqual(expectedSecondOperation.Amount, operations[1].Amount);
            Assert.AreEqual(expectedThirdOperation.Type, operations[2].Type);
            Assert.AreEqual(expectedThirdOperation.Amount, operations[2].Amount);
            Assert.AreEqual(expectedFourthOperation.Type, operations[3].Type);
            Assert.AreEqual(expectedFourthOperation.Amount, operations[3].Amount);
        }

        [Test]
        public void Check_Operations_on_an_account_with_balance()
        {
            Account account = new Account(18.15m);
            account.Deposit(18.15m);
            account.Retrieve(5.42m);
            List<Operation> operations = account.GetOperations();
            Operation expectedFirstOperation = new Operation(OperationType.Deposit, 18.15m, 36.30m, DateTime.Now);
            Operation expectedSecondOperation = new Operation(OperationType.Retrieve, 5.42m, 30.88m, DateTime.Now);
            Assert.AreEqual(2, operations.Count);
            Assert.AreEqual(expectedFirstOperation.Type, operations[0].Type);
            Assert.AreEqual(expectedFirstOperation.Amount, operations[0].Amount);
            Assert.AreEqual(expectedFirstOperation.Balance, operations[0].Balance);
            Assert.AreEqual(expectedSecondOperation.Type, operations[1].Type);
            Assert.AreEqual(expectedSecondOperation.Amount, operations[1].Amount);
            Assert.AreEqual(expectedSecondOperation.Balance, operations[1].Balance);
        }


        [Test]
        public void Check_Operations_Date_on_an_account_with_multiple_retrieve_and_deposit()
        {
            FakeDateTimeWrapper fakeDateTimeWrapper = new FakeDateTimeWrapper();
            Account account = new Account(18.15m, fakeDateTimeWrapper);
            FakeDateTimeWrapper.Date = new DateTime(2020,1,1);
            account.Deposit(18.15m);
            FakeDateTimeWrapper.Date = new DateTime(2020, 1, 5);
            account.Retrieve(5.42m);
            FakeDateTimeWrapper.Date = new DateTime(2020, 2, 12);
            account.Retrieve(12.73m);
            FakeDateTimeWrapper.Date = new DateTime(2020, 3, 3);
            account.Deposit(5.42m);
            List<Operation> operations = account.GetOperations();
            Operation expectedFirstOperation = new Operation(OperationType.Deposit, 18.15m, 0, new DateTime(2020, 1, 1));
            Operation expectedSecondOperation = new Operation(OperationType.Retrieve, 5.42m, 0, new DateTime(2020, 1, 5));
            Operation expectedThirdOperation = new Operation(OperationType.Retrieve, 12.73m, 0, new DateTime(2020, 2, 12));
            Operation expectedFourthOperation = new Operation(OperationType.Deposit, 5.42m, 0, new DateTime(2020, 3, 3));
            Assert.AreEqual(4, operations.Count);
            Assert.AreEqual(expectedFirstOperation.Date, operations[0].Date);
            Assert.AreEqual(expectedSecondOperation.Date, operations[1].Date);
            Assert.AreEqual(expectedThirdOperation.Date, operations[2].Date);
            Assert.AreEqual(expectedFourthOperation.Date, operations[3].Date);
        }

        [Test]
        public void Check_Show_Operations_on_an_account_with_multiple_retrieve_and_deposit()
        {
            FakeDateTimeWrapper fakeDateTimeWrapper = new FakeDateTimeWrapper();
            Account account = new Account(18.15m, fakeDateTimeWrapper);
            FakeDateTimeWrapper.Date = new DateTime(2020, 1, 1);
            account.Deposit(18.15m);
            FakeDateTimeWrapper.Date = new DateTime(2020, 1, 5);
            account.Retrieve(5.42m);
            TextWriter outputText = new StringWriter();
            Console.SetOut(outputText);
            account.ShowOperations();
            string expectedoutputText = "01/01/2020 00:00:00 / Deposit / 18,15 / 36,30\r\n05/01/2020 00:00:00 / Retrieve / 5,42 / 30,88\r\n";
            Assert.AreEqual(expectedoutputText, outputText.ToString());
        }
    }
}
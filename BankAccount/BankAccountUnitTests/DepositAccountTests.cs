using BankAccount.Models;
using NUnit.Framework;

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
    }
}
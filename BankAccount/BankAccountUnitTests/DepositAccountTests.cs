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

    }
}
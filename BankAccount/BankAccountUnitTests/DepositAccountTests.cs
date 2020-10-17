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
            account.Amount += 5;
            Assert.AreEqual(5, account.Amount);
        }

        [Test]
        public void Deposit_5_42_euros_on_a_new_account()
        {
            Account account = new Account();
            account.Amount += 5.42m;
            Assert.AreEqual(5.42m, account.Amount);
        }
    }
}
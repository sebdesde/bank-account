using BankAccount.Helpers;
using System;


namespace BankAccountUnitTests.Helpers
{
    public class FakeDateTimeWrapper : IDateTimeWrapper
    {
        public static DateTime Date { get; set; }

        public DateTime GetDateTimeNow()
        {
            return Date;
        }
    }
}

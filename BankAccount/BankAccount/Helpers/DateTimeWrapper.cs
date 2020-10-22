using System;
namespace BankAccount.Helpers
{
    public class DateTimeWrapper : IDateTimeWrapper
    {
        public DateTime GetDateTimeNow()
        {
            return DateTime.Now;
        }
    }
}

namespace BankAccount.Models
{
    public class Operation
    {
        public OperationType Type { get; private set; }
        public decimal Amount { get; private set; }


        public Operation(OperationType type, decimal amount)
        {
            Type = type;
            Amount = amount;
        }
    }
}
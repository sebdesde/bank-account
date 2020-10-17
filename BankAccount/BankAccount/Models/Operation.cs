namespace BankAccount.Models
{
    public class Operation
    {
        public OperationType Type { get; private set; }
        public decimal Amount { get; private set; }
        public decimal Balance { get; private set; }


        public Operation(OperationType type, decimal amount, decimal balance)
        {
            Type = type;
            Amount = amount;
            Balance = balance;
        }
    }
}
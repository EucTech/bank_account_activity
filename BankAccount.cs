using System;

namespace BankAccountApp
{
    public class BankAccount
    {
        private decimal _balance;

        public void Deposit(decimal amount)
        {
            ValidateAmount(amount);
            _balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            ValidateAmount(amount);

            if (amount > _balance)
                throw new InvalidOperationException("Insufficient funds: overdrafts are not allowed.");

            _balance -= amount;
        }

        public decimal GetBalance()
        {
            return _balance;
        }

        // Validation for Deposit and Withdraw
        private static void ValidateAmount(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.", nameof(amount));
        }
    }
}
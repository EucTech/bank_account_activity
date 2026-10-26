# BankAccount (TDD Activity)

A simple BankAccount

## Features

- `Deposit(decimal amount)`: adds money to the account
- `Withdraw(decimal amount)`: removes money from the account
- `GetBalance()`: returns the current balance

## Rules

- Deposits and withdrawals must be greater than zero (otherwise `ArgumentException`)
- Overdrafts are not allowed (otherwise `InvalidOperationException`)

## Project Structure

```
bank_account_activity/
├── BankAccount.cs
├── BankAccountTests.cs
├── bank_account_activity.csproj
└── README.md
```

## Run the Tests

Requires the .NET 7 SDK

```bash
dotnet test
```

## TDD Approach

Each requirement was built in a Red-Green-Refactor cycle:

1. **Red:** write a failing test
2. **Green:** write the minimum code to pass it
3. **Refactor:** clean up while tests stay green

Validation logic shared by `Deposit` and `Withdraw` was extracted into a private `ValidateAmount` method during refactoring.
using System;
using NUnit.Framework;
using BankAccountApp;

namespace BankAccountApp.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        private BankAccount _account;

        [SetUp]
        public void SetUp()
        {
            _account = new BankAccount();
        }

        // ---- GetBalance ----
        [Test]
        public void NewAccount_HasZeroBalance()
        {
            Assert.That(_account.GetBalance(), Is.EqualTo(0m));
        }

        // ----  Deposit ----
        [Test]
        public void Deposit_PositiveAmount_IncreasesBalance()
        {
            _account.Deposit(100m);
            Assert.That(_account.GetBalance(), Is.EqualTo(100m));
        }

        [Test]
        public void Deposit_MultipleTimes_AccumulatesBalance()
        {
            _account.Deposit(100m);
            _account.Deposit(50.25m);
            Assert.That(_account.GetBalance(), Is.EqualTo(150.25m));
        }

        // ---- Cycle 3: Deposit validation ----
        [TestCase(-1)]
        [TestCase(-100.50)]
        [TestCase(0)]
        public void Deposit_NegativeOrZeroAmount_ThrowsArgumentException(double amount)
        {
            Assert.Throws<ArgumentException>(() => _account.Deposit((decimal)amount));
        }

        [Test]
        public void Deposit_InvalidAmount_DoesNotChangeBalance()
        {
            _account.Deposit(100m);
            Assert.Throws<ArgumentException>(() => _account.Deposit(-5m));
            Assert.That(_account.GetBalance(), Is.EqualTo(100m));
        }

        // ---- Withdraw ----
        [Test]
        public void Withdraw_ValidAmount_DecreasesBalance()
        {
            _account.Deposit(100m);
            _account.Withdraw(40m);
            Assert.That(_account.GetBalance(), Is.EqualTo(60m));
        }

        [Test]
        public void Withdraw_EntireBalance_LeavesZero()
        {
            _account.Deposit(100m);
            _account.Withdraw(100m);
            Assert.That(_account.GetBalance(), Is.EqualTo(0m));
        }

        // ---- Withdraw validation ----
        [TestCase(-1)]
        [TestCase(-100.50)]
        [TestCase(0)]
        public void Withdraw_NegativeOrZeroAmount_ThrowsArgumentException(double amount)
        {
            _account.Deposit(100m);
            Assert.Throws<ArgumentException>(() => _account.Withdraw((decimal)amount));
        }

        // ---- No overdrafts ----
        [Test]
        public void Withdraw_MoreThanBalance_ThrowsInvalidOperationException()
        {
            _account.Deposit(50m);
            Assert.Throws<InvalidOperationException>(() => _account.Withdraw(50.01m));
        }

        [Test]
        public void Withdraw_MoreThanBalance_DoesNotChangeBalance()
        {
            _account.Deposit(50m);
            Assert.Throws<InvalidOperationException>(() => _account.Withdraw(100m));
            Assert.That(_account.GetBalance(), Is.EqualTo(50m));
        }

        [Test]
        public void Withdraw_FromEmptyAccount_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _account.Withdraw(1m));
        }
    }
}
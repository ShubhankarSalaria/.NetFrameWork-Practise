using NUnit.Framework;
using System;

// Test fixture class for Bank Account related unit tests
[TestFixture]
public class UnitTest
{
    // Test to verify that a valid deposit
    // correctly increases the account balance
    [Test]
    public void Test_Deposit_ValidAmount()
    {
        // Arrange: create an account with initial balance
        Program account = new Program(1000m);

        // Act: deposit a valid amount
        account.Deposit(500m);

        // Assert: check if balance is updated correctly
        // (Only one assert as per requirement)
        Assert.AreEqual(1500m, account.Balance);
    }

    // Test to verify that depositing a negative amount
    // throws the expected exception with correct message
    [Test]
    public void Test_Deposit_NegativeAmount()
    {
        // Arrange: create an account with initial balance
        Program account = new Program(1000m);

        // Act & Assert: ensure exception message matches expected value
        Assert.AreEqual(
            "Deposit amount cannot be negative",
            Assert.Throws<Exception>(() => account.Deposit(-200m)).Message
        );
    }

    // Test to verify that a valid withdrawal
    // correctly decreases the account balance
    [Test]
    public void Test_Withdraw_ValidAmount()
    {
        // Arrange: create an account with sufficient balance
        Program account = new Program(1000m);

        // Act: withdraw a valid amount
        account.Withdraw(300m);

        // Assert: verify the updated balance
        Assert.AreEqual(700m, account.Balance);
    }

    // Test to verify that withdrawing more than
    // available balance throws an exception
    [Test]
    public void Test_Withdraw_InsufficientFunds()
    {
        // Arrange: create an account with limited balance
        Program account = new Program(500m);

        // Act & Assert: check for correct exception message
        Assert.AreEqual(
            "Insufficient funds.",
            Assert.Throws<Exception>(() => account.Withdraw(800m)).Message
        );
    }
}
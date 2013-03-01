using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace UnitTestsDemo
{
    [TestFixture]
    public class AccountTests
    {
        Account account;

        public AccountTests()
        {
            // Uruchamia się przed wszystkimi przypadkami testowymi w tej klasie
        }

        [SetUp]
        public void SetUp()
        { 
            // Uruchamia się przed każdym testem
            // Inicjalizacja Ninjecta, Sesji itp.
            account = new Account();
        }

        [TearDown]
        public void TearDown()
        {
            // Uruchamia się po każdym teście
            // Dispose, zamykanie sesji itp.
           // account.Dispose();
        }


        [Test]
        public void Method_Scenario_Result()
        {
            // Arrange


            // Act


            // Assert

        }

        [Test]
        public void Deposit_Some_AddToBalance()
        {
            // Arrange
            account = new Account();

            // Act
            account.Deposit(100);

            // Assert
            Assert.AreEqual(100, account.Balance);
        }
      

        [Test]
        public void TransferFunds_WhenHaveFunds_DoTransfer()
        {
           // Arrange 
           var  src = new Account();
            src.Deposit(200);

            var dst = new Account();
            dst.Deposit(100);

            // Act
            src.TransferFunds(dst, 100);

            // Assert
            Assert.AreEqual(200, dst.Balance);
            Assert.AreEqual(100, src.Balance);
            
        }

        [Test]
        public void TransferFunds_WhenNoFunds_ThrowsException()
        {
            Account source = new Account();
            source.Deposit(150m);

            Account destination = new Account();
            destination.Deposit(200m);

            Assert.Throws<Exception>(() => source.TransferFunds(destination, 200));

            Assert.AreEqual(150m, source.Balance);
            Assert.AreEqual(200m, source.Balance);
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp;
using NSubstitute;

namespace BankApp.Test
{
    [TestFixture]
    class BankAppTests
    {
        Bank sut;
        IAuditLogger logger;
        Account acc;

        [SetUp]
        public void Setup()
        {
            logger = Substitute.For<IAuditLogger>();
            sut = new Bank(logger);
            acc = new Account { Name = "Jonny", Number = "1", Balance = 0 };
        }

        [Test]
        public void CanCreateBankAccount()
        {
            sut.CreateAccount(acc);

            var result = sut.GetAccount("1");

            Assert.AreEqual(result.Name, "Jonny");
            Assert.AreEqual(result.Number, "1");
            Assert.AreEqual(result.Balance, 0);
        }

        [Test]
        public void CanNotCreateDuplicateAccounts()
        {
            sut.CreateAccount(acc);

            Assert.Throws<DuplicateAccount>(() => {

                sut.CreateAccount(acc);

            });
        }

        [Test]
        public void WhenCreatingAnAccount_AMessageIsWrittenToTheAuditLog()
        {
            sut.CreateAccount(acc);

            logger.Received(1).AddMessage(Arg.Is<string>(m => m.Contains(acc.Name) && m.Contains(acc.Number)));

        }

        [Test]
        public void WhenCreatinAnValidAccount_OnMessageAreWrittenToTheAuditLog()
        {
            sut.CreateAccount(acc);

            logger.Received(1).AddMessage(Arg.Any<string>());
        }


        [Test]
        public void WhenCreatingAnInvalidAccount_TwoMessagesAreWrittenToTheAuditLog()
        {
            acc.Number = "nepp";

            Assert.Throws<InvalidAccount>(() => {
                sut.CreateAccount(acc);
            });

            logger.Received(2).AddMessage(Arg.Any<string>());
        }

        [Test]
        public void WhenCreatingAnInvalidAccount_AWarn12AndErro45MessageIsWrittenToAuditLog()
        {
            acc.Number = "nepp";

            Assert.Throws<InvalidAccount>(() => {
                sut.CreateAccount(acc);
            });

            logger.Received(2).AddMessage(Arg.Is<string>(m => m.Contains("Warn12:") || m.Contains("Error45:")));
        }

        [Test]
        public void VerifyThat_GetAuditLog_GetsTheLogFromTheAuditLogger()
        {
            logger.GetLog().Returns(new List<string> {
                "Item 1", "Item 2", "Item 3"
            });

            List<string> Logs = sut.GetAuditLog();

            Assert.AreEqual(3, Logs.Count());
        }





    }
}

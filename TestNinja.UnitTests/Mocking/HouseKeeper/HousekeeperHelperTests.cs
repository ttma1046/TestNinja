using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;
using TestNinja.Mocking.HouseKeeper;

namespace TestNinja.UnitTests.Mocking.HouseKeeper
{
    public class HousekeeperHelperTests
    {
        private Mock<IHousekeeperService> housekeeperService;
        private Mock<IUnitOfWork> unitOfWork;
        private Mock<IEmailSender> emailSender;
        private Mock<IStatementGenerator> statementGenerator;
        private HousekeeperHelper housekeeperHelper;
        
        [SetUp]
        public void Setup()
        {
            unitOfWork = new Mock<IUnitOfWork>();
            emailSender = new Mock<IEmailSender>();
            statementGenerator = new Mock<IStatementGenerator>();

            housekeeperHelper = new HousekeeperHelper(unitOfWork.Object, statementGenerator.Object, emailSender.Object);
            unitOfWork.Setup(r => r.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
                new Housekeeper
                {
                    
                }
            }.AsQueryable());
        }
        
        
        [Test]
        public void SendStatementEmails_WhenCalled_AlwaysReturnTrue()
        {
            // Arrange
            // Act
            var result = housekeeperHelper.SendStatementEmails(new DateTime(2018, 1, 7, 14, 0, 0));
            
            // Assert
            Assert.That(result, Is.True);
        }
    }
}
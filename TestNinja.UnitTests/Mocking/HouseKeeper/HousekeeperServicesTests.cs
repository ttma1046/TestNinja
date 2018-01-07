using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;
using TestNinja.Mocking.HouseKeeper;

namespace TestNinja.UnitTests.Mocking.HouseKeeper
{
    public class HousekeeperServicesTests
    {
        private Mock<IUnitOfWork> unitOfWork;
        private Mock<IEmailSender> emailSender;
        private Mock<IStatementGenerator> statementGenerator;
        private Mock<IMessageBox> messageBox;
        private HousekeeperService _housekeeperService;
        private DateTime _statementDate = new DateTime(2018, 1, 1);
        private Housekeeper _housekeeper;
        private string _statementfilename;

        [SetUp]
        public void Setup()
        {
            _housekeeper = new Housekeeper
            {
                Email = "a",
                FullName = "b",
                Oid = 1,
                StatementEmailBody = "c"
            };
            
            unitOfWork = new Mock<IUnitOfWork>();
            
            unitOfWork.Setup(r => r.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
                _housekeeper
            }.AsQueryable());

            _statementfilename = "fileName";
            statementGenerator = new Mock<IStatementGenerator>();
            statementGenerator.Setup(sg => sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate)).Returns(() => _statementfilename);
            
            emailSender = new Mock<IEmailSender>();
            messageBox = new Mock<IMessageBox>();            
            _housekeeperService = new HousekeeperService(unitOfWork.Object, statementGenerator.Object, emailSender.Object, messageBox.Object);
        }
        
        [Test]
        public void SendStatementEmails_WhenCalled_AlwaysReturnTrue()
        {
            // Arrange
            // Act
            var result = _housekeeperService.SendStatementEmails(new DateTime(2018, 1, 7, 14, 0, 0));
            
            // Assert
            Assert.That(result, Is.True);
        }
        
        [Test]
        public void SendStatementEmails_WhenCalled_GenerateStatements()
        {
            // Arrange

            // Act
            _housekeeperService.SendStatementEmails(_statementDate);
            
            // Assert
            statementGenerator.Verify(s => s.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate));
        }
        
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void SendStatementEmails_HouseKeepersEmailIsNull_ShouldNotGenerateStatements(string houseKeeperEmail)
        {
            // Arrange
            _housekeeper.Email = houseKeeperEmail;
            
            // Act
            _housekeeperService.SendStatementEmails(_statementDate);
            
            // Assert
            statementGenerator.Verify(s => s.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate), Times.Never);
        }
        
        [Test]
        public void SendStatementEmails_WhenCalled_EmailTheStatement()
        {
            // Arrange
            statementGenerator.Setup(sg => sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate)).Returns(_statementfilename);
            
           // Act
            _housekeeperService.SendStatementEmails(_statementDate);
            
            // Assert
            VerifyEmailSent();
        }
        
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void SendStatementEmails_StatementFilenameIsNull_ShouldNotEmailFile(string statementFileName)
        {
            // Arrange
            _statementfilename = statementFileName;
            // statementGenerator.Setup(sg => sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate)).Returns(() => null);
            // Act
            _housekeeperService.SendStatementEmails(_statementDate);
            
            // Assert
            VerifyEmailNotSent();
        }
        
        [Test]
        public void SendStatementEmails_EmailSendingFails_DisplayAMessageBox()
        {
            // Arrange
            emailSender.Setup(es => es.EmailFile(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()
                )).Throws<Exception>();
            
            // Act
            _housekeeperService.SendStatementEmails(_statementDate);
            
            // Assert
            VerifyMessageBoxShown();
        }

        private void VerifyMessageBoxShown()
        {
            messageBox.Verify(m => m.Show(It.IsAny<string>(), It.IsAny<string>(), MessageBoxButtons.OK));
        }

        private void VerifyEmailNotSent()
        {
            emailSender.Verify(s => s.EmailFile(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()),
                Times.Never);
        }
        
        private void VerifyEmailSent()
        {
            emailSender.Verify(s => s.EmailFile(_housekeeper.Email, _housekeeper.StatementEmailBody, _statementfilename,
                string.Format("Sandpiper Statement {0:yyyy-MM} {1}", _statementDate, _housekeeper.FullName)));
        }

    }
}
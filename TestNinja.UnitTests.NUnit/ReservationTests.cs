using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.NUnit
{   
    [TestFixture]
    public class ReservationTests
    {

        [Test]
        public void CanBeCanncelledBy_AdminCancelling_ReturnsTrue()
        {
            // Arrange
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            // Assert
            // Assert.IsTrue(result);
            Assert.That(result, Is.True);
            // Assert.That(result == true);
        }

        [Test]
        public void CanBeCancelledBy_SameUserCancellingTheReservation_ReturnsTrue()
        {
            // Arrange
            var userMadeBy = new User();

            var reservation = new Reservation { MadeBy = userMadeBy };

            // Act
            var result = reservation.CanBeCancelledBy(userMadeBy);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_AnotherUserCancellingReservation_ReturnsFalse()
        {
            // Arrange
            var reservation = new Reservation { MadeBy = new User() };

            var anotherUser = new User();

            // Act
            var result = reservation.CanBeCancelledBy(anotherUser);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CanBeCancelledBy_NullUserCantCancellingReservation_ReturnsFalse()
        {
            // Arrange
            var reservation = new Reservation();

            var anotherUser = new User();

            // Act
            var result = reservation.CanBeCancelledBy(anotherUser);

            // Assert
            Assert.IsFalse(result);
        }
    }
}

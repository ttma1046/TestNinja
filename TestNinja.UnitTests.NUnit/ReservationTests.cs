using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.NUnit
{   
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void NUnit_CanBeCanncelledBy_AdminCancelling_ReturnsTrue()
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
        public void NUnit_CanBeCancelledBy_SameUserCancellingTheReservation_ReturnsTrue()
        {
            // Arrange
            var UserMadeBy = new User();

            var reservation = new Reservation { MadeBy = UserMadeBy };

            // Act
            var result = reservation.CanBeCancelledBy(UserMadeBy);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void NUnit_CanBeCancelledBy_AnotherUserCancellingReservation_ReturnsFalse()
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
        public void NUnit_CanBeCancekkedBy_NullUserCantCancellingReservation_ReturnsFalse()
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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestClass]
    public class ReservationTests
    {
        [TestMethod]
        public void CanBeCanncelledBy_AdminCancelling_ReturnsTrue()
        {
            // Arrange
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_SameUserCancellingTheReservation_ReturnsTrue()
        {
            // Arrange
            var UserMadeBy = new User();

            var reservation = new Reservation { MadeBy = UserMadeBy };

            // Act
            var result = reservation.CanBeCancelledBy(UserMadeBy);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
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

        [TestMethod]
        public void CanBeCancekkedBy_NullUserCantCancellingReservation_ReturnsFalse()
        {
            // Arrange
            var reservation = new Reservation();

            var anotherUser = new User();

            // Act
            var result = reservation.CanBeCancelledBy(anotherUser);
            

            Assert.IsFalse(result);
        }
    }
}

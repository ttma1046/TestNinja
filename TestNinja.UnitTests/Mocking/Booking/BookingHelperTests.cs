using System;
using System.Linq;
using System.Collections.Generic;

using Moq;
using NUnit.Framework;
using TestNinja.Mocking.Booking;


namespace TestNinja.UnitTests.Mocking.Booking
{
    [TestFixture]
    public class BookingHelper_OverlappingBookingsExistTests
    {
        private Mock<IBookingRepository> bookingRepository;
        private TestNinja.Mocking.Booking.Booking _existingBooking;

        [SetUp]
        public void Setup()
        {
            bookingRepository = new Mock<IBookingRepository>();
            
            _existingBooking = new TestNinja.Mocking.Booking.Booking
            {
                ArrivalDate = ArriveOn(2017, 1, 15),
                DepartureDate = DepartOn(2017, 1, 20),
                Reference = "a",
                Id = 2
            };
            
            bookingRepository.Setup(r => r.GetActiveBookings(1)).Returns(new List<TestNinja.Mocking.Booking.Booking>
            {
                _existingBooking
            }.AsQueryable());

        }


        [Test]
        public void WhenBookingStatusEqualsCancelled_ReturnEmptyString()
        {
            // Arrange
                        
            // Act
            
            // Assert
            
        }
        
        [Test]
        public void BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {
            // Arrange


            // Act
            var result = BookingHelper.OverlappingBookingsExist(new TestNinja.Mocking.Booking.Booking
            {
                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate, days: 2),
                DepartureDate = Before(_existingBooking.ArrivalDate),
                Reference = "a"                
            }, bookingRepository.Object);

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void BookingStartsAndFinishesAfterAnExistingBooking_ReturnEmptyString()
        {
            // Arrange
            
            // Act
            
            // Assert
            
        }
        
        [Test]
        public void BookingStartsAfterAnExistingBookingStartsFinishesAfterAnExistingBookingFinishes_OverlappingReturnReference()
        {
            // Arrange
            
            // Act
            
            // Assert
            
        }

        [Test]
        public void BookingStartsBeforeAnExistingBookingStartsButFinishesBeforeExistingBookingFinishes_OverlappingReturnReference()
        {
            // Arrange
            
            // Act
            
            // Assert
            
        }
        
        [Test]
        public void BookingStartsAfterAnExistingBookingStartsButFinishesBeforeExistingBookingFinishes_OverlappingReturnReference()
        {
            // Arrange
            
            // Act
            
            // Assert
            
        }

        private DateTime Before(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(-days);
        }
        
        private DateTime After(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(+days);
        }

        private DateTime ArriveOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 14, 0, 0);
        }
        
        private DateTime DepartOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }
    }
}
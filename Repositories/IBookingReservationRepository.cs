using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookingReservationRepository
    {
        IEnumerable<BookingReservation> GetAllBookingReservations();
        void AddBookingReservation(BookingReservation reservation);
        void UpdateBookingReservation(BookingReservation reservation);
        void DeleteBookingReservation(BookingReservation reservation);
        BookingReservation? GetBookingReservationByID(int id);
        IEnumerable<BookingReservation> GetBookingReservationsByDateRange(DateOnly startDate, DateOnly endDate);
    }
}

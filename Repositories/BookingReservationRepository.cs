using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingReservationRepository : IBookingReservationRepository
    {
        public IEnumerable<BookingReservation> GetAllBookingReservations() => BookingReservationDAO.Instance.GetAllBookingReservations();

        public void AddBookingReservation(BookingReservation reservation) => BookingReservationDAO.Instance.AddBookingReservation(reservation);

        public void UpdateBookingReservation(BookingReservation reservation) => BookingReservationDAO.Instance.UpdateBookingReservation(reservation);

        public void DeleteBookingReservation(BookingReservation reservation) => BookingReservationDAO.Instance.DeleteBookingReservation(reservation);

        public BookingReservation? GetBookingReservationByID(int id) => BookingReservationDAO.Instance.GetBookingReservationByID(id);

        public IEnumerable<BookingReservation> GetBookingReservationsByDateRange(DateOnly startDate, DateOnly endDate) => BookingReservationDAO.Instance.GetBookingReservationsByDateRange(startDate, endDate);
    }
}
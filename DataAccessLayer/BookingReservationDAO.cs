using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BookingReservationDAO : SingletonBase<BookingReservationDAO>
    {
        private HotelminiDBContext _context;
        public BookingReservationDAO()
        {
            _context = new HotelminiDBContext();
        }
        public IEnumerable<BookingReservation> GetAllBookingReservations()
        {
            return _context.BookingReservations.ToList();
        }
        public void AddBookingReservation(BookingReservation reservation)
        {
            _context.BookingReservations.Add(reservation);
            _context.SaveChanges();
        }
        public void UpdateBookingReservation(BookingReservation reservation)
        {
            _context.BookingReservations.Update(reservation);
            _context.SaveChanges();
        }
        public void DeleteBookingReservation(BookingReservation reservation)
        {
            _context.BookingReservations.Remove(reservation);
            _context.SaveChanges();
        }
        public BookingReservation? GetBookingReservationByID(int id)
        {
            BookingReservation? bookingReservation = _context.BookingReservations.FirstOrDefault(b => b.BookingReservationID == id);
            return bookingReservation;
        }
        public IEnumerable<BookingReservation>GetBookingReservationsByDateRange(DateOnly startDate, DateOnly endDate)
        {
            return _context.BookingReservations.Where(b=> b.BookingDate >= startDate && b.BookingDate <= endDate).ToList();
        }
    }
}

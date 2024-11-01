using BusinessObjects;

namespace DataAccessLayer
{
    public class BookingDetailDAO : SingletonBase<BookingDetailDAO>
    {
        private HotelminiDBContext _context;

        public BookingDetailDAO()
        {
            _context = new HotelminiDBContext();
        }

        public IEnumerable<BookingDetail> GetAllBookingDetails()
        {
            return _context.BookingDetails.ToList();
        }

        public void AddBookingDetail(BookingDetail bookingDetail)
        {
            _context.BookingDetails.Add(bookingDetail);
            _context.SaveChanges();
        }

        public void UpdateBookingDetail(BookingDetail bookingDetail)
        {
            _context.BookingDetails.Update(bookingDetail);
            _context.SaveChanges();
        }

        public void DeleteBookingDetail(BookingDetail bookingDetail)
        {
            _context.BookingDetails.Remove(bookingDetail);
            _context.SaveChanges();
        }

        public BookingDetail? GetBookingDetailById(int bookingReservationId, int roomId)
        {
            BookingDetail? bookingDetail = _context.BookingDetails.FirstOrDefault(bd => bd.BookingReservationID == bookingReservationId && bd.RoomID == roomId);
            return bookingDetail;
        }
    }
}
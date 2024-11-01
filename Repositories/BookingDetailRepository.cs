using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class BookingDetailRepository : IBookingDetailRepository
    {
        public IEnumerable<BookingDetail> GetAllBookingDetails() => BookingDetailDAO.Instance.GetAllBookingDetails();

        public void AddBookingDetail(BookingDetail bookingDetail) => BookingDetailDAO.Instance.AddBookingDetail(bookingDetail);

        public void UpdateBookingDetail(BookingDetail bookingDetail) => BookingDetailDAO.Instance.UpdateBookingDetail(bookingDetail);

        public void DeleteBookingDetail(BookingDetail bookingDetail) => BookingDetailDAO.Instance.DeleteBookingDetail(bookingDetail);

        public BookingDetail? GetBookingDetailById(int bookingReservationId, int roomId) => BookingDetailDAO.Instance.GetBookingDetailById(bookingReservationId, roomId);
    }
}
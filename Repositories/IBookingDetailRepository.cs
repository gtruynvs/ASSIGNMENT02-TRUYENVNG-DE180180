using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookingDetailRepository
    {
        IEnumerable<BookingDetail> GetAllBookingDetails();

        void AddBookingDetail(BookingDetail bookingDetail);

        void UpdateBookingDetail(BookingDetail bookingDetail);

        void DeleteBookingDetail(BookingDetail bookingDetail);

        BookingDetail? GetBookingDetailById(int bookingReservationId, int roomId);
    }
}
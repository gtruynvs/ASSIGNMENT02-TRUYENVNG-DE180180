using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    public class BookingDetail
    {
        public int BookingReservationID { get; set; }

        public int RoomID { get; set; }

        [Required]
        public DateOnly StartDate { get; set; }

        [Required]
        public DateOnly EndDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ActualPrice { get; set; }

        [ForeignKey("BookingReservationID")]
        public virtual BookingReservation BookingReservation { get; set; } = null!;

        [ForeignKey("RoomID")]
        public virtual RoomInformation RoomInformation { get; set; } = null!;
    }
}
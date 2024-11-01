using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class BookingReservation
    {
        [Key]
        public int BookingReservationID { get; set; }

        [Required]
        public DateOnly BookingDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        public int CustomerID { get; set; }

        public int? BookingStatus { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; } = null!;

        public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();
    }
}
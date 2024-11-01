using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class RoomInformation
    {
        [Key]
        public int RoomID { get; set; }

        [Required]
        [MaxLength(50)]
        public string RoomNumber { get; set; } = null!;

        [MaxLength(220)]
        public string? RoomDetailDescription { get; set; }

        public int? RoomMaxCapacity { get; set; }

        public int RoomTypeID { get; set; }

        public int? RoomStatus { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? RoomPricePerDate { get; set; }

        [ForeignKey("RoomTypeID")]
        public virtual RoomType RoomType { get; set; } = null!;

        public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();
    }
}
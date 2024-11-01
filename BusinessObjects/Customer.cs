using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [MaxLength(50)]
        public string? CustomerFullName { get; set; }

        [MaxLength(12)]
        public string? Telephone { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;

        public DateOnly? CustomerBirthday { get; set; }
        public int? CustomerStatus { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; } = null!;

        public virtual ICollection<BookingReservation> BookingReservations { get; set; } = new List<BookingReservation>();
    }
}
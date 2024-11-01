using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class RoomType
    {
        [Key]
        public int RoomTypeID { get; set; }

        [Required]
        [MaxLength(50)]
        public string RoomTypeName { get; set; } = null!;

        [MaxLength(250)]
        public string? TypeDescription { get; set; }

        [MaxLength(250)]
        public string? TypeNote { get; set; }

        public virtual ICollection<RoomInformation> Rooms { get; set; } = new List<RoomInformation>();
    }
}
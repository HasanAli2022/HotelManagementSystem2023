using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Rooms
    {
        [Key]
        public int RoomID { get; set; }
        [Required]
        [StringLength(50)]
        public string RoomType { get; set; }
        [Required]
        public Decimal RoomPrice { get; set; }
        [Required]
        public string RoomImage { get; set; }
        public string? RoomNo { get; set; }
        [Required]
        public int RoomHotelID { get; set; }
    }
}

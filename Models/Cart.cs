using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }
        [Required]
        public int CartHotelID { get; set; }
        [Required]
        public int CartRoomID { get; set; }
        [Required]
        public int CartRDID { get; set; }
        [Required]
        public decimal CartPrice { get; set; }
        [Required]
        public int CartUserID { get; set; }
    }
}

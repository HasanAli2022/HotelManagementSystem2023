using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Hotels
    {
        [Key]
        public int HotelID { get; set; }
        [Required]
        [StringLength(35)]
        public string HotelName { get; set; }
        [StringLength(100)]
        [Required]
        public string HotelAddress { get; set; }
        [Required]
        [StringLength(25)]
        public string HotelCity { get; set; }
        [Required]
        [StringLength (50)]
        public string HotelEmail { get; set; }
        [Required]
        [StringLength(25)]
        public string HotelPhone { get; set; }
        [StringLength(100)]
        public string HotelImage { get; set; }
    }
}

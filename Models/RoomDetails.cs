using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class RoomDetails
    {
        [Key]
        public int RDID { get; set; }
        [Required]
        [StringLength(50)]
        public string RDImage1 { get; set; }
        
        [StringLength(50)]
        public string? RDImage2 { get; set; }
        
        [StringLength(50)]
        public string? RDImage3 { get; set; }
        
        public string? RDFood { get; set; }
        [Required]
        public string RDFeatures { get; set; }
        [Required]
        public int RDRoomID { get; set; }
        [Required]
        public int RDHotelID { get; set; }

    }
}

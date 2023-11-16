using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Invoices
    {
        [Key]
        public int InvoiceID { get; set; }
        [Required]
        public int InvoiceHotelID { get; set; }
        [Required]
        public int InvoiceRoomID { get; set; }
        [Required]
        public int InvoiceRDID { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }
        [Required]
        public Decimal InvoicePrice { get; set; }
        [Required]
        public int InvoiceUserID { get; set; }
        [Required]
        public Decimal InvoiceTax { get; set; }
        [Required]
        public Decimal InvoiceTotal { get; set; }
        [Required]
        public Decimal InvoiceDiscount { get; set; }
        [Required]
        public Decimal InvoiceNetPrice { get; set; }
        [Required]
        public DateTime InvoiceDateFrom { get; set; }
        [Required]
        public DateTime InvoiceDateTo { get; set; }
    }
}

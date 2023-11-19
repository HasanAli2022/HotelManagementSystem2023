using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
	public class ShoppingController : Controller
	{

        private readonly AppDbContext _context;
        public ShoppingController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
		{
            var Hotel = _context.Hotels.ToList();
            return View(Hotel);
        }

        public IActionResult Rooms(int id)
        {
            var availableRooms = _context.Rooms.Where(x=>x.RoomHotelID == id).ToList();
            return View(availableRooms);
        }

        public IActionResult Invoice(int id)
        {
            Decimal tax = 15/100;
            var rooms = _context.Rooms.SingleOrDefault(x=>x.RoomID == id);
            var invoice = new Invoices
            {
                InvoiceRoomID = rooms.RoomID,
                InvoiceHotelID = rooms.RoomHotelID,
                InvoiceRDID = rooms.RoomID,
                InvoicePrice = rooms.RoomPrice,

                InvoiceTotal = rooms.RoomPrice * 1,

                InvoiceDiscount = 0,
                InvoiceTax = (decimal) 0.15 * rooms.RoomPrice /*( rooms.RoomPrice * tax )*/ ,
                InvoiceNetPrice = (decimal)(1.15 ) * rooms.RoomPrice * 1 ,
                InvoiceDateFrom = DateTime.Now.Date,
                InvoiceDate = DateTime.Now.Date,
                InvoiceDateTo = DateTime.Now.AddDays(1),
                InvoiceUserID = 1

            };
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
            var currentInvoice = _context.Invoices.Where(y => y.InvoiceID == invoice.InvoiceID);

            return View(currentInvoice);
        }
    }
}

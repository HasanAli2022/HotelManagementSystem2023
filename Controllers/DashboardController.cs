using HotelManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using HotelManagementSystem.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using MimeKit;
using MailKit.Net.Smtp;

namespace HotelManagementSystem.Controllers
{
    public class DashboardController : Controller
    {
		private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
			_context = context;
		}

        /*kmmlzqdcdtbvbkio*/
        public async Task<string> SendEMail()
		{
			var message = new MimeMessage();
			message.From.Add(new MailboxAddress("Test Message", "hasan14192010@gmail.com"));
			message.To.Add(MailboxAddress.Parse("hasanalbenhasan@gmail.com"));
			message.Subject="Test email from my project in ASP.Net Core MVC";
			message.Body = new TextPart("Plain")
			{
				Text = "Welcome in my App"
			};

			using (var client=new SmtpClient())
			{
				try
				{
					client.Connect("smtp.gmail.com",587);
					client.Authenticate("hasan14192010@gmail.com", "kmmlzqdcdtbvbkio");
					await client.SendAsync(message);
					client.Disconnect(true);
				}
				catch (Exception e)
				{
					return e.Message.ToString();
				}
			}
			return "ok";
		}

		[HttpPost]
		public IActionResult CreateNewHotel(Hotels Hotels)
		{
			_context.Hotels.Add(Hotels);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult DeleteHotel(int id)
		{
			var deletedHotel = _context.Hotels.SingleOrDefault(x=>x.HotelID == id);
			if (deletedHotel != null)
			{
                _context.Hotels.Remove(deletedHotel);
				_context.SaveChanges();
				TempData["Deletion"] = "Ok";
            }
			
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult UpdateHotel(Hotels Hotels)
		{
			_context.Hotels.Update(Hotels);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

        public IActionResult EditHotel(int id)
        {
            var selectedHotel = _context.Hotels.SingleOrDefault(x => x.HotelID == id);
            return View(selectedHotel);
        }

        
        [Authorize]
        public async Task<IActionResult> Index()
        {
			var currentuser = HttpContext.User.Identity.Name;
			ViewBag.CurrentUser = currentuser;

			/*CookieOptions option = new CookieOptions();
			option.Expires = DateTime.Now.AddMinutes(20);
			Response.Cookies.Append("Username", currentuser,option);*/
			HttpContext.Session.SetString("Username", currentuser);


			var Hotel = _context.Hotels.ToList();
			return View(Hotel);
		}
		[HttpPost]
        public IActionResult Index(string city)
        {
            var Hotel = _context.Hotels.Where(x=>x.HotelCity==city);
            return View(Hotel);
        }

		public IActionResult Rooms()
		{
			/*ViewBag.CurrentUser = Request.Cookies["Username"];*/
			ViewBag.currentuser = HttpContext.Session.GetString("Username");

			var HotelNames = _context.Hotels.ToList();
			ViewBag.HotelNames = HotelNames;
			var rooms = _context.Rooms.ToList();
			return View(rooms);
		}

		[HttpPost]
		public IActionResult CreateNewRoom(Rooms rooms)
		{
			_context.Rooms.Add(rooms);
			_context.SaveChanges();
			return RedirectToAction("Rooms");
		}

		public IActionResult DeleteRoom(int id)
		{
			var deletedRoom = _context.Rooms.SingleOrDefault(x => x.RoomID.Equals(id));
			if (deletedRoom != null)
			{
				_context.Rooms.Remove(deletedRoom);
				_context.SaveChanges();
				TempData["Deletion"] = "Ok";
			}

			return RedirectToAction("Rooms");
		}

        [HttpPost]
        public IActionResult UpdateRoom(Rooms rooms)
        {
            _context.Rooms.Update(rooms);
            _context.SaveChanges();
            return RedirectToAction("Rooms");
        }

        public IActionResult EditRoom(int id)
        {
            var HotelNames = _context.Hotels.ToList();
            ViewBag.HotelNames = HotelNames;

            var selectedRoom = _context.Rooms.SingleOrDefault(x => x.RoomID == id);
            return View(selectedRoom);
        }

		public IActionResult RoomDetails()
		{
            /*ViewBag.CurrentUser = Request.Cookies["Username"];*/

            ViewBag.currentuser = HttpContext.Session.GetString("Username");

			var HotelNames = _context.Hotels.ToList();
			ViewBag.HotelNames = HotelNames;
			var rooms = _context.Rooms.ToList();
			ViewBag.RoomNo = rooms;
			var rd = _context.RoomDetails.ToList();
			return View(rd);
		}
		[HttpPost]
		public IActionResult RoomDetails(int HotelId)
		{
			/*ViewBag.CurrentUser = Request.Cookies["Username"];*/

			ViewBag.currentuser = HttpContext.Session.GetString("Username");

			var HotelNames = _context.Hotels.ToList();
			ViewBag.HotelNames = HotelNames;
			var rooms = _context.Rooms.SingleOrDefault(x=>x.RoomHotelID.Equals(HotelId));
			ViewBag.RoomNo = rooms;
			var rd = _context.RoomDetails.ToList();
			return View(rd);
		}

		[HttpPost]
		public IActionResult CreateNewRoomDetails(RoomDetails rd)
		{
			_context.RoomDetails.Add(rd);
			_context.SaveChanges();
			return RedirectToAction("RoomDetails");
		}

		public IActionResult DeleteRoomDetails(int id)
		{
			var deletedRoomDetails = _context.RoomDetails.SingleOrDefault(x => x.RDID.Equals(id));
			if (deletedRoomDetails != null)
			{
				_context.RoomDetails.Remove(deletedRoomDetails);
				_context.SaveChanges();
				TempData["Deletion"] = "Ok";
			}

			return RedirectToAction("RoomDetails");
		}

		[HttpPost]
		public IActionResult UpdateRoomDetails(RoomDetails rd)
		{
			_context.RoomDetails.Update(rd);
			_context.SaveChanges();
			return RedirectToAction("RoomDetails");
		}

		public IActionResult EditRoomDetails(int id)
		{
			var HotelNames = _context.Hotels.ToList();
			ViewBag.HotelNames = HotelNames;
			var rooms = _context.Rooms.ToList();
			ViewBag.RoomNo = rooms;

			var selectedRoomdetails = _context.RoomDetails.SingleOrDefault(x => x.RDID == id);
			return View(selectedRoomdetails);
		}
	}
}

using HotelManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using HotelManagementSystem.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace HotelManagementSystem.Controllers
{
    public class DashboardController : Controller
    {
		private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
			_context = context;
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
        public IActionResult Index()
        {
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
    }
}

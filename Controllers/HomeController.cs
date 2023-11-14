using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelManagementSystem.Controllers
{
    public class HomeController : Controller
    {
       /* private readonly ILogger<HomeController> _logger;*/
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Hotel = _context.Hotels.ToList();
            return View(Hotel);
        }

        [HttpPost]
        public IActionResult Index(string HotelCity)
        {
            var selectedHotels = _context.Hotels.Where(x=>x.HotelCity.Contains(HotelCity));

            return View(selectedHotels.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateNewRecord(Hotels Hotels) 
        {
            if(ModelState.IsValid)
            {
                _context.Hotels.Add(Hotels);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            var h = _context.Hotels.ToList();
            return View("Index",h);
            
        }

        [HttpPost]
        public IActionResult UpdateRecord(Hotels Hotels) 
        {
            _context.Hotels.Update(Hotels);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteHotel(int id)
        {
            var deletedhotel = _context.Hotels.SingleOrDefault(x => x.HotelID == id);
            _context.Hotels.Remove(deletedhotel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult EditHotel(int id)
        {
            var selectedHotel = _context.Hotels.SingleOrDefault(x=> x.HotelID == id);
            return View(selectedHotel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
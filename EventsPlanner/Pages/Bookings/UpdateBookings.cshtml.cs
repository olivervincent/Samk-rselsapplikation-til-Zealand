using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventsPlanner.Models;
using EventsPlanner.Services.Interface;
using System.Linq;

namespace EventsPlanner.Pages.Bookings
{
    public class UpdateBookingsModel : PageModel
    {
        [BindProperty]
        public Booking Booking { get; set; }
        private readonly IBookingService _service;

        public UpdateBookingsModel(IBookingService service)
        {
            _service = service;
        }

        public void OnGet(int id)
        {
            Booking = _service.GetBookings().FirstOrDefault(b => b.BookingId == id);

            if (Booking == null)
            {
                RedirectToPage("/Bookings/GetBookings");
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.UpdateBooking(Booking);

            return RedirectToPage("/Bookings/GetBookings");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventsPlanner.Models;
using EventsPlanner.Services.Interface;
using System.Linq;
using System.Collections.Generic;

namespace EventsPlanner.Pages.Bookings
{
    public class UpdateBookingsModel : PageModel
    {
        [BindProperty]
        public Booking Booking { get; set; }
        [BindProperty]
        public IEnumerable<Stand> Stands { get; set; }
        [BindProperty]
        public List<Guest> Guests { get; set; }
        [BindProperty(SupportsGet = true)]
        public int StandNo { get; set; }
        [BindProperty(SupportsGet = true)]
        public int GuestNo { get; set; }
        private readonly IBookingService _service;
        private readonly IStandService _sService;
        private readonly IGuestService _guestService;

        public UpdateBookingsModel(IBookingService service, IStandService SService, IGuestService guestService )
        {
            _service = service;
            _sService = SService;
            _guestService = guestService;
        }

        public void OnGet(int id)
        {
            Booking = _service.GetBookings().FirstOrDefault(b => b.BookingId == id);
            int x = Booking.EventNo;
            Stands = _sService.GetStandsPerEvent(x);
            Guests = _guestService.GetGuests().ToList();
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
            Booking.StandNo = StandNo;
            Booking.GuestNo = GuestNo;
            _service.UpdateBooking(Booking);

            return RedirectToPage("/Bookings/GetBookings");
        }
    }
}

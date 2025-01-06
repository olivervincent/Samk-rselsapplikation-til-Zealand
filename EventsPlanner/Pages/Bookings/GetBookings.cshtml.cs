using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsPlanner.EventdbContext;
using EventsPlanner.Models;
using EventsPlanner.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventsPlanner
{
    public class GetBookingsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public DateTime? DateFrom{ get; set; }
        [BindProperty(SupportsGet = true)]
        public DateTime? DateTo{ get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
        public int Count {
            get
            {
                return Bookings.Count();
            } 
        }

        IBookingService bService;
        public GetBookingsModel(IBookingService service)
        {
            bService = service;
        }
        public void OnGet()
        {      
            if (DateFrom.HasValue && DateTo.HasValue)
            {
                Bookings = bService.FilterBookingsByDate(DateFrom.Value, DateTo.Value);
            }
            else
                Bookings = bService.GetBookings();           
        }
        public void OnGetGuestBookings(int id)
        {
            Bookings = bService.GetBookingsPerGuest(id);
        }
        public void OnGetBookingsPerEventPerStand(int id1, int id2)
        {

            Bookings = bService.GetBookingsPerEventPerStand(id1, id2);
        }
        public IActionResult OnPost(int bookingId)
        {
            bService.DeleteBooking(bookingId);


            return RedirectToPage();
        }
    }
}
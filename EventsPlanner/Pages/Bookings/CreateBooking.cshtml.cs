using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EventsPlanner.Models;
using EventsPlanner.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventsPlanner;

public class CreateBookingModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public DateTime? DateFrom { get; set; }
    [BindProperty(SupportsGet = true)]
    public DateTime? DateTo { get; set; }
    [BindProperty]
    public Booking Booking { get; set; }
    [BindProperty]
    public List<Event> Events { get; set; }
    [BindProperty]
    public List<Guest> Guests { get; set; }
    [BindProperty]
    public List<Stand> Stands { get; set; }
    [BindProperty(SupportsGet = true)]
    public int StandNo { get; set; }
    [BindProperty(SupportsGet = true)]
    public int GuestNo { get; set; }
    [BindProperty(SupportsGet = true)]
    public int EventNo { get; set; }

    IBookingService bService;
    IEventService eService;
    IStandService sService;
    IGuestService gService;
    public CreateBookingModel(IBookingService service,
        IEventService EService,
        IStandService SService,
        IGuestService GService)
    {
        bService = service;
        eService = EService;
        sService = SService;
        gService = GService;
    }
    public IActionResult OnGet(int id)
    {
        EventNo = id;
        Guests = gService.GetGuests().ToList();
        Stands = sService.GetStands().Where(x => x.EventNo == id).ToList();
        Events = eService.GetEvents().ToList();
        return Page();
    }

    public IActionResult OnPost()
    {

        if (!ModelState.IsValid)
        {
            return Page();
        }
        Booking.StandNo = StandNo;
        Booking.GuestNo = GuestNo;
        
       
        bService.CreateBooking(Booking);
       return  RedirectToPage("/Bookings/GetBookings");
    }
}
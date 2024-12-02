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
    public DateTime? DateFrom{ get; set; }
    [BindProperty(SupportsGet = true)]
    public DateTime? DateTo{ get; set; }
    [BindProperty]
    public Booking Booking { get; set; }
    [BindProperty]
    public List<Event> Events { get; set; }
    [BindProperty]
    public List<Guest> Guests { get; set; }
    [BindProperty]
    public List<Stand> Stands { get; set; }
    [BindProperty]
    public int StandsNo { get; set; }
    [BindProperty]
    public int GuestsNo { get; set; }
    
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
        Guests = gService.GetGuests().ToList();
        Stands = sService.GetStands().Where(x => x.EventNo == id).ToList();
        Events = eService.GetEvents().ToList();
        return Page();
    }

    public void OnPost()
    {
        // Log the values of StandsNo and GuestsNo
        Console.WriteLine($"StandsNo: {StandsNo}, GuestsNo: {GuestsNo}");

        // Ensure the values exist in the respective tables
        if (!sService.GetStands().Any(s => s.StandNo == StandsNo))
        {
            Console.WriteLine("Stand does not exist");
        }

        if (!gService.GetGuests().Any(g => g.GuestNo == GuestsNo))
        {
            Console.WriteLine("Guest does not exist");
        }

        Booking.StandNo = StandsNo;
        Booking.GuestNo = GuestsNo;
        Booking.Stand = sService.GetStands().FirstOrDefault(s => s.StandNo == StandsNo);
        Booking.GuestNoNavigation = gService.GetGuests().FirstOrDefault(g => g.GuestNo == GuestsNo);
        bService.CreateBooking(Booking);
        RedirectToPage("/Bookings/GetBookings");
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EventsPlanner.Models;
using EventsPlanner.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventsPlanner;

public class CreateStandsModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public int EventNo { get; set; }

    [BindProperty(SupportsGet = true)]
    public Stand Stand { get; set; }

    [BindProperty]
    public List<Event> Events { get; set; }

    IEventService eService;


    IStandService sService;
    public CreateStandsModel(IStandService SService, IEventService EService)
    {
        eService = EService;
        sService = SService;
    }
    public IActionResult OnGet()
    {
        Events = eService.GetEvents().ToList();
        return Page();
    }

    public IActionResult OnPost()
    {
        Stand.EventNo = EventNo;
        sService.CreateStand(Stand);
        return RedirectToPage("/Stands/GetStands");
    }
}
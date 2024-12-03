using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EventsPlanner.Models;
using EventsPlanner.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventsPlanner;

public class CreateGuestsModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public Guest Guest { get; set; }
    
    IGuestService gService;
    public CreateGuestsModel(IGuestService GService)
    {
        gService = GService;
    }
    public IActionResult OnGet()
    {
        return Page();
    }

    public IActionResult OnPost()
    {
        gService.CreateGuest(Guest);
        return RedirectToPage("/Guests/GetGuests");
    }
}
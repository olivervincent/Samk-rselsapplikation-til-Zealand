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
    public class GetGuestsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria{ get;set;}
        public IEnumerable<Guest> Guests { get; set; }

        IGuestService context;
        public GetGuestsModel(IGuestService service)
        {
            context = service;
        }
        public void OnGet()
        {
            if (!String.IsNullOrEmpty(FilterCriteria))
            {
                Guests = context.GetGuests().Where(g => g.Address.Contains(FilterCriteria));
            }
            else
                 Guests = context.GetGuests();
        }
    }
}
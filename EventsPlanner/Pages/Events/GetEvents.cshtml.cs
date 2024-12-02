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
    public class GetEventsModel : PageModel
    {
        public IEnumerable<Event> Events { get; set; }
        [BindProperty(SupportsGet =true)]
        public string FilterCriteria { get; set; }
     
        IEventService hService;
        public GetEventsModel(IEventService service)
        {
            hService = service;
        }
        public void OnGet()
        {
            if ( !String.IsNullOrEmpty(FilterCriteria))
            {
                Events = hService.FilterEventsByCity(FilterCriteria);
            }
            else
                Events = hService.GetEvents();
            
        }
    }
}
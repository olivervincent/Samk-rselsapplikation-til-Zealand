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
    public class GetStandsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
       public Stand Stand { get; set; }
        public IEnumerable<Stand> Stands { get; set; }
        public int Count { get { return Stands.Count(); } }


        IStandService rService;
        public GetStandsModel(IStandService service)
        {
            rService = service;
        }
        public void OnGet()
        {
            if (Stand.Price > 0 || !String.IsNullOrEmpty(Stand.Types))
            {
                Stands = rService.GetStands(Stand.Price, Stand.Types);
            }
            else
                Stands = rService.GetStands();
        }

        public IActionResult OnPost(int standNo, int eventNo)
        {
            rService.DeleteStand(standNo, eventNo);
           
            return RedirectToPage();           
        }

        public void OnGetEventStands(int id)
        {
            Stands = rService.GetStandsPerEvent(id);          
        }
    }
}
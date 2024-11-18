using EventsPlanner.EventdbContext;
using EventsPlanner.Models;
using EventsPlanner.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlanner.Services.EFService
{
    public class EFGuestService:IGuestService
    {
        private EventdbContext.EventdbContext context;
        public EFGuestService(EventdbContext.EventdbContext service)
        {
            context = service;
        }
        public IEnumerable<Guest> GetGuests()
        {
            return context.Guests;
        }
    }
}

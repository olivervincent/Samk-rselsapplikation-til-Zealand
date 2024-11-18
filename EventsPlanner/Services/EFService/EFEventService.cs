using EventsPlanner.EventdbContext;
using EventsPlanner.Models;
using EventsPlanner.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlanner.Services.EFService
{
    public class EFEventService:IEventService
    {
        private  EventdbContext.EventdbContext  context;
        public EFEventService(EventdbContext.EventdbContext service)
        {
            context = service;
        }
        public IEnumerable<Event> GetEvents()
        {
            return context.Events;
        }
        public IEnumerable<Event> FilterEventsByCity(string filter)
        {
            return context.Events.Where(h => h.Address.Contains(filter));
        }
    }
}

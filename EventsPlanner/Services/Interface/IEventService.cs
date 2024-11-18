using EventsPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlanner.Services.Interface
{
  public   interface IEventService
    {
        public IEnumerable<Event> GetEvents();
        public IEnumerable<Event> FilterEventsByCity( string filter);
    }
}

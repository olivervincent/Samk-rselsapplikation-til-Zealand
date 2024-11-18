using EventsPlanner.EventdbContext;
using EventsPlanner.Models;
using EventsPlanner.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlanner.Services.EFService
{
    public class EFStandService : IStandService
    {
        private EventdbContext.EventdbContext context;
        public EFStandService(EventdbContext.EventdbContext service)
        {
            context = service;
        }

        public IEnumerable<Stand> GetStands()
        {
            return context.Stands;
        }
        public IEnumerable<Booking> GetBookingByStandByEvent(int id1, int id2)
        {
            Stand room = context.Stands
            .Include(b => b.Bookings)
            .AsNoTracking()
            .FirstOrDefault(m => m.StandNo == id2 && m.EventNo == id1);

            var Bookings = from booking in room.Bookings
                           select booking;
            return Bookings;
        }
        public IEnumerable<Stand> GetStandsPerEvent(int id)
        {
            return context.Stands.Where(r => r.EventNo == id);
        }
        public IEnumerable<Stand> GetStands(double price, string types)
        {
            if(price>0 && types==null)
            return context.Stands.Where(r => r.Price<=price);
            else if(price==0 && types!=null)
                return context.Stands.Where(r => r.Types==types);
            else
                return context.Stands.Where(r => r.Price <= price && r.Types==types);
        }
    }
}

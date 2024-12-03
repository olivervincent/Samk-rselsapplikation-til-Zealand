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

        public void CreateGuest(Guest guest)
        {
            guest.GuestNo = context.Guests.Max(g => g.GuestNo) + 1;

            context.Guests.Add(guest);
            context.SaveChanges();

        }

        public void UpdateGuest(Guest guest)
        {
            context.Guests.Update(guest);
            context.SaveChanges();
        }

        public void DeleteGuest(int id)
        {
            var guest = context.Guests.Find(id);
            context.Guests.Remove(guest);
            context.SaveChanges();
        }
    }
}

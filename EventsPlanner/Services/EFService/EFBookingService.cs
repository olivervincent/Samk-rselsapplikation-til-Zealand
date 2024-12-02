using EventsPlanner.EventdbContext;
using EventsPlanner.Models;
using EventsPlanner.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlanner.Services.EFService
{
    public class EFBookingService:IBookingService
    {
        private EventdbContext.EventdbContext context;
        public EFBookingService(EventdbContext.EventdbContext service)
        {
            context = service;
        }
        public IEnumerable<Booking> GetBookings()
        {
            return context.Bookings;
        }
        public IEnumerable<Booking> FilterBookingsByDate(DateTime dateFrom, DateTime dateTo )
        {
            return context.Bookings.Where(b => b.DateFrom <= dateFrom && b.DateTo >= dateTo);
        }
        public IEnumerable<Booking> GetBookingsPerGuest(int id)
        {
           return  context.Bookings.Where(b => b.GuestNo == id);
        }
        public IEnumerable<Booking> GetBookingsPerEventPerStand(int hid, int rid)
        {
            return context.Bookings.Where(b=>b.EventNo==hid && b.StandNo==rid);          
        }
        public void CreateBooking(Booking booking)
        {
            using (var context = new EventdbContext.EventdbContext())
            {
                // Check if the GuestNo exists in the Guest table
                var guestExists = context.Guests.Any(g => g.GuestNo == booking.GuestNo);
                if (!guestExists)
                {
                    throw new ArgumentException($"The specified GuestNo does not exist. {booking.GuestNo}");
                }

                // Insert the booking into the database
                context.Bookings.Add(booking);
                context.SaveChanges();
            }
        }
    }
}


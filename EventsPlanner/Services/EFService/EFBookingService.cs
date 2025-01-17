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
        public IEnumerable<Booking> FilterBookingsByDate(DateTime dateFrom, DateTime dateTo)
        {
            return context.Bookings.Where(b => b.DateFrom < dateTo && b.DateTo > dateFrom);
        }
        public IEnumerable<Booking> GetBookingsPerGuest(int id)
        {
           return  context.Bookings.Where(b => b.GuestNo == id);
        }
        public IEnumerable<Booking> GetBookingsPerEventPerStand(int hid, int rid)
        {
            return context.Bookings.Where(b=>b.EventNo==hid && b.StandNo==rid);          
        }
        public Booking GetBookingById(int id)
        {
            return context.Bookings.Find(id);
        }
        public void CreateBooking(Booking booking)
        {
            using (var context = new EventdbContext.EventdbContext())
            {
                
                var guestExists = context.Guests.Any(g => g.GuestNo == booking.GuestNo);
                if (!guestExists)
                {
                    throw new ArgumentException($"The specified GuestNo does not exist. {booking.GuestNo}");
                }
                
               
                context.Bookings.Add(booking);
                context.SaveChanges();
            }
        }
        public void DeleteBooking(int bid)
        {
            using (var context = new EventdbContext.EventdbContext())
            {
                var booking = context.Bookings.Find(bid);
                if (booking != null)
                {
                    context.Bookings.Remove(booking);
                    context.SaveChanges();
                }
            }
        }
        public void UpdateBooking(Booking booking)
        {
            using (var context = new EventdbContext.EventdbContext())
            {
                var bookingToUpdate = context.Bookings.Find(booking.BookingId);
                if (bookingToUpdate != null)
                {
                    bookingToUpdate.DateFrom = booking.DateFrom;
                    bookingToUpdate.DateTo = booking.DateTo;
                    bookingToUpdate.EventNo = booking.EventNo;
                    bookingToUpdate.GuestNo = booking.GuestNo;
                    bookingToUpdate.StandNo = booking.StandNo;
                    context.SaveChanges();
                }
            }
        }
    }
}


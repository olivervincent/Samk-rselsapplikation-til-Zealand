using EventsPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlanner.Services.Interface
{
   public  interface IBookingService
    {
        public IEnumerable<Booking> GetBookings();
        public IEnumerable<Booking> FilterBookingsByDate(DateTime dateFrom, DateTime dateTo);
        public IEnumerable<Booking> GetBookingsPerGuest(int gid);
        public IEnumerable<Booking> GetBookingsPerEventPerStand(int hid, int rid);
    }
}

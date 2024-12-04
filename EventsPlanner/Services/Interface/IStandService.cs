using EventsPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlanner.Services.Interface
{
  public  interface IStandService
    {
        public IEnumerable<Stand> GetStands();
        IEnumerable<Booking> GetBookingByStandByEvent(int id1, int id2);
        IEnumerable<Stand> GetStandsPerEvent(int id1);
       IEnumerable<Stand>  GetStands(double Price , string Types);

        public void CreateStand(Stand stand);
        public void UpdateStand(Stand stand);
        public void DeleteStand(int id, int id2);
    }
}

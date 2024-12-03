using EventsPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlanner.Services.Interface
{
    public interface IGuestService
    {
        public IEnumerable<Guest> GetGuests();

        public void CreateGuest(Guest guest);
        public void UpdateGuest(Guest guest);
        public void DeleteGuest(int id);

    }

   
}

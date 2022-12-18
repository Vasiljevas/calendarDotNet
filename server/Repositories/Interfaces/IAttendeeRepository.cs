using System;
using System.Collections.Generic;
using CalendarApi.Models;

namespace CalendarApi.Repositories.Interfaces
{
  public interface IAttendeeRepository
  {
    
    public IEnumerable<Attendee> GetAttendees();
    public void CreateAttendee(Attendee attendee);

  }
}
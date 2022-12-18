using System;
using CalendarApi.Models;
using CalendarApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using CalendarApi.Data;


namespace CalendarApi.Repositories
{
  public class UserRepository : IUserRepository
  {
    CalendarDbContext _context;
    public UserRepository(CalendarDbContext context)
    {
      _context = context;
    }

    public bool AddUser(User user)
    {
      _context.Users.Add(user);
      _context.SaveChanges();

      return true;
    }

    public bool DeleteUser(Guid id)
    {
      User userToDelete = _context.Users.ToList<User>().First(e => e.Id == id);
      _context.Users.Remove(userToDelete);
      _context.SaveChanges();
      return true;
    }
    public User UpdateUser(User user)
    {
      _context.Users.Update(user);
      _context.SaveChanges();
      return user;
    }
    public User GetUserById(Guid id)
    {
      return _context.Users.Include(u => u.Events).ToList().First(u => u.Id == id);
    }

    public IEnumerable<User> GetUsers() => _context.Users.ToList();

    public IEnumerable<Event> GetEventsByUserId(Guid id)
    {
      var user = _context.Users.Include(u => u.Events).ToList().First(u => u.Id == id);
      return user.Events;
    }

    public User GetUserByEventId(Guid eventId)
    {
      var user = _context.Users.Include(u => u.Events).ToList().First(u => u.Events.Any(e => e.Id == eventId));
      return user;
    }
  }
}
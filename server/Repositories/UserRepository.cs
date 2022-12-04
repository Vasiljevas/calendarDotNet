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

    public bool DeleteUser(User user)
    {
      throw new NotImplementedException();
    }

    public User GetUserById(Guid id)
    {
      return _context.Users.ToList().First(u => u.Id == id);
    }

    public IEnumerable<User> GetUsers() => _context.Users.ToList();
  }
}
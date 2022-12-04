using System;
using System.Collections.Generic;
using CalendarApi.Models;

namespace CalendarApi.Repositories.Interfaces
{
  public interface IUserRepository
  {
    public IEnumerable<User> GetUsers();
    public User GetUserById(Guid id);
    public bool AddUser(User user);
  }
}
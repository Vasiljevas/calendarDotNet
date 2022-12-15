using System;
using CalendarApi.Models;

namespace CalendarApi.Services.Interfaces
{
  public interface IUserService
  {
    IEnumerable<User> GetUsers();
    User GetUserById(Guid id);
    User CreateUser(User user);
    User DeleteUser(Guid id);
    User UpdateUser(User user);
  }
}
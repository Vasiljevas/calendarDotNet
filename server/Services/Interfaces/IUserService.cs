using System;
using CalendarApi.Models;

namespace CalendarApi.Services.Interfaces
{
  public interface IUserService
  {
    IEnumerable<User> GetUsers();
    User GetUserById(Guid id);
    Task<User> CreateUser();
    Task<User> DeleteUser();
    Task<User> UpdateUser();
  }
}
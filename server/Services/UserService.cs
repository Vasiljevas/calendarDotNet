using System;
using CalendarApi.Models;
using CalendarApi.Services.Interfaces;
using CalendarApi.Repositories.Interfaces;

namespace CalendarApi.Services
{
  public class UserService : IUserService
  {

    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository repository)
    {
      this._userRepository = repository;
    }

    public User CreateUser(User user)
    {
      _userRepository.AddUser(user);
      return _userRepository.GetUserById(user.Id);
    }

    public User DeleteUser(Guid id)
    {
      User deletedUser = _userRepository.GetUserById(id);
      _userRepository.DeleteUser(id);
      return deletedUser;
    }

    public User UpdateUser(User user)
    {
      User updatedUser = _userRepository.UpdateUser(user);
      return updatedUser;
    }

    public User GetUserById(Guid id)
    {
      return _userRepository.GetUserById(id);
    }

    public IEnumerable<User> GetUsers()
    {
      return _userRepository.GetUsers();
    }

  }
}
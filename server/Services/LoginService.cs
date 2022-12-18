using System;
using System.Collections.Generic;
using CalendarApi.Services.Interfaces;
using CalendarApi.Models;
using CalendarApi.Repositories.Interfaces;

namespace CalendarApi.Services
{
  public class LoginService : ILoginService
  {
    private readonly IHashPasswordService _hashPasswordService;
    private readonly IUserRepository _userRepository;

    public LoginService(IHashPasswordService hashPasswordService, IUserRepository userRepository)
    {
      _hashPasswordService = hashPasswordService;
      _userRepository = userRepository;
    }

    public bool CheckUserLoginInformation(User tryUser, User loginUser)
    {
      if (!String.IsNullOrEmpty(loginUser.Email) && _hashPasswordService.ValidatePassword(_hashPasswordService.SaltPasswordHardcoded(tryUser.Password), loginUser.Password))
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public void AddUser(User user)
    {
      _userRepository.AddUser(user);
    }

    public IEnumerable<User> GetUsers()
    {
      return _userRepository.GetUsers();
    }
  }
}
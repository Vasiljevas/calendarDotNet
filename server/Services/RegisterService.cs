using System;
using CalendarApi.Services.Interfaces;
using CalendarApi.Models;
using System.Text.RegularExpressions;
using System.Data;

namespace CalendarApi.Services
{
  public class RegisterService : IRegisterService
  {
    private readonly IHashPasswordService _hashPasswordService;
    private readonly ILoginService _loginService;

    public RegisterService(ILoginService loginService, IHashPasswordService hashPasswordService)
    {
      _loginService = loginService;
      _hashPasswordService = hashPasswordService;
    }

    public void RegisterUser(User user)
    {
      string email = user.Email;
      Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
      Match match = regex.Match(email);
      if (!match.Success)
      {
        throw new Exception();
      }

      IEnumerable<User> users = _loginService.GetUsers();
      if (users.Any(u => u.Email == user.Email))
      {
        throw new DuplicateNameException();
      }

      string hashedPassword = _hashPasswordService.PasswordHash(_hashPasswordService.SaltPasswordHardcoded(user.Password));
      user.Password = hashedPassword;

      _loginService.AddUser(user);
    }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CalendarApi.Repositories.Interfaces;
using CalendarApi.Services.Interfaces;
using CalendarApi.Models;

namespace CalendarApi.Controllers
{
  [ApiController]
  [Route("api/login")]
  public class LoginController : ControllerBase
  {
    private readonly IUserRepository _userRepository;
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService, IUserRepository userRepo)
    {
      _loginService = loginService;
      _userRepository = userRepo;
    }

    [HttpPost]
    [Route("check")]
    public ActionResult<User> VerifyUser(User user)
    {
      try
      {
        IEnumerable<User> users = _loginService.GetUsers();
        User goodUser = users.Single(u => u.Email == user.Email);

        if (goodUser == null)
        {
          throw new KeyNotFoundException();
        }

        if (_loginService.CheckUserLoginInformation(user, goodUser))
        {
          return Ok(goodUser);
        }
        throw new System.Exception();
      }
      catch (KeyNotFoundException)
      {
        return NotFound("No existing user");
      }
      catch (Exception)
      {
        return NotFound("Bad username or password");
      }
    }

    [HttpGet]
    [Route("users")]
    public ActionResult<List<User>> GetUsers()
    {
      return Ok(_userRepository.GetUsers());
    }
  }
}
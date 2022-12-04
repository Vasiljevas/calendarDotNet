using System;
using Microsoft.AspNetCore.Mvc;
using CalendarApi.Models;
using CalendarApi.Services.Interfaces;
using System.Data;

namespace CalendarApi.Controllers
{
  [ApiController]
  [Route("api/register")]
  public class RegisterController : ControllerBase
  {
    private readonly IRegisterService _registerService;
    private readonly ILoginService _loginService;

    public RegisterController(IRegisterService registerService, ILoginService loginService)
    {
      _loginService = loginService;
      _registerService = registerService;
    }

    [HttpPost]
    [Route("add")]
    public ActionResult<User> RegisterUser(User user)
    {
      User newUser = new User(Guid.NewGuid(), user.Name, user.Email, user.Password, null, null, user.Role);
      try
      {
        if (newUser == null)
        {
          throw new Exception();
        }
        _registerService.RegisterUser(newUser);
        return Ok(newUser);
      }
      catch (DuplicateNameException)
      {
        return Problem("User email already in use!");
      }
      catch (Exception)
      {
        return Problem("Registration failed");
      }
    }
  }
}
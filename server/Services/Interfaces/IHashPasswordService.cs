using System.Collections.Generic;
using CalendarApi.Models;

namespace CalendarApi.Services.Interfaces
{
  public interface IHashPasswordService
  {
    string GetRandomSalt();
    string PasswordHash(string password);
    bool ValidatePassword(string password, string correctHash);
    string SaltPasswordHardcoded(string password);
  }
}
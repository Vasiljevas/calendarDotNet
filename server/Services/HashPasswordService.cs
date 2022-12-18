using System;
using System.Collections.Generic;
using CalendarApi.Services.Interfaces;
using DevOne.Security.Cryptography.BCrypt;

namespace CalendarApi.Services
{
  public class HashPasswordService : IHashPasswordService
  {
    public string GetRandomSalt()
    {
      return BCryptHelper.GenerateSalt(11);
    }
    public string PasswordHash(string password)
    {
      return BCryptHelper.HashPassword(password, GetRandomSalt());
    }

    public bool ValidatePassword(string password, string correctHash)
    {
      return BCryptHelper.CheckPassword(password, correctHash);
    }
    public string SaltPasswordHardcoded(string password)
    {
      return password + "SF!@%Dwq%@~";
    }
  }
}
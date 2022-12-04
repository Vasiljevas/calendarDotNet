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

        public Task<User> CreateUser()
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteUser()
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser()
        {
            throw new NotImplementedException();
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
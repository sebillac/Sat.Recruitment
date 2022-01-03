using Sat.Recruitment.Entities;
using System;
using System.Threading.Tasks;

namespace Sat.Recruitment.Services
{
    public interface IUserService
    {
        public Task<User> CreateAsync(User user);
        public Task<User> GetUserByIdAsync(int id);
    }
}

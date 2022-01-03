using Sat.Recruitment.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Repository.Interfaces
{
    public interface IUserRepository
    {
        public IList<User> GetList();
        public Task<User> AddAsync(User user);
    }
}

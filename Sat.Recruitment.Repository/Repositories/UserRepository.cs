using Sat.Recruitment.Api.Helpers;
using Sat.Recruitment.Entities;
using Sat.Recruitment.Repository.Interfaces;
using Sat.Recruitment.Repository.Mappers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Repository
{
    public class UserRepository : IUserRepository
    {
        List<User> _listUsers;

        public UserRepository()
        {
            CreateListUsers();
        }

        private void CreateListUsers()
        {
            FileHelper helper = new FileHelper();
            _listUsers = new List<User>();

            StreamReader reader = helper.ReadDataFromFile("Users");

            using (reader)
            {
                while (reader.Peek() >= 0)
                {
                    User user = UserMapper.StringToUser(reader.ReadLineAsync().Result);
                    _listUsers.Add(user);
                }
            }
        }

        public Task<User> AddAsync(User user)
        {
            User userAux = _listUsers.FirstOrDefault(x => x.Email == user.Email && x.Phone == user.Phone);

            if (userAux == null)
            {
                int newId = _listUsers.Max(x => x.Id);
                user.Id = newId + 1;

                _listUsers.Add(user);
                return Task.Run(() => user);
            }
            else
            {
                throw new Exception("The user is duplicated");
            }
        }

        public IList<User> GetList()
        {
            return _listUsers;
        }
    }
}

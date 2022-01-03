using Sat.Recruitment.Api.Helpers;
using Sat.Recruitment.Entities;
using Sat.Recruitment.Repository.Interfaces;
using Sat.Recruitment.Repository.Mappers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Repository.Repositories
{
    public class UserTypeRepository : IUserTypeRepository
    {

        List<UserType> _listUserTypes;
        public UserTypeRepository()
        {
            CreateListUserTypes();
        }

        private void CreateListUserTypes()
        {
            FileHelper helper = new FileHelper();
            _listUserTypes = new List<UserType>();

            StreamReader reader = helper.ReadDataFromFile("UserTypes");

            while (reader.Peek() >= 0)
            {
                UserType userType = UserTypeMapper.StringToUserType(reader.ReadLineAsync().Result);

                _listUserTypes.Add(userType);
            }
        }

        public IList<UserType> GetList()
        {
            return _listUserTypes;
        }
    }
}

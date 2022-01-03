using Sat.Recruitment.Entities;
using Sat.Recruitment.Repository.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Repository.Mappers
{
    public static class UserMapper
    {
        public static User StringToUser(string line)
        {
            return new User
            {
                Id = int.Parse(line.Split(',')[0]),
                Name = line.Split(',')[1],
                Email = line.Split(',')[2],
                Phone = line.Split(',')[3],
                Address = line.Split(',')[4],
                UserType = line.Split(',')[5],
                Money = decimal.Parse(line.Split(',')[6], CultureHelper.GetNumberFormat()),
            };
        }
    }
}

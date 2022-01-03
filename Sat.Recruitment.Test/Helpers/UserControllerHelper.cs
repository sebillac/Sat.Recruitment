using Moq;
using Sat.Recruitment.Business;
using Sat.Recruitment.Entities;
using Sat.Recruitment.Repository.Interfaces;
using Sat.Recruitment.Repository.Mappers;
using Sat.Recruitment.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Test.Helpers
{
   public static class UserControllerHelper
    {
        public static Mock<IUserService> GetUserServiceMock()
        {
            var mockRepo = new Mock<IUserService>();

            mockRepo.Setup(repo => repo.CreateAsync(GetUser()))
                .ReturnsAsync(GetUser());

            mockRepo.Setup(repo => repo.GetUserByIdAsync(5))
                .ReturnsAsync(GetUser());

            return mockRepo;
        }

        public static Mock<IUserRepository> GetUserRepositoryMock()
        {
            var mockRepo = new Mock<IUserRepository>();

            mockRepo.Setup(repo => repo.GetList())
                .Returns(CreateListUserMock());

            mockRepo.Setup(repo => repo.AddAsync(GetUser()))
                .ReturnsAsync(GetUser());

            return mockRepo;
        }

        private static User GetUser()
        {
            return new User
            {
                Id = 5,
                Address = "Av. Juan G",
                Email = "mike@gmail.com",
                Money = 124,
                Name = "Mike",
                Phone = "+349 1122354215",
                UserType = "Normal"
            };
        }
        public static Mock<IUserTypeRepository> GetUserTypeRepositoryMock()
        {
            var mockRepo = new Mock<IUserTypeRepository>();

            mockRepo.Setup(repo => repo.GetList())
                .Returns(CreateListUserTypeMock());

            return mockRepo;
        }

        private static List<User> CreateListUserMock()
        {
            List<User> list = new List<User>();

            list.Add(UserMapper.StringToUser("1,Juan,Juan @marmol.com,+5491154762312,Peru 2464,Normal,1234"));
            list.Add(UserMapper.StringToUser("2,Franco,Franco.Perez @gmail.com,+534645213542,Alvear y Colombres,Premium,112234"));
            list.Add(UserMapper.StringToUser("3,Agustina,Agustina @gmail.com,+534645213542,Garay y Otra Calle, SuperUser,112234"));

            return list;
        }
        private static List<UserType> CreateListUserTypeMock()
        {
            List<UserType> list = new List<UserType>();

            list.Add(UserTypeMapper.StringToUserType("Normal,0.8,10,101"));
            list.Add(UserTypeMapper.StringToUserType("Normal,0.12,102"));
            list.Add(UserTypeMapper.StringToUserType("SuperUser,0.2,100"));
            list.Add(UserTypeMapper.StringToUserType("Premium,2,100"));

            return list;
        }

    }
}

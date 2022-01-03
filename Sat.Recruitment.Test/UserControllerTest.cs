using System;
using System.Collections.Generic;
using System.Dynamic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Business;
using Sat.Recruitment.Entities;
using Sat.Recruitment.Repository;
using Sat.Recruitment.Repository.Interfaces;
using Sat.Recruitment.Repository.Repositories;
using Sat.Recruitment.Services;
using Sat.Recruitment.Test.Helpers;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserControllerTest
    {

        [Fact]
        public async void Create_User_OK()
        {
            //Me faltó implementar mejor el repository del User. Pero estoy muy complicado de tiempos

            var logger = new Mock<ILogger<UserController>>();
            var userRepository = new UserRepository();
            var userBusiness = new UserBusiness(userRepository, UserControllerHelper.GetUserTypeRepositoryMock().Object);
            var userController = new UserController(userBusiness, logger.Object);

            var user = new User
            {
                Address = "calle 1234",
                Email = "mike@gmail.com",
                Money = 124,
                Name = "Mike",
                Phone = "+349 1122354215",
                UserType = "Normal"
            };

            var result = await userController.CreateUser(user);
            var okResult = result as CreatedAtActionResult;

            Assert.Equal(201, okResult.StatusCode);
        }

        [Fact]
        public async void Validate_User_Duplicated()
        {
            var logger = new Mock<ILogger<UserController>>();
            var userRepository = new UserRepository();
            var userBusiness = new UserBusiness(userRepository, UserControllerHelper.GetUserTypeRepositoryMock().Object);
            var userController = new UserController(userBusiness, logger.Object);

            var user = new User
            {
                Address = "Av. Juan G",
                Email = "Agustina@gmail.com",
                Money = 124,
                Name = "Agustina",
                Phone = "+534645213542",
                UserType = "SuperUser"
            };

            var result = await userController.CreateUser(user);
            var okResult = result as BadRequestResult;

            Assert.Equal(400, okResult.StatusCode);
        }
    }
}

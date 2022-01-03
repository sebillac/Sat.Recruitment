using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Moq;
using Sat.Recruitment.Business;
using Sat.Recruitment.Entities;
using Sat.Recruitment.Repository;
using Sat.Recruitment.Repository.Interfaces;
using Sat.Recruitment.Repository.Mappers;
using Sat.Recruitment.Repository.Repositories;
using Sat.Recruitment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


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
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserTypeRepository, UserTypeRepository>();
            services.AddScoped<IUserService, UserBusiness>();
            services.AddControllers();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

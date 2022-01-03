using Sat.Recruitment.Entities;
using Sat.Recruitment.Repository.Interfaces;
using Sat.Recruitment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Business
{
    public class UserBusiness : IUserService
    {
        IUserRepository _userRepository;
        IUserTypeRepository _userTypeRepository;

        public UserBusiness(IUserRepository userRepository, IUserTypeRepository userTypeRepository)
        {
            _userRepository = userRepository;
            _userTypeRepository = userTypeRepository;
        }
        public Task<User> CreateAsync(User user)
        {
            user = CalculateGift(user);

            return _userRepository.AddAsync(user);
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            return Task.Run(()=> _userRepository.GetList().FirstOrDefault(x=> x.Id == id));
        }

        private User CalculateGift(User user)
        {
            List<UserType> userTypeList = _userTypeRepository.GetList().Where(x => x.Description == user.UserType).ToList();

            foreach (var userType in userTypeList)
            {
                if (user.Money > userType.MinimumMoney)
                    if(userType.MaximumMoney != 0)
                        if(user.Money < userType.MaximumMoney)
                            user.Money = user.Money + (user.Money * userType.Percentage);
                    else
                        user.Money = user.Money + (user.Money * userType.Percentage);
            }

            return user;
        }
    }
}

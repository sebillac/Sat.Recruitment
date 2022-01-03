using Sat.Recruitment.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Repository.Interfaces
{
    public interface IUserTypeRepository
    {
        public IList<UserType> GetList();
    }
}

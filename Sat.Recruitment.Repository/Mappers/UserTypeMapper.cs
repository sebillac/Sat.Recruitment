using Sat.Recruitment.Entities;
using Sat.Recruitment.Repository.Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Sat.Recruitment.Repository.Mappers
{
    public static class UserTypeMapper
    {
        public static UserType StringToUserType(string line)
        {
            string[] fields = line.Split(',');
            NumberFormatInfo numberFormat = CultureHelper.GetNumberFormat();

            return new UserType
            {
                Description = fields[0],
                Percentage = decimal.Parse(fields[1], numberFormat),
                MinimumMoney = decimal.Parse(fields[2], numberFormat),
                MaximumMoney = (fields.Length > 3) ? decimal.Parse(fields[3], numberFormat) : 0
            };
        }
    }
}

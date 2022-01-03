using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Entities
{
    public class UserType
    {
        public string Description { get; set; }
        public decimal Percentage { get; set; }
        public decimal MinimumMoney { get; set; }
        public decimal MaximumMoney { get; set; }
    }
}

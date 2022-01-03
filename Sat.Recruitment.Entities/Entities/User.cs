using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sat.Recruitment.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string UserType { get; set; }

        [Required]
        public decimal Money { get; set; }

        public void Validate()
        {
            var results = new StringBuilder();

            if (this.Name == null)
                results.AppendLine("The name is required");
            if (this.Email == null)
                results.AppendLine("The email is required");
            if (this.Address == null)
                results.AppendLine("The address is required");
            if (this.Phone == null)
                results.AppendLine("The phone is required");

            if (results.Length > 0)
                throw new Exception(results.ToString());
        }        
    }
}

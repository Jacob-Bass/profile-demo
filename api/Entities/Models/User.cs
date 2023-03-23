using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("user")]
    public class User
    {
        
        public Guid UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(9)]
        public string UserName { get; set; }
        [Required]
        [MinLength(10)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!@#$%^&*=_+?]).{1,}$",
         ErrorMessage = "Password must contain at least 1 uppercase letter, lowercase letter, number and special character.")]
        public string Password { get; set; }

    }
}

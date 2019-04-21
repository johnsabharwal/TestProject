using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Account
{
    public class UserBase
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid mobile")]
        public long Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }

        public virtual void validate()
        {
            throw new Exception("Not implemented");
        }
    }
    public class CreateUser : UserBase
    {
        public override void validate()
        {
            if (this.Password.Length < 6)
            {
                throw new Exception("Invalid Password");
            }
        }
    }
    public class UpdateUser:UserBase
    {
       
        public long userId { get; set; }
    }
}

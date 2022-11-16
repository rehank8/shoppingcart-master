using ShoppingCartApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartApp.Models.DTO.RegisreUser
{
    public class RegisterUserDTO
    {
        public string Id { get; set; }

        public int FKRoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string EmailId { get; set; }

        public string Address { get; set; }
        public string IPAddress { get; set; }

        public bool IsActive { get; set; }
        public bool RememberMe { get; set; }

        public bool IsSecurityQuestions { get; set; }

        public List<SecurityQuestions> SecurityQuestions { get; set; }

        public User ConvertToModel()
        {
            User user = new User();

            user.Id = Id;
            user.Username = Username;
            user.EmailId = EmailId;
            user.Address = Address;
            user.IsActive = IsActive;
            user.FKRoleId = FKRoleId;
            user.IPAddress = IPAddress;
            user.IsSecurityQuestions = IsSecurityQuestions;
            return user;
        }
    }

    public class LoginUserDTO
    {
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        public bool IsSocial { get; set; }
    }


    public class LoginSucessfulUserDTO
    {
        public string id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Image { get; set; }

        public bool IsValid { get; set; }

        public bool IsActive { get; set; }

        public string InActiveReason { get; set; }
    }

    public class LoginSucessDTO
    {

        public string Token { get; set; }
        public DateTime TokenExpiration { get; set; }
        public bool IsSecurityQuestions { get; set; }

        public List<SecurityQuestions> SecurityQuestions { get; set; }
    }
}

using ShoppingCartApp.Models.DTO.Common;
using ShoppingCartApp.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCartApp.Models.DTO.UserDTO
{
    public class UserDTO : EntityDTO<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public int FKRoleId { get; set; }

        public User ConvertToModel()
        {
            User user = new User();

            user.Id = Id;
            user.Username = Username;
            user.FKRoleId = FKRoleId;
            user.EmailId = EmailId;
            user.Address = Address;
            user.IsActive = IsActive;
            user.IsDelete = false;

            return user;
        }
    }

    public class AddUserDTO : AddEntityDto<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int FKRoleId { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }

        public User ConvertToModel()
        {
            User user = new User();

            user.Id = Guid.NewGuid().ToString();
            user.Username = Username;
            user.Password = Password;
            user.EmailId = EmailId;
            user.Address = Address;
            user.PhoneNo = PhoneNo;
            user.IsActive = IsActive;
            user.IsDelete = false;
            user.FKRoleId = FKRoleId;

            return user;
        }
    }

    // ViewModel for UpdateUsers 
    public class UpdateUserDTO : UpdateEntityDtO<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }

        public User ConvertToModel()
        {
            User user = new User();

            user.Id = Id;
            user.Username = Username;
            user.EmailId = EmailId;
            user.Address = Address;
            user.IsActive = IsActive;
            user.IsDelete = false;

            return user;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using BusinessLogic.Objects;

namespace DataAccess
{
    public class UserEntity
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }

        public static UserEntity FromDomain(User user)
        {
            UserEntity entity = new UserEntity()
            {
                Username = user.UserName,
                Password = user.Password,
                RegisterDate = user.RegisterDate,
            };
            return entity;
        }

        public static User FromEntity(UserEntity entity)
        {
            User user = new User()
            {
                UserName = entity.Username,
                Password = entity.Password,
                RegisterDate = entity.RegisterDate,
            };

            return user;
        }
    }
}

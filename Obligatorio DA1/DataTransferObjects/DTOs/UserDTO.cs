using System;

namespace DataTransferObjects.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }

        public UserDTO() { }

        public UserDTO(string username, string password, DateTime registerDate)
        {
            Username = username;
            Password = password;
            RegisterDate = registerDate;
        }
    }
}

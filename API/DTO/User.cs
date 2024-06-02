////Un-Used


using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.DTO
{
    public  class User: IdentityUser<int>
    {
        public  string? Username { get; set; }
        public  string? Token { get; set; }
        public  string? KnownAs { get; set; }
        public  string? Gender { get; set; }
        public string? Password { get; set; }
    }

    public class UserEntity
    {
       private static List<User> _users;    
       public static List<User> Users => _users;
       static UserEntity()
        {
            _users = new List<User>
            {
                new User
                {
                    Username = "user1",
                    Token = "token123",
                    KnownAs = "User One",
                    Gender = "Female",
                    Password = "Pass@123",
                },
                new User
                {
                    Username = "user2",
                    Token = "token456",
                    KnownAs = "User Two",
                    Gender = "Male",
                    Password = "Pass@123",
                },
                new User
                {
                    Username = "user3",
                    Token = "token789",
                    KnownAs = "User Three",
                    Gender = "Female",
                    Password = "Pass@123",
                }
            };
        }
    }
}
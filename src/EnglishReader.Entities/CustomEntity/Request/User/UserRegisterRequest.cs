using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishReader.Entities.CustomEntity.Request.User
{
    public class UserRegisterRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishReader.Entities.Entity
{
    public class User : Base
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public string Token { get; set; }
    }
}

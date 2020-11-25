using EnglishReader.Core.Utilities.Results;
using EnglishReader.Entities.CustomEntity.Request.User;
using EnglishReader.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishReader.Business.Abstract
{
    public interface IUserManager
    {
        IResult Register(UserRegisterRequest userRegister);
    }
}

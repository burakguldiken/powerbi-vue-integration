using EnglishReader.Business.Abstract;
using EnglishReader.Business.Constants;
using EnglishReader.Business.Enums;
using EnglishReader.Business.Validation.FluentValidation;
using EnglishReader.Core.Aspects.Transaction;
using EnglishReader.Core.Aspects.Validation;
using EnglishReader.Core.Security.Hashing;
using EnglishReader.Core.Utilities.Results;
using EnglishReader.DataAccess.Abstract;
using EnglishReader.Entities.CustomEntity.Request.User;
using EnglishReader.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishReader.Business.Concrete
{
    public class UserManager : IUserManager
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserRegisterValidation), Priority = 1)]
        [TransactionAspect]
        public IResult Register(UserRegisterRequest userRegister)
        {
            try
            {
                var userExits = _userDal.Get(x => x.Email == userRegister.Email);

                if(userExits != null)
                {
                    return new ErrorResult(Messages.UserAlreadyExists);
                }

                byte[] passwordHash, passwordSalt;
                HashHelper.CreatePasswordHash(userRegister.Password, out passwordHash, out passwordSalt);

                var user = new User()
                {
                    Email = userRegister.Email,
                    Name = userRegister.Name,
                    Surname = userRegister.Surname,
                    Phone = userRegister.Phone,
                    PasswordHash = Convert.ToBase64String(passwordHash),
                    PasswordSalt = Convert.ToBase64String(passwordSalt),
                    CreationDate = DateTime.Now,
                    StatusId = (int)EnumStatus.Active
                };

                _userDal.Add(user);

                return new SuccessResult(Messages.UserRegistered);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
    }
}

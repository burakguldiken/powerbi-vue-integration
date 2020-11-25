using EnglishReader.Core;
using EnglishReader.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using EnglishReader.Core.Context.EntityFramework;

namespace EnglishReader.DataAccess.Abstract
{
    public interface IUserDal : IRepository<User>
    {
    }
}

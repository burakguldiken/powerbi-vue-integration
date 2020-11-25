using EnglishReader.Core.Context.EntityFramework;
using EnglishReader.DataAccess.Abstract;
using EnglishReader.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EnglishReader.DataAccess.Concrete.EntityFramework.Context;

namespace EnglishReader.DataAccess.EntityFramework.Concrete
{
    public class EfUserDal : EfRepositoryBase<User, EnglishAssistantDbContext>, IUserDal
    {
       
    }
}

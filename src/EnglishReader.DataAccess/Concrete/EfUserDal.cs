using EnglishReader.Core.Context.EntityFramework;
using EnglishReader.DataAccess.Abstract;
using EnglishReader.DataAccess.Concrete.Context;
using EnglishReader.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishReader.DataAccess.Concrete
{
    public class EfUserDal : EfRepositoryBase<User, EnglishAssistantDbContext>, IUserDal
    {
       
    }
}

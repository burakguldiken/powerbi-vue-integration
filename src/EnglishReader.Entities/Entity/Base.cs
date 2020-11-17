using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishReader.Entities.Entity
{
    public class Base
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int StatusId { get; set; }
    }
}

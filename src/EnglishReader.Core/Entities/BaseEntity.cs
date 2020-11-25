using System;

namespace EnglishReader.Core.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int StatusId { get; set; }
    }
}

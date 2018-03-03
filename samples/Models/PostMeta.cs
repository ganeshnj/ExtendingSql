using ExtendSql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class PostMeta : IMeta, IEntity
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}

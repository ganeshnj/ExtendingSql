using ExtendSql;
using System.Collections.Generic;

namespace Models
{
    public class Post : IMetas<PostMeta>, IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<PostMeta> Metas { get; set; } = new List<PostMeta>();
    }
}

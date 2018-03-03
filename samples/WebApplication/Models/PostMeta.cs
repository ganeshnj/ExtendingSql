using ExtendSql;

namespace WebApplication.Models
{
    /// <summary>
    /// Meta class for Post metas
    /// </summary>
    public class PostMeta : IMeta, IEntity
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Models.PostViewModels
{
    public class EditPostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        private DateTime? _createdOn = null;
        public DateTime? CreatedOn
        {
            get
            {
                if (_createdOn == null)
                {
                    if (Metas != null)
                    {
                        DateTime.TryParse(CreatedOnMeta.Value, out DateTime createdOn);
                        _createdOn = createdOn;
                    }
                }
                return _createdOn;
            }
            set
            {
                if (_createdOn != value)
                {
                    _createdOn = value;
                }
            }
        }

        private PostMetaViewModel _createdOnMeta { get; set; }
        public PostMetaViewModel CreatedOnMeta
        {
            get
            {
                if (_createdOnMeta == null)
                {
                    if (Metas != null)
                    {
                        _createdOnMeta = Metas.FirstOrDefault(cm => cm.Key == nameof(CreatedOn));
                    }
                }

                return _createdOnMeta;
            }
            set
            {
                if (_createdOnMeta != value)
                {
                    _createdOnMeta = new PostMetaViewModel()
                    {
                        Id = value.Id,
                        PostId = value.PostId,
                        Key = nameof(CreatedOn),
                        Value = CreatedOn.ToString()
                    };
                }
            }
        }

        public List<PostMetaViewModel> Metas { get; set; }
    }
}

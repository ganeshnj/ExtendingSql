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
                    DateTime.TryParse(CreatedOnMeta.Value, out DateTime createdOn);
                    _createdOn = createdOn;
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

        private string _subtitle { get; set; }
        public string Subtitle
        {
            get
            {
                if (_subtitle == null)
                {
                    _subtitle = SubtitleMeta?.Value;
                }

                return _subtitle;
            }
            set
            {
                if (_subtitle != value)
                {
                    _subtitle = value;
                }
            }
        }

        private PostMetaViewModel _subtitleMeta { get; set; }
        public PostMetaViewModel SubtitleMeta
        {
            get
            {
                if (_subtitleMeta == null)
                {
                    if (Metas != null)
                    {
                        _subtitleMeta = Metas.FirstOrDefault(cm => cm.Key == nameof(Subtitle));
                    }
                }

                return _subtitleMeta;
            }
            set
            {
                if (_subtitleMeta != value)
                {
                    _subtitleMeta = new PostMetaViewModel()
                    {
                        Id = value.Id,
                        PostId = value.PostId,
                        Key = nameof(Subtitle),
                        Value = Subtitle
                    };
                }
            }
        }

        public List<PostMetaViewModel> Metas { get; set; }
    }
}

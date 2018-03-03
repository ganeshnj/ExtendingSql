using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Models.PostViewModels
{
    public class PostViewModel
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
                    var createdOnMeta = Metas.FirstOrDefault(cm => cm.Key == nameof(CreatedOn)); 
                    if (createdOnMeta != null)
                    {
                        DateTime.TryParse(createdOnMeta.Value, out DateTime createdOn);
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

        private string _subtitle = null;
        public string Subtitle
        {
            get
            {
                if (_subtitle == null)
                {
                    var subtitleMeta = Metas.FirstOrDefault(cm => cm.Key == nameof(Subtitle));
                    if (subtitleMeta != null)
                    {
                        _subtitle = subtitleMeta.Value;
                    }
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

        public List<PostMetaViewModel> Metas { get; set; }
    }
}

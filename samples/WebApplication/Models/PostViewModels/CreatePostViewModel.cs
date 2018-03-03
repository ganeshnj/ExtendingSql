using System;

namespace WebApplication.Models.PostViewModels
{
    public class CreatePostViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}

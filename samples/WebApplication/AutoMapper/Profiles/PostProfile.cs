using AutoMapper;
using WebApplication.Models;
using WebApplication.Models.PostViewModels;

namespace WebApplication.AutoMapper.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostViewModel>().ReverseMap();
            CreateMap<Post, CreatePostViewModel>().ReverseMap();
            CreateMap<Post, EditPostViewModel>().ReverseMap();

            CreateMap<PostMeta, PostMetaViewModel>().ReverseMap();
        }
    }
}

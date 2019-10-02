using AutoMapper;
using CoreWeatherApi.Core.Dtos;
using CoreWeatherApi.Core.Entities;

namespace CoreWeatherApi.Core.Configurations
{
    public class MapperProfile : Profile 
    {
        public MapperProfile()
        {
            CreateMap<BlogDto, Blog>();
            CreateMap<Blog, BlogDto>();
            CreateMap<CommentDto, Comment>();
            CreateMap<Comment, CommentDto>();
            CreateMap<EntryDto, Entry>();
            CreateMap<Entry, EntryDto>();
        }
    }
}
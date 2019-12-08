using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ComeToTurkey.API.Dtos;
using ComeToTurkey.API.Models;

namespace ComeToTurkey.API.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
           

            CreateMap<User, UserForDetailedDto>().ForMember(dest => dest.PhotoUrl,
                opt => { opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url); }).ForMember(dest => dest.Age, opt =>
            {
                opt.MapFrom(d => d.DateOfBirth.CalculateAge());
            });
            CreateMap<Photo, PhotosForDetailedDto>();
            CreateMap<Follow, FollowerDto>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<Photo, PhotosForReturnDto>();
            CreateMap<PhotoForCreationDto, Photo>();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<MessageForCreationDto, Message>().ReverseMap();
            CreateMap<Message, MessageToReturnDto>()
                .ForMember(dest => dest.SenderPhotoUrl, opt => opt.MapFrom(u => u.Sender.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(dest => dest.RecipientPhotoUrl, opt => opt.MapFrom(u => u.Recipient.Photos.FirstOrDefault(p => p.IsMain).Url));



            CreateMap<CommentsForCreationDto, Comment>().ReverseMap();
            CreateMap<Comment, CommentToReturnDto>()
                .ForMember(dest => dest.SenderPhotoUrl,
                    opt => opt.MapFrom(u => u.Sender.Photos.FirstOrDefault(p => p.IsMain).Url));
               

            CreateMap<BlogForCreationDto, Blog>();


            CreateMap<Blog, BlogForListDto>().ForMember(dest => dest.PhotoUrl,
                    opt => opt.MapFrom(u => u.User.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(dest => dest.CommentsReceivedCount, opt => opt.MapFrom(u => u.CommentsReceived.Count))
                .ForMember(dest => dest.BlogLikesCount, opt => opt.MapFrom(u => u.BlogLikes.Count));




            CreateMap<Blog, BlogForReturnDto>()
                .ForMember(dest => dest.PhotoUrl,
                    opt => opt.MapFrom(u => u.User.Photos.FirstOrDefault(p => p.IsMain).Url)).ForMember(
                    dest => dest.BlogLikesCount,
                    opt => opt.MapFrom(u => u.BlogLikes.Count))
                .ForMember(dest => dest.CommentsReceivedCount, opt => opt.MapFrom(u => u.CommentsReceived.Count));
               



            CreateMap<User, UserListDto>().ForMember(desc => desc.PhotoUrl,
                opt => opt.MapFrom(x => x.Photos.FirstOrDefault(p => p.IsMain).Url));

            CreateMap<Like, LikeToReturnDto>()
                .ForMember(dest => dest.SenderPhotoUrl,
                    opt => opt.MapFrom(u => u.Liker.Photos.FirstOrDefault(p => p.IsMain).Url));


            CreateMap<Team, AboutPagesToReturnDto>();

            CreateMap<User, UserForAdminDto>().ForMember(desc => desc.PhotoUrl,
                opt => opt.MapFrom(x => x.Photos.FirstOrDefault(p => p.IsMain).Url));



            CreateMap<BlogCategory, BlogCategoryToReturn>();
            CreateMap<City, CityToReturnDto>();
            CreateMap<Blog, BlogForAdminDto>();
            CreateMap<Destination, DestinationForAdminDto>();
            CreateMap<New, NewsForReturnDto>();

            CreateMap<NewsForCreationDto, New>();

            CreateMap<Blog, BlogsForPopularDto>();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComeToTurkey.API.Dtos;
using ComeToTurkey.API.Helpers;
using ComeToTurkey.API.Models;

namespace ComeToTurkey.API.Data
{
   public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<IEnumerable<T>> GetList<T>() where T : class;
        Task<bool> SaveAll();
        Task<User> GetUser(int userId);
        Task<Photo> GetPhoto(int id);
        Task<User> GetMe(int id);
        Task<Photo> GetMainPhoto(int id);
        Task<Message> GetMessage(int id);
        Task<PagedList<Message>> GetMessagesForUser(MessageParams messageParams);
        Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId);
        Task<Follow> GetFollow(int userId, int recipientId);
        void UnFollow(Follow follow);
        Task<PagedList<Comment>> GetCommentsForUser(CommentParams commentParams);
        Task<Comment> GetComment(int id);
        Task<Blog> GetBlog(int blogId);
        Task<PagedList<Blog>> GetBlogs(BlogParams userParams);
        Task<IEnumerable<User>> GetUsers();
        Task<Like> GetBlogLike(int userId, int recipientId);
        Task<About> GetAbout();
        Task<IEnumerable<BlogCategoryToReturnDto>> GetBlogCategories();
        Task<List<Destination>> GetDestinationList();
        Task<List<Blog>> GetBlogList();
        Task<New> GetNews(int newId);
        Task<List<Blog>> GetPopularBlogs();



    }
}

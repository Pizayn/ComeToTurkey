using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComeToTurkey.API.Dtos;
using ComeToTurkey.API.Helpers;
using ComeToTurkey.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ComeToTurkey.API.Data
{
    public class Repository:IRepository
    {
        private DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetList<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<User> GetUser(int userId)
        {
            var user = await _context.Users.Include(x => x.Photos).Include(p=>p.Followers).Include(b=>b.Blogs)
                .FirstOrDefaultAsync(u => u.Id == userId);
            return user;
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync(p => p.Id == id);
            return photo;
        }

        public async Task<User> GetMe(int id)
        {
            var user = await _context.Users.Include(p => p.Photos).IgnoreQueryFilters().FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<Photo> GetMainPhoto(int id)
        {
            var photo = await _context.Photos.Where(i => i.UserId == id).FirstOrDefaultAsync(m => m.IsMain);
            return photo;
        }
        public async Task<Message> GetMessage(int id)
        {
            return await _context.Messages.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<PagedList<Message>> GetMessagesForUser(MessageParams messageParams)
        {
            var messages = _context.Messages.Include(u => u.Sender).ThenInclude(p => p.Photos).Include(u => u.Recipient).ThenInclude(p => p.Photos).AsQueryable();
            switch (messageParams.MessageContainer)
            {
                case "Inbox":
                    messages = messages.Where(u => u.RecipientId == messageParams.UserId && u.IsDeletedByRecipient == false);
                    break;
                case "Outbox":
                    messages = messages.Where(u => u.SenderId == messageParams.UserId && u.IsDeletedBySender == false);
                    break;
                default:
                    messages = messages.Where(u => u.RecipientId == messageParams.UserId && u.IsDeletedByRecipient == false && u.IsRead == false);
                    break;
            }
            messages = messages.OrderByDescending(d => d.SendDate);
            return await PagedList<Message>.CrateAsync(messages, messageParams.PageNumber, messageParams.PageSize);
        }

        public async Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId)
        {
            var messages = await _context.Messages.Include(u => u.Sender).ThenInclude(p => p.Photos).Include(u => u.Recipient).ThenInclude(p => p.Photos)
                .Where(m => (m.RecipientId == userId && m.IsDeletedByRecipient == false && m.SenderId == recipientId) || (m.SenderId == userId && m.IsDeletedBySender == false && m.RecipientId == recipientId))
                .OrderByDescending(m => m.SendDate).ToListAsync();
            return messages;
        }

        public async Task<Follow> GetFollow(int userId, int recipientId)
        {
            return await _context.Follows.FirstOrDefaultAsync(x =>
                x.FollowerId == userId && x.FollowingId == recipientId);
        }

        public void UnFollow(Follow follow)
        {
            _context.Follows.Remove(follow);
        }

        public async Task<PagedList<Comment>> GetCommentsForUser(CommentParams commentParams)
        {
            var comments = _context.Comments.Include(u => u.Sender).ThenInclude(p => p.Photos).Include(u => u.Recipient).AsQueryable();
           
               
              comments = comments.Where(u => u.RecipientId == commentParams.blogId && u.IsDeletedByRecipient == false);
                 
               
                  
                 
            
            comments = comments.OrderByDescending(d => d.SendDate);
            return await PagedList<Comment>.CrateAsync(comments, commentParams.PageNumber, commentParams.PageSize);
        }

        public async Task<Comment> GetComment(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(m => m.Id == id);

        }

        public async Task<Blog> GetBlog(int blogId)
        {
            return await _context.Blogs.Include(x=>x.CommentsReceived).Include(b=>b.BlogCategory).Include(c=>c.City).Include(u=>u.User).ThenInclude(p=>p.Photos).Include(l=>l.BlogLikes).FirstOrDefaultAsync(x => x.BlogId == blogId);
        }

        public async Task<PagedList<Blog>> GetBlogs(BlogParams userParams)
        {
           

            var blogs = _context.Blogs.OrderByDescending(u => u.CreatedTime).AsQueryable();
            var userFollowings = await GetUserFollowings(userParams.UserId);
            blogs = blogs.Where(u => userFollowings.Contains(u.UserId) || u.UserId==userParams.UserId).Include(c=>c.CommentsReceived).Include(b=>b.BlogLikes).Include(u=>u.User).ThenInclude(p=>p.Photos);
            if (userParams.BlogCategoryId != 0)
            {
                blogs= blogs.Where(b => b.BlogCategoryId==userParams.BlogCategoryId);
            }





            return await PagedList<Blog>.CrateAsync(blogs, userParams.PageNumber, userParams.PageSize);
        }

        public  async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.Include(p=>p.Photos).ToListAsync();
        }

        private async Task<IEnumerable<int>> GetUserFollowings(int id)
        {
            var user = await _context.Users.Include(x => x.Followings)
                .FirstOrDefaultAsync(u => u.Id == id);
          
               return user.Followings.Where(u => u.FollowerId == id).Select(i => i.FollowingId);
            
           
        }
        public async Task<Like> GetBlogLike(int userId, int recipientId)
        {
            return await _context.Likes.FirstOrDefaultAsync(x =>
                x.LikerId == userId && x.BlogLikeId == recipientId);
        }

     

        public async Task<About> GetAbout()
        {
            return await _context.Abouts.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BlogCategoryToReturnDto>> GetBlogCategories()
        {
            var blogCategories =await _context.BlogCategories.Take(3).Select(c => new BlogCategoryToReturnDto
            {
              BlogCategoryName = c.BlogCategoryName,
                BlogCategoryNameCount = c.Blogs.Count(),
            }).OrderBy(b=>b.BlogCategoryNameCount).ToListAsync();
            return blogCategories;
        }

        public async Task<List<Blog>> GetBlogList()
        {
            return await _context.Blogs.Include(x => x.City).Include(c => c.BlogCategory).ToListAsync();
        }

        public async Task<New> GetNews(int newId)
        {
            return await _context.News.FirstOrDefaultAsync(x => x.NewId == newId);
        }

        public async Task<List<Blog>> GetPopularBlogs()
        {
            return await _context.Blogs.Include(b=>b.BlogLikes).OrderByDescending(b=>b.BlogLikes.Count).Take(3).ToListAsync();
        }

        public async Task<List<Destination>> GetDestinationList()
        {
            return await _context.Destinations.Include(x => x.City).ToListAsync();
        }
    }
}

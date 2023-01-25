using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private AppDbContext _dbContext;
        public PostController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("/getAllPosts")]
        public async Task<JsonResult> GetAllPosts()
        {
            var allPosts = await _dbContext.posts.ToListAsync();

            //Добавляем заголовок общего количества постов в БД
            Response.Headers.Append("post-count", $"{allPosts.Count}");

            return new JsonResult(allPosts);
        }

        [HttpGet]
        [Route("/getAllPosts/limit={_limit:int}&page={_page:int}")]
        public async Task<JsonResult> GetAllPosts(int _limit, int _page)
        {
            var allPosts = await _dbContext.posts.ToListAsync();

            //Добавляем заголовок общего количества постов в БД
            Response.Headers.Append("post-count", $"{allPosts.Count}");

            List<Post> partOfPosts = new List<Post>();

            int postIndexInList = 0;
            while (postIndexInList < _limit)
            {
                    try
                    {
                        var postIndex = postIndexInList + _limit * _page - _limit;

                        if(postIndex < allPosts.Count)
                        {
                            partOfPosts.Add(allPosts[postIndex]);
                        }
                    }
                    catch { }

                postIndexInList++;
            }

            return new JsonResult(partOfPosts);
        }

        [HttpPost]
        [Route("/addNewPost")]
        public async Task<string> AddNewPost(Post newPost)
        {
            try
            {
                if (newPost.Title == string.Empty || newPost.Body == string.Empty)
                {
                    return "Необходимо заполнить данные!";
                }
                else
                {
                    await _dbContext.posts.AddAsync(newPost);
                    await _dbContext.SaveChangesAsync();

                    return "Пост успешно добавлен!";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpDelete]
        [Route("/deletePost/id={id:int}")]
        public async Task<string> DeletePost(int id)
        {
            try
            {
                var post = await _dbContext.posts.FindAsync(id);
                if (post != null)
                {
                    _dbContext.posts.Remove(post);
                    await _dbContext.SaveChangesAsync();

                    return "Пост успешно удален!";
                }
                else
                {
                    return "Пост не найден!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}


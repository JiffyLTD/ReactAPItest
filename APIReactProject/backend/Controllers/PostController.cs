using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
        public JsonResult GetAllPosts()
        {
            //Добавляем заголовок общего количества постов в БД
            Response.Headers.Append("post-count", $"{_dbContext.posts.ToList().Count}");

            return new JsonResult(_dbContext.posts.ToList());
        }

        [HttpGet]
        [Route("/getAllPosts/limit={_limit:int}&page={_page:int}")]
        public JsonResult GetAllPosts(int _limit, int _page)
        {
            //Добавляем заголовок общего количества постов в БД
            Response.Headers.Append("post-count", $"{_dbContext.posts.ToList().Count}");


            var allPosts = _dbContext.posts.ToList();

            List<Post> posts = new List<Post>();

            int postIndextInList = 0;
            while (postIndextInList < _limit)
            {
                    try
                    {
                        posts.Add(allPosts[postIndextInList + _limit * _page - _limit]);
                    }
                    catch { }

                postIndextInList++;
            }

            return new JsonResult(posts);
        }
    }
}


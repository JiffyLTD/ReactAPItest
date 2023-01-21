using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        public PostController() { }

        public class LowerCaseNamingPolicy : JsonNamingPolicy
        {
            public override string ConvertName(string name) =>
                name.ToLower();
        }

        [HttpGet]
        [Route("/getAllPosts")]
        public JsonResult GetAll(int? _limit, int? _page)
        {
            Post[] posts = new Post[22];

            int postsCount = 0;
            for (int i = 0; i <= 21; i++)
            {
                Post post = new();

                post.Id = i;
                post.Title = "TestTitle " + i;
                post.Body = "TestBody " + i;

                posts[i] = post;
                postsCount++;
            }

            Response.Headers.Append("post-count", $"{postsCount}");

            var jsonOptions = new System.Text.Json.JsonSerializerOptions 
            {
                WriteIndented = true,
                PropertyNamingPolicy = new LowerCaseNamingPolicy(),
            };

            if(_page == 1)
            {
                Post[] posts2 = new Post[10];

                for(int j = 0;j < 10; j++)
                {
                    posts2[j] = posts[j];
                }

                return new JsonResult(posts2,jsonOptions);
            }
            if (_page == 2)
            {
                Post[] posts2 = new Post[10];

                int count = 0;

                for (int j = 10; j < 20; j++)
                {
                    posts2[count] = posts[j];
                    count++;
                }

                return new JsonResult(posts2, jsonOptions);
            }
            if (_page == 3)
            {
                Post[] posts2 = new Post[2];

                int count = 0;

                for (int j = 20; j < 22; j++)
                {
                    posts2[count] = posts[j];
                    count++;
                }

                return new JsonResult(posts2, jsonOptions);
            }

            return  new JsonResult(posts, jsonOptions);
        }
    }

    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Body { get; set; } = null!;
    }
}


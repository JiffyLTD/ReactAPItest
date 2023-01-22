using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Body { get; set; } = null!;
    }
}

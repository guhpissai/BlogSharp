using Blog.Models;

namespace Blog.Repositories
{
  public class Post
  {
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Summary { get; set; }
    public string? Body { get; set; }
    public string? Slug { get; set; }
    public List<Category> Categories { get; set; } = [];
  }
}
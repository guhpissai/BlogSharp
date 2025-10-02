using Blog.Repositories;

namespace Blog.Services
{
  public class PostService
  {
    private readonly Repository<Post> _repository;

    public PostService(Repository<Post> repository)
    {
      _repository = repository;
    }

    public void Create(Post post)
    {
      if (string.IsNullOrWhiteSpace(post.Title))
        throw new Exception("O título do post é obrigatório");

      if (string.IsNullOrWhiteSpace(post.Summary))
        throw new Exception("O resumo do post é obrigatório");

      if (string.IsNullOrWhiteSpace(post.Body))
        throw new Exception("O conteúdo do post é obrigatório");

      _repository.Create(post);
    }

    public void Update(Post post)
    {
      var existingPost = _repository.Get(post.Id);
      if (existingPost == null)
        throw new Exception("Post não encontrado");

      if (string.IsNullOrWhiteSpace(post.Title))
        throw new Exception("O título do post é obrigatório");

      if (string.IsNullOrWhiteSpace(post.Summary))
        throw new Exception("O resumo do post é obrigatório");

      if (string.IsNullOrWhiteSpace(post.Body))
        throw new Exception("O conteúdo do post é obrigatório");

      _repository.Update(post);
    }
    public void Delete(int id)
    {
      var existingPost = _repository.Get(id);
      if (existingPost == null)
        throw new InvalidOperationException("Post não encontrado");

      _repository.Delete(existingPost);
    }
    public IEnumerable<Post> GetAll()
      => _repository.Get();

    public Post? GetById(short id)
      => _repository.Get(id);
  }
}
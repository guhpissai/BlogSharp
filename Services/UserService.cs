using Blog.Models;
using Blog.Repositories;

namespace Blog.Services
{
  public class UserService : IUserService
  {
    private readonly IRepository<User> _repository;
    // Realizando injeção de dependencia
    public UserService(IRepository<User> repository)
    {
      _repository = repository;
    }

    public IEnumerable<User> GetAll()
      => _repository.Get();

    public User GetById(int id)
      => _repository.Get(id) ?? throw new InvalidOperationException("Usuário não encontrado");

    public void Create(User user)
    {

      var existingUsers = _repository.Get();

      if (existingUsers.Any(u => u.Name == user.Name))
        throw new InvalidOperationException("Nome do usuário já existe.");

      if (existingUsers.Any(u => u.Email == user.Email))
        throw new InvalidOperationException("E-mail já utilizado.");

      var rows = _repository.Create(user);

      if (rows == 0)
        throw new InvalidOperationException("Não foi possivel criar o usuário");
    }

    public void Delete(int id)
    {
      var user = _repository.Get(id);

      if (user == null)
      {
        throw new InvalidOperationException("Usuário não encontrado.");
      }

      _repository.Delete(user);
    }

    public void Update(User user)
    {
      var usuarioExistente = _repository.Get(user.Id);

      if (usuarioExistente == null)
      {
        throw new InvalidOperationException("Usuário não encontrado.");
      }

      var existingUsers = _repository.Get();

      if (existingUsers.Any(u => u.Name == user.Name && u.Id != user.Id))
        throw new InvalidOperationException("Nome do usuário já existe.");

      if (existingUsers.Any(u => u.Email == user.Email && u.Id != user.Id))
        throw new InvalidOperationException("E-mail já utilizado.");

      var registered = _repository.Update(user);

      if (!registered)
      {
        throw new InvalidOperationException("Usuário não encontrado.");
      }
    }
  }
}
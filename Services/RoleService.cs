using Blog.Models;
using Blog.Repositories;

namespace Blog.Services
{
  public class RoleService : IRoleService
  {
    private readonly IRepository<Role> _repository;

    public RoleService(IRepository<Role> repository)
    {
      _repository = repository;
    }
    public void Create(Role role)
    {
      var existsRoles = _repository.Get();

      if (existsRoles.Any(r => r.Name == role.Name))
      {
        throw new InvalidOperationException("Nome do cargo já existe");
      }

      _repository.Create(role);
    }

    public void Delete(int id)
    {
      var existRole = _repository.Get(id);

      if (existRole == null)
        throw new InvalidOperationException("Cargo inválido");

      _repository.Delete(existRole);
    }

    public IEnumerable<Role> GetAll()
     => _repository.Get();

    public Role GetById(int id)
     => _repository.Get(id);

    public void Update(Role role)
    {
      var usuarioExistente = _repository.Get(role.Id);

      if (usuarioExistente == null)
      {
        throw new InvalidOperationException("Cargo não encontrado.");
      }

      var existingRoles = _repository.Get();

      if (existingRoles.Any(u => u.Name == role.Name && u.Id != role.Id))
        throw new InvalidOperationException("Nome do cargo já existe.");

      var registered = _repository.Update(role);

      if (!registered)
      {
        throw new InvalidOperationException("Cargo não encontrado.");
      }
    }
  }
}
using Blog.Models;
using Blog.Services;

namespace Blog.Screens.RoleScreens
{
  public static class UpdateRoleScreen
  {
    public static void Load(RoleService _service)
    {
      Console.Clear();
      Console.WriteLine();
      Console.WriteLine("============ ATUALIZAR PERFIL ==============");
      Console.WriteLine();

      try
      {

        Console.Write("Id: ");
        if (!int.TryParse(Console.ReadLine(), out var roleId))
          throw new Exception("Id inválido!");

        var role = _service.GetById(roleId);

        Console.Write("Nome: ");
        var nome = Console.ReadLine();
        var slug = nome!.ToLower();

        role.Name = nome;
        role.Slug = slug;

        _service.Update(role);

        Console.WriteLine("");
        Console.WriteLine($"Perfil atualizado com sucesso!");
        Console.WriteLine("Pressione ENTER para voltar...");
        Console.ReadKey();
        MenuRoleScreen.Load();
      }
      catch (Exception ex)
      {
        Console.WriteLine("");
        Console.WriteLine($"Erro: {ex.Message}");
        Console.WriteLine("Pressione ENTER para voltar...");
        Console.ReadKey();
        MenuRoleScreen.Load();
      }
    }
  }
}
using Blog.Models;
using Blog.Services;
using Blog.Utils;

namespace Blog.Screens.RoleScreens
{
  public static class CreateRoleScreen
  {
    public static void Load(RoleService _service)
    {
      Console.Clear();
      Console.WriteLine("============ CRIAR PERFIL ==============");
      Console.WriteLine();

      try
      {

        Console.Write("Nome: ");
        var nome = Console.ReadLine();
        var slug = nome!.ToLower();

        Role role = new();
        role.Name = nome;
        role.Slug = slug;

        _service.Create(role);

        Console.WriteLine("");
        Console.WriteLine($"Perfil {nome} criado com sucesso!");
        Console.WriteLine("Pressione ENTER para voltar...");
        Console.ReadKey();
        MenuRoleScreen.Load();
      }
      catch (Exception ex)
      {
        ConsoleHelper.ShowException(ex.Message);
        MenuRoleScreen.Load();
      }
    }
  }
}
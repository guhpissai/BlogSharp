using Blog.Models;
using Blog.Services;

namespace Blog.Screens.RoleScreens
{
  public static class DeleteRoleScreen
  {
    public static void Load(RoleService _service)
    {
      Console.Clear();
      Console.WriteLine("============ DELETAR PERFIL ==============");
      Console.WriteLine();

      try
      {

        Console.Write("Digite o ID do perfil que deseja deletar: ");
        if (!short.TryParse(Console.ReadLine(), out var roleId))
          throw new Exception("Id inválido, digite apenas numeros");

        _service.Delete(roleId);

        Console.WriteLine("");
        Console.WriteLine($"Perfil deletado com sucesso!");
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
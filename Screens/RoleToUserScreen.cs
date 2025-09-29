using Blog.Services;

namespace Blog.Screens
{
  public static class RoleToUserScreen
  {
    public static void Load(RoleToUserService _service, RoleService _roleService, UserService _userService)
    {
      Console.Write("Digite o nome do usuário: ");
      var nome = Console.ReadLine();

      var users = _userService.GetAll();

      var user = users.FirstOrDefault(u => u.Name == nome);

      if (user == null)
      {
        Console.WriteLine("Usuário inválido");
        Console.WriteLine("Pressione ENTER para voltar...");
        Console.ReadKey();
        Program.Menu();
        return;
      }

      var roles = _roleService.GetAll().ToList();

      Console.WriteLine("Escolha o perfil: ");

      for (int i = 0; i < roles.Count; i++)
      {
        Console.WriteLine($"[{i + 1}] - {roles[i].Name}");
      }

      if (!short.TryParse(Console.ReadLine(), out var option))
      {
        Console.WriteLine("Perfil inválido, digite apenas números");
        Console.WriteLine("Pressione ENTER para voltar...");
        Console.ReadKey();
        Program.Menu();
        return;
      }

      if (option < 1 || option > roles.Count)
      {
        Console.WriteLine("Opção inválida!");
        Console.WriteLine("Pressione ENTER para voltar...");
        Console.ReadKey();
        Program.Menu();
        return;
      }

      var r = roles.ToList()[option - 1];

      _service.UserToRole(user.Id, r.Id);
    }
  }
}
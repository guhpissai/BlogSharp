using Blog.Models;
using Blog.Repositories;
using Blog.Screens.MenuPostScreen;
using Dapper.Contrib.Extensions;

namespace Blog.Screens.UserScreen
{
  public static class CreateUserScreen
  {
    public static void Load()
    {
      Console.Clear();
      Console.WriteLine("══════════════════════════════════════════════");
      Console.WriteLine("                CRIAR USUÁRIO                 ");
      Console.WriteLine("══════════════════════════════════════════════");

      Console.Write("Nome: ");
      var name = Console.ReadLine();
      var slug = name?.ToLower();

      Console.Write("E-mail: ");
      var email = Console.ReadLine();

      Console.Write("Senha: ");
      var password = Console.ReadLine();

      Console.Write("Bio: ");
      var bio = Console.ReadLine();

      Console.Write("Imagem (URL): ");
      var image = Console.ReadLine();

      var user = new User();
      user.Name = name;
      user.Email = email;
      user.PasswordHash = password;
      user.Bio = bio;
      user.Image = image;
      user.Slug = slug;

      try
      {
        var repository = new Repository<User>(Database.Connection);
        repository.Create(user);

        Console.WriteLine($"Usuário {name} criada com sucesso!");

        Console.WriteLine();
        Console.WriteLine("Pressione ENTER para voltar...");
        Console.ReadKey();
        MenuUserScreen.Load();
      }
      catch (Exception ex)
      {
        Console.WriteLine("\n❌ Não foi possível criar o usuário, pressione ENTER para tentar novamente...");
        Console.WriteLine("");
        Console.WriteLine(ex.Message);
        Console.ReadKey();
        Console.Clear();
        Load();
      }
    }
  }
}
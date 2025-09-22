using Blog.Models;
using Blog.Repositories;
using Blog.Screens;
using Blog.Services;

namespace Blog.Screens.UserScreens
{
  public static class UpdateUserScreen
  {
    public static void Load(UserService _service)
    {
      Console.Clear();
      Console.WriteLine("══════════════════════════════════════════════");
      Console.WriteLine("                ATUALIZAR TAG                 ");
      Console.WriteLine("══════════════════════════════════════════════");

      try
      {
        Console.Write("Id: ");

        if (!int.TryParse(Console.ReadLine(), out var tagId))
        {
          Console.WriteLine("");
          Console.WriteLine("Id inválido! Use apenas números");
          Console.WriteLine("Pressione ENTER para tentar novamente");
          Console.ReadKey();
          Load(_service);
          return;
        }

        var user = _service.GetById(tagId);
        if (user == null)
        {
          Console.WriteLine("");
          Console.WriteLine("Usuário não encontrado!");
          Console.WriteLine("Pressione ENTER para tentar novamente");
          Console.ReadKey();
          Load(_service);
          return;
        }

        Console.Write($"Nome [{user.Name}]: ");
        var name = Console.ReadLine();
        var slug = name?.ToLower();

        Console.Write($"E-mail [{user.Email}]: ");
        var email = Console.ReadLine();

        Console.Write($"Senha [********]: ");
        var password = Console.ReadLine();

        Console.Write($"Bio [{user.Bio}]: ");
        var bio = Console.ReadLine();

        Console.Write($"Imagem (URL) [{user.Image}]: ");
        var image = Console.ReadLine();

        user.Name = string.IsNullOrWhiteSpace(name) ? user.Name : name;
        user.Email = string.IsNullOrWhiteSpace(email) ? user.Email : email;
        user.PasswordHash = string.IsNullOrWhiteSpace(email) ? user.Email : email;
        user.Bio = string.IsNullOrWhiteSpace(bio) ? user.Bio : bio;
        user.Image = image;
        user.Slug = string.Join("-", user.Name!.Split(" "))
                     .ToLower();

        _service.Update(user);

        Console.WriteLine("");
        Console.WriteLine($"Usuário atualizada com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine("\n❌ Ocorreu um erro ao atualizar a usuário.");
        System.Diagnostics.Debug.WriteLine(ex);
      }

      Console.WriteLine("\nPressione ENTER para voltar...");
      Console.ReadKey();
      MenuUserScreen.Load();
    }
  }
}
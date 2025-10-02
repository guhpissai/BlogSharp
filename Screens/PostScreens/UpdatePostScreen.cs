using Blog.Models;
using Blog.Screens.RoleScreens;
using Blog.Services;
using Blog.Utils;

namespace Blog.Screens.PostScreens
{
  public static class UpdateRPostScreen
  {
    public static void Load(PostService service)
    {
      Console.Clear();
      Console.WriteLine("══════════════════════════════════════════════");
      Console.WriteLine("               ✏️  ATUALIZAR POST             ");
      Console.WriteLine("══════════════════════════════════════════════");
      Console.WriteLine();

      try
      {
        Console.Write("Id do Post: ");
        var id = int.Parse(Console.ReadLine()!);

        Console.Write("Título: ");
        var title = Console.ReadLine();

        Console.Write("Resumo: ");
        var summary = Console.ReadLine();

        Console.Write("Texto: ");
        var body = Console.ReadLine();

        var post = new Post
        {
          Id = id,
          Title = title,
          Summary = summary,
          Body = body
        };

        service.Update(post);

        Console.WriteLine();
        Console.WriteLine($"Post {id} atualizado com sucesso!");
        Console.WriteLine("Pressione ENTER para voltar...");
        Console.ReadKey();
        MenuPostScreen.Load();
      }
      catch (Exception ex)
      {
        ConsoleHelper.ShowException(ex.Message);
        MenuPostScreen.Load();
      }
    }
  }
}
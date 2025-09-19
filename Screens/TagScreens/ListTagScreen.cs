using Blog.Models;
using Blog.Repositories;
using Blog.Services;

namespace Blog.Screens.TagScreens
{
  public static class ListTagScreen
  {
    private static readonly TagService _service = new();
    public static void Load()
    {
      List();
    }

    private static void List()
    {
      Console.Clear();
      Console.WriteLine("============ LISTA DE TAGS ==============");
      Console.WriteLine();

      try
      {
        var tags = _service.GetAll();

        if (!tags.Any())
          Console.WriteLine("Nenhuma tag encontrada");

        foreach (var tag in tags)
        {
          Console.WriteLine($"{tag.Name,-15} | {tag.Slug}");
        }

        Console.WriteLine("");
        Console.WriteLine("Pressione ENTER para voltar...");
        Console.ReadKey();
        Program.Menu();
      }
      catch (Exception ex)
      {
        Console.WriteLine("");
        Console.WriteLine(ex.Message);
        Console.WriteLine("Pressione ENTER para voltar...");
        Console.ReadKey();
        Program.Menu();
      }
    }
  }
}
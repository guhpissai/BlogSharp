using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
  public static class ListTagScreen
  {
    public static void Load()
    {
      List();
    }

    private static void List()
    {
      var repository = new Repository<Tag>(Database.Connection);

      var tags = repository.Get();

      Console.Clear();
      Console.WriteLine("============ LISTA DE TAGS ==============");
      Console.WriteLine();

      if (tags == null)
      {
        Console.WriteLine("Nenhuma tag encontrada");
      }
      else
      {
        foreach (var tag in tags)
        {
          Console.WriteLine($"{tag.Name.ToString().PadRight(15)} | {tag.Slug}");
        }
      }

      Console.WriteLine();
      Console.WriteLine("Pressione ENTER para voltar...");
      Console.ReadKey();
      Program.Menu();
    }
  }
}
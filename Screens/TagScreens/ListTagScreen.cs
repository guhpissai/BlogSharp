using Blog.Services;
using Blog.Utils;

namespace Blog.Screens.TagScreens
{
  public static class ListTagScreen
  {
    public static void Load(TagService _service)
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
        MenuScreen.Load();
      }
      catch (Exception ex)
      {
        ConsoleHelper.ShowException(ex.Message);
        MenuTagScreen.Load();
      }
    }
  }
}
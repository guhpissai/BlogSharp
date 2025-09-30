using Blog.Models;
using Blog.Services;
using Blog.Utils;

namespace Blog.Screens.TagScreens
{
  public static class CreateTagScreen
  {
    public static void Load(TagService _service)
    {
      Console.Clear();
      Console.WriteLine("══════════════════════════════════════════════");
      Console.WriteLine("                  CRIAR TAG                   ");
      Console.WriteLine("══════════════════════════════════════════════");

      try
      {
        Console.Write("Qual vai ser o nome da tag? ");
        var name = Console.ReadLine();
        var slug = name?.ToLower();

        var tag = new Tag();
        tag.Name = name;
        tag.Slug = slug;

        _service.Create(tag);

        Console.WriteLine($"Tag {name} criada com sucesso!");

        Console.WriteLine();
        Console.WriteLine("Pressione ENTER para voltar...");
        Console.ReadKey();
        MenuTagScreen.Load();
      }
      catch (Exception ex)
      {
        ConsoleHelper.ShowException(ex.Message);
        Load(_service);
      }
    }
  }
}
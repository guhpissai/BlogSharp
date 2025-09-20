using Blog.Models;
using Blog.Services;

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

      Console.Write("Qual vai ser o nome da tag? ");
      var name = Console.ReadLine();
      var slug = name?.ToLower();

      var tag = new Tag();
      tag.Name = name;
      tag.Slug = slug;

      try
      {
        _service.Create(tag);

        Console.WriteLine($"Tag {name} criada com sucesso!");

        Console.WriteLine();
        Console.WriteLine("Pressione ENTER para voltar...");
        Console.ReadKey();
        MenuTagScreen.Load();
      }
      catch (Exception ex)
      {
        Console.WriteLine("");
        Console.WriteLine($"\n❌ Não foi possível criar a Tag, pressione ENTER para tentar novamente... (Erro: {ex.Message})");
        Console.ReadKey();
        Console.Clear();
        Load(_service);
      }
    }
  }
}
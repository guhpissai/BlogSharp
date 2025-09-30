using Blog.Services;
using Blog.Utils;

namespace Blog.Screens.TagScreens
{
  public static class UpdateTagScreen
  {
    public static void Load(TagService _service)
    {
      Console.Clear();
      Console.WriteLine("══════════════════════════════════════════════");
      Console.WriteLine("                ATUALIZAR TAG                 ");
      Console.WriteLine("══════════════════════════════════════════════");

      try
      {
        Console.Write("Id: ");
        if (!int.TryParse(Console.ReadLine(), out var tagId))
          throw new Exception("Id inválido!");

        var tag = _service.GetById(tagId);

        Console.WriteLine("");
        Console.Write($"Nome [{tag.Name}]: ");
        var tagName = Console.ReadLine();

        _service.Update(tagId, tagName!);

        Console.WriteLine("");
        Console.WriteLine($"Tag atualizada com sucesso!");
        Console.WriteLine("\nPressione ENTER para voltar...");
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
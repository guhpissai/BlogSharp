using Blog.Services;
using Blog.Utils;

namespace Blog.Screens;

public static class ReportCategoryPost
{
  public static void Load(CategoryService _service, ReportService _reportService)
  {
    Console.Clear();
    Console.WriteLine("Escolha a categoria:");
    Console.WriteLine("");

    var categories = _service.GetAll();

    for (int i = 0; i < categories.Count(); i++)
    {
      Console.WriteLine($"[{i + 1}] - {categories.ElementAt(i).Name}");
    }

    if (!short.TryParse(Console.ReadLine(), out var option))
    {
      Console.WriteLine("Opção inválida");
    }

    try
    {
      var result = _reportService.GetPostsByCategory(categories.ElementAt(option - 1).Id);

      Console.WriteLine("");
      foreach (var r in result)
      {
        Console.WriteLine($"{"ID",-3} | {"Nome",-20} | {"Slug",-25} | {"Posts",5}");
        Console.WriteLine(new string('-', 60));
        Console.WriteLine($"{r.Id,-3} | {r.Name,-20} | {r.Slug,-25} | {r.Posts,5}");
      }

      Console.WriteLine("");
      Console.WriteLine("Pressione ENTER para voltar...");
      Console.ReadKey();
      MenuReportScreen.Load();
    }
    catch (Exception ex)
    {
      ConsoleHelper.ShowException(ex.Message);
      MenuReportScreen.Load();
    }
  }
}
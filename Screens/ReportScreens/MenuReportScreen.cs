using Blog.Models;
using Blog.Repositories;
using Blog.Services;
using Blog.Utils;

namespace Blog.Screens;

public static class MenuReportScreen
{
  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("══════════════════════════════════════════════");
    Console.WriteLine($"                 RELATÓRIOS                  ");
    Console.WriteLine("══════════════════════════════════════════════");

    Console.WriteLine("");
    Console.WriteLine("[1] - Relatorio numero de posts por categorias");
    Console.WriteLine("[0] - Voltar");

    if (!short.TryParse(Console.ReadLine(), out var option))
    {
      ConsoleHelper.ShowInvalidOption();
      Console.Clear();
      MenuScreen.Load();
      return;
    }

    var repository = new ReportRepository(Database.Connection!);
    var reportRepository = new Repository<Category>(Database.Connection!);
    var service = new ReportService(repository);
    var reportService = new CategoryService(reportRepository);

    switch (option)
    {
      case 1:
        ReportCategoryPost.Load(reportService, service);
        break;
      case 0:
        MenuScreen.Load();
        break;
      default:
        ConsoleHelper.ShowInvalidOption();
        Load();
        break;
    }
  }
}
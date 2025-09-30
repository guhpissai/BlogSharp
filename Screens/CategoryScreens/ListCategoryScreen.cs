using Blog.Services;
using Blog.Utils;

namespace Blog.Screens.CategoryScreens
{
  public static class ListCategoryScreen
  {
    public static void Load(CategoryService _service)
    {
      Console.Clear();
      Console.WriteLine("============ LISTA DE TAGS ==============");
      Console.WriteLine();

      try
      {
        var categories = _service.GetAll();

        if (!categories.Any())
        {
          Console.WriteLine("");
          Console.WriteLine("Nenhuma categoria encontrada");
          Console.WriteLine("Pressione ENTER para voltar...");
          Console.ReadKey();
          MenuCategoryScreen.Load();
        }
        else
          foreach (var category in categories)
          {
            Console.WriteLine($"{category.Name,-15} | {category.Slug}");
          }

        Console.WriteLine("");
        Console.WriteLine("Pressione ENTER para voltar...");
        Console.ReadKey();
        MenuCategoryScreen.Load();
      }
      catch (Exception ex)
      {
        ConsoleHelper.ShowException(ex.Message);
        MenuCategoryScreen.Load();
      }
    }
  }
}
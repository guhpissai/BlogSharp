using Blog.Models;
using Blog.Repositories;
using Blog.Services;
using Blog.Utils;

namespace Blog.Screens.CategoryScreens
{
  public static class MenuCategoryScreen
  {
    public static void Load()
    {
      MenuBlog.Load("Categoria");

      if (!short.TryParse(Console.ReadLine(), out short option))
      {
        ConsoleHelper.ShowInvalidOption();
        Load();
        return;
      }

      var repository = new Repository<Category>(Database.Connection!);
      var service = new CategoryService(repository);

      switch (option)
      {
        case 1:
          ListCategoryScreen.Load(service);
          break;
        case 2:
          CreateCategoryScreen.Load(service);
          break;
        case 3:
          UpdateCategoryScreen.Load(service);
          break;
        case 4:
          DeleteCategoryScreen.Load(service);
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
}
using Blog.Models;
using Blog.Repositories;
using Blog.Services;

namespace Blog.Screens.CategoryScreens
{
  public static class MenuCategoryScreen
  {
    public static void Load()
    {
      Menu.MenuLoad("Categoria");

      if (!short.TryParse(Console.ReadLine(), out short option))
      {
        Program.ShowInvalidOption();
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
          ListCategoryScreen.Load(service);
          break;
        case 3:
          ListCategoryScreen.Load(service);
          break;
        case 4:
          ListCategoryScreen.Load(service);
          break;
        case 0:
          Program.Menu();
          break;
        default:
          Program.ShowInvalidOption();
          Load();
          break;
      }
    }
  }
}
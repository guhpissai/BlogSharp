using Blog.Models;
using Blog.Repositories;
using Blog.Services;

namespace Blog.Screens.TagScreens
{
  public static class MenuTagScreen
  {
    public static void Load()
    {
      Menu.MenuLoad("Tag");

      if (!short.TryParse(Console.ReadLine(), out short option))
      {
        Program.ShowInvalidOption();
        Load();
        return;
      }

      var repository = new Repository<Tag>(Database.Connection!);
      var service = new TagService(repository);

      switch (option)
      {
        case 1:
          ListTagScreen.Load(service);
          break;
        case 2:
          CreateTagScreen.Load(service);
          break;
        case 3:
          UpdateTagScreen.Load(service);
          break;
        case 4:
          DeleteTagScreen.Load(service);
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
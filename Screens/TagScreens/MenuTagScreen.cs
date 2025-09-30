using Blog.Models;
using Blog.Repositories;
using Blog.Services;
using Blog.Utils;

namespace Blog.Screens.TagScreens
{
  public static class MenuTagScreen
  {
    public static void Load()
    {
      MenuBlog.Load("Tag");

      if (!short.TryParse(Console.ReadLine(), out short option))
      {
        ConsoleHelper.ShowInvalidOption();
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
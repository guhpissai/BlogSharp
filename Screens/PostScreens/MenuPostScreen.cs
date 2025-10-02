using Blog.Models;
using Blog.Repositories;
using Blog.Services;
using Blog.Utils;

namespace Blog.Screens.RoleScreens
{
  public static class MenuPostScreen
  {
    public static void Load()
    {
      MenuBlog.Load("Post");

      if (!short.TryParse(Console.ReadLine(), out var option))
      {
        ConsoleHelper.ShowInvalidOption();
        Load();
        return;
      }

      var repository = new Repository<Post>(Database.Connection!);
      var service = new PostService(repository);

      switch (option)
      {
        case 1:
          ListPostScreen.Load(service);
          break;
        case 2:
          CreatePostScreen.Load(service);
          break;
        case 3:
          UpdateRPostScreen.Load(service);
          break;
        case 4:
          DeletePostScreen.Load(service);
          break;
        default:
          ConsoleHelper.ShowInvalidOption();
          Load();
          return;
      }
    }
  }
}
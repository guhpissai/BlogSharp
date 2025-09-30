using Blog.Repositories;
using Blog.Services;
using Blog.Utils;

namespace Blog.Screens.UserScreens
{
  public static class MenuUserScreen
  {
    public static void Load()
    {
      MenuBlog.Load("Usuário");

      if (!short.TryParse(Console.ReadLine(), out short option))
      {
        ConsoleHelper.ShowInvalidOption();
        Load();
        return;
      }

      var repository = new UserRepository(Database.Connection!);
      var service = new UserService(repository);

      switch (option)
      {
        case 1:
          ListUserScreen.Load(service);
          break;
        case 2:
          CreateUserScreen.Load(service);
          break;
        case 3:
          UpdateUserScreen.Load(service);
          break;
        case 4:
          DeleteUserScreen.Load(service);
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
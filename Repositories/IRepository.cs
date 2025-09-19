using System.Collections.Generic;

namespace Blog.Repositories
{
  public interface IRepository<TModel> where TModel : class
  {
    IEnumerable<TModel> Get();
    TModel Get(int id);
    long Create(TModel model);
    bool Update(TModel model);
    bool Delete(TModel model);
  }
}
namespace Blog.Repositories;

public interface IReportRepository
{
  IEnumerable<CategoryPostReportDto> GetPostsByCategory(int CategoryId);
}
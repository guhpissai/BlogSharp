namespace Blog.Services;

public interface IReportService
{
  IEnumerable<CategoryPostReportDto> GetPostsByCategory(int categoryId);
}
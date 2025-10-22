using Blog.Repositories;

namespace Blog.Services;

public class ReportService : IReportService
{
  private readonly IReportRepository _repository;

  public ReportService(IReportRepository repository)
  {
    _repository = repository;
  }

  public IEnumerable<CategoryPostReportDto> GetPostsByCategory(int categoryId)
    => _repository.GetPostsByCategory(categoryId);
}
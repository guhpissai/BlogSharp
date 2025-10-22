using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class ReportRepository : IReportRepository
{
  private readonly SqlConnection _connection;

  public ReportRepository(SqlConnection connection)
  {
    _connection = connection;
  }

  public IEnumerable<CategoryPostReportDto> GetPostsByCategory(int categoryId)
  {
    var parameters = new DynamicParameters();
    parameters.Add("CategoryId", categoryId);

    return _connection.Query<CategoryPostReportDto>(
        "sp_GetCategoryPostCount",
        parameters,
        commandType: CommandType.StoredProcedure
    );
  }
}

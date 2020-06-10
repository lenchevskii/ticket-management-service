using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("TicketManagement.BL")]

namespace TicketManagement.DAL.Data
{
  internal class AreaLayoutRepository : GenericRepository<int, AreaLayout>
  {
    public override async Task CreateAsync(AreaLayout entity)
    {
      if (entity is null)
      {
        throw new ArgumentNullException(nameof(entity));
      }

      try
      {
        using (SqlConnection sqlConnection = new SqlConnection(@"data source=DESKTOP-9BC48BB\SQLEXPRESS;initial catalog=TicketManagement;integrated security=True;MultipleActiveResultSets=True;"))
        {
          await sqlConnection.OpenAsync();

          using (SqlCommand sqlCommand = new SqlCommand($"AreaLayout_Create_Entity", sqlConnection))
          {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter("@VenueId", entity.VenueId));
            sqlCommand.Parameters.Add(new SqlParameter("@Description", entity.Description));

            await sqlCommand.ExecuteNonQueryAsync();
          }
        }
      }
      catch (InvalidOperationException exception)
      {
        // Try checking if the connection failed here
        throw new InvalidOperationException(exception.Message);
      }
    }
  }
}

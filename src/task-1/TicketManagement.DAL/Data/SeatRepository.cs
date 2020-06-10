using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("TicketManagement.BL")]

namespace TicketManagement.DAL.Data
{
  internal class SeatRepository : GenericRepository<int, Seat>
  {
    public override async Task CreateAsync(Seat entity)
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

          using (SqlCommand sqlCommand = new SqlCommand($"Seat_Create_Entity", sqlConnection))
          {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter("@AreaId", entity.AreaId));
            sqlCommand.Parameters.Add(new SqlParameter("@Row", entity.Row));
            sqlCommand.Parameters.Add(new SqlParameter("@Number", entity.Number));

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

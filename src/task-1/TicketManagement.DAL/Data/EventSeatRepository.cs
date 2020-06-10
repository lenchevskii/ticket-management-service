using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("TicketManagement.BL")]

namespace TicketManagement.DAL.Data
{
  internal class EventSeatRepository : GenericRepository<int, EventSeat>
  {
    public override async Task CreateAsync(EventSeat entity)
    {
      if (entity != null)
      {
        try
        {
          using (SqlConnection sqlConnection = new SqlConnection(@"data source=DESKTOP-9BC48BB\SQLEXPRESS;initial catalog=TicketManagement;integrated security=True;MultipleActiveResultSets=True;"))
          {
            await sqlConnection.OpenAsync();

            using (SqlCommand sqlCommand = new SqlCommand($"EventSeat_Create_Entity", sqlConnection))
            {
              sqlCommand.CommandType = CommandType.StoredProcedure;
              sqlCommand.Parameters.Add(new SqlParameter("@EventAreaId", entity.EventAreaId));
              sqlCommand.Parameters.Add(new SqlParameter("@Row", entity.Row));
              sqlCommand.Parameters.Add(new SqlParameter("@Number", entity.Number));
              sqlCommand.Parameters.Add(new SqlParameter("@State", entity.State));

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
      else
      {
        throw new ArgumentNullException(nameof(entity));
      }
    }
  }
}

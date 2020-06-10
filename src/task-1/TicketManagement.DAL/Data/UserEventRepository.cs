using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("TicketManagement.BL")]

namespace TicketManagement.DAL.Data
{
  internal class UserEventRepository : GenericRepository<int, UserEvent>
  {
    public override async Task CreateAsync(UserEvent entity)
    {
      if (entity != null)
      {
        try
        {
          using (SqlConnection sqlConnection = new SqlConnection(@"data source=DESKTOP-9BC48BB\SQLEXPRESS;initial catalog=TicketManagement;integrated security=True;MultipleActiveResultSets=True;"))
          {
            await sqlConnection.OpenAsync();

            using (SqlCommand sqlCommand = new SqlCommand($"UserEvent_Create_Entity", sqlConnection))
            {
              sqlCommand.CommandType = CommandType.StoredProcedure;
              sqlCommand.Parameters.Add(new SqlParameter("@Name", entity.Name));
              sqlCommand.Parameters.Add(new SqlParameter("@Description", entity.Description));
              sqlCommand.Parameters.Add(new SqlParameter("@LayoutId", entity.LayoutId));

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

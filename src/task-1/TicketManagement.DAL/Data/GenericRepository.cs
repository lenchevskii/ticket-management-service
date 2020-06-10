using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TicketManagement.DAL.Interfaces;

[assembly: InternalsVisibleTo("TicketManagement.BL")]
[assembly: InternalsVisibleTo("ConsoleTest")]

namespace TicketManagement.DAL.Data
{
  internal class GenericRepository<TKey, TEntity> : IRepository<TKey, TEntity>
      where TEntity : class
  {
    public virtual async Task<IEnumerable<TEntity>> GetAsync(TKey key)
    {
      try
      {
        using (SqlConnection sqlConnection = new SqlConnection(@"data source=DESKTOP-9BC48BB\SQLEXPRESS;initial catalog=TicketManagement;integrated security=True;MultipleActiveResultSets=True;"))
        {
          await sqlConnection.OpenAsync();

          using (SqlCommand sqlCommand = new SqlCommand($"{typeof(TEntity).Name}_Get_Entity", sqlConnection))
          {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter("@Id", key));

            using (SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync())
            {
              var entities = await CreateListAsync(sqlDataReader);

              return entities;
            }
          }
        }
      }
      catch (InvalidOperationException exception)
      {
        // Try checking if the connection failed here
        throw new InvalidOperationException(exception.Message);
      }
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
      try
      {
        using (SqlConnection sqlConnection = new SqlConnection(@"data source=DESKTOP-9BC48BB\SQLEXPRESS;initial catalog=TicketManagement;integrated security=True;MultipleActiveResultSets=True;"))
        {
          await sqlConnection.OpenAsync();

          using (SqlCommand sqlCommand = new SqlCommand($"{typeof(TEntity).Name}_Get_All", sqlConnection))
          {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync())
            {
              var entities = await CreateListAsync(sqlDataReader);

              return entities;
            }
          }
        }
      }
      catch (InvalidOperationException exception)
      {
        // Try checking if the connection failed here
        throw new InvalidOperationException(exception.Message);
      }
    }

    public virtual async Task CreateAsync(TEntity entity) => throw new NotImplementedException();

    public virtual async Task DeleteAsync(TKey key)
    {
      try
      {
        using (SqlConnection sqlConnection = new SqlConnection(@"data source=DESKTOP-9BC48BB\SQLEXPRESS;initial catalog=TicketManagement;integrated security=True;MultipleActiveResultSets=True;"))
        {
          await sqlConnection.OpenAsync();

          using (SqlCommand sqlCommand = new SqlCommand($"{typeof(TEntity).Name}_Delete_Entity", sqlConnection))
          {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter("@Id", key));

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

    public virtual async Task DeleteRangeAsync(TKey[] keys)
    {
      if (keys is null)
      {
        throw new ArgumentNullException(nameof(keys));
      }

      try
      {
        using (SqlConnection sqlConnection = new SqlConnection(@"data source=DESKTOP-9BC48BB\SQLEXPRESS;initial catalog=TicketManagement;integrated security=True;MultipleActiveResultSets=True;"))
        {
          await sqlConnection.OpenAsync();

          foreach (var key in keys)
          {
            using (SqlCommand sqlCommand = new SqlCommand($"{typeof(TEntity).Name}_Delete_Entity", sqlConnection))
            {
              sqlCommand.CommandType = CommandType.StoredProcedure;
              sqlCommand.Parameters.Add(new SqlParameter("@Id", key));
              await sqlCommand.ExecuteNonQueryAsync();
            }
          }
        }
      }
      catch (InvalidOperationException exception)
      {
        // Try checking if the connection failed here
        throw new InvalidOperationException(exception.Message);
      }
    }

    // Helper
    private async Task<IEnumerable<TEntity>> CreateListAsync(SqlDataReader reader)
    {
      var results = new List<TEntity>();

      if (reader == null)
      {
        string readerParam = "sql data reader error";
        throw new ArgumentNullException(readerParam);
      }

      while (await reader.ReadAsync())
      {
        var item = Activator.CreateInstance<TEntity>();
        foreach (var property in typeof(TEntity).GetProperties().Where(p => !p.GetGetMethod().IsVirtual))
        {
          if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
          {
            Type convertTo = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
            property.SetValue(item, Convert.ChangeType(reader[property.Name], convertTo), null);
          }
        }

        results.Add(item);
      }

      return results;
    }
  }
}

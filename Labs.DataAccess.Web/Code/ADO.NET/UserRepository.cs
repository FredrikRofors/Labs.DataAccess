using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Labs.DataAccess.Web.Code.ADO.NET
{
    /// <summary>
    /// This is a demo implementation showing how to do dataaccess in .NET using good old ADO.NET.
    /// </summary>
    public class UserRepository : BaseRepository, IUserRepository
    {
        /// <summary>
        /// Fetches a user by id. 
        /// </summary>
        /// <param name="id">Key identifying a user.</param>
        /// <returns>The user if found, else null.</returns>
        public User GetById(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand("select * from users where id = @userId", connection);
                command.Parameters.AddWithValue("userId", id);
                connection.Open();

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return Map(reader); 
                }

                return null;
            }
        }

        private Code.User Map(IDataRecord record)
        {
            if (record == null)
                return null;

            return new User()
            {
                Id = (int)record["Id"],
                Firstname = (string)record["Firstname"],
                Lastname = (string)record["Lastname"],
                Email = (string)record["Email"]
            };
        }
    }
}
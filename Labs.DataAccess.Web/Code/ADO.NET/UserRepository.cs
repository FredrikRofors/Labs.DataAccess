using System;
using System.Collections.Generic;
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
        public User GetUser(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "select * from users where id = " + id;
                var command = new SqlCommand(sql, connection);
                
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return new User()
                    {
                        Id = (int)reader["Id"],
                        Firstname = (string)reader["Firstname"],
                        Lastname = (string)reader["Lastname"],
                        Email = (string)reader["Email"]
                    };
                }

                return null;
            }
        }
    }
}
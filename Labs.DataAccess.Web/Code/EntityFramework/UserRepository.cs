﻿using System.Linq;

namespace Labs.DataAccess.Web.Code.EntityFramework
{
    /// <summary>
    /// This is a demo implementation showing how to do dataaccess in .NET using Entity Framework (database-first model)
    /// </summary>
    public class UserRepository : BaseRepository, IUserRepository
    {
        public Code.User GetById(int id)
        {
            using (var context = new EntityFrameworkDbContext())
            {
                var user = context.Users.SingleOrDefault(u => u.Id == id);
                return Map(user);    
            }
        }

        /// <summary>
        /// Maps the User type generated by EntityFramework to our own POCO type.
        /// </summary>
        /// <param name="user">User object handed to us by EntityFramework.</param>
        /// <returns>Our own dataaccess technology independent User object.</returns>
        private Code.User Map(Labs.DataAccess.Web.Code.EntityFramework.User user)
        {
            if (user == null)
                return null;

            return new Code.User()
            {
                Id = user.Id,
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Email = user.Email
            };
        }
    }
}
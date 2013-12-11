namespace Labs.DataAccess.Web.Code
{
    public interface IUserRepository
    {
        /// <summary>
        /// Fetches a user by id. 
        /// </summary>
        /// <param name="id">Key identifying a user.</param>
        /// <returns>The user if found, else null.</returns>
        User GetUser(int id);
    }
}
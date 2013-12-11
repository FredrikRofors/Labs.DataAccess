using System.Configuration;

namespace Labs.DataAccess.Web.Code
{
    public class BaseRepository
    {
        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["LocalhostDatabase"].ConnectionString;
            }
        }
    }
}
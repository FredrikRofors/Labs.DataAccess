using System;
using Labs.DataAccess.Web.Code;

namespace Labs.DataAccess.Web
{
    public partial class DataAccessDemo : System.Web.UI.Page
    {
        /// <summary>
        /// The user id to search for (entered via the GUI). 
        /// </summary>
        public int UserId
        {
            get
            {
                int userId;
                if (!int.TryParse(txtUserId.Text, out userId))
                {
                    throw new Exception("Ooouups - the user did not enter a valid user id - should be caught by input validation at an earlier stage!");    
                }

                return userId;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearchUsingAdo_OnClick(object sender, EventArgs e)
        {
            var userRepo = new Code.ADO.NET.UserRepository();
            var user = userRepo.GetUser(UserId);

            RenderSearchResult(user);
        }

        protected void btnSearchUsingStronglyTypedDataset_OnClick(object sender, EventArgs e)
        {
            var userRepo = new Code.StronglyTypedDataset.UserRepository(); 
            var user = userRepo.GetUser(UserId);

            RenderSearchResult(user);
        }
        
        protected void btnSearchUsingLinqToSql_OnClick(object sender, EventArgs e)
        {
            var userRepo = new Code.LINQ.to.SQL.UserRepository();
            var user = userRepo.GetUser(UserId);

            RenderSearchResult(user);
        }

        protected void btnSearchUsingEntityFramework_OnClick(object sender, EventArgs e)
        {
            var userRepo = new Code.EntityFramework.UserRepository();
            var user = userRepo.GetUser(UserId);

            RenderSearchResult(user);
        }

        
        private void RenderSearchResult(User searchResult)
        {
            // clear previous searchresult
            txtSearchResult_UserId.Text = "";
            txtSearchResult_Firstname.Text = "";
            txtSearchResult_Lastname.Text = "";
            txtSearchResult_Email.Text = "";
            searchResultHit.Visible = false;
            searchResultNoHit.Visible = false;

            // no searchresult
            if (searchResult == null)
            {
                searchResultNoHit.Visible = true;
                return;
            }

            searchResultHit.Visible = true;
            txtSearchResult_UserId.Text = searchResult.Id.ToString();
            txtSearchResult_Firstname.Text = searchResult.Firstname;
            txtSearchResult_Lastname.Text = searchResult.Lastname;
            txtSearchResult_Email.Text = searchResult.Email;
        }
    }
}
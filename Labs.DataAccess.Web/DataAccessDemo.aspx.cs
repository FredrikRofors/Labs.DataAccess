using System;
using System.Diagnostics;
using System.Globalization;
using Labs.DataAccess.Web.Code;

namespace Labs.DataAccess.Web
{
    public partial class DataAccessDemo : System.Web.UI.Page
    {
        private struct SearchResult<T>
        {
            /// <summary>
            /// The actual search result. 
            /// </summary>
            public T Data { get; set; }

            /// <summary>
            /// The time spent executing the search query.
            /// </summary>
            public TimeSpan PerformanceCost { get; set; }
        }

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

        protected void btnSearchUsingAdo_OnClick(object sender, EventArgs e)
        {
            var searchresult = SearchUserById(UserId, new Code.ADO.NET.UserRepository());
            RenderSearchResult(searchresult);
        }

        protected void btnSearchUsingStronglyTypedDataset_OnClick(object sender, EventArgs e)
        {
            var searchresult = SearchUserById(UserId, new Code.StronglyTypedDataset.UserRepository());
            RenderSearchResult(searchresult);
        }
        
        protected void btnSearchUsingLinqToSql_OnClick(object sender, EventArgs e)
        {
            var searchresult = SearchUserById(UserId, new Code.LINQ.to.SQL.UserRepository());
            RenderSearchResult(searchresult);
        }

        protected void btnSearchUsingEntityFramework_OnClick(object sender, EventArgs e)
        {
            var searchresult = SearchUserById(UserId, new Code.EntityFramework.UserRepository());
            RenderSearchResult(searchresult);
        }



        private SearchResult<User> SearchUserById(int id, IUserRepository userRepo)
        {
            var stopWatch = Stopwatch.StartNew();
            var user = userRepo.GetUser(id);
            stopWatch.Stop();

            return new SearchResult<User>()
            {
                Data = user,
                PerformanceCost = stopWatch.Elapsed
            };
        }
        
        private void RenderSearchResult(SearchResult<User> searchResult)
        {
            // clear previous searchresult
            litPerformanceCost.Text = "";
            txtSearchResult_UserId.Text = "";
            txtSearchResult_Firstname.Text = "";
            txtSearchResult_Lastname.Text = "";
            txtSearchResult_Email.Text = "";
            searchResultHit.Visible = false;
            searchResultNoHit.Visible = false;

            // no searchresult
            if (searchResult.Data == null)
            {
                searchResultNoHit.Visible = true;
                return;
            }

            searchResultHit.Visible = true;
            litPerformanceCost.Text = string.Format("(search took {0}ms)", searchResult.PerformanceCost.TotalMilliseconds);
            var user = searchResult.Data;
            txtSearchResult_UserId.Text = user.Id.ToString();
            txtSearchResult_Firstname.Text = user.Firstname;
            txtSearchResult_Lastname.Text = user.Lastname;
            txtSearchResult_Email.Text = user.Email;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyTunes.Logic;

namespace MyTunes.Admin
{
    public partial class AddGenre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string GenreAction = Request.QueryString["GenreAction"];
            if (GenreAction == "add")
            {
                LabelAddStatus.Text = "Genre added!";
            }


        }

        protected void AddGenreButton_Click(object sender, EventArgs e)
        {


            // Add Genre data to DB.
            AddGenres Genres = new AddGenres();
            bool addSuccess = Genres.AddGenre(AddGenreName.Text);
            if (addSuccess)
            {
                // Reload the page.
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?GenreAction=add");
            }
            else
            {
                LabelAddStatus.Text = "Unable to add new Genre to database.";
            }
        }
    }
}
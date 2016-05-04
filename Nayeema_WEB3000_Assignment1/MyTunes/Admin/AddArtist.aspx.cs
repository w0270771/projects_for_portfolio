using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyTunes.Logic;

namespace MyTunes.Admin
{
    public partial class AddArtist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ArtistAction = Request.QueryString["ArtistAction"];
            if (ArtistAction == "add")
            {
                LabelAddStatus.Text = "Artist added!";
            }


        }

        protected void AddArtistButton_Click(object sender, EventArgs e)
        {


            // Add Artist data to DB.
            AddArtists Artists = new AddArtists();
            bool addSuccess = Artists.AddArtist(AddArtistName.Text);
            if (addSuccess)
            {
                // Reload the page.
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?ArtistAction=add");
            }
            else
            {
                LabelAddStatus.Text = "Unable to add new Artist to database.";
            }
        }

    }
}
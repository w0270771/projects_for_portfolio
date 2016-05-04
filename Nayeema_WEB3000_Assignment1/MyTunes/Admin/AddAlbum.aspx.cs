using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyTunes.Models;
using MyTunes.Logic;

namespace MyTunes.Admin
{
    public partial class AddAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string AlbumAction = Request.QueryString["AlbumAction"];
            if (AlbumAction == "add")
            {
                LabelAddStatus.Text = "Album added!";
            }

          
        }

        protected void AddAlbumButton_Click(object sender, EventArgs e)
        {


            // Add Album data to DB.
            AddAlbums Albums = new AddAlbums();
            bool addSuccess = Albums.AddAlbum(AddAlbumName.Text,DropDownArtist.SelectedValue);
            if (addSuccess)
            {
                // Reload the page.
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?AlbumAction=add");
            }
            else
            {
                LabelAddStatus.Text = "Unable to add new Album to database.";
            }
        }



        public IQueryable GetArtists()
        {
            var _db = new MyTunes.Models.MyTunesContext();
            IQueryable query = _db.Artists;
            return query;
        }

       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyTunes.Logic;
using MyTunes.Models;

namespace MyTunes.Admin
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string TrackAction = Request.QueryString["TrackAction"];
            if (TrackAction == "add")
            {
                LabelAddStatus.Text = "Track added!";
            }

            if (TrackAction == "remove")
            {
                LabelRemoveStatus.Text = "Track removed!";
            }
        }

        protected void AddTrackButton_Click(object sender, EventArgs e)
        {
            

                // Add Track data to DB.
                AddTracks Tracks = new AddTracks();
                bool addSuccess = Tracks.AddTrack(AddTrackName.Text, 
                    AddTrackPrice.Text, DropDownAddAlbum.SelectedValue, DropDownMediaType.SelectedValue
                    , DropDownGenre.SelectedValue);
                if (addSuccess)
                {
                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?TrackAction=add");
                }
                else
                {
                    LabelAddStatus.Text = "Unable to add new Track to database.";
                }
            }
            
        

        public IQueryable GetAlbums()
        {
            var _db = new MyTunes.Models.MyTunesContext();
            IQueryable query = _db.Albums;
            return query;
        }

        public IQueryable GetGenres()
        {
            var _db = new MyTunes.Models.MyTunesContext();
            IQueryable query = _db.Genres;
            return query;
        }

        public IQueryable GetMediaTypes()
        {
            var _db = new MyTunes.Models.MyTunesContext();
            IQueryable query = _db.MediaTypes;
            return query;
        }

        public IQueryable GetTracks()
        {
            var _db = new MyTunes.Models.MyTunesContext();
            IQueryable query = _db.Tracks;
            return query;
        }

        protected void RemoveTrackButton_Click(object sender, EventArgs e)
        {
            using (var _db = new MyTunes.Models.MyTunesContext())
            {
                int TrackId = Convert.ToInt16(DropDownRemoveTrack.SelectedValue);
                var myItem = (from c in _db.Tracks where c.TrackId == TrackId select c).FirstOrDefault();
                if (myItem != null)
                {
                    _db.Tracks.Remove(myItem);
                    _db.SaveChanges();

                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?TrackAction=remove");
                }
                else
                {
                    LabelRemoveStatus.Text = "Unable to locate Track.";
                }
            }
        }
    }
}
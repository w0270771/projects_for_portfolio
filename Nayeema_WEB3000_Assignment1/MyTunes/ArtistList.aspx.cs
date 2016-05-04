using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyTunes.Models;
using System.Web.ModelBinding;
namespace MyTunes
{
    public partial class ArtistList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Artist> GetArtists()
        {
            var _db = new MyTunes.Models.MyTunesContext();
            IQueryable<Artist> query = _db.Artists;
            return query;
        }
    }
}
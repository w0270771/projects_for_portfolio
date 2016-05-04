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
    public partial class AlbumList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Album> GetAlbums()
        {
            var _db = new MyTunes.Models.MyTunesContext();
            IQueryable<Album> query = _db.Albums;
            return query;
        }
    }
}
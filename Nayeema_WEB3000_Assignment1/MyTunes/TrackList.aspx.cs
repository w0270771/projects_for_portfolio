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
    public partial class TrackList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        public IQueryable<Track> GetTracks([QueryString("id")] int? AlbumId,
            [QueryString("mediatypeid")] int? MediaTypeId, [QueryString("genreid")] int? GenreId,
            [QueryString("artistid")] int? ArtistId)
        {
            var _db = new MyTunesContext();
            IQueryable<Track> query = _db.Tracks;
            if (AlbumId.HasValue && AlbumId > 0)
            {
                query = query.Where(p => p.AlbumId == AlbumId);
            }
            else if (MediaTypeId.HasValue && MediaTypeId > 0)
            {
                query = query.Where(p => p.MediaTypeId == MediaTypeId);
            }

            else if (GenreId.HasValue && GenreId > 0)
            {
                query = query.Where(p => p.GenreId == GenreId);
            }

            else if (ArtistId.HasValue && ArtistId > 0)
            {
                query = query.Where(p => p.Album.ArtistId == ArtistId);
            }

            return query;
        }

        /*public IQueryable<Track> GetTracks([QueryString("id")] int? MediaTypeId)
        {
            var _db = new MyTunesContext();
            IQueryable<Track> query = _db.Tracks;
            
            if (MediaTypeId.HasValue && MediaTypeId > 0)
            {
                query = query.Where(p => p.MediaTypeId == MediaTypeId);
            }
            return query;
        }*/

    }
}
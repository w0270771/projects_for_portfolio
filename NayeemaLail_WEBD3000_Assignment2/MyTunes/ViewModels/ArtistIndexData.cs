using MyTunes.Models;
using PagedList;
using System.Collections.Generic;

namespace MyTunes.ViewModels
{
    public class ArtistIndexData
    {

        public IEnumerable<Track> Tracks { get; set; }
        public IPagedList<Artist> Artists { get; set; }
        public IEnumerable<Album> Albums { get; set; }
    }
}
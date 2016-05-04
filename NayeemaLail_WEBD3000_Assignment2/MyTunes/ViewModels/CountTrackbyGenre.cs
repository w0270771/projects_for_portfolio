using System;
using System.ComponentModel.DataAnnotations;

namespace MyTunes.ViewModels
{
    public class CountTrackbyGenre
    {
        public int TrackCount { get; set; }
       
        public String GenreType { get; set; }

    }
}
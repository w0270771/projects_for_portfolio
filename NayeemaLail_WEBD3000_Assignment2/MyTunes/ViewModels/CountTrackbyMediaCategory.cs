using System;
using System.ComponentModel.DataAnnotations;

namespace MyTunes.ViewModels
{
    public class CountTrackByMediaCategory
    {
        public int TrackCount { get; set; }
       
        public String MediaCategory { get; set; }

    }
}
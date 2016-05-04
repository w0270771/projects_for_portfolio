using System;
using System.ComponentModel.DataAnnotations;

namespace MyTunes.ViewModels
{
    public class CountTrackByMediaType
    {
        public int TrackCount { get; set; }
       
        public String MediaType { get; set; }

    }
}
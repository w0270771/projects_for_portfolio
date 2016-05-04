using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyTunes.Models;

namespace MyTunes.Logic
{
    public class AddMediaTypes
    {
        public bool AddMediaType(string MediaTypeName, string MediaCategory)
        {
            var myMediaType = new MediaType();
            myMediaType.Name = MediaTypeName;
            myMediaType.MediaCategoryId = Convert.ToInt32(MediaCategory);

            using (MyTunesContext _db = new MyTunesContext())
            {
                // Add Track to DB.
                _db.MediaTypes.Add(myMediaType);
                _db.SaveChanges();
            }
            // Success.
            return true;
        }
    }
}
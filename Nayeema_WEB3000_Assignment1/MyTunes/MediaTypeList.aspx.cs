using System;
using System.Linq;
using MyTunes.Models;

namespace MyTunes
{
    public partial class MediaTypeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<MediaType> GetMediaTypes()
        {
          
            var _db = new MyTunes.Models.MyTunesContext();
            IQueryable<MediaType> query = _db.MediaTypes;
            return query;
       
        }
    }
}
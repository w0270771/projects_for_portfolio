using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyTunes.Models;
using MyTunes.Logic;

namespace MyTunes.Admin
{
    public partial class AddMediaType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string MediaTypeAction = Request.QueryString["MediaTypeAction"];
            if (MediaTypeAction == "add")
            {
                LabelAddStatus.Text = "MediaType added!";
            }


        }

        protected void AddMediaTypeButton_Click(object sender, EventArgs e)
        {


            // Add MediaType data to DB.
            AddMediaTypes MediaTypes = new AddMediaTypes();
            bool addSuccess = MediaTypes.AddMediaType(AddMediaTypeName.Text, DropDownMediaCategory.SelectedValue);
            if (addSuccess)
            {
                // Reload the page.
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?MediaTypeAction=add");
            }
            else
            {
                LabelAddStatus.Text = "Unable to add new MediaType to database.";
            }
        }



        public IQueryable GetMediaCategories()
        {
            var _db = new MyTunes.Models.MyTunesContext();
            IQueryable query = _db.MediaCategories;
            return query;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login_Page_Design
{
    public partial class Chat : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var id = HttpContext.Current.User.Identity;
            //if (id.IsAuthenticated == false)
                //Response.Redirect("/login.aspx");
        }

        protected void Send_btn_Click(object sender, EventArgs e)
        {
        }
    }
}
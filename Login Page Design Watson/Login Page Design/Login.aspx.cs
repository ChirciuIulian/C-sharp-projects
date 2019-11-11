using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login_Page_Design
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var id = (WindowsIdentity)HttpContext.Current.User.Identity;
            id.AddClaim(new System.Security.Claims.Claim("workspace", TextBox3.Text));
            id.AddClaim(new System.Security.Claims.Claim("password", TextBox2.Text));
            System.Web.Security.FormsAuthentication.SetAuthCookie(TextBox1.Text, true);

            Response.Redirect("Chat.aspx");
            //Conversation_Helper help = new Conversation_Helper(TextBox3.Text, TextBox1.Text, TextBox2.Text);
            //var res = help.GetResponse("Hello", context).GetAwaiter().GetResult();
            //try
            //{
            //    var login_message = JsonConvert.DeserializeObject(res).output.text[0].ToString();
            //    if (login_message.Contains("Hello"))
            //        Response.Write("<script>alert('Welcome');</script>");
            //}
            //catch
            //{
            //    Response.Write("<script>alert('Wrong Username/Password/Workspace, Please try again');</script>");
            //}

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = null;
            TextBox2.Text = null;
            TextBox3.Text = null;
        }
    }

}
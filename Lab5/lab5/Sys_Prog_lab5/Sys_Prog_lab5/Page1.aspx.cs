using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sys_Prog_lab5
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Page5.aspx?email=" + email.Text);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Page2.aspx?email="+ email.Text + "&name=" + name.Text);
        }
    }
}
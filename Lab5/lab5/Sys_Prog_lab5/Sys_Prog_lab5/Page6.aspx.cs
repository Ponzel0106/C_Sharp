using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sys_Prog_lab5
{
    public partial class Page6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Button1.Text = "Вилучити замовлення " + Request.QueryString["id"];
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Page5.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string QueryText = "DELETE FROM [Avia_Lab3] WHERE [ID] = " + Request.QueryString["id"];
                string DB = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Avia_Lab;Integrated Security=True";
                using (SqlConnection Conn = new SqlConnection(DB))
                {
                    Conn.Open();
                    SqlCommand Comm = new SqlCommand(QueryText, Conn);
                    SqlDataReader R = Comm.ExecuteReader();
                }
                Page3.SendMessage("Замовлення з ID = " + Request.QueryString["id"] + "вилучено.", Request.QueryString["email"]);
                Response.Redirect("~/Page7.aspx?id=" + Request.QueryString["id"]);
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }
    }
}
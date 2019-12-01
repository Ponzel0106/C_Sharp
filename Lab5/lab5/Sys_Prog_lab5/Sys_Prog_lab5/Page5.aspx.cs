using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sys_Prog_lab5
{
    public partial class Page5 : System.Web.UI.Page
    {
        string[] celsnames = new string[] { "ID", "Name", "From", "To", "Price", "BuisnessClass", "ChildNumber", "AdultNumber", "One way","Photo", "DepartDate", "ReturnDate", "E-mail", "ChildTicket" };
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string QueryText = "select * from [dbo].[Avia_Lab3]";
                string DB = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Avia_Lab;Integrated Security=True";
                using (SqlConnection Conn = new SqlConnection(DB))
                {
                    Conn.Open();
                    SqlCommand Comm = new SqlCommand(QueryText, Conn);
                    SqlDataReader R = Comm.ExecuteReader();
                    TableRow tr1 = new TableRow();
                    TableCell[] tablehead = new TableCell[14];
                    Label[] thl = new Label[14];
                    for (int i = 0; i < celsnames.Length - 1; i++)
                    {
                        tablehead[i] = new TableCell();
                        thl[i] = new Label();
                        thl[i].Text = celsnames[i];
                        tablehead[i].Controls.Add(thl[i]);
                        tr1.Cells.Add(tablehead[i]);
                    }

                    Table1.Rows.Add(tr1);

                    while (R.Read())
                    {
                        TableRow tr2 = new TableRow();
                        TableCell[] tablehead2 = new TableCell[14];
                        Label[] thl2 = new Label[14];
                        for (int i = 0; i < celsnames.Length - 1; i++)
                        {
                            if(i != 9)
                            {
                                tablehead2[i] = new TableCell();
                                thl2[i] = new Label();
                                thl2[i].Text =R[i].ToString();
                                tablehead2[i].Controls.Add(thl2[i]);
                                tr2.Cells.Add(tablehead2[i]);
                            }
                            else
                            {
                                tablehead2[i] = new TableCell();
                                Image im = new Image();
                                im.ImageUrl = "~/User Photos/" + R[i].ToString();
                                tablehead2[i].Controls.Add(im);
                                tr2.Cells.Add(tablehead2[i]);
                            }
                        }

                        Table1.Rows.Add(tr2);

                        Table1.BorderStyle = BorderStyle.Solid;
                        Table1.GridLines = GridLines.Both;

                    }
                }
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Page1.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int s;
            if(int.TryParse(TextBox1.Text, out s))
            {
                Response.Redirect("~/Page6.aspx?id=" + TextBox1.Text + "&email=" + Request.QueryString["email"]);
            }
        }
    }
}
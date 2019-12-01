using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sys_Prog_lab5
{
    public partial class Page2 : System.Web.UI.Page
    {
        string[] cityList = new string[] { "Гамбург", "Київ", "Тбілісі", "Шарм - ель - Шейх" };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (From.Items.Count == 0)
            {
                TextBox2.Text = Request.QueryString["name"].ToString();
                foreach (string item in cityList)
                {
                    From.Items.Add(new ListItem(item));
                    To.Items.Add(new ListItem(item));
                }
                From.SelectedIndex = 1;
                To.Items.Remove("Київ");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Page1.aspx");
        }

        protected void From_TextChanged(object sender, EventArgs e)
        {
            //var a = To.SelectedValue;
            //To.Items.Clear();
            //foreach (string item in cityList)
            //{
            //    if (item != From.Text)
            //    {
            //        To.Items.Add(new ListItem(item));
            //    }
            //}
            //To.SelectedValue = a;
            if (From.Text == "Київ")
            {
                To.Items.Clear();
                foreach (string item in cityList)
                {
                    if (item != From.Text)
                    {
                        To.Items.Add(new ListItem(item));
                    }
                }
            }
            else
            {
                To.Items.Clear();
                To.Items.Add(new ListItem("Київ"));
            }
        }

        protected void To_TextChanged(object sender, EventArgs e)
        {
            //var a = From.SelectedValue;
            //From.Items.Clear();
            //foreach (string item in cityList)
            //{
            //    if (item != To.Text)
            //    {
            //        From.Items.Add(new ListItem(item));
            //    }
            //}
            //From.SelectedValue = a;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string dname = PhotoUpload.PostedFile.FileName.Substring(PhotoUpload.PostedFile.FileName.LastIndexOf("\\") + 1);
            if (dname != "")
                PhotoUpload.PostedFile.SaveAs(@"C:\Users\maksy\OneDrive\Документы\2.2 курс\Petrovich\Lab5\lab5\Sys_Prog_lab5\Sys_Prog_lab5\User Photos" + dname);
            Response.Redirect("~/Page3.aspx?photoUrl=~/User Photos/" + dname + "&name=" + TextBox2.Text + "&route=" + From.Text + "*" + To.Text + "&dday=" + dateTransform(TextBox3.Text, TextBox4.Text, TextBox5.Text) + "&rday=" + dateTransform(TextBox6.Text, TextBox7.Text, TextBox8.Text) + "&email=" + Request.QueryString["email"].ToString());
            //
        }
        private string dateTransform(string day, string month, string year)
        {
            string res = month + "/" + day + "/" + year;
            if (res.Length < 7)
                return "1/1/1000";
            return res;
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == 1)
            {
                TextBox6.Enabled = false;
                TextBox7.Enabled = false;
                TextBox8.Enabled = false;
            }
            else
            {
                TextBox6.Enabled = true;
                TextBox7.Enabled = true;
                TextBox8.Enabled = true;
            }
        }
    }
}
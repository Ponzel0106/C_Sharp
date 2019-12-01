using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sys_Prog_lab5
{
    public partial class Page3 : System.Web.UI.Page
    {
        static int childnum;
        static int adultnum;
        string route = "";
        static double summ = 0;
        private string[] price = new string[] { "Гамбург*Київ_1000", "Тбілісі*Київ_1500", "Шарм - ель - Шейх*Київ_2000", "Київ*Гамбург_1000", "Київ*Тбілісі_1500", "Київ*Шарм - ель - Шейх_2000" };
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = Request.QueryString["name"];
            Image.ImageUrl = Request.QueryString["photoUrl"];
            route = Request.QueryString["route"];
            if (!IsPostBack)
            {
                childnum = 0;
                adultnum = 0;
                TextBox1.Text = "0";
                TextBox2.Text = "0";
            }
            RecalcSumm();
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Page2.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            childnum++;
            TextBox1.Text = childnum.ToString();
            RecalcSumm();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if(childnum > 0)
            {
                childnum--;
                TextBox1.Text = childnum.ToString();
                RecalcSumm();
            }
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            adultnum++;
            TextBox2.Text = adultnum.ToString();
            RecalcSumm();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if(adultnum > 0)
            {
                adultnum--;
                TextBox2.Text = adultnum.ToString();
                RecalcSumm();
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == 0)
            {
                RadioButtonList2.Enabled = true;
                CheckBox1.Enabled = true;
            }
            else
            {
                RadioButtonList2.Enabled = false;
                CheckBox1.Enabled = false;
            }
            RecalcSumm();
        }
        private void RecalcSumm()
        {
            foreach (var r in price)
            {
                if (r.Split('_')[0] == route)
                {
                    summ = Convert.ToInt32(r.Split('_')[1]);
                    break;
                }
            }
            double adsu = summ;
            if (RadioButtonList2.SelectedIndex == 0 && RadioButtonList2.Enabled)
                summ *= 0.8;
            if (CheckBox1.Checked && CheckBox1.Enabled)
                summ *= 1.25;
            if (RadioButtonList1.SelectedIndex == 1)
            {
                summ *= 3;
                summ += adultnum * adsu * 2.5;
                summ += childnum * adsu * 2.5 * 0.7;
            }
            else
            {
                summ += adultnum * adsu;
                summ += childnum * adsu * 0.7;
            }
            Label6.Text = "Вартість замовлення = " + summ.ToString() + " грн";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            int oway = 0;
            if (Request.QueryString["rday"].ToString() == "1/1/1000")
                  oway = 1;
            string QueryText = "INSERT [dbo].[Avia_Lab3] ([Name],[From],[To],[Price],[BuisnessClass],[ChildNumber],[AdultNumber],[One way],[Photo],[DepartDate],[ReturnDate],[E-mail],[ChildTicket])  VALUES('" + Request.QueryString["name"] + "', N'" + route.Split('*')[0] + "', N'" + route.Split('*')[1] + "', "+summ.ToString()+", "+RadioButtonList1.SelectedIndex.ToString()+ ", "+childnum.ToString()+ ", "+adultnum.ToString()+", "+oway.ToString()+ " , '"+ Request.QueryString["photoUrl"].Substring(Request.QueryString["photoUrl"].LastIndexOf("/") + 1) + "',CONVERT(DATE, '"+ Request.QueryString["dday"].ToString() + "'), CONVERT(DATE, '" + Request.QueryString["rday"].ToString() + "'), '"+ Request.QueryString["email"].ToString() + "', " + RadioButtonList2.SelectedIndex.ToString()+")";
            string DB = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Avia_Lab;Integrated Security=True";
            using (SqlConnection Conn = new SqlConnection(DB))
            {
                Conn.Open();
                SqlCommand Comm = new SqlCommand(QueryText, Conn);
                SqlDataReader R = Comm.ExecuteReader();
            }
            SendMessage("Ви придбвли квиток та можете подивитися інформацію про нього на сайті в розділі \"Існуючі\"", Request.QueryString["email"].ToString());
            Response.Redirect("~/Page4.aspx");
        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            RecalcSumm();
        }
        public static void SendMessage(string message, string to)
        {
            to = "3marsd@gmail.com";
            string from = "3marsd@gmail.com";
            string passw = "Dkflbvbh2002";
            NetworkCredential loginInfo = new NetworkCredential(from, passw);
            MailMessage msg = new MailMessage();
            //SmtpClient smtpClient = new SmtpClient("aspmx.l.google.com", 587);
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            msg.From = new MailAddress(from);
            msg.To.Add(new MailAddress(to));
            msg.Subject = "Лист від компанії \"Крутий штопор\"!";
            msg.Body = message;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(msg);
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Zavd7
{
    public partial class Form1 : Form
    {
        public DataTable T;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string DB = @"Data Source=(LocalDB)\MSSQLLocalDB; Initial Catalog=Shipping; Integrated Security=True";
            string Query = "select * from  Cargo ";
            using (SqlConnection Conn = new SqlConnection(DB))
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                Conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(Query, DB);
                da.Fill(ds);
                T = ds.Tables[0];
                dgv1.DataSource = T;
            }
        }
    }
}
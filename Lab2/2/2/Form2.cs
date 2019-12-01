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
namespace Infectious
{
    public partial class Form2 : Form
    {
        string DB = @"Data Source=(LocalDB)\MSSQLLocalDB; Initial Catalog=Infectious; Integrated Security=True";

        public Form2()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            textBox1.Enabled = false;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            textBox1.Enabled = true;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Refresh_ComboBox();
            form1.Show();
            this.Hide();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                errorProvider1.Clear();
                errorProvider2.Clear();
                errorProvider3.Clear();
                using (SqlConnection Conn = new SqlConnection(DB))
                {
                    Conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select * " + " from Categorie_of_infectious_disease", DB);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            else if (radioButton2.Checked)
            {
                errorProvider1.Clear();
                errorProvider2.Clear();
                errorProvider3.Clear();
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    errorProvider2.SetError(textBox2, "Не вказано Name");
                }
                else if (string.IsNullOrEmpty(textBox3.Text))
                {
                    errorProvider3.SetError(textBox3, "Потрібен опис");
                }
                else
                {
                    errorProvider2.Clear();
                    errorProvider3.Clear();
                    using (SqlConnection Conn = new SqlConnection(DB))
                    {
                        Conn.Open();
                        SqlCommand cmd = Conn.CreateCommand();
                        cmd.CommandText = "insert Infectious.dbo.Categorie_of_infectious_disease " + " values (N'" + textBox2.Text + "', N'" + textBox3.Text + "')";
                        MessageBox.Show("Число доданих записів: " + cmd.ExecuteNonQuery());
                    }
                }
            }
            else if (radioButton3.Checked)
            {
                errorProvider1.Clear();
                errorProvider2.Clear();
                errorProvider3.Clear();
                int id;
                if (int.TryParse(textBox1.Text, out id) && id >= 1)
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        errorProvider2.SetError(textBox2, "Не вказано Name");
                    }
                    else if (string.IsNullOrEmpty(textBox3.Text))
                    {
                        errorProvider3.SetError(textBox3, "Потрібен опис");
                    }

                    else
                    {
                        errorProvider1.Clear();
                        errorProvider2.Clear();
                        errorProvider3.Clear();
                        using (SqlConnection Conn = new SqlConnection(DB))
                        {
                            Conn.Open();
                            SqlCommand cmd = Conn.CreateCommand();
                            cmd.CommandText = "update Infectious.dbo.Categorie_of_infectious_disease " + " set Name = N'" + textBox2.Text + "', Description = N'" + textBox3.Text + "' where ID = " + textBox1.Text;
                            MessageBox.Show("Число оновлених записів: " + cmd.ExecuteNonQuery());
                        }
                    }
                }
                else
                {
                    errorProvider1.SetError(textBox1, "Невірно вказаний ID. Вкажіть ціле число, більше за нуль!");
                }
                   
            }
            
            else
            {
                errorProvider2.Clear();
                errorProvider3.Clear();
                int id;
                if (int.TryParse(textBox1.Text, out id) && id >= 1)
                {
                    errorProvider1.Clear();
                    using (SqlConnection Conn = new SqlConnection(DB))
                    {
                        Conn.Open();
                        SqlCommand cmd = Conn.CreateCommand();
                        cmd.CommandText = "delete from Infectious.dbo.Categorie_of_infectious_disease " + " where ID = " + textBox1.Text;
                        MessageBox.Show("Число вилучених записів: " + cmd.ExecuteNonQuery());
                    }
                }
                else
                {
                    errorProvider1.SetError(textBox1, "Невірно вказаний ID. Вкажіть ціле число, більше за нуль!");
                }
            }
        }
    }
}

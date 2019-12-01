using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Infectious
{
    public partial class Form1 : Form
    {
        public DataRowCollection Categorie_List;
        string DB = "server=192.168.67.128; port=3306; database=Infectious; user=root; password=1234567890; charset=utf8";

        public Form1()
        {
            InitializeComponent();
            using (MySqlConnection Conn = new MySqlConnection(DB))
            {
                Conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from Categorie_of_infectious_disease", DB);
                DataSet ds = new DataSet();
                da.Fill(ds);
                bool checker1 = false;
                bool checker2 = false;
                foreach (DataRow i in ds.Tables[0].Rows)
                {

                    if (i.ItemArray[1].ToString() == "Епідемії" && i.ItemArray[2].ToString() == "масове поширення інфекційної хвороби серед населення відповідної території за короткий проміжок часу")
                    {
                        checker1 = true;
                    }
                    if (i.ItemArray[1].ToString() == "Грибкові захворювання‎" && i.ItemArray[2].ToString() == "Опис")
                    {
                        checker2 = true;
                    }
                }
                if (!checker1 || !checker2)
                {
                    MySqlCommand cmd = Conn.CreateCommand();
                    if (!checker1)
                    {
                        cmd.CommandText = "insert into Categorie_of_infectious_disease(Name, Description) " + " values ('Епідемії','масове поширення інфекційної хвороби серед населення відповідної території за короткий проміжок часу')";
                        cmd.ExecuteNonQuery();
                    }
                    if (!checker2)
                    {
                        cmd.CommandText = "insert into Categorie_of_infectious_disease(Name, Description) " + " values ('Грибкові захворювання‎', 'Опис')";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            Refresh_ComboBox();
        }
        public void Refresh_ComboBox()
        {
            comboBox1.Items.Clear();
            using (MySqlConnection Conn = new MySqlConnection(DB))
            {
                Conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from Categorie_of_infectious_disease", DB);
                DataSet ds = new DataSet();
                da.Fill(ds);
                Categorie_List = ds.Tables[0].Rows;
                foreach (DataRow i in Categorie_List)
                {
                    comboBox1.Items.Add(i.ItemArray[1].ToString());
                }
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            comboBox1.Enabled = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            comboBox1.Enabled = true;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            comboBox1.Enabled = true;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            comboBox1.Enabled = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
            }
            textBox1.Enabled = false;
            comboBox1.Enabled = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
            }
            textBox1.Clear();
            textBox1.Enabled = true;
            comboBox1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (checkBox1.Checked)
                {
                    string id = null; ;
                    foreach (DataRow i in Categorie_List)
                    {
                        if (i.ItemArray[1].ToString() == comboBox1.Text)
                        {
                            id = i.ItemArray[0].ToString();
                            break;
                        }
                    }
                    if (id != null)
                    {
                        using (MySqlConnection Conn = new MySqlConnection(DB))
                        {
                            Conn.Open();
                            MySqlDataAdapter da = new MySqlDataAdapter("select * " + " from Infectious_disease as I_d " + " where I_d.Categorie_ID = " + id, DB);
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            dataGridView1.DataSource = ds.Tables[0];
                        }
                    }
                    else
                    {
                        errorProvider5.SetError(comboBox1, "Вкажіть категорію із запропонованого списку!");
                    }
                }
                else if (checkBox2.Checked)
                {
                    int id;

                    if (int.TryParse(textBox1.Text, out id) && id >= 1)
                    {
                        errorProvider1.Clear();
                        using (MySqlConnection Conn = new MySqlConnection(DB))
                        {
                            Conn.Open();
                            MySqlDataAdapter da = new MySqlDataAdapter("select * " + "from Infectious_disease AS I_d " + " where I_d.ID = " + textBox1.Text, DB);
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            dataGridView1.DataSource = ds.Tables[0];
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(textBox1, "Невірно вказаний ID. Вкажіть ціле число, більше за нуль!");
                    }
                }
                else
                {
                    using (MySqlConnection Conn = new MySqlConnection(DB))
                    {
                        Conn.Open();
                        MySqlDataAdapter da = new MySqlDataAdapter(" select * " + "from Infectious_disease AS I_d " + " INNER JOIN Categorie_of_infectious_disease as CoID " + " on I_d.Categorie_ID = CoID.ID", DB);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
            }
            else if (radioButton2.Checked)
            {
                if (!String.IsNullOrEmpty(textBox2.Text)) errorProvider1.Clear(); else errorProvider1.SetError(textBox2, "Введіть назву хвороби");
                if (!String.IsNullOrEmpty(textBox3.Text)) errorProvider2.Clear(); else errorProvider2.SetError(textBox3, "Введіть рівень небезпеки");
                if (!String.IsNullOrEmpty(textBox4.Text)) errorProvider3.Clear(); else errorProvider3.SetError(textBox4, "Введіть скільки проходить інкубаційний період");
                if (!String.IsNullOrEmpty(textBox5.Text)) errorProvider4.Clear(); else errorProvider4.SetError(textBox5, "Введіть спосіб зараження");
                string categorie_id = null; ;
                foreach (DataRow i in Categorie_List)
                {
                    if (i.ItemArray[1].ToString() == comboBox1.Text)
                    {
                        categorie_id = i.ItemArray[0].ToString();
                        break;
                    }
                }
                if (categorie_id != null) errorProvider5.Clear(); else errorProvider5.SetError(comboBox1, "Виберіть категорію");
                if (errorProvider1.GetError(textBox2) == "" && errorProvider2.GetError(textBox3) == "" && errorProvider3.GetError(textBox4) == "" && errorProvider4.GetError(textBox5) == "" && errorProvider5.GetError(comboBox1) == "")
                {
                    using (MySqlConnection Conn = new MySqlConnection(DB))
                    {
                        Conn.Open();
                        MySqlCommand cmd = Conn.CreateCommand();
                        cmd.CommandText = "insert into Infectious_disease (Name, ThreatLevel, IncubatoryPeriod, WayOfInfection, Categorie_ID)" + " values (N'" + textBox2.Text + "', N'" + textBox3.Text + "', N'" + textBox4.Text + "', N'" + textBox5.Text + "', " + categorie_id + ")";
                        MessageBox.Show("Число доданих записів: " + cmd.ExecuteNonQuery());
                    }
                }
            }
            else if (radioButton3.Checked)
            {
                int id;
                string category = null;
                if (!String.IsNullOrEmpty(textBox2.Text)) errorProvider1.Clear(); else errorProvider1.SetError(textBox2, "Введіть назву інфекції");
                if (!String.IsNullOrEmpty(textBox3.Text)) errorProvider2.Clear(); else errorProvider2.SetError(textBox3, "Введіть рівень небезпеки");
                if (!String.IsNullOrEmpty(textBox4.Text)) errorProvider3.Clear(); else errorProvider3.SetError(textBox4, "Введіть інкубаційний період");
                if (!String.IsNullOrEmpty(textBox5.Text)) errorProvider4.Clear(); else errorProvider4.SetError(textBox5, "Введіть спосіб зараження");
                if (int.TryParse(textBox1.Text, out id) && id >= 1) errorProvider5.Clear(); else errorProvider5.SetError(textBox1, "Введіть id цифрами більше чим 0");
                foreach (DataRow i in Categorie_List)
                {
                    if (i.ItemArray[1].ToString() == comboBox1.Text)
                    {
                        category = i.ItemArray[0].ToString();
                        break;
                    }
                }
                if (category != null) errorProvider6.Clear(); else errorProvider6.SetError(comboBox1, "Виберіть катeгорію");
                if (errorProvider1.GetError(textBox2) == "" && errorProvider2.GetError(textBox3) == "" && errorProvider3.GetError(textBox4) == "" && errorProvider4.GetError(textBox5) == "" && errorProvider6.GetError(comboBox1) == "" && errorProvider5.GetError(textBox1) == "")
                {
                    using (MySqlConnection Conn = new MySqlConnection(DB))
                    {
                        Conn.Open();
                        MySqlCommand cmd = Conn.CreateCommand();
                        cmd.CommandText = "update Infectious_disease " + " set Name = '" + textBox2.Text + "', ThreatLevel = '" + textBox3.Text + "', IncubatoryPeriod = '" + textBox4.Text + "', WayOfInfection = '" + textBox5.Text + "', Categorie_ID = '" + category + "' where ID = " + textBox1.Text;
                        MessageBox.Show("Число оновлених записів: " + cmd.ExecuteNonQuery());
                    }
                }
            }
            else
            {
                int id;
                if (int.TryParse(textBox1.Text, out id) && id >= 1)
                {
                    errorProvider1.Clear();
                    using (MySqlConnection Conn = new MySqlConnection(DB))
                    {
                        Conn.Open();
                        MySqlCommand cmd = Conn.CreateCommand();
                        cmd.CommandText = "delete from Infectious_disease " + " where ID = " + id;
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

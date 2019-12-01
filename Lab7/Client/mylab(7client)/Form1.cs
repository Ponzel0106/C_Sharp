using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mylab_7client_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ServiceReference2.Service1Client work = new ServiceReference2.Service1Client())
            {
                label1.Text = work.F4(Convert.ToDouble(textBox1.Text)).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (ServiceReference2.Service1Client worker = new ServiceReference2.Service1Client())
            {
                dataGridView1.DataSource = worker.GetAllMembers().Tables[0];
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (ServiceReference2.Service1Client worker = new ServiceReference2.Service1Client())
            {
                dataGridView1.DataSource = worker.GetMemberByID(Convert.ToInt32(textBox2.Text)).Tables[0];
            }
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client2_Lab7_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ServiceReference1.Service1Client worker = new ServiceReference1.Service1Client())
            {
                label1.Text = Convert.ToString(worker.IsLoginFree(textBox1.Text));
                label2.Text = worker.MyIPAddress();
            }
        }
    }
}

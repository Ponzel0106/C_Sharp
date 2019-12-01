using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zavd6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Ponzel"))
            {
                string mes = "";
                string[] s = (string[])key.GetValue("P5");
                for (int i = 0; i < s.Length; i++)
                {
                    mes = mes + s[i] + Environment.NewLine;
                }
                key.Close();
                MessageBox.Show(mes);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Ponzel");
            key.SetValue("P6", new string[] { "Я - студент" + "\r\n" + "кафедри КІ!" }, RegistryValueKind.MultiString);
            key.Close();
            MessageBox.Show("Дані додано успішно!");
        }
    }
}

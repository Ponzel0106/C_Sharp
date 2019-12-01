
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Diagnostics;
using System.Threading;

namespace Client
{
    public partial class Form1 : Form
    {
        [Serializable]
        public class FileDetails
        {
            public string FILETYPE = "";
            public long FILESIZE = 0;
        }

        private static FileDetails fileDet = new FileDetails();

        // Поля, связанные с UdpClient
        private const int remotePort = 49000;
        private static string serverIp = "10.0.65.106";
        private string filePath = @"file1.xml";
       


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.comboBox2.Items.Clear();
            label1.Text = "";
            comboBox2.Enabled = true;
            try
            {
                CreateXML("request", comboBox1.Items.IndexOf(comboBox1.SelectedItem).ToString());
                Adder(Connect(),true);
            }
            catch (Exception f)
            {
                label1.Text = f.ToString();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = null;
            try
            {
                CreateXML("surname", comboBox2.Text);
                Adder(Connect(), false);
            }
            catch (Exception f)
            {
                label1.Text = f.ToString();
            }
        }
        private void Combobox1(object sender, EventArgs e)
        {
            button1.Enabled = true;
            label1.Text = "";
            comboBox2.Text = null;
            button2.Enabled = false;
            this.comboBox2.Items.Clear();

        }
        private void Combobox11(object sender, EventArgs e)
        {
            comboBox2.Enabled = false;
            comboBox2.Text = null;

        }
        private void Combobox2(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void CreateXML(string type, string text)
        {


            XmlDocument doc = new XmlDocument();
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
            doc.RemoveAll();
            XmlElement xRoot = doc.DocumentElement;
            XmlElement element = doc.CreateElement("REQUESTS");
            XmlElement currentKey = doc.CreateElement(type);
            XmlText currentKeyText = doc.CreateTextNode(text);
            currentKey.AppendChild(currentKeyText);
            element.AppendChild(currentKey);
            doc.AppendChild(element);
            doc.Save(filePath);
                
        }
        public XmlDocument Connect()
        {
            string F = File.ReadAllText(filePath, Encoding.UTF8);
            byte[] M = Encoding.UTF8.GetBytes(F);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(serverIp), Convert.ToInt32(remotePort));
            byte[] bytes = new byte[1000000];
            XmlDocument xml = new XmlDocument();
            using (Socket S = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                S.ReceiveTimeout = 2500;
                S.Connect(ipEndPoint);
                S.Send(M);
                int bytesRec = S.Receive(bytes);
                    xml.LoadXml(Encoding.UTF8.GetString(bytes));
                    xml.Save(filePath);
                    S.Shutdown(SocketShutdown.Both);
                    return xml;
            }
        }
        public void Adder(XmlDocument doc, bool N)
        {

            // comboBox2.Items.Add( "");
            XmlElement xRoot = doc.DocumentElement;
            if (xRoot.HasChildNodes)
            {
                for (int i = 0; i < xRoot.ChildNodes.Count; i++)
                {
                    if(N)
                    comboBox2.Items.Add(xRoot.ChildNodes[i].InnerText);
                    label1.Text += xRoot.ChildNodes[i].InnerText + Environment.NewLine;
                }
            }
            else
                label1.Text = "Таких людей немає";
        }
    }

    }


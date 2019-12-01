using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Xml.Serialization;
using System.Xml;
using System.Threading;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using static Microsoft.Win32.RegistryKey;

namespace WindowsService4._0
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        private bool triger;
        const int CHAP_PORT = 49000;
        UdpClient client;
        private string filePath = @"C:\Users\maksy\OneDrive\Документы\2.2 курс\Petrovich\Laba4\SERVICE\file1.xml";
        Thread T;
        protected override void OnStart(string[] args)
        {

            T = new Thread(WorkerThread);
            T.Start();
        }
        void WorkerThread()
        {
            //Debugger.Launch();
            IPEndPoint targetEP = new IPEndPoint(IPAddress.Any, CHAP_PORT);
            client = new UdpClient(CHAP_PORT);
            byte[] buffer = client.Receive(ref targetEP);
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.LoadXml(Encoding.UTF8.GetString(buffer));
                xml = CheckRequest(xml);
                xml.Save(filePath);
            }
            catch (XmlException ex)
            {

            }
            buffer = Encoding.UTF8.GetBytes(xml.OuterXml);
            client.Send(buffer, buffer.Length, targetEP);
            client.Close();
            WorkerThread();

        }
        private XmlDocument CheckRequest(XmlDocument doc)
        {
            XmlElement xRoot = doc.DocumentElement;

            string curKey;


            curKey = xRoot.ChildNodes[0].InnerText;
            doc.RemoveAll();




            using (RegistryKey v = OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\SEARCH-Server"))
            {
                string temp;
                Regex regex = new Regex(Cases(curKey));
                XmlElement element = doc.CreateElement("ANSWER");
                bool ZX = true;
                for (int i = 0; i < v.GetValueNames().Length; i++)
                {
                    temp = v.GetValue(v.GetValueNames()[i]).ToString();

                    string matches = regex.Match(temp).ToString();
                    if (!String.IsNullOrEmpty(matches))
                    {
                        ZX = false;
                        XmlElement currentKey = doc.CreateElement($"SurName{i + 1}");
                        if (triger)
                        {
                            XmlText currentKeyText = doc.CreateTextNode(temp);
                            currentKey.AppendChild(currentKeyText);
                        }
                        else
                        {
                            XmlText currentKeyText = doc.CreateTextNode(Regex.Split(temp, @"\s")[0]);
                            currentKey.AppendChild(currentKeyText);
                        }
                        element.AppendChild(currentKey);
                        doc.AppendChild(element);
                    }
                }
                if (ZX)
                {
                    doc.AppendChild(element);
                }
            }
            return doc;

        }


        public string Cases(string temp)
        {
            string rr = "";
            //int temp1 = int.Parse();
            if (Int32.TryParse(temp, out int temp1))
            {
                switch (temp1)
                {
                    case 0:
                        rr = @"А[а-еж-щюяїієґ]{0,15}'?[а-еж-щюяїієґ]{1,15}";
                        break;
                    case 1:
                        rr = @"А\s";
                        break;
                    case 2:
                        rr = @"[А-ЕЖЗЙ-ЩЮЯЇІЄҐ][а-еж-щюяїієґ]{1,15}'?[а-еж-щюяїієґ]{2,15}ов\s[А-ЕЖЗЙ-ЩЮЯЇІЄҐ][а-еж-щюяїієґ]{0,15}'?[а-еж-щюяїієґ]{1,15}";
                        break;
                    case 3:
                        rr = @"\w";
                        break;
                }
                triger = false;
                return rr;
            }
            else
            {
                triger = true;
                return temp;
            }
        }

        protected override void OnStop()
        {
        }
    }
}

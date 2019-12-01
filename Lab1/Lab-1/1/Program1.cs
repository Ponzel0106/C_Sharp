using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Win32;
using System.IO;
namespace SysProga1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                string arg1 = args[0].ToLower();
                string arg2 = args[1].ToLower();
                using (WebClient W = new WebClient())
                {
                    W.DownloadFile("ftp://ftp.univ.kiev.ua/pub/linux/centos/build/rpmcompare5.pl.txt", @"C:\Users\maksy\OneDrive\Документы\2.2 курс\Petrovich\rpmcompare5.pl.txt");
                }
                using (StreamReader sr = new StreamReader(File.OpenRead(@"C:\Users\maksy\OneDrive\Документы\2.2 курс\Petrovich\rpmcompare5.pl.txt")))
                {
                    using (StreamWriter sw = new StreamWriter(File.Open(@"C:\Users\maksy\OneDrive\Документы\2.2 курс\Petrovich\RpmCompare-LIGHT.txt", FileMode.Create)))
                    {
                        string CurLine;
                        string[] split;
                        int counter;
                        bool cheker1;
                        bool cheker2;
                        string ls;
                        while (!sr.EndOfStream)
                        {
                            cheker1 = false;
                            cheker2 = false;
                            counter = 0;
                            CurLine = sr.ReadLine();
                            split = CurLine.Split(new String[] { "\t", " " }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string s in split)
                            {
                                ls = s.ToLower();
                                if (ls.Contains(arg1) || (counter == 0 && ls.StartsWith("#")))
                                {
                                    cheker1 = true;
                                }
                                else if (ls.Contains("="))
                                {
                                    cheker2 = true;
                                }
                                counter++;
                            }
                            if (cheker1)
                            {

                            }
                            else if (cheker2)
                            {
                                sw.WriteLine(arg2);
                            }
                            else
                            {
                                sw.WriteLine(CurLine);
                            }
                            
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("SYNTAX: SysProga1.exe <Arg1> <Arg2>");
            }
        }
    }
}

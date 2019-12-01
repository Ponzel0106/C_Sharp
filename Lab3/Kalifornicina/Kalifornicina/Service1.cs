using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using System.IO;
using Microsoft.Win32;
using static Microsoft.Win32.RegistryKey;
using System.Text.RegularExpressions;

namespace Kalifornicina
{
    public partial class Service1 : ServiceBase
    {
        private static string LogPath = @"C:\Windows\Logs\TaskQueue_" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".log";
        private const string PIDsPath = @"C:\Windows\Task_Queue\PIDs.txt";
        private const string ParametersRegPath = @"SOFTWARE\Task_Queue\Parameters";
        private const string ClaimCheckPeriod = "Task_Claim_Check_Period";

        private static int ExecutionQuantity = GetParametr("Task_Execution_Quantity");
        private static int ExecutionDuration = GetParametr("Task_Execution_Duration");
        private static Queue<MyProcess> ProcessQueue = new Queue<MyProcess>();
        private static Thread firstThread, secondThread;
        private static List<MyProcess> ProcessesInProgress = new List<MyProcess>();

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            CreateFile(LogPath);
            CreateFile(PIDsPath);

            //Створюємо та запускаємо два паралельних процеси
            firstThread = new Thread(FirstThread);
            secondThread = new Thread(SecondThread);
            firstThread.Start();
            secondThread.Start();
        }

        protected override void OnStop()
        {
        }

        private static void CreateFile(string path)
        {
            if (!File.Exists(path))
            {
                if (path == PIDsPath)
                {
                    using (StreamWriter sw = File.AppendText(PIDsPath))
                    {
                        sw.WriteLine("==CLAIMS and TASKS==");
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(LogPath))
                    {
                    }
                }
            }
        }

        //Перший процес 
        private static void FirstThread()
        {
            System.Timers.Timer timer = new System.Timers.Timer(GetParametr(ClaimCheckPeriod) * 1000);
            timer.Elapsed += ChooseProcess;
            timer.Start();
        }

        private static int GetParametr(string name)
        {
            RegistryKey paramsKey = OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(ParametersRegPath);
            if (paramsKey == null)
            {
                switch (name)
                {
                    case "Task_Execution_Duration":
                        return 60;
                    case ClaimCheckPeriod:
                        return 30;
                    case "Task_Execution_Quantity":
                        return 1;
                    default:
                        return -1;
                }
            }
            else
            {
                int val = (int)paramsKey.GetValue(name);
                switch (name)
                {
                    case "Task_Execution_Duration":
                        if (30 <= val && val <= 180)
                        {
                            return val;
                        }
                        else
                        {
                            return 60;
                        }
                    case ClaimCheckPeriod:
                        if (10 <= val && val <= 45)
                        {
                            return val;
                        }
                        else
                        {
                            return 30;
                        }
                    case "Task_Execution_Quantity":
                        if (1 <= val && val <= 3)
                        {
                            return val;
                        }
                        else
                        {
                            return 1;
                        }
                    default:
                        return val;
                }
            }
        }

        //Виявляє та послідовно обробляє заявки одну за одною в залежності від  коректності кожної з них
        private static void ChooseProcess(object sender, EventArgs e)
        {
            List<Process> chooseProcess = new List<Process>();
            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName == "wordpad")
                {
                    chooseProcess.Add(theprocess);
                }
                else if (theprocess.ProcessName == "mspaint")
                {
                    using (StreamWriter sw = File.AppendText(LogPath))
                    {
                        sw.WriteLine("-----------------------------------------<" + DateTime.Now + ">----------------------------------------------------------------");
                        sw.WriteLine("Помилка!!! Некорректна заявка (mspaint) ProcessId=" + theprocess.Id);
                    }
                    theprocess.Kill();
                }
            }
            if (chooseProcess.Count() == 1)
            {
                Processing(chooseProcess[0]);
            }
            else if (chooseProcess.Count() > 1)
            {
                Process minProcessById = chooseProcess[0];
                foreach (Process process in chooseProcess)
                {
                    if (minProcessById.Id > process.Id)
                    {
                        minProcessById = process;
                    }
                }
                Processing(minProcessById);
            }
        }

        //Обробка
        private static void Processing(Process theprocess)
        {
            string theprocessId = CorrectId(theprocess);
            if (CheckIdInQueue(theprocessId))
            {
                Process newProcessNotepad = Process.Start("notepad.exe"); //запускаємо новий процес блокнот
                MyProcess myprocess = new MyProcess(theprocessId, newProcessNotepad);
                ProcessQueue.Enqueue(myprocess);
                using (StreamWriter sw = File.AppendText(LogPath))
                {
                    sw.WriteLine("-----------------------------------------<" + DateTime.Now + ">----------------------------------------------------------------");
                    sw.WriteLine("Задача Task_" + theprocessId + " успішно прийнята в обробку...");
                }
                theprocess.Kill();
            }
            else
            {
                theprocess.Kill();
            }
        }

        //Перевіряємо чи була така задача з таким номером
        private static bool CheckIdInQueue(string theprocessId)
        {
            using (StreamReader sr = new StreamReader(PIDsPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("wordpad_PID=" + theprocessId))
                        return false;
                }
            }
            return true;
        }

        private static string CorrectId(Process theprocess)
        {
            Regex reg1 = new Regex(@"^[0-9]{3}$");
            Regex reg2 = new Regex(@"^[0-9]{4}$");
            Regex reg3 = new Regex(@"^[0-9]{2}$");
            Regex reg4 = new Regex(@"^[0-9]{1}$");
            if (reg4.IsMatch(theprocess.Id.ToString()))
            {
                return ("0000" + theprocess.Id.ToString());
            }
            if (reg3.IsMatch(theprocess.Id.ToString()))
            {
                return ("000" + theprocess.Id.ToString());
            }
            if (reg1.IsMatch(theprocess.Id.ToString()))
            {
                return ("00" + theprocess.Id.ToString());
            }
            else if (reg2.IsMatch(theprocess.Id.ToString()))
            {
                return ("0" + theprocess.Id.ToString());
            }
            else
                return theprocess.Id.ToString();
        }

        //Другий процес 
        private static void SecondThread()
        {
            System.Timers.Timer timer = new System.Timers.Timer(2000);
            timer.Elapsed += Executing;
            timer.Start();
        }

        //Виконання
        private static void Executing(object sender, EventArgs e)
        {
            while (ProcessesInProgress.Count() < ExecutionQuantity && ProcessQueue.Count() > 0)
            {
                ProcessQueue.Peek().InitialTime = DateTime.Now;
                ProcessesInProgress.Add(ProcessQueue.Dequeue());
            }
            List<string> Text = new List<string>();
            List<MyProcess> RemoveList = new List<MyProcess>();
            using (StreamReader sr = new StreamReader(PIDsPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("==CLAIMS and TASKS==") || line.Contains("COMPLETED"))
                        Text.Add(line);
                }
            }
            foreach (MyProcess i in ProcessesInProgress)
            {
                int secondsNow = (int)Math.Round((DateTime.Now - i.InitialTime).TotalSeconds, MidpointRounding.AwayFromZero);
                if (secondsNow >= ExecutionDuration - 1)
                {
                    Text.Add("wordpad_PID=" + i.Id + "    Notepad_PID=" + CorrectId(i.Notepad) + "    -COMPLETED");
                    using (StreamWriter sw = File.AppendText(LogPath))
                    {
                        sw.WriteLine("-----------------------------------------<" + DateTime.Now + ">----------------------------------------------------------------");
                        sw.WriteLine("Задача Task_" + i.Id + " успішно ВИКОНАНА!");
                    }
                    i.Notepad.Kill();
                    RemoveList.Add(i);
                }
                else
                {
                    Text.Add("wordpad_PID=" + i.Id + "    Notepad_PID=" + CorrectId(i.Notepad) + "    -In progress - " + secondsNow * 100 / ExecutionDuration + " percents");
                }
            }
            foreach (MyProcess j in ProcessQueue)
            {
                Text.Add("wordpad_PID=" + j.Id + "    Notepad_PID=" + CorrectId(j.Notepad) + "    -Queued");
            }
            if (RemoveList.Count > 0)
            {
                foreach (MyProcess i in RemoveList)
                {
                    ProcessesInProgress.Remove(i);
                }
            }
            using (StreamWriter sr = new StreamWriter(PIDsPath))
            {
                foreach (string i in Text)
                {
                    sr.WriteLine(i);
                }
            }
        }
    }

    class MyProcess
    {
        private string id;
        private Process notepad;
        private DateTime initialTime;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public Process Notepad
        {
            get { return notepad; }
            set { notepad = value; }
        }

        public DateTime InitialTime
        {
            get { return initialTime; }
            set { initialTime = value; }
        }
        public MyProcess(string id, Process notepad)
        {
            this.id = id;
            this.notepad = notepad;
        }
    }
}

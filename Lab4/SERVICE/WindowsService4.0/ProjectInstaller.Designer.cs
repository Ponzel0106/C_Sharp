namespace WindowsService4._0
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.servicePetrovich228 = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller1Petrovich228 = new System.ServiceProcess.ServiceInstaller();
            // 
            // servicePetrovich228
            // 
            this.servicePetrovich228.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.servicePetrovich228.Password = null;
            this.servicePetrovich228.Username = null;
            // 
            // serviceInstaller1Petrovich228
            // 
            this.serviceInstaller1Petrovich228.ServiceName = "Petrovich228";
            this.serviceInstaller1Petrovich228.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.servicePetrovich228,
            this.serviceInstaller1Petrovich228});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller servicePetrovich228;
        private System.ServiceProcess.ServiceInstaller serviceInstaller1Petrovich228;
    }
}
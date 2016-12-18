using System;
using System.IO;
using System.ServiceModel;
using System.ServiceProcess;

namespace WindowsService
{
    public partial class WindowsService : ServiceBase
    {
        ServiceHost host;

        public WindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                host = new ServiceHost(typeof(WebService.WebService));
                host.Open();
            }
            catch (Exception e)
            {
                using (FileStream file = new FileStream(@"C:\ErrLog.txt", FileMode.CreateNew))
                {
                    string contents = $"{e.Message} \n\n {e.StackTrace}";
                    byte[] binary = System.Text.Encoding.UTF8.GetBytes(contents);
                    file.Write(binary, 0, binary.Length);
                }
            }
        }

        protected override void OnStop()
        {
            host?.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Commission
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new FrmMain());

            ///////////////////////////////////////////////////////

            //FrmLogin Login = new FrmLogin();
            //if (Login.ShowDialog() == DialogResult.OK)
            //{
            //    Login.Close();
            //    Application.Run(new FrmMain());
            //    //mutex.ReleaseMutex();
            //}
            //else
            //{
            //    Application.Exit();
            //}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new FrmMain());

            FrmLogin Login = new FrmLogin();
            if (Login.ShowDialog() == DialogResult.OK)
            {
                Login.Close();
                Application.Run(new FrmMain());
                //mutex.ReleaseMutex();
            }
            else
            {
                Application.Exit();
            }



            //bool isNew = true;

            //System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out isNew);
            ////System.Threading.Mutex mutex = new System.Threading.Mutex(true, System.Diagnostics.Process.GetCurrentProcess().ProcessName, out isNew);
            //if (isNew)
            //{
            //    Application.EnableVisualStyles();
            //    Application.SetCompatibleTextRenderingDefault(false);

            //    //Application.Run(new FrmMain());

            //    FrmLogin Login = new FrmLogin();
            //    if (Login.ShowDialog() == DialogResult.OK)
            //    {
            //        Login.Close();
            //        Application.Run(new FrmMain());
            //        mutex.ReleaseMutex();
            //    }
            //    else
            //    {
            //        Application.Exit();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show(null, "应用程序已经在运行，不允许同时运行多个相同程序。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    Application.Exit();
            //}
        }
    }
}

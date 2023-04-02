using Frm_ShanLiang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShanLiang
{
    internal static class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //解決傳統的Windows Forms在高解析度（High DPI）設定下，所引發的文字模糊問題
            if (System.Environment.OSVersion.Version.Major >= 6) { SetProcessDPIAware(); }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_Homepage());
            Application.Run(new Frm_StorePage());
            Application.Run(new Frm_StoreSignInPage());
            Application.Run(new Frm_SignupPage());
            Application.Run(new Frm_LoginPage());
            Application.Run(new Frm_MemberPage());
            Application.Run(new Frm_StoreManagerPage());
        }
    }
}

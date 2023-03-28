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
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Frm_Homepage());
            //Application.Run(new Frm_StorePage());
            //Application.Run(new Frm_StoreSignInPage());
            //Application.Run(new Frm_SignInPage());
            //Application.Run(new Frm_LoginPage());
            Application.Run(new Frm_MemberPage());

        }
    }
}

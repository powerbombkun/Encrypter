using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Encrypter
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppSetting.Instance.Load();
            Application.Run(new MainForm());
            AppSetting.Instance.Save();
        }
    }
}

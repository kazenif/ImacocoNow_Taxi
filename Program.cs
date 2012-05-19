using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Threading;

namespace PCGPS
{
    static class Program
    {
        static Form1 form = null;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] arg)
        {
            // ThreadExceptionイベント・ハンドラを登録する
            Application.ThreadException += new
              ThreadExceptionEventHandler(Application_ThreadException);

            // UnhandledExceptionイベント・ハンドラを登録する
            Thread.GetDomain().UnhandledException += new
              UnhandledExceptionEventHandler(Application_UnhandledException); 
            
            SplashForm.ShowSplash();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            form = new Form1();
            form.args = arg;
            Application.Run(form);

        }

        // 未処理例外をキャッチするイベント・ハンドラ
        // （Windowsアプリケーション用）
        public static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ShowErrorMessage(e.Exception, "Application_ThreadExceptionによる例外通知です。");
            Environment.Exit(0);
        }

        // 未処理例外をキャッチするイベント・ハンドラ
        // （主にコンソール・アプリケーション用）
        public static void Application_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                ShowErrorMessage(ex, "Application_UnhandledExceptionによる例外通知です。");
            }
            Environment.Exit(0);
        }

        public static void ShowErrorMessage(Exception ex, string message)
        {
            System.Media.SystemSounds.Hand.Play();

            StringBuilder sb = new StringBuilder();
            sb.Append(message).Append("\r\n");
            sb.Append("---------------------------------------\r\n");
            do
            {
                sb.Append(ex.Message);
                sb.Append("\r\n");
                sb.Append(ex.TargetSite);
                sb.Append("\r\n");
                sb.Append(ex.Source);
                sb.Append("\r\n");
                sb.Append(ex.StackTrace);
                sb.Append("\r\n");
                sb.Append("---------------------------------------\r\n");
                ex = ex.InnerException;
            } while (ex != null);

            ErrorForm fm = new ErrorForm();
            fm.textBox1.Text = sb.ToString();
            fm.chkReboot.Checked = Properties.Settings.Default.RestartOnError;
            fm.chkNeverDisplay.Checked = Properties.Settings.Default.NeverDisplayErrorDialog;
            fm.chkSend.Checked = Properties.Settings.Default.SendError;

            if (!fm.chkNeverDisplay.Checked)
            {
                fm.ShowDialog();

                Properties.Settings.Default.RestartOnError = fm.chkReboot.Checked;
                Properties.Settings.Default.NeverDisplayErrorDialog = fm.chkNeverDisplay.Checked;
                Properties.Settings.Default.SendError = fm.chkSend.Checked;
            }

            if (fm.chkReboot.Checked)
            {
                sb = new StringBuilder();
                if (form.chkAutoPost.Checked)
                {
                    sb.Append("/ap ");
                }
                if (form.chkAutoTwit.Checked)
                {
                    sb.Append("/at ");
                }
                if (form.btnCommOpenClose.Text == "GPS切断")
                {
                    sb.Append("/connect");
                }
                System.Diagnostics.Process.Start(Application.ExecutablePath, sb.ToString());
            }
        }

   }

}
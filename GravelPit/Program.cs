using System.Diagnostics;
using System.Globalization;
using System.Net;

namespace GravelPit
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (File.Exists($"{Environment.GetEnvironmentVariable("APPDATA")}\\GravelPit\\lang.txt"))
            {
                string lang = File.ReadAllText($"{Environment.GetEnvironmentVariable("APPDATA")}\\GravelPit\\lang.txt");

                var newCluture = new CultureInfo(lang);
                newCluture.NumberFormat.NumberDecimalSeparator = ",";

                CultureInfo.CurrentCulture = newCluture;
                CultureInfo.CurrentUICulture = newCluture;
            }
            else
            {
                var newCluture = new CultureInfo("en-EN");
                newCluture.NumberFormat.NumberDecimalSeparator = ",";

                CultureInfo.CurrentCulture = newCluture;
                CultureInfo.CurrentUICulture = newCluture;
            }

            ApplicationConfiguration.Initialize();
            Application.ThreadException += new ThreadExceptionEventHandler(MyCommonExceptionHandlingMethod);
            Application.Run(new Main());
        }
        private static void MyCommonExceptionHandlingMethod(object sender, ThreadExceptionEventArgs t)
        {
            if (t.Exception is HttpRequestException httpException)
            {
                MessageBox.Show("Can't connect to the main server.\n\n" + t.Exception.Message + "\n\n" + t.Exception.StackTrace);
                return;
            }

            MessageBox.Show(t.Exception.Message + "\n\n" + t.Exception.StackTrace);
        }
    }
}
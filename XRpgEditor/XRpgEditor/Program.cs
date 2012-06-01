using System;
using System.Windows.Forms;

namespace XRpgEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
        	Application.SetCompatibleTextRenderingDefault(false);
			using (var form = new FormMain())
				Application.Run(form);
        }
    }
}


using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;

#if WINDOWS
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using F16Gaming.Game.RPGLibrary.Logging;
using Microsoft.Win32.SafeHandles;
#endif

namespace DiseasedToast
{
#if WINDOWS || XBOX
    static class Program
    {
#if WINDOWS && DEBUG
    	[DllImport("kernel32", EntryPoint = "GetStdHandle", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    	private static extern IntPtr GetStdHandle(int nStdHandle);

    	[DllImport("kernel32", EntryPoint = "AllocConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    	private static extern bool AllocConsole();

    	[DllImport("kernel32", EntryPoint = "FreeConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    	private static extern int FreeConsole();

    	private const int STD_OUTPUT_HANDLE = -11;
    	private const int CODE_PAGE = 437;
#endif

    	private static log4net.ILog _log;

        static void Main(string[] args)
        {
			if (string.IsNullOrEmpty(Thread.CurrentThread.Name))
				Thread.CurrentThread.Name = "Main";

#if WINDOWS && DEBUG
			if (!System.Diagnostics.Debugger.IsAttached)
			{
				AllocConsole();
				var stdHandle = GetStdHandle(STD_OUTPUT_HANDLE);
				var safeFileHandle = new SafeFileHandle(stdHandle, true);
				var fileStream = new FileStream(safeFileHandle, FileAccess.Write);
				var encoding = Encoding.GetEncoding(CODE_PAGE);
				var stdOut = new StreamWriter(fileStream, encoding) { AutoFlush = true };
				Console.SetOut(stdOut);
			}
#endif

			_log = LogManager.GetLogger(typeof(Program));

			_log.Info("### !!! APPLICATION LOAD !!! ###");

			_log.Info("Deleting old log files (>7 days)...");

			// Delete log files older than 7 days
			if (Directory.Exists("logs"))
			{
				var now = DateTime.Now;
				var max = new TimeSpan(7, 0, 0, 0); // 7 days
				foreach (var file in from file in Directory.GetFiles("logs")
										let modTime = File.GetLastAccessTime(file)
										let age = now.Subtract(modTime)
										where age > max
										select file)
				{
					try
					{
						File.Delete(file);
						_log.Info("Deleted old log file: " + file);
					}
					catch (IOException ex)
					{
						_log.Warn("Failed to delete log file: " + file + "(" + ex.Message + ")");
					}
				}
			}

			_log.Info("Old log files deleted!");

			_log.Info("Starting game...");
			using (var game = new MainGame())
				game.Run();

#if WINDOWS && DEBUG
			_log.Debug("Unloading console...");
			FreeConsole();
			_log.Debug("Console unloaded!");
#endif
			_log.Info("### !!! APPLICATION EXIT !!! ###");
        }
    }
#endif
}


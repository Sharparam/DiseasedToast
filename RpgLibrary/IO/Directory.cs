using System.IO;

namespace RpgLibrary.IO
{
	public static class Directory
	{
		private static readonly log4net.ILog _log = Logging.LogManager.GetLogger(typeof (Directory));

		public static void CopyDirectory(string source, string dest)
		{
			_log.Debug("Copying directory:\n\t" + source + "\nto:\n\t" + dest);
			if (!System.IO.Directory.Exists(dest))
				System.IO.Directory.CreateDirectory(dest);

			foreach (var path in System.IO.Directory.GetDirectories(source, "*", SearchOption.AllDirectories))
				System.IO.Directory.CreateDirectory(dest + path.Substring(source.Length));

			foreach (var path in System.IO.Directory.GetFiles(source, "*", SearchOption.AllDirectories))
				File.Copy(path, dest + path.Substring(source.Length));
			_log.Debug("Copy completed!");
		}
	}
}

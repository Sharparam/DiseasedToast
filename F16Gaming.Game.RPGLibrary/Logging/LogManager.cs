using System;
using System.IO;
using log4net;
using log4net.Config;

namespace F16Gaming.Game.RPGLibrary.Logging
{
	public static class LogManager
	{
		private static bool _loaded;

		public static void LoadConfig(string file = null)
		{
			if (file == null)
			{
				if (File.Exists(AppDomain.CurrentDomain.FriendlyName + ".config"))
					XmlConfigurator.Configure();
				else
					BasicConfigurator.Configure();
			}
			else
			{
				if (File.Exists(file))
					XmlConfigurator.Configure(new FileInfo(file));
				else
				{
					LoadConfig(); // Load default configuration if specified file does not exist
					return;
				}
			}

			_loaded = true;
		}

		public static ILog GetLogger(object sender)
		{
			if (!_loaded)
				LoadConfig();

			return log4net.LogManager.GetLogger(sender.GetType().ToString() == "System.RuntimeType" ? (Type) sender : sender.GetType());
		}
	}
}

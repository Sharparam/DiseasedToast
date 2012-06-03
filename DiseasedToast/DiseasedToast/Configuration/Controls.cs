using System;
using System.IO;
using Microsoft.Xna.Framework.Input;
using XRpgLibrary.Configuration;

namespace DiseasedToast.Configuration
{
	internal enum Keyboard
	{
		MoveUp		= Keys.W,
		MoveDown	= Keys.S,
		MoveLeft	= Keys.A,
		MoveRight	= Keys.D,

		CameraUp	= Keys.Up,
		CameraDown	= Keys.Down,
		CameraLeft	= Keys.Left,
		CameraRight	= Keys.Right,

		ZoomIn			= Keys.PageUp,
		ZoomOut			= Keys.PageDown,
		ToggleCamera	= Keys.F,
		ResetCamera		= Keys.C
	}

	internal enum GamePad
	{
		MoveUp		= Buttons.LeftThumbstickUp,
		MoveDown	= Buttons.LeftThumbstickDown,
		MoveLeft	= Buttons.LeftThumbstickLeft,
		MoveRight	= Buttons.LeftThumbstickRight,
		
		CameraUp	= Buttons.DPadUp,
		CameraDown	= Buttons.DPadDown,
		CameraLeft	= Buttons.DPadLeft,
		CameraRight	= Buttons.DPadRight,
		
		ZoomIn			= Buttons.LeftShoulder,
		ZoomOut			= Buttons.RightShoulder,
		ToggleCamera	= Buttons.RightStick,
		ResetCamera		= Buttons.LeftStick
	}

	internal class ControlsManager
	{
		public static readonly string SettingsFile = Path.Combine(Paths.SettingsFolder, "Controls.settings");

		private readonly log4net.ILog _log;

		public static Controls Controls { get; private set; }

		internal ControlsManager() : this(SettingsFile)
		{ }

		internal ControlsManager(string file)
		{
			_log = RpgLibrary.Logging.LogManager.GetLogger(this);

			if (File.Exists(file))
			{
				_log.Info("Loading controls from " + file + "...");
				Controls = RpgLibrary.Serializing.Serializer.JsonDeserialize<Controls>(file);
				_log.Debug("Controls loaded!");
			}
			else
			{
				Controls = new Controls();
				SetDefaultControls();
				_log.Debug("Saving controls to " + SettingsFile + "...");
				RpgLibrary.Serializing.Serializer.JsonSerialize(Controls, SettingsFile);
			}

			CheckControls();
		}

		private void SetDefaultControls()
		{
			_log.Info("Setting default controls...");
			_log.Debug("Setting default keyboard controls...");
			foreach (var name in Enum.GetNames(typeof(Keyboard)))
			{
				var key = (Keys) Enum.Parse(typeof (Keyboard), name, false);
				_log.Debug(name + " -> " + key);
				Controls.Keyboard.Set(name, key);
			}

			_log.Debug("Setting default gamepad controls...");
			foreach (var name in Enum.GetNames(typeof(GamePad)))
			{
				var button = (Buttons) Enum.Parse(typeof (GamePad), name, false);
				_log.Debug(name + " -> " + button);
				Controls.GamePad.Set(name, button);
			}
			_log.Debug("Default controls set!");
		}

		private void CheckControls()
		{
			_log.Info("Checking control mapping for missing keys...");
			_log.Debug("Checking keyboard mapping...");
			foreach (var name in Enum.GetNames(typeof(Keyboard)))
			{
				var key = (Keys) Enum.Parse(typeof (Keyboard), name, false);
				if (!Controls.Keyboard.Mapping.ContainsKey(name))
				{	
					_log.Debug("Entry for " + name + " missing, setting to " + key);
					Controls.Keyboard.Set(name, key);
				}
				else if (Controls.Keyboard.Mapping[name].Default != key)
				{
					_log.Debug("Default setting for " + name + " incorect, updating to " + key);
					Controls.Keyboard.SetDefault(name, key);
				}
			}
			_log.Debug("Checking gamepad mapping...");
			foreach (var name in Enum.GetNames(typeof(GamePad)))
			{
				var button = (Buttons)Enum.Parse(typeof(GamePad), name, false);
				if (!Controls.GamePad.Mapping.ContainsKey(name))
				{
					_log.Debug("Entry for " + name + " missing, setting to " + button);
					Controls.GamePad.Set(name, button);
				}
				else if (Controls.GamePad.Mapping[name].Default != button)
				{
					_log.Debug("Default setting for " + name + " incorrect, updating to " + button);
					Controls.GamePad.SetDefault(name, button);
				}
			}
			_log.Debug("Done checking!");
		}
	}
}

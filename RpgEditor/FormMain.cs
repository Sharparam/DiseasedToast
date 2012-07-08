using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using F16Gaming.Game.RPGLibrary;
using F16Gaming.Game.RPGLibrary.Serializing;

namespace RpgEditor
{
	public partial class FormMain : Form
	{
		#region Fields

		private const string MainTitle = "XNA RPG Editor";

		private static string _gamePath = string.Empty;
		private const string GameFile = "Game.xgi";
		private const string ClassFolder = "Classes";
		private const string ItemFolder = "Items";
		private const string ArmorFolder = "Armor";
		private const string ShieldFolder = "Shields";
		private const string WeaponFolder = "Weapons";
		private const string ContainerFolder = "Containers";
		private const string KeyFolder = "Keys";
		private const string SkillFolder = "Skills";

		private RolePlayingGame _rpg;
		private FormClasses _classForm;
		private FormArmor _armorForm;
		private FormShields _shieldsForm;
		private FormWeapons _weaponsForm;
		private FormKeys _keysForm;
		private FormContainers _containersForm;
		private FormSkills _skillsForm;

		#endregion

		#region Properties

		public string GameFolder
		{
			get { return _rpg.Name; }
		}

		public static string GameFilePath
		{
			get { return Path.Combine(_gamePath, GameFile); }
		}

		public static string ClassPath
		{
			get { return Path.Combine(_gamePath, ClassFolder); }
		}

		public static string ItemPath
		{
			get { return Path.Combine(_gamePath, ItemFolder); }
		}

		public static string ArmorPath
		{
			get { return Path.Combine(ItemPath, ArmorFolder); }
		}

		public static string ShieldPath
		{
			get { return Path.Combine(ItemPath, ShieldFolder); }
		}

		public static string WeaponPath
		{
			get { return Path.Combine(ItemPath, WeaponFolder); }
		}

		public static string KeyPath
		{
			get { return Path.Combine(_gamePath, KeyFolder); }
		}

		public static string ContainerPath
		{
			get { return Path.Combine(_gamePath, ContainerFolder); }
		}

		public static string SkillPath
		{
			get { return Path.Combine(_gamePath, SkillFolder); }
		}

		#endregion

		#region Constructors

		public FormMain()
		{
			InitializeComponent();
		}

		#endregion

		#region Event Handlers

		private void FormMainFormClosing(object sender, FormClosingEventArgs e)
		{
			if (_rpg == null)
				return;

			DialogResult result = MessageBox.Show("Unsaved changes will be lost. Save before exit?", "Exit",
			                                      MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
			switch (result)
			{
				case DialogResult.Yes:
					SaveGame();
					break;
				case DialogResult.Cancel:
					e.Cancel = true;
					break;
			}
		}

		#endregion

		#region Menu Item Event Handlers

		private void NewGameMenuItemClick(object sender, EventArgs e)
		{
			using (var newGameForm = new FormNewGame())
			{
				DialogResult result = newGameForm.ShowDialog();
				if (result != DialogResult.OK || newGameForm.RolePlayingGame == null)
					return;

				var folderBrowser = new FolderBrowserDialog
				{
					Description = "Select folder to create game in.",
					SelectedPath = Application.StartupPath
				};

				result = folderBrowser.ShowDialog();

				if (result != DialogResult.OK)
					return;

				try
				{
					_rpg = newGameForm.RolePlayingGame;

					_gamePath = Path.Combine(folderBrowser.SelectedPath, GameFolder);

					if (Directory.Exists(_gamePath))
					{
						MessageBox.Show("Target directory already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

					Directory.CreateDirectory(_gamePath);
					Directory.CreateDirectory(ClassPath);
					Directory.CreateDirectory(ArmorPath);
					Directory.CreateDirectory(ShieldPath);
					Directory.CreateDirectory(WeaponPath);
					Directory.CreateDirectory(KeyPath);
					Directory.CreateDirectory(ContainerPath);
					Directory.CreateDirectory(SkillPath);

					Serializer.Serialize(_rpg, GameFilePath);

					ExportMenuItem.Enabled = true;
					ClassesMenuItem.Enabled = true;
					ItemsMenuItem.Enabled = true;
					KeysMenuItem.Enabled = true;
					ContainersMenuItem.Enabled = true;

					SetTitle(_rpg.Name);
					StatusBar.Text = _gamePath;
				}
				catch (IOException ex)
				{
					MessageBox.Show(
						"IO operation failed when creating game files. IOException thrown with message: " + ex.Message +
						"\n\nStack Trace:\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
		}

		private void OpenGameMenuItemClick(object sender, EventArgs e)
		{
			var folderBrowser = new FolderBrowserDialog
			{
				Description = "Select Game folder.",
				SelectedPath = Application.StartupPath
			};

			bool tryAgain;
			DialogResult result;

			do
			{
				result = folderBrowser.ShowDialog();
				if (result == DialogResult.OK)
				{
					if (File.Exists(folderBrowser.SelectedPath + @"\" + GameFile))
					{
						try
						{
							OpenGame(folderBrowser.SelectedPath);
							tryAgain = false;
						}
						catch (Exception ex)
						{
							result = MessageBox.Show(
								"Failed to open game. " + ex.GetType() + " thrown with message: " + ex.Message + "\n\nStack Trace:\n" +
								ex.StackTrace, "Error Opening Game", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
							tryAgain = result == DialogResult.Retry;
						}
					}
					else
					{
						result = MessageBox.Show("No Game file could be found in the specified folder.", "Game Not Found",
												 MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
						tryAgain = result == DialogResult.Retry;
					} 
				}
				else
				{
					tryAgain = false;
				}
			} while (tryAgain);
		}

		private void SaveGameMenuItemClick(object sender, EventArgs e)
		{
			SaveGame();
		}

		private void ExportMenuItemClick(object sender, EventArgs e)
		{
			if (_rpg == null)
				return;

			var folderBrowser = new FolderBrowserDialog
			{
				Description = "Select target directory.",
				SelectedPath = Application.StartupPath
			};

			DialogResult result = folderBrowser.ShowDialog();

			if (result != DialogResult.OK)
				return;

			string path = folderBrowser.SelectedPath;

			if (path.Substring(0, _gamePath.Length) == _gamePath)
			{
				MessageBox.Show("Cannot export data to current working directory.", "Export Error",
								MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (Directory.EnumerateFileSystemEntries(path).Any())
			{
				result = MessageBox.Show("Target directory is not empty, export cannot continue unless target directory is empty. Delete contents of target directory?", "Target Not Empty",
										 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result != DialogResult.Yes)
				{
					MessageBox.Show("Export cancelled by user.", "Export Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				try
				{
					Directory.Delete(path, true);
				}
				catch(IOException ex)
				{
					MessageBox.Show("Failed to delete target directory. IOException thrown with message: " + ex.Message, "Export Error",
					                MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			}

			try
			{
				F16Gaming.Game.RPGLibrary.IO.Directory.CopyDirectory(_gamePath, path);
				MessageBox.Show("Successfully exported game data to target directory:\n" + path, "Data Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (IOException ex)
			{
				MessageBox.Show("Directory or file creation in destination directory failed. IOException thrown with message: " + ex.Message, "Export Error",
								MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void ExitMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}

		private void ClassesMenuItemClick(object sender, EventArgs e)
		{
			if (_classForm == null)
				_classForm = new FormClasses {MdiParent = this};

			_classForm.Show();
			_classForm.BringToFront();
		}

		private void WeaponsMenuItemClick(object sender, EventArgs e)
		{
			if (_weaponsForm == null)
				_weaponsForm = new FormWeapons {MdiParent = this};

			_weaponsForm.Show();
			_weaponsForm.BringToFront();
		}

		private void ArmorMenuItemClick(object sender, EventArgs e)
		{
			if (_armorForm == null)
				_armorForm = new FormArmor {MdiParent = this};

			_armorForm.Show();
			_armorForm.BringToFront();
		}

		private void ShieldsMenuItemClick(object sender, EventArgs e)
		{
			if (_shieldsForm == null)
				_shieldsForm = new FormShields {MdiParent = this};

			_shieldsForm.Show();
			_shieldsForm.BringToFront();
		}

		private void KeysMenuItemClick(object sender, EventArgs e)
		{
			if (_keysForm == null)
				_keysForm = new FormKeys {MdiParent = this};

			_keysForm.Show();
			_keysForm.BringToFront();
		}

		private void ContainersMenuItemClick(object sender, EventArgs e)
		{
			if (_containersForm == null)
				_containersForm = new FormContainers {MdiParent = this};

			_containersForm.Show();
			_containersForm.BringToFront();
		}

		private void SkillsMenuItemClick(object sender, EventArgs e)
		{
			if (_skillsForm == null)
				_skillsForm = new FormSkills {MdiParent = this};

			_skillsForm.Show();
			_skillsForm.BringToFront();
		}

		#endregion

		#region Methods

		private void SetTitle(string title)
		{
			Text = string.Format("{0} - {1}", title, MainTitle);
		}

		private void OpenGame(string path)
		{
			_gamePath = path;
			_rpg = Serializer.Deserialize<RolePlayingGame>(GameFilePath);

			SetTitle(_rpg.Name);
			StatusLabel.Text = _gamePath;

			if (!Directory.Exists(ClassPath))
				Directory.CreateDirectory(ClassPath);

			if (!Directory.Exists(ArmorPath))
				Directory.CreateDirectory(ArmorPath);

			if (!Directory.Exists(ShieldPath))
				Directory.CreateDirectory(ShieldPath);

			if (!Directory.Exists(WeaponPath))
				Directory.CreateDirectory(WeaponPath);

			if (!Directory.Exists(KeyPath))
				Directory.CreateDirectory(KeyPath);

			if (!Directory.Exists(ContainerPath))
				Directory.CreateDirectory(ContainerPath);

			if (!Directory.Exists(SkillPath))
				Directory.CreateDirectory(SkillPath);

			FormDetails.ReadEntityData();
			FormDetails.ReadItemData();
			FormDetails.ReadKeyData();
			FormDetails.ReadContainerData();
			FormDetails.ReadSkillData();
			PrepareForms();
		}

		private void PrepareForms()
		{
			if (_classForm == null)
				_classForm = new FormClasses {MdiParent = this};

			_classForm.LoadClasses();

			if (_armorForm == null)
				_armorForm = new FormArmor {MdiParent = this};

			_armorForm.LoadArmor();

			if (_shieldsForm == null)
				_shieldsForm = new FormShields {MdiParent = this};

			_shieldsForm.LoadShields();

			if (_weaponsForm == null)
				_weaponsForm = new FormWeapons {MdiParent = this};

			_weaponsForm.LoadWeapons();

			if (_keysForm == null)
				_keysForm = new FormKeys {MdiParent = this};

			_keysForm.LoadKeys();

			if (_containersForm == null)
				_containersForm = new FormContainers {MdiParent = this};

			_containersForm.LoadContainers();

			if (_skillsForm == null)
				_skillsForm = new FormSkills {MdiParent = this};

			_skillsForm.LoadSkills();

			ExportMenuItem.Enabled = true;
			ClassesMenuItem.Enabled = true;
			ItemsMenuItem.Enabled = true;
			KeysMenuItem.Enabled = true;
			ContainersMenuItem.Enabled = true;
			SkillsMenuItem.Enabled = true;
		}

		private void SaveGame()
		{
			if (_rpg == null)
				return;

			try
			{
				Serializer.Serialize(_rpg, GameFilePath);
				FormDetails.WriteEntityData();
				FormDetails.WriteItemData();
				FormDetails.WriteKeyData();
				FormDetails.WriteContainerData();
				FormDetails.WriteSkillData();
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error saving data. " + ex.GetType() + " thrown with message: " + ex.Message + "\n\nStack Trace:\n" +
					ex.StackTrace, "Error Saving Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		#endregion
	}
}

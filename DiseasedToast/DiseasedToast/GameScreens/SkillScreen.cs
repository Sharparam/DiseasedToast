using System;
using System.Linq;
using System.Collections.Generic;
using F16Gaming.Game.RPGLibrary.Characters;
using F16Gaming.Game.RPGLibrary.Controls;
using F16Gaming.Game.RPGLibrary.GameManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using DiseasedToast.Components;

namespace DiseasedToast.GameScreens
{
	internal class SkillLabelSet
	{
		internal readonly Label Label;
		internal readonly LinkLabel LinkLabel;
		internal readonly Label CountLabel;
		internal int Value;

		internal SkillLabelSet(Label label, LinkLabel linkLabel, Label countLabel)
		{
			Label = label;
			LinkLabel = linkLabel;
			CountLabel = countLabel;
			Value = 0;
		}
	}

	internal class SkillScreen : BaseGameState
	{
		#region Fields

		private int _skillPoints;
		private int _unassignedPoints;
		private Character _target;

		private PictureBox _background;
		private Label _pointsRemaining;

		private readonly List<SkillLabelSet> _skillLabels = new List<SkillLabelSet>();
		private readonly Stack<string> _undoStack = new Stack<string>();
		private EventHandler _linkLabelHandler;

		#endregion

		#region Properties

		public int SkillPoints
		{
			get { return _skillPoints; }
			set
			{
				_skillPoints = value;
				_unassignedPoints = value;
			}
		}

		#endregion

		#region Constructors

		public SkillScreen(Game game, GameStateManager manager) : base(game, manager)
		{
			_linkLabelHandler = AddSkillLabelSelected;
		}

		#endregion

		#region XNA Methods

		public override void Initialize()
		{
			base.Initialize();
		}

		protected override void LoadContent()
		{
			base.LoadContent();

			CreateControls(GameRef.Content);
		}

		public override void Update(GameTime gameTime)
		{
			ControlManager.Update(gameTime);
			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			GameRef.SpriteBatch.Begin();

			base.Draw(gameTime);

			ControlManager.Draw(GameRef.SpriteBatch);

			GameRef.SpriteBatch.End();
		}

		#endregion

		#region Event Handlers

		private void AcceptLabelSelected(object sender, EventArgs e)
		{
			Log.Debug("AcceptLabel selected, changing to GamePlayScreen...");
			_undoStack.Clear();
			GameRef.AudioManager.Song.GetSong("MenuTheme").BeginEndFade();
			Transition(ChangeType.Change, GameRef.GamePlayScreen);
		}

		private void UndoLabelSelected(object sender, EventArgs e)
		{
			if (_unassignedPoints == _skillPoints)
				return;

			string skillName = _undoStack.Peek();
			Log.Debug("Undoing assignment of " + skillName);
			_undoStack.Pop();
			_unassignedPoints++;

			foreach (var set in _skillLabels.Where(set => set.LinkLabel.Type == skillName))
			{
				set.Value--;
				set.CountLabel.Text = set.Value.ToString();
				_target.Entity.Skills[skillName].Decrease();
			}

			_pointsRemaining.Text = "Skill Points: " + _unassignedPoints;
		}

		private void AddSkillLabelSelected(object sender, EventArgs e)
		{
			if (_unassignedPoints <= 0)
				return;

			string skillName = ((LinkLabel) sender).Type;

			Log.Debug("AddSkillLabel selected, adding skill point to " + skillName);

			_undoStack.Push(skillName);
			_unassignedPoints--;

			foreach (var set in _skillLabels.Where(set => set.LinkLabel.Type == skillName))
			{
				set.Value++;
				set.CountLabel.Text = set.Value.ToString();
				_target.Entity.Skills[skillName].Increase();
			}

			_pointsRemaining.Text = "Skill Points: " + _unassignedPoints;
		}

		#endregion

		#region Methods

		private void CreateControls(ContentManager content)
		{
			Log.Info("Creating controls...");
			_background = new PictureBox(content.Load<Texture2D>(@"Backgrounds\Title"), GameRef.ScreenRectangle);
			ControlManager.Add(_background);

			var nextControlPosition = new Vector2(300, 150);

			_pointsRemaining = new Label { Text = "Skill Points: " + _unassignedPoints, Position = nextControlPosition };

			nextControlPosition.Y += ControlManager.Font.LineSpacing + 10.0f;
			ControlManager.Add(_pointsRemaining);

			/*string skillPath = @"Game\Skills\";
			string[] skillFiles = Directory.GetFiles(skillPath, "*.skill");

			var skillData = new List<SkillData>();

			foreach (var file in skillFiles)
			{
			    var data = Serializer.Deserialize<SkillData>(file);
			    var label = new Label {Text = data.Name, Type = data.Name, Position = nextControlPosition};
			    var linkLabel = new LinkLabel {Text = "+", Type = data.Name, TabStop = true, Position = new Vector2(nextControlPosition.X + 350, nextControlPosition.Y)};
			    var countLabel = new Label {Text = "0", Type = data.Name, Position = new Vector2(linkLabel.Position.X + 50, nextControlPosition.Y)};

			    nextControlPosition.Y += ControlManager.Font.LineSpacing + 10.0f;

			    linkLabel.Selected += AddSkillLabelSelected;

			    ControlManager.Add(label);
			    ControlManager.Add(linkLabel);
			    ControlManager.Add(countLabel);

			    _skillLabels.Add(new SkillLabelSet(label, linkLabel, countLabel));
			}*/

			foreach (var key in DataManager.SkillData.Keys)
			{
				var data = DataManager.SkillData[key];

				var label = new Label
				{
					Text = data.Name,
					Type = data.Name,
					Position = nextControlPosition
				};

				var countLabel = new Label
				{
					Text = "0",
					Position = new Vector2(nextControlPosition.X + 300, nextControlPosition.Y)
				};

				var linkLabel = new LinkLabel
				{
					TabStop = true,
					Text = "+",
					Type = data.Name,
					Position = new Vector2(nextControlPosition.X + 390, nextControlPosition.Y)
				};
				linkLabel.Selected += AddSkillLabelSelected;

				nextControlPosition.Y += ControlManager.Font.LineSpacing + 10f;

				ControlManager.Add(label);
				ControlManager.Add(countLabel);
				ControlManager.Add(linkLabel);

				_skillLabels.Add(new SkillLabelSet(label, linkLabel, countLabel));
			}

			nextControlPosition.Y += ControlManager.Font.LineSpacing + 10.0f;

			var undoLabel = new LinkLabel {Text = "Undo", Position = nextControlPosition, TabStop = true};
			undoLabel.Selected += UndoLabelSelected;
			nextControlPosition.Y += ControlManager.Font.LineSpacing + 10.0f;
			ControlManager.Add(undoLabel);

			var acceptLabel = new LinkLabel {Text = "Accept", Position = nextControlPosition, TabStop = true};
			acceptLabel.Selected += AcceptLabelSelected;
			ControlManager.Add(acceptLabel);

			ControlManager.NextControl();
			Log.Debug("Controls created!");
		}

		public void SetTarget(Character target)
		{
			_target = target;

			foreach (var set in _skillLabels)
			{
				set.Value = target.Entity.Skills[set.Label.Text].Value;
				set.CountLabel.Text = set.Value.ToString();
			}
		}

		#endregion
	}
}

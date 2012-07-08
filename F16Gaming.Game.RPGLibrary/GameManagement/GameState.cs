using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace F16Gaming.Game.RPGLibrary.GameManagement
{
	/// <summary>
	/// This is a game component that implements IUpdateable.
	/// </summary>
	public class GameState : DrawableGameComponent
	{
		#region Fields

		private readonly List<GameComponent> _childComponents;
		private readonly GameState _tag;

		protected readonly GameStateManager StateManager;

		#endregion

		#region Properties

		public List<GameComponent> Components
		{
			get { return _childComponents; }
		}

		public GameState Tag
		{
			get { return _tag; }
		}

		#endregion

		#region Constructors

		public GameState(Microsoft.Xna.Framework.Game game, GameStateManager manager) : base(game)
		{
			StateManager = manager;
			_childComponents = new List<GameComponent>();
			_tag = this;
		}

		#endregion

		#region XNA Methods

		public override void Initialize()
		{
			base.Initialize();
		}

		public override void Update(GameTime gameTime)
		{
			foreach (var component in _childComponents.Where(c => c.Enabled))
				component.Update(gameTime);

			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			foreach (var component in _childComponents)
			{
				var drawComponent = component as DrawableGameComponent;
				if (drawComponent != null && drawComponent.Visible)
					drawComponent.Draw(gameTime);
			}

			base.Draw(gameTime);
		}

		#endregion

		#region Methods

		internal protected virtual void StateChange(object sender, EventArgs e)
		{
			if (StateManager.CurrentState == Tag)
				Show();
			else
				Hide();
		}

		protected virtual void Show()
		{
			Visible = true;
			Enabled = true;
			foreach (var component in _childComponents)
			{
				component.Enabled = true;
				var drawComponent = component as DrawableGameComponent;
				if (drawComponent != null)
					drawComponent.Visible = true;
			}
		}

		protected virtual void Hide()
		{
			Visible = false;
			Enabled = false;
			foreach (var component in _childComponents)
			{
				component.Enabled = false;
				var drawComponent = component as DrawableGameComponent;
				if (drawComponent != null)
					drawComponent.Visible = false;
			}
		}

		#endregion
	}
}

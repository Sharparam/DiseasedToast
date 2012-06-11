using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace XRpgLibrary.GameManagement
{
	public enum ChangeType
	{
		Change,
		Pop,
		Push
	}

	/// <summary>
	/// This is a game component that implements IUpdateable.
	/// </summary>
	public class GameStateManager : GameComponent
	{
		#region Events

		public event EventHandler StateChange;

		#endregion

		#region Fields

		private readonly Stack<GameState> _gameStates = new Stack<GameState>();
		private const int StartDrawOrder = 5000;
		private const int DrawOrderInc = 100;
		private int _drawOrder;

		#endregion

		#region Properties

		public GameState CurrentState
		{
			get { return _gameStates.Peek(); }
		}

		#endregion

		#region Constructors

		public GameStateManager(Game game) : base(game)
		{
			_drawOrder = StartDrawOrder;
		}

		#endregion

		#region XNA Methods

		public override void Initialize()
		{
			base.Initialize();
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
		}

		#endregion

		#region Methods

		private void OnStateChange(EventArgs e = null)
		{
			if (StateChange != null)
				StateChange(this, e);
		}

		public void PopState()
		{
			if (_gameStates.Count <= 0)
				return;

			RemoveState();
			_drawOrder -= DrawOrderInc;
			OnStateChange();
		}

		private void RemoveState()
		{
			GameState state = _gameStates.Peek();
			StateChange -= state.StateChange;
			Game.Components.Remove(state);
			_gameStates.Pop();
		}

		public void PushState(GameState state)
		{
			_drawOrder += DrawOrderInc;
			state.DrawOrder = _drawOrder;
			AddState(state);
			OnStateChange();
		}

		private void AddState(GameState state)
		{
			_gameStates.Push(state);
			Game.Components.Add(state);
			StateChange += state.StateChange;
		}

		public void ChangeState(GameState state)
		{
			while (_gameStates.Count > 0)
				RemoveState();

			state.DrawOrder = StartDrawOrder;
			_drawOrder = StartDrawOrder;
			AddState(state);
			OnStateChange();
		}

		#endregion
	}
}

using System;
using System.Collections.Generic;
using F16Gaming.Game.RPGLibrary.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace F16Gaming.Game.RPGLibrary.Sprites
{
	public class AnimatedSprite : BaseSprite
	{
		#region Fields

		private Dictionary<AnimationKey, Animation> _animations;
		private AnimationKey _currentAnimation;
		private bool _animating;
		private Point _mapSize;

		#endregion

		#region Properties

		public AnimationKey CurrentAnimation
		{
			get { return _currentAnimation; }
			set { _currentAnimation = value; }
		}

		public bool IsAnimating
		{
			get { return _animating; }
			set { _animating = value; }
		}

		public override int Width
		{
			get { return _animations[_currentAnimation].FrameWidth; }
		}

		public override int Height
		{
			get { return _animations[_currentAnimation].FrameHeight; }
		}

		#endregion

		#region Constructors

		public AnimatedSprite(Texture2D texture, Dictionary<AnimationKey, Animation> animations, Point? tile = null) : base(texture, null, tile)
		{
			_animations = new Dictionary<AnimationKey, Animation>();
			foreach (var key in animations.Keys)
				_animations.Add(key, (Animation) animations[key].Clone());
			_mapSize = new Point(0, 0);
		}

		#endregion

		#region Methods

		public override void Update(GameTime gameTime)
		{
			if (!_animating)
				return;

			_animations[_currentAnimation].Update(gameTime);
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, float depth = 0.0f)
		{
			spriteBatch.Draw(
				Texture,
				Position,
				_animations[_currentAnimation].CurrentFrameRectangle,
				Color.White,
				0.0f,
				Vector2.Zero,
				1.0f,
				SpriteEffects.None,
				depth);
		}

		public void LockToMap()
		{
			SpritePosition.X = MathHelper.Clamp(Position.X, 0, _mapSize.X - Width);
			SpritePosition.Y = MathHelper.Clamp(Position.Y, 0, _mapSize.Y - Height);
		}

		public void LockToMap(int width, int height)
		{
			_mapSize = new Point(width, height);
			LockToMap();
		}

		public void SetMapSize(int width, int height)
		{
			_mapSize = new Point(width, height);
		}

		#endregion
	}
}

using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using XRpgLibrary.TileEngine;

namespace XRpgLibrary.Sprites
{
	public class AnimatedSprite : BaseSprite
	{
		#region Fields

		private Dictionary<AnimationKey, Animation> _animations;
		private AnimationKey _currentAnimation;
		private bool _animating;

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
		}

		#endregion

		#region Methods

		public override void Update(GameTime gameTime)
		{
			if (!_animating)
				return;

			_animations[_currentAnimation].Update(gameTime);
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(
				Texture,
				Position,
				_animations[_currentAnimation].CurrentFrameRectangle,
				Color.White);
		}

		public void LockToMap()
		{
			SpritePosition.X = MathHelper.Clamp(Position.X, 0, TileMap.WidthPixels - Width);
			SpritePosition.Y = MathHelper.Clamp(Position.Y, 0, TileMap.HeightPixels - Height);
		}

		#endregion
	}
}

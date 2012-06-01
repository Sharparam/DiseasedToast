using System;
using Microsoft.Xna.Framework;

namespace XRpgLibrary.Sprites
{
	public enum AnimationKey { North, South, West, East, NorthWest, NorthEast, SouthWest, SouthEast }

	public class Animation
	{
		#region Fields

		private Rectangle[] _frames;
		private int _fps;
		private TimeSpan _frameLength;
		private TimeSpan _frameTimer;
		private int _currentFrame;
		private int _frameWidth;
		private int _frameHeight;

		#endregion

		#region Properties

		public int FramesPerSecond
		{
			get { return _fps; }
			set
			{
				_fps = (int) MathHelper.Clamp(value, 1, 60);
				_frameLength = TimeSpan.FromSeconds(1 / (double) _fps);
			}
		}

		public Rectangle CurrentFrameRectangle
		{
			get { return _frames[_currentFrame]; }
		}

		public int CurrentFrame
		{
			get { return _currentFrame; }
			set { _currentFrame = (int) MathHelper.Clamp(value, 0, _frames.Length - 1); }
		}

		public int FrameWidth
		{
			get { return _frameWidth; }
		}

		public int FrameHeight
		{
			get { return _frameHeight; }
		}

		#endregion

		#region Constructors

		public Animation(int frameCount, int frameWidth = 32, int frameHeight = 32, int xOffset = 0, int yOffset = 0)
		{
			_frames = new Rectangle[frameCount];
			_frameWidth = frameWidth;
			_frameHeight = frameHeight;
			for (int i = 0; i < frameCount; i++)
				_frames[i] = new Rectangle(xOffset * _frameWidth + (_frameWidth * i), yOffset * _frameHeight, _frameWidth, _frameHeight);

			FramesPerSecond = 5;
			Reset();
		}

		private Animation(Animation animation)
		{
			_frames = animation._frames;
			FramesPerSecond = 5;
		}

		#endregion

		#region Methods

		public void Update(GameTime gameTime)
		{
			_frameTimer += gameTime.ElapsedGameTime;

			if (_frameTimer >= _frameLength)
			{
				_frameTimer = TimeSpan.Zero;
				CurrentFrame = (CurrentFrame + 1) % _frames.Length;
			}
		}

		public void Reset()
		{
			CurrentFrame = 0;
			_frameTimer = TimeSpan.Zero;
		}

		public object Clone()
		{
			var animationClone = new Animation(this) {_frameWidth = _frameWidth, _frameHeight = _frameHeight};
			animationClone.Reset();
			return animationClone;
		}

		#endregion
	}
}

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
	public class GoombaObject : ObjectKernel<GoombaSpriteEnum, GoombaMotionEnum>
	{
		public GoombaObject(Vector2 location) : base(location) { }
		
		protected override void Initialize()
		{
			State = new ObjectState<GoombaSpriteEnum, GoombaMotionEnum>(default(Vector2));
			Sprites = new Dictionary<GoombaSpriteEnum, ISprite>();
			Motions = new Dictionary<GoombaMotionEnum, ObjectMotion>();
			
		}
	}
}
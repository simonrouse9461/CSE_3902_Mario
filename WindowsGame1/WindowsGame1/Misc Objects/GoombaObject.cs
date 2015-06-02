using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
	public class GoombaObject : ObjectKernel<GoombaSpriteEnum, EnemyMotionEnum>
	{
		public GoombaObject(Vector2 location) : base(location) { }
		
		protected override void Initialize()
		{
			State = new ObjectState<GoombaSpriteEnum, EnemyMotionEnum>(default(Vector2));
			Sprites = new Dictionary<GoombaSpriteEnum, ISprite>();
			Motions = new Dictionary<EnemyMotionEnum, ObjectMotion>();
			
		}
	}
}
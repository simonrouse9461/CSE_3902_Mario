using System;
using System.Collections.Generic;
namespace WindowsGame1
{
    public class GoombaCollisionHandler : ICollisionHandler<GoombaSpriteState, GoombaMotionState>
    {
        private IObject Goomba;
        private CollisionDetectorNew CollisionDetector;
        
        public GoombaCollisionHandler(IObject goomba, List<IObject> objList)
        {
            Goomba = goomba;
            CollisionDetector = new CollisionDetectorNew(this.Goomba, objList);
        }

        protected void Initialize()
        {
            
        }

        public List<Action<GoombaSpriteState, GoombaMotionState>> GetAction()
        {
            return new List<Action<GoombaSpriteState, GoombaMotionState>>();
        }
    }
}
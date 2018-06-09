using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    class Brick : GameObject
    {
        #region preop
        private object _rectangle;

        public object Rectangle
        {
            get { return _rectangle; }
            set { _rectangle = value; }
        }
        #endregion

        #region ctor
        public Brick(double position_X, double position_Y, int objWidth, int objLength) : base(position_X, position_Y, objWidth, objLength)
        {

        }
        #endregion

        #region Methods
        protected override void collided(GameObject gameObj)
        {

            if (CollidesWith(gameObj))
            {

            }
        }

        public bool IsCollided(GameObject gameObj)
        {
            if (this.CollidesWith(gameObj))
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}

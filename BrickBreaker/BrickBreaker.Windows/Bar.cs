using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    class Bar : MovableObject
    {
        #region ctor
        public Bar(double position_X, double position_Y, int objWidth, int objLength) : base(position_X, position_Y, objWidth, objLength)
        {

        }

        #endregion

        #region method
        protected override void collided(GameObject gameObj)
        {
            if (gameObj is Wall)
            {
                while (CollidesWith(gameObj))
                {
                    Position_X -= Math.Sign(_velocity_X) * 0.1;
                }

            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    class Ball : MovableObject
    {
        #region data members
        public int countCollides = 0;
        const double maxBounceAngle = (5 * Math.PI) / 12; // 75 degrees
        #endregion

        #region ctor
        public Ball(double position_X, double position_Y, int objWidth, int objLength, double velocity_X, double velocity_Y) : base(position_X, position_Y, objWidth, objLength)
        {
            _velocity_X = velocity_X;
            _velocity_Y = velocity_Y;
        }
        #endregion

        #region Methods
        protected override void collided(GameObject gameObj)
        {

            // skip the second time at tick the ball collides with object
            countCollides++;
            if (countCollides > 1)
            {
                return;
            }


            while (CollidesWith(gameObj))
            {
                Position_X -= Math.Sign(_velocity_X) * 0.1;
                Position_Y -= Math.Sign(_velocity_Y) * 0.1;
            }

            double x2 = this.Position_X + ObjWidth;
            double y2 = this.Position_Y + ObjLength;


            double delta_X = Math.Min(Math.Abs(x2 - gameObj.Position_X), Math.Abs(Position_X - (gameObj.Position_X + gameObj.ObjWidth)));
            double delta_Y = Math.Min(Math.Abs(y2 - gameObj.Position_Y), Math.Abs(Position_Y - (gameObj.Position_Y + gameObj.ObjLength)));


            if (delta_X > delta_Y)
            {
                if (gameObj is Bar)
                {
                    double bounceAngle = BarBounceAngle(gameObj);
                    SetVelocityFromAngle(bounceAngle);
                }
                else
                {
                    _velocity_Y *= -1;
                }
            }
            else
            {
                _velocity_X *= -1;
            }

        }

        private double BarBounceAngle(GameObject gameObj)
        {
            double barCenter = (gameObj.ObjWidth / 2) + gameObj.Position_X;
            double ballCenter = (this.ObjWidth / 2) + this.Position_X;

            double relativePosition = (ballCenter - barCenter) / (gameObj.ObjWidth / 2);
            double bounceAngle = relativePosition * maxBounceAngle;
            return bounceAngle;
        }

        private void SetVelocityFromAngle(double bounceAngle)
        {
            double ballSpeed = 7 + Math.Abs(bounceAngle / maxBounceAngle) * 6;
            _velocity_Y = ballSpeed * -Math.Cos(bounceAngle);
            _velocity_X = ballSpeed * Math.Sin(bounceAngle);
        }
        #endregion
    }
}

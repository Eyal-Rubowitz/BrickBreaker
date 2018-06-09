using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    class MovableObject : GameObject
    {
        #region data members

        protected double _velocity_X = 0;
        protected double _velocity_Y = 0;

        #endregion

        #region enum
        public enum Directions
        {
            LEFT = -1,
            RIGHT = 1,
            NONE = 0
        }
        #endregion

        #region ctor
        public MovableObject(double position_X, double position_Y, int objWidth, int objLength) : base(position_X, position_Y, objWidth, objLength)
        {

        }
        #endregion

        #region Methods
        public void SetMovement(Directions direction)
        {
            _velocity_X = 2 * ((int)direction / 0.1);
        }

        public void Movement()
        {
            Position_X += _velocity_X;
            Position_Y += _velocity_Y;
        }

        public void StopMovement()
        {
            Position_X -= _velocity_X;
            Position_Y -= _velocity_Y;
        }
        #endregion
    }
}

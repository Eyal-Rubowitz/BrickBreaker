using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    class Wall : GameObject
    {
        #region ctor
            public Wall(double position_X, double position_Y, int objWidth, int objLength) : base(position_X, position_Y, objWidth, objLength)
            {

            }
        #endregion
    }
}

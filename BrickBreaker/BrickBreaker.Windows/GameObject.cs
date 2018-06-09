using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    class GameObject
    {
        #region prop
        private double _position_X;

        public double Position_X
        {
            get { return _position_X; }
            set { _position_X = value; }
        }


        private double _position_Y;

        public double Position_Y
        {
            get { return _position_Y; }
            set { _position_Y = value; }
        }

        private int _objWidth;

        public int ObjWidth
        {
            get { return _objWidth; }
            set { _objWidth = value; }
        }


        private int _objLength;

        public int ObjLength
        {
            get { return _objLength; }
            set { _objLength = value; }
        }
        #endregion

        #region ctor
        public GameObject(double position_X, double position_Y, int objWidth, int objLength)
        {
            _position_X = position_X;
            _position_Y = position_Y;
            _objWidth = objWidth;
            _objLength = objLength;
        }
        #endregion

        #region Methods
        // the method check a condition: if there is a collision between this object and another object.
        // the position of this object (that was creat from this class) to another object which accept as argument 
        protected bool CollidesWith(GameObject gameObj)
        {
            return (
                (this.Position_X <= (gameObj.Position_X + gameObj._objWidth)) &&
                ((this.Position_X + this._objWidth) >= gameObj.Position_X) &&
                (this.Position_Y <= (gameObj.Position_Y + gameObj._objLength)) &&
                 ((this.Position_Y + this._objLength) >= gameObj.Position_Y)
                );
        }

        protected virtual void collided(GameObject gameObj)
        {
            // this method use by the inherent classes and impliment logic difrently in each case
        }

        // when collide occur between 2 objects (CollidesWith == true),
        // activate collision logic for each of those 2 object. 
        public bool Collision(GameObject gameObj)
        {
            if (this.CollidesWith(gameObj))
            {
                this.collided(gameObj);
                gameObj.collided(this);
                return true;
            }
            return false;
        }
        #endregion
    }
}

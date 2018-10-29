/*
 * A class to store 2D Vectors
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.GameEngine.Math
{
    public class Vector2
    {
        private float x; // X Position of the Vector
        private float y; // Y Position of the Vector

        /// <summary>
        /// Constructor with the position defaultly set to ZERO
        /// </summary>
        public Vector2()
        {
            x = 0;
            y = 0;
        }

        /// <summary>
        /// Constructor where you set the X and Y position
        /// </summary>
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Returns a new Vector2 of 0, 0
        /// </summary>
        /// <returns></returns>
        public static Vector2 Zero()
        {
            return (new Vector2(0, 0));
        }

        /// <summary>
        /// Get or set the X position of this Vector
        /// </summary>
        public float X
        {
            get { return (x); }
            set { x = value; }
        }

        /// <summary>
        /// Get or set the Y position of this Vector
        /// </summary>
        public float Y
        {
            get { return (y); }
            set { y = value; }
        }
    }
}

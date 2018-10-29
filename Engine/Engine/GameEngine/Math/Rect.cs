/*
 * A class to store a Rectangle and detect intersections between rectangles
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.GameEngine.Math
{
    public class Rect
    {
        private Vector2 topLeft; // The top-left location of the rectangle
        private Vector2 bottomRight; // The bottom-right location of the rectangle, not relative to the top-left position

        /// <summary>
        /// Constructor with default values 0, 0, 0, 0
        /// </summary>
        public Rect()
        {
            topLeft = new Vector2(0, 0);
            bottomRight = new Vector2(0, 0);
        }

        /// <summary>
        /// Constructor with the values for top-left and bottom-right(not relative to the top-left position)
        /// </summary>
        /// <param name="topLeft"></param>
        /// <param name="bottomRight"></param>
        public Rect(Vector2 topLeft, Vector2 bottomRight)
        {

        }
    }
}

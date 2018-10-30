using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.GameEngine
{
    public static class MathHelper
    {
        /// <summary>
        /// Gets the angle between 2 points
        /// </summary>
        /// <param name="x1">point 1 x</param>
        /// <param name="y1">point 1 y</param>
        /// <param name="x2">point 2 x</param>
        /// <param name="y2">point 2 y</param>
        /// <returns>Double</returns>
        public static float PointDirection(float x1, float y1, float x2, float y2)
        {
            float xDiff = x2 - x1;
            float yDiff = y2 - y1;

            return (float)(-(System.Math.Atan2(yDiff, xDiff) * 180.0 / System.Math.PI));
        }

        /// <summary>
        /// Get the distance between 2 points
        /// </summary>
        /// <param name="x1">point 1 x</param>
        /// <param name="y1">point 1 y</param>
        /// <param name="x2">point 2 x</param>
        /// <param name="y2">point 2 y</param>
        /// <returns>Double</returns>
        public static float PointDistance(float x1, float y1, float x2, float y2)
        {
            return (float)(System.Math.Sqrt(System.Math.Pow((x2 - x1), 2) + System.Math.Pow((y2 - y1), 2)));
        }

        /// <summary>
        /// Returns the length and direction, like that off Game Maker
        /// </summary>
        /// <param name="len">Length from the point</param>
        /// <param name="dir">Angle(360 degrees from 0)</param>
        /// <returns>Double</returns>
        public static float LengthDirX(float len, float dir)
        {
            return (float)(len * System.Math.Cos(dir * deg2Rad()));
        }

        /// <summary>
        /// Returns the length and direction, like that off Game Maker
        /// </summary>
        /// <param name="len">Length from the point</param>
        /// <param name="dir">Angle(360 degrees from 0)</param>
        /// <returns>Double</returns>
        public static float LengthDirY(float len, float dir)
        {
            return (float)(len * -System.Math.Sin(dir * deg2Rad()));
        }

        public static float Clamp(float value, float min, float max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }
        /// <summary>
        /// Snap a position to an invisible grid space
        /// </summary>
        /// <param name="position"></param>
        /// <param name="gridSize"></param>
        /// <returns></returns>
        public static float Snap(float position, float gridSize)
        {
            return (float)(Math.Round(position / gridSize) * gridSize);
        }

        /// <summary>
        /// Lerp a point towards another point
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static float Lerp(float from, float to, float amount)
        {
            return (from + amount * (to - from));
        }

        /// <summary>
        /// Round a number to the nearest whole number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static float Round(float number)
        {
            return (float)(Math.Round(number));
        }

        /// <summary>
        /// Return the largest whole number less than or equal to the specified number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static float Floor(float number)
        {
            return (float)(Math.Floor(number));
        }

        /// <summary>
        /// Returns the smallest whole number that is greater than or equal to the specified number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static float Ceil(float number)
        {
            return (float)(Math.Ceiling(number));
        }

        /// <summary>
        /// Returns an absolute value of a number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static float Abs(float number)
        {
            return (Math.Abs(number));
        }

        /// <summary>
        /// Return a random number
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float Random(float max)
        {
            return (new Random(Guid.NewGuid().GetHashCode()).Next((int)max));
        }

        /// <summary>
        /// Return a random number between min and max
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float RandomRange(float min, float max)
        {
            return (new Random(Guid.NewGuid().GetHashCode()).Next((int)min, (int)max));
        }

        public static string String(object val)
        {
            return (val.ToString());
        }

        public static float Real(object val)
        {
            return (float.Parse(val.ToString()));
        }

        public static bool Boolean(object val)
        {
            return (bool.Parse(val.ToString()));
        }

        private static float deg2Rad()
        {
            return (float)((System.Math.PI * 2) / 360);
        }
    }
}

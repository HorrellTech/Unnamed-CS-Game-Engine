/*
 * A static class to return colors based on the color name rather than having to use HEX 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace Engine.GameEngine
{
    public static class Colors
    {
        public static Color Black { get { return (Color.Black); } } // Black (duh)

        /// <summary>
        /// Return a color based on Red Green Blue with values 0.1 - 1.0
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Color RGBA(float r, float g, float b, float a)
        {
            return (new Color((byte)(r * 255), (byte)(g * 255), (byte)(b * 255), (byte)(a * 255)));
        }

        /// <summary>
        /// Return a color based on Red Green Blue with values 0.0 - 1.0
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Color RGB(float r, float g, float b)
        {
            return (new Color((byte)(r * 255), (byte)(g * 255), (byte)(b * 255)));
        }

        /// <summary>
        /// Return a color based on Red Green Blue Alphas
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Color RGBA(byte r, byte g, byte b, byte a)
        {
            return (new Color(r, g, b, a));
        }
        /// <summary>
        /// Return a color based on Red Green Blue 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Color RGB2(byte r, byte g, byte b)
        {
            return (new Color(r, g, b));
        }

        /// <summary>
        /// Return a color based on Red Green Blue Alphas
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Color RGBA2(byte r, byte g, byte b, byte a)
        {
            return (new Color(r, g, b, a));
        }
    }
}

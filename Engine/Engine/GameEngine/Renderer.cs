/*
 * The renderer will be used to draw shapes and set views etc
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Engine.GameEngine
{
    public class Renderer
    {
        public RenderWindow window; // Get a reference to the window that will be rendering the game
        public Color color; // Draw color
        public byte alpha; // The drawing alpha

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="window">SFML Render Window</param>
        public Renderer(RenderWindow window)
        {
            this.window = window;
            color = Color.White;
            alpha = 0xFF;
        }

        /// <summary>
        /// Set the drawing color
        /// </summary>
        /// <param name="color"></param>
        public void DrawSetColor(Color color)
        {
            var r = color.R;
            var g = color.G;
            var b = color.B;

            this.color = new Color(r, g, b, alpha);
        }

        /// <summary>
        /// Get color from RGB (0x00 - 0xFF)
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public Color RGB(byte r, byte g, byte b)
        {
            return (new Color(r, g, b));
        }

        /// <summary>
        /// Set the drawing alpha transparency (0x00 - 0xFF)
        /// </summary>
        /// <param name="alpha"></param>
        public void DrawSetAlpha(byte alpha)
        {
            this.alpha = alpha;
        }

        /// <summary>
        /// Draw a line from one point to another
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void DrawLine(float x1, float y1, float x2, float y2)
        {
            Vertex[] line =
                {
                    new Vertex(new Vector2f(x1, y1), color),
                    new Vertex(new Vector2f(x2, y2), color)
                };

            window.Draw(line, PrimitiveType.Lines);
        }

        /// <summary>
        /// Draw a rectangle from one point to another, as an outline or not
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="outline"></param>
        public void DrawRectangle(float x1, float y1, float x2, float y2, bool outline)
        {
            if(outline)
            {
                // Draw the rectangle parts using lines if we are just drawing an outline
                DrawLine(x1, y1, x1, y2); // Left
                DrawLine(x1, y1, x2, y1); // Top
                DrawLine(x1, y2, x2, y2); // Bottom
                DrawLine(x2, y1, x2, y2); // Right
            }
            else
            {
                RectangleShape rect = new RectangleShape(new Vector2f(x2 - x1, y2 - y1));

                rect.Position = new Vector2f(x1, y1);
                rect.FillColor = color;
                rect.OutlineColor = color;

                window.Draw(rect);
            }
        }
    }
}

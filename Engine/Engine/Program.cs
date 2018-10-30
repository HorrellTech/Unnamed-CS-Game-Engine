using Engine.GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Engine
{
    static class Program
    {
        private static RenderWindow window;
        private static Renderer renderer; // The game renderer for testing
        private static ContextSettings settings = new ContextSettings(); // Settings for the drawing (antialiasing etc)
        private static bool autoResize = true; // If the drawing resolution should resize to fit the window

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            // SET THE SETTINGS HERE
            settings.AntialiasingLevel = 8;

            window = new RenderWindow(new SFML.Window.VideoMode(800, 600), "Unnamed Game Engine", Styles.Default, settings); // Create a new game window
            renderer = new Renderer(window);
            window.SetVerticalSyncEnabled(true);

            window.Closed += WinClosed;
            window.Resized += WinResized;

            // Main game loop
            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear(Color.Black); // Clear the screen

                // DO LOOP AND DRAWING HERE

                // Draw a basic line

                renderer.DrawSetAlpha(0xFF);
                renderer.DrawSetColor(Color.Red);
                renderer.DrawRectangle(32, 32, 64, 64, false);

                window.Display();
            }
        }

        // When the user closes the window
        private static void WinClosed(object sender, EventArgs e)
        {
            window.Close();
        }

        private static void WinResized(object sender, SizeEventArgs e)
        {
            if (autoResize)
            {
                window.SetView(new SFML.Graphics.View(new FloatRect(0, 0, e.Width, e.Height))); // Reset the game resolution
            }
        }
    }
}

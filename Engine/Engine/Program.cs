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
        private static uint windowWidth = 640;
        private static uint windowHeight = 480;
        private static uint windowDepth = 32;
        private static RenderWindow window;
        private static Renderer renderer; // The game renderer for testing
        private static ContextSettings settings = new ContextSettings(); // Settings for the drawing (antialiasing etc)
        private static bool autoResize = false; // If the drawing resolution should resize to fit the window

        /// <summary>
        /// The main entry point for the application.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
        /// </summary>
        static void Main(string[] args)
        {
            // SET THE SETTINGS HERE
            settings.DepthBits = 24;
            settings.StencilBits = 8;
            settings.AntialiasingLevel = 4;
            settings.MajorVersion = 3;
            settings.MinorVersion = 0;

            window = new RenderWindow(new SFML.Window.VideoMode(windowWidth, windowHeight, windowDepth), "Unnamed Game Engine", Styles.Default, settings); // Create a new game window
            renderer = new Renderer(window); // Create the renderer
            window.SetVerticalSyncEnabled(true); // Vertical Sync

            window.Closed += WinClosed;
            window.Resized += WinResized;

            // Main game loop
            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear(Colors.Black); // Clear the screen

                // DO LOOP AND DRAWING HERE

                // Draw a basic line

                renderer.DrawSetAlpha(0xFF);
                renderer.DrawSetColor(Color.Red);
                renderer.DrawRectangle(32, 32, 128, 128, false); // Draw a simple rectangle

                renderer.DrawSetColor(renderer.RGB(0x00, 0x00, 0xFF));
                renderer.DrawSetAlpha(0xAA);
                renderer.DrawLine(0, 0, 300, 300); // Draw a simple line with alpha transparency at half

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
            if (autoResize) // If the autoResize resoultion is set to true
            {
                window.SetView(new SFML.Graphics.View(new FloatRect(0, 0, e.Width, e.Height))); // Reset the game resolution
            }
        }
    }
}

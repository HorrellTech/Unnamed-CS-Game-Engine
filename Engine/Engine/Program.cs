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

        private static Clock clock = new Clock(); // For calculating FPS
        private static float fps = 0;

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

            float lastTime = 0.0f; // The last calculated time
            // Main game loop
            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear(Colors.Black); // Clear the screen

                // DO LOOP AND DRAWING HERE

                // Draw a basic line
                renderer.DrawSetColor(Color.Red);
                renderer.DrawRectangle(64, 32, 64 + 32, 32 + 32, false);

                // Everything before here needs to be rendered
                window.Display();

                // Calculate FPS
                float currentTime = clock.Restart().AsSeconds();
                fps = 1.0f / lastTime;// (currentTime - lastTime);
                lastTime = currentTime;

                // Set the title with the frames per second
                window.SetTitle("Unnamed Game Engine (FPS: " + ((int)fps).ToString() + ")");
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

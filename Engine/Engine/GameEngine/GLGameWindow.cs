using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Engine.GameEngine
{
    public class GLGameWindow : OpenTK.GameWindow
    {
        private double updateRate;
        private DisplayDevice displayDevice = DisplayDevice.Default; // Use the default diaplay device

        public GameWindow(int width = 640, int height = 480, string title = "My Game", double updateRate = (1.0 / 30), WindowBorder windowBorder = WindowBorder.Fixed, GameWindowFlags windowFlags = GameWindowFlags.Default) 
            : base(width, height, OpenTK.Graphics.GraphicsMode.Default, title, windowFlags, DisplayDevice.Default)
        {
            this.updateRate = updateRate;
            this.Title = title;
            this.WindowBorder = WindowBorder.Fixed;

            // We want to center the screen if not fullscreen
            var w = (displayDevice.Width - width) / 2;
            var h = (displayDevice.Height - height) / 2;

            this.Location = new System.Drawing.Point(w, h);
        }

        public void Show()
        {
            this.Run(updateRate);
        }
    }
}

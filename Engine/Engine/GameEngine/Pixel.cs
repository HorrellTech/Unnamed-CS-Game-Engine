using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.GameEngine
{
    public struct Pixel
    {
        public int r; // Red
        public int g; // Green
        public int b; // Blue
        public int a; // Alpha

        public Pixel(int r, int g, int b, int a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public Pixel(int r, int g, int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            a = 255;
        }
    }
}

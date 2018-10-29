using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.GameEngine
{
    public static class Shaders
    {
        /// <summary>
        /// Basic fragment shader
        /// </summary>
        public static string FragBasic = @"
        void main()
        {
            gl_FragColor = vec4(0.0, 1.0, 1.0, 1.0);
        }
";

        /// <summary>
        /// Basic vertex shader
        /// </summary>
        public static string VertBasic = @"
attribute vec4 a_Position;

        void main()
        {
            gl_Position = a_Position;
        }
";




    }
}

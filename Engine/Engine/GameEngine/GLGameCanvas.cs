using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.GameEngine
{
    public class GLGameCanvas : GLControl
    {

        public GLGameCanvas()
            :base(OpenTK.Graphics.GraphicsMode.Default)
        {

        }
    }
}

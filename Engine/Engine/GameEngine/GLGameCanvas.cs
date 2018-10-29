using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Engine.GameEngine
{
    public class GLGameCanvas : GLControl
    {
        // Delegates for the loop events
        public delegate void _OnDraw(object sender, System.Windows.Forms.PaintEventArgs e);
        public delegate void _OnLoop(object sender);
        public event _OnDraw OnDraw;
        public event _OnLoop OnLoop;


        int vertex_shader_object, fragment_shader_object, shader_program;
        int vertex_buffer_object, color_buffer_object, element_buffer_object;

        private bool vSync = false; // Vertical sync

        private Thread loopThread;

        public GLGameCanvas()
            :base(OpenTK.Graphics.GraphicsMode.Default)
        {
            VSync = vSync;

            CreateShaders(Shaders.VertBasic, Shaders.FragBasic,
                    out vertex_shader_object, out fragment_shader_object,
out shader_program);

            loopThread = new Thread(Loop);
            Paint += GLGameCanvas_Paint;
        }

        // The loop event
        private void Loop()
        {
            if(OnLoop != null)
            {
                OnLoop(this);
            }
            

        }

        private void GLGameCanvas_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // Do the painting
            if(OnDraw != null)
            {
                OnDraw(sender, e);
            }
        }

        public void CreateShaders(string vs, string fs,
            out int vertexObject, out int fragmentObject,
            out int program)
        {
            int status_code;
            string info;

            vertexObject = GL.CreateShader(ShaderType.VertexShader);
            fragmentObject = GL.CreateShader(ShaderType.FragmentShader);

            // Compile vertex shader
            GL.ShaderSource(vertexObject, vs);
            GL.CompileShader(vertexObject);
            GL.GetShaderInfoLog(vertexObject, out info);
            GL.GetShader(vertexObject, ShaderParameter.CompileStatus, out status_code);

            if (status_code != 1)
                throw new ApplicationException(info);

            // Compile vertex shader
            GL.ShaderSource(fragmentObject, fs);
            GL.CompileShader(fragmentObject);
            GL.GetShaderInfoLog(fragmentObject, out info);
            GL.GetShader(fragmentObject, ShaderParameter.CompileStatus, out status_code);

            if (status_code != 1)
                throw new ApplicationException(info);

            program = GL.CreateProgram();
            GL.AttachShader(program, fragmentObject);
            GL.AttachShader(program, vertexObject);

            GL.LinkProgram(program);
            GL.UseProgram(program);
        }
    }
}

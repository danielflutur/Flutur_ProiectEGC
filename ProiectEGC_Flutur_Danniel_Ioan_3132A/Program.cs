using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Platform;

namespace ProiectEGC_Flutur_Daniel_Ioan_3132A
{
    class SimpleWindow : GameWindow
    {

        //Constructor
        public SimpleWindow() : base(800, 600)
        {
            KeyDown += Keyboard_KeyDown;
        }

        void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Exit();

            if (e.Key == Key.F11)
                if (this.WindowState == WindowState.Fullscreen)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Fullscreen;
        }
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.DarkGreen);
        }
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();
            int x = mouse.X;
            int y = mouse.Y;
            if (keyboard[Key.X])
            {
                GL.Rotate(5, 1, 1, 1);
            }
            if (keyboard[Key.Y])
            {
                GL.Rotate(-5, 1, 1, 1);
            }
            if ((x != X || y != Y) && mouse[MouseButton.Left])
            {
                GL.Viewport(x, -y, Width, Height);
            }
            if (keyboard[Key.Escape])
                Exit();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            // Modul imediat! Suportat până la OpenGL 3.5 (este ineficient din cauza multiplelor apeluri de
            // funcții).
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(Color.Black);
            GL.Vertex2(-1.0f, 1.0f);
            GL.Color3(Color.MidnightBlue);
            GL.Vertex2(0.0f, -1.0f);
            GL.Color3(Color.Blue);
            GL.Vertex2(1.0f, 1.0f);
            GL.Color3(Color.AliceBlue);
            GL.Vertex2(1.0f, 1.0f);

            GL.End();
            // Sfârșitul modului imediat!

            this.SwapBuffers();
        }

        static void Main(string[] args)
        {
            using (SimpleWindow example = new SimpleWindow())
            {
                example.Run(30.0, 0.0);
            }
        }
    }
}

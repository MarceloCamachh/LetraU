using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;

namespace LetraU
{
    class Game : GameWindow
    {
        public Game(int width, int height) : base(width, height, GraphicsMode.Default, "Diseño Letra U - 3D")
        {
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(0.0f, 0.0f, 0.5f, 1.0f);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);
            float aspectRatio = (float)Width / Height;
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.DegreesToRadians(45.0f), aspectRatio, 0.1f, 100.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);
            // Configura la cámara
            Matrix4 modelview = Matrix4.LookAt(
                new Vector3(1.5f, 2f, 3.5f), // Posición de la cámara
                new Vector3(0.0f, 0.1f, 0.0f), // Punto de mira
                Vector3.UnitY); // Vector arriba
            GL.LoadMatrix(ref modelview);

            GL.PushMatrix();
            GL.Color4(0.5f, 0.5f, 0.5f, 0.0f);

             // Parte de la U lateral Izq 
                GL.Begin(PrimitiveType.LineLoop);
                // Cara frontal
                GL.Vertex3(-0.8f, 1.2f, 0.3f);
                GL.Vertex3(-0.4f, 1.2f, 0.3f);
                GL.Vertex3(-0.4f, -0.8f, 0.3f);
                GL.Vertex3(-0.8f, -0.8f, 0.3f);
                GL.End();
            

            GL.Begin(PrimitiveType.LineLoop);
            // Cara superior            
            GL.Vertex3(-0.8f, 1.2f, 0.3f);
            GL.Vertex3(-0.8f, 1.2f, -0.3f);
            GL.Vertex3(-0.4f, 1.2f, -0.3f);
            GL.Vertex3(-0.4f, 1.2f, 0.3f);
            GL.End();

            GL.Begin(PrimitiveType.LineLoop);
            // Cara inferior
            GL.Vertex3(-0.8f, -0.8f, -0.3f);
            GL.Vertex3(-0.4f, -0.8f, -0.3f);
            GL.Vertex3(-0.4f, -0.8f, 0.3f);
            GL.Vertex3(-0.8f, -0.8f, 0.3f);
            GL.End();

            GL.Begin(PrimitiveType.LineLoop);
            // Cara Atras
            GL.Vertex3(-0.8f, 1.2f, -0.3f);
            GL.Vertex3(-0.4f, 1.2f, -0.3f);
            GL.Vertex3(-0.4f, -0.8f, -0.3f);
            GL.Vertex3(-0.8f, -0.8f, -0.3f);
            GL.End();

            GL.Begin(PrimitiveType.LineLoop);
            // Cara Lateral Izq
            GL.Vertex3(-0.8f, 1.2f, 0.3f);
            GL.Vertex3(-0.8f, 1.2f, -0.3f);
            GL.Vertex3(-0.8f, -0.8f, -0.3f);
            GL.Vertex3(-0.8f, -0.8f, 0.3f);
            GL.End();

            GL.Begin(PrimitiveType.LineLoop);
            // Cara Lateral Der
            GL.Vertex3(-0.4f, 1.2f, 0.3f);
            GL.Vertex3(-0.4f, 1.2f, -0.3f);
            GL.Vertex3(-0.4f, -0.8f, -0.3f);
            GL.Vertex3(-0.4f, -0.8f, 0.3f);
            GL.End();

            // Parte de la U lateral Der 
            GL.Begin(PrimitiveType.LineLoop);
            // Cara frontal
            GL.Vertex3(0.4f, 1.2f, 0.3f);
            GL.Vertex3(0.8f, 1.2f, 0.3f);
            GL.Vertex3(0.8f, -0.8f, 0.3f);
            GL.Vertex3(0.4f, -0.8f, 0.3f);
            GL.End();

            GL.Begin(PrimitiveType.LineLoop);
            // Cara superior
            GL.Vertex3(0.4f, 1.2f, 0.3f);
            GL.Vertex3(0.4f, 1.2f, -0.3f);
            GL.Vertex3(0.8f, 1.2f, -0.3f);
            GL.Vertex3(0.8f, 1.2f, 0.3f);
            GL.End();

            GL.Begin(PrimitiveType.LineLoop);
            // Cara inferior
            GL.Vertex3(0.4f, -0.8f, 0.3f);
            GL.Vertex3(0.4f, -0.8f, -0.3f);
            GL.Vertex3(0.8f, -0.8f, -0.3f);
            GL.Vertex3(0.8f, -0.8f, 0.3f);
            GL.End();

            GL.Begin(PrimitiveType.LineLoop);
            // Cara Atras
            GL.Vertex3(0.4f, 1.2f, -0.3f);
            GL.Vertex3(0.8f, 1.2f, -0.3f);
            GL.Vertex3(0.8f, -0.8f, -0.3f);
            GL.Vertex3(0.4f, -0.8f, -0.3f);
            GL.End();

            GL.Begin(PrimitiveType.LineLoop);
            // Cara Lateral Izq
            GL.Vertex3(0.4f, 1.2f, 0.3f);
            GL.Vertex3(0.4f, 1.2f, -0.3f);
            GL.Vertex3(0.4f, -0.8f, -0.3f);
            GL.Vertex3(0.4f, -0.8f, 0.3f);
            GL.End();

            GL.Begin(PrimitiveType.LineLoop);
            // Cara Lateral Der
            GL.Vertex3(0.8f, 1.2f, 0.3f);
            GL.Vertex3(0.8f, 1.2f, -0.3f);
            GL.Vertex3(0.8f, -0.8f, -0.3f);
            GL.Vertex3(0.8f, -0.8f, 0.3f);
            GL.End();

            // Parte de la U inferior 
            GL.Begin(PrimitiveType.LineLoop);
            // Cara frontal
            GL.Vertex3(-0.8f, -0.8f, 0.3f);
            GL.Vertex3(0.8f, -0.8f, 0.3f);
            GL.Vertex3(0.8f, -1.2f, 0.3f);
            GL.Vertex3(-0.8f, -1.2f, 0.3f);
            GL.End();

            GL.Begin(PrimitiveType.LineLoop);
            // Cara Atras
            GL.Vertex3(-0.8f, -0.8f, -0.3f);
            GL.Vertex3(0.8f, -0.8f, -0.3f);
            GL.Vertex3(0.8f, -1.2f, -0.3f);
            GL.Vertex3(-0.8f, -1.2f, -0.3f);
            GL.End();

            GL.Begin(PrimitiveType.LineLoop);
            // Cara superior
            GL.Vertex3(-0.8f, -0.8f, 0.3f);
            GL.Vertex3(-0.8f, -0.8f, -0.3f);
            GL.Vertex3(0.8f, -0.8f, -0.3f);
            GL.Vertex3(0.8f, -0.8f, 0.3f);
            GL.End();

            GL.Begin(PrimitiveType.LineLoop);
            // Cara inferior
            GL.Vertex3(-0.8f, -1.2f, 0.3f);
            GL.Vertex3(-0.8f, -1.2f, -0.3f);
            GL.Vertex3(0.8f, -1.2f, -0.3f);
            GL.Vertex3(0.8f, -1.2f, 0.3f);
            GL.End();

            GL.Begin(PrimitiveType.LineLoop);
            // Cara lateral Izq
            GL.Vertex3(-0.8f, -0.8f, 0.3f);
            GL.Vertex3(-0.8f, -0.8f, -0.3f);
            GL.Vertex3(-0.8f, -1.2f, -0.3f);
            GL.Vertex3(-0.8f, -1.2f, 0.3f);
            GL.End();

            GL.Begin(PrimitiveType.LineLoop);
            // Cara lateral Der
            GL.Vertex3(0.8f, -0.8f, 0.3f);
            GL.Vertex3(0.8f, -0.8f, -0.3f);
            GL.Vertex3(0.8f, -1.2f, -0.3f);
            GL.Vertex3(0.8f, -1.2f, 0.3f);
            GL.End();

            // Dibuja los ejes coordenados-------------------------------------------------------------------------------------
            GL.Begin(PrimitiveType.Lines);

            // Eje X (Rojo)
            GL.Color3(1.0f, 0.0f, 0.0f);
            GL.Vertex3(-2.0f, 0.0f, 0.0f);
            GL.Vertex3(2.0f, 0.0f, 0.0f);

            // Eje Y (Verde)
            GL.Color3(0.0f, 1.0f, 0.0f);
            GL.Vertex3(0.0f, -2.0f, 0.0f);
            GL.Vertex3(0.0f, 2.0f, 0.0f);

            // Eje Z (Azul)
            GL.Color3(0.0f, 0.0f, 1.0f);
            GL.Vertex3(0.0f, 0.0f, -2.0f);
            GL.Vertex3(0.0f, 0.0f, 2.0f);

            GL.End();


            GL.PopMatrix();
            SwapBuffers();
        }
    }
}

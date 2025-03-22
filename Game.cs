using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;

namespace TareaU
{
    class Game : GameWindow
    {
        public Game(int width, int height) : base(width, height, GraphicsMode.Default, "Tarea Letra U ")
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

            Matrix4 modelview = Matrix4.LookAt(
                new Vector3(1.5f, 2f, 3.5f),  // Cámara
                new Vector3(0.0f, 0.1f, 0.0f), // Mira al origen
                Vector3.UnitY);
            GL.LoadMatrix(ref modelview);

            // Dibuja múltiples letras U (ahora sin Translate)
            DibujarLetraU(new Vector3(-2f, 0.0f, 0.0f));  // Centro
            //DibujarLetraU(new Vector3(1.5f, 0.0f, 0.0f)); // A la derecha
            //DibujarLetraU(new Vector3(-1.5f, 0.0f, 0.0f)); // A la izquierda

            DibujarEjes(); // Solo una vez

            SwapBuffers();
        }

        private void DibujarLetraU(Vector3 posicion, float rotacionY = 0f)
        {
            GL.PushMatrix();
            GL.Rotate(rotacionY, 0f, 1f, 0f);
            GL.Scale(0.3f, 0.3f, 0.3f); // Puedes ajustar este valor para cambiar el tamaño de todas las letras
            GL.Color4(0.5f, 0.5f, 0.5f, 1.0f);

            // Parte lateral izquierda de la U
            DibujaCaja(posicion, -0.8f, -0.8f, 0.3f, -0.4f, 1.2f, -0.3f);
            // Parte lateral derecha de la U
            DibujaCaja(posicion, 0.4f, -0.8f, 0.3f, 0.8f, 1.2f, -0.3f);
            // Parte inferior de la U
            DibujaCaja(posicion, -0.8f, -1.2f, 0.3f, 0.8f, -0.8f, -0.3f);

            GL.PopMatrix();
        }

        private void DibujaCaja(Vector3 offset, float x1, float y1, float z1, float x2, float y2, float z2)
        {
            // 8 vértices con offset aplicado
            Vector3[] v = new Vector3[8];
            v[0] = new Vector3(x1, y2, z1) + offset;
            v[1] = new Vector3(x2, y2, z1) + offset;
            v[2] = new Vector3(x2, y1, z1) + offset;
            v[3] = new Vector3(x1, y1, z1) + offset;
            v[4] = new Vector3(x1, y2, z2) + offset;
            v[5] = new Vector3(x2, y2, z2) + offset;
            v[6] = new Vector3(x2, y1, z2) + offset;
            v[7] = new Vector3(x1, y1, z2) + offset;

            // Caras (6)
            DibujarCara(v[0], v[1], v[2], v[3]); // Frente
            DibujarCara(v[4], v[5], v[6], v[7]); // Atrás
            DibujarCara(v[0], v[4], v[7], v[3]); // Izquierda
            DibujarCara(v[1], v[5], v[6], v[2]); // Derecha
            DibujarCara(v[0], v[1], v[5], v[4]); // Superior
            DibujarCara(v[3], v[2], v[6], v[7]); // Inferior
        }

        private void DibujarCara(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
        {
            GL.Begin(PrimitiveType.LineLoop);
            GL.Vertex3(a);
            GL.Vertex3(b);
            GL.Vertex3(c);
            GL.Vertex3(d);
            GL.End();
        }

        private void DibujarEjes()
        {
            GL.Begin(PrimitiveType.Lines);

            GL.Color3(1.0f, 0.0f, 0.0f); // X
            GL.Vertex3(-2.0f, 0.0f, 0.0f);
            GL.Vertex3(2.0f, 0.0f, 0.0f);

            GL.Color3(0.0f, 1.0f, 0.0f); // Y
            GL.Vertex3(0.0f, -2.0f, 0.0f);
            GL.Vertex3(0.0f, 2.0f, 0.0f);

            GL.Color3(0.0f, 0.0f, 1.0f); // Z
            GL.Vertex3(0.0f, 0.0f, -2.0f);
            GL.Vertex3(0.0f, 0.0f, 2.0f);

            GL.End();
        }
    }
}

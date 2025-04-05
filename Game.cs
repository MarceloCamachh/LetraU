using LetraU;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;

namespace TareaU
{
    class Game : GameWindow
    {
        public Objeto objeto;
        public Objeto objeto2;

        public Game(int width, int height) : base(width, height, GraphicsMode.Default, "Tarea Letra U ")
        {
            objeto = new Objeto(new Vector3(1, 0, 0), this.getVertices());
            objeto2 = new Objeto(new Vector3(-1, 0, 0), this.getVertices());


            Console.WriteLine(this.getVertices().Count);
            Console.WriteLine("hola");
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
            //DibujarLetraU(new Vector3(-2f, 0.0f, 0.0f));  // Centro
            //DibujarLetraU(new Vector3(1.5f, 0.0f, 0.0f)); // A la derecha
            //DibujarLetraU(new Vector3(-1.5f, 0.0f, 0.0f)); // A la izquierda
            this.objeto.Draw();
            //this.objeto2.Draw();


            DibujarEjes(); // Solo una vez
            SwapBuffers();
        }

        private void DibujarLetraU(Vector3 posicion, float rotacionY = 0f)
        {
            GL.PushMatrix();
            GL.Rotate(rotacionY, 0f, 1f, 0f);
            GL.Scale(0.3f, 0.3f, 0.3f); // Puedes ajustar este valor para cambiar el tamaño de todas las letras
            GL.Color4(0.5f, 0.5f, 0.5f, 1.0f);

            

            GL.PopMatrix();
        }

        public List<Vector3 []> getVertices()
        {
            List<Vector3[]> list = new List<Vector3[]>();
            // Parte lateral izquierda de la U
            DibujaCaja(list, -0.8f, -0.8f, 0.3f, -0.4f, 1.2f, -0.3f);
            // Parte lateral derecha de la U
            DibujaCaja(list, 0.4f, -0.8f, 0.3f, 0.8f, 1.2f, -0.3f);
            // Parte inferior de la U
            DibujaCaja(list, -0.8f, -1.2f, 0.3f, 0.8f, -0.8f, -0.3f);
            return list;
        } 

        private void DibujaCaja(List<Vector3[]> list, float x1, float y1, float z1, float x2, float y2, float z2)
        {
            // 8 vértices con offset aplicado
            Vector3[] v = new Vector3[8];
            v[0] = new Vector3(x1, y2, z1);
            v[1] = new Vector3(x2, y2, z1);
            v[2] = new Vector3(x2, y1, z1);
            v[3] = new Vector3(x1, y1, z1);
            v[4] = new Vector3(x1, y2, z2);
            v[5] = new Vector3(x2, y2, z2);
            v[6] = new Vector3(x2, y1, z2);
            v[7] = new Vector3(x1, y1, z2);

            // Caras (6)
            list.Add(DibujarCara(v[0], v[1], v[2], v[3])); // Frente
            list.Add(DibujarCara(v[4], v[5], v[6], v[7])); // Atrás
            list.Add(DibujarCara(v[0], v[4], v[7], v[3])); // Izquierda
            list.Add(DibujarCara(v[1], v[5], v[6], v[2])); // Derecha
            list.Add(DibujarCara(v[0], v[1], v[5], v[4])); // Superior
            list.Add(DibujarCara(v[3], v[2], v[6], v[7])); // Inferior
        }

        private Vector3[] DibujarCara(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
        {
            Vector3[] array = new Vector3[4];
            array[3] = d;
            array[1] = b;
            array[2] = c;
            array[0] = a;
            return array;
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

using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace LetraU
{
    public class Objeto
    {
        private Vector3 centro;
        private List<Vector3[]> listaDeVertices;

        public Objeto(Vector3 centro,List<Vector3[]> list)
        {
            this.centro = centro;
            this.listaDeVertices = list;
        }

        public void Draw()
        {
            GL.PushMatrix();
            //GL.Rotate(rotacionY, 0f, 1f, 0f);
            GL.Scale(0.4f, 0.4f, 0.4f); // Puedes ajustar este valor para cambiar el tamaño de todas las letras
            GL.Color4(0.5f, 0.5f, 0.5f, 1.0f);
            GL.Begin(PrimitiveType.Quads);

            foreach (Vector3[] vector in this.listaDeVertices)
            {
                GL.Vertex3(vector[0]+this.centro);
                GL.Vertex3(vector[1]+this.centro);
                GL.Vertex3(vector[2]+this.centro);
                GL.Vertex3(vector[3]+this.centro);
            }

            GL.End();
            GL.PopMatrix();
        }
    }
}

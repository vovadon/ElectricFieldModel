using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace ElectricFieldModel
{
    public static class MyOl
    {
        public static void Sphere(double r, int nx, int ny, int offsetX = 0, int offsetY = 0, int offsetZ = 0)
        {
            int ix, iy;
            double x, y, z;

            for (iy = 0; iy < ny; ++iy)
            {
                GL.Begin(PrimitiveType.QuadStrip);
                for (ix = 0; ix <= nx; ++ix)
                {
                    x = r * Math.Sin(iy * Math.PI / ny) * Math.Cos(2 * ix * Math.PI / nx);
                    y = r * Math.Sin(iy * Math.PI / ny) * Math.Sin(2 * ix * Math.PI / nx);
                    z = r * Math.Cos(iy * Math.PI / ny);
                    GL.Normal3(x + offsetX, y + offsetY, z + offsetZ); //нормаль направлена от центра
                    GL.TexCoord2((double)ix / (double)nx, (double)iy / (double)ny);
                    GL.Vertex3(x + offsetX, y + offsetY, z + offsetZ);

                    x = r * Math.Sin((iy + 1) * Math.PI / ny) * Math.Cos(2 * ix * Math.PI / nx);
                    y = r * Math.Sin((iy + 1) * Math.PI / ny) * Math.Sin(2 * ix * Math.PI / nx);
                    z = r * Math.Cos((iy + 1) * Math.PI / ny);
                    GL.Normal3(x + offsetX, y + offsetY, z + offsetZ);
                    GL.TexCoord2((double)ix / (double)nx, (double)(iy + 1) / (double)ny);
                    GL.Vertex3(x + offsetX, y + offsetY, z + offsetZ);
                }
                GL.End();
            }
        }

        public static void Cube(int negX, int negY, int negZ, int posX, int posY, int posZ)
        {
            GL.Begin(PrimitiveType.LineLoop);
            GL.Vertex3(negX, negY, negZ);
            GL.Vertex3(negX, negY, posZ);
            GL.Vertex3(negX, posY, posZ);
            GL.Vertex3(negX, posY, negZ);
            GL.End();

            GL.Begin(PrimitiveType.LineLoop);
            GL.Vertex3(posX, posY, posZ);
            GL.Vertex3(posX, posY, negZ);
            GL.Vertex3(posX, negY, negZ);
            GL.Vertex3(posX, negY, posZ);
            GL.End();

            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(negX, negY, posZ);
            GL.Vertex3(posX, negY, posZ);

            GL.Vertex3(negX, negY, negZ);
            GL.Vertex3(posX, negY, negZ);

            GL.Vertex3(negX, posY, posZ);
            GL.Vertex3(posX, posY, posZ);

            GL.Vertex3(negX, posY, negZ);
            GL.Vertex3(posX, posY, negZ);
            GL.End();
        }
    }
}

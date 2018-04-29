using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ElectricFieldModel
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            gCtrl.Load += GCtrl_Load;
            gCtrl.Paint += GCtrl_Paint;
            gCtrl.KeyDown += GCtrl_KeyDown;

            rotationTimer.Tick += RotationTimer_Tick;
            startTimerBut.Click += (o, e) => rotationTimer.Start();
        }

        private void RotationTimer_Tick(object sender, EventArgs e)
        {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.Rotate(2, 0, 0, 1);

            gCtrl.Invalidate();
        }

        private void GCtrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                GL.MatrixMode(MatrixMode.Projection);
                GL.Rotate(30, 0, 0, 1);
            }
            if (e.KeyCode == Keys.B)
            {
                GL.MatrixMode(MatrixMode.Modelview);
                GL.Rotate(30, 0, 0, 1);
            }

            gCtrl.Invalidate();
        }

        private void GCtrl_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            #region Cube
            ///*задняя*/
            //GL.Color3(Color.Red);
            //GL.Begin(PrimitiveType.Polygon);
            //GL.Vertex3(0, 0, 0);
            //GL.Vertex3(width, 0, 0);
            //GL.Vertex3(width, width, 0);
            //GL.Vertex3(0, width, 0);
            //GL.End();

            ///*левая*/
            //GL.Begin(PrimitiveType.Polygon);
            //GL.Vertex3(0, 0, 0);
            //GL.Vertex3(0, 0, width);
            //GL.Vertex3(0, width, width);
            //GL.Vertex3(0, width, 0);
            //GL.End();

            ///*нижняя*/
            //GL.Begin(PrimitiveType.Polygon);
            //GL.Vertex3(0, 0, 0);
            //GL.Vertex3(0, 0, width);
            //GL.Vertex3(width, 0, width);
            //GL.Vertex3(width, 0, 0);
            //GL.End();

            ///*верхняя*/
            //GL.Begin(PrimitiveType.Polygon);
            //GL.Vertex3(0, width, 0);
            //GL.Vertex3(0, width, width);
            //GL.Vertex3(width, width, width);
            //GL.Vertex3(width, width, 0);
            //GL.End();

            ///*передняя*/
            //GL.Begin(PrimitiveType.Polygon);
            //GL.Vertex3(0, 0, width);
            //GL.Vertex3(width, 0, width);
            //GL.Vertex3(width, width, width);
            //GL.Vertex3(0, width, width);
            //GL.End();

            ///*правая*/
            //GL.Begin(PrimitiveType.Polygon);
            //GL.Vertex3(width, 0, 0);
            //GL.Vertex3(width, 0, width);
            //GL.Vertex3(width, width, width);
            //GL.Vertex3(width, width, 0);
            //GL.End();

            //GL.Color3(Color.Black);
            //GL.Begin(PrimitiveType.LineLoop);
            //GL.Vertex3(0, 0, 0);
            //GL.Vertex3(0, width, 0);
            //GL.Vertex3(width, width, 0);
            //GL.Vertex3(width, 0, 0);
            //GL.End();

            //GL.Begin(PrimitiveType.LineLoop);
            //GL.Vertex3(width, 0, 0);
            //GL.Vertex3(width, 0, width);
            //GL.Vertex3(width, width, width);
            //GL.Vertex3(width, width, 0);
            //GL.End();

            //GL.Begin(PrimitiveType.LineLoop);
            //GL.Vertex3(0, 0, width);
            //GL.Vertex3(width, 0, width);
            //GL.Vertex3(width, width, width);
            //GL.Vertex3(0, width, width);
            //GL.End();

            //GL.Begin(PrimitiveType.LineLoop);
            //GL.Vertex3(0, 0, 0);
            //GL.Vertex3(0, 0, width);
            //GL.Vertex3(0, width, width);
            //GL.Vertex3(0, width, 0);
            //GL.End();

            //GL.Color3(Color.Black);
            //GL.Begin(PrimitiveType.Lines);
            //GL.Vertex3(0, 0, 0);
            //GL.Vertex3(50, 0, 0);
            //GL.Vertex3(0, 0, 0);
            //GL.Vertex3(0, 50, 0);
            //GL.Vertex3(0, 0, 0);
            //GL.Vertex3(0, 0, 50);
            //GL.End();
            #endregion

            GL.Color3(Color.White);
            
            MyOl.Sphere(5, 16, 16);

            gCtrl.SwapBuffers();
        }

        private void GCtrl_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color.Black);
            GL.Enable(EnableCap.DepthTest);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)(60 * Math.PI / 180), 1, 5, 20);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

            Matrix4 modelwiev = Matrix4.LookAt(5, 5, 10, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelwiev);

            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
        }
    }
}
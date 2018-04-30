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
using ElectricFieldModel.Core;

namespace ElectricFieldModel
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            electricField = new Field(new Coord3d(-width, -width, -width), new Coord3d(width, width, width));

            electricField.AddCharges(new Charge(new Coord3d(0, 0, 0), 5, 4E-6), new Charge(new Coord3d(20, 0, 0), 5, -4E-6));

            gCtrl.Load += GCtrl_Load;
            gCtrl.Paint += GCtrl_Paint;
            gCtrl.KeyDown += GCtrl_KeyDown;
        }

        private void GCtrl_KeyDown(object sender, KeyEventArgs e)
        {
            GL.MatrixMode(MatrixMode.Projection);
            switch (e.KeyCode)
            {
                case Keys.A:
                    GL.Translate(1, 0, 0);
                    break;
                case Keys.D:
                    GL.Translate(-1, 0, 0);
                    break;
                case Keys.W:
                    GL.Translate(0, -1, 0);
                    break;
                case Keys.S:
                    GL.Translate(0, 1, 0);
                    break;
                case Keys.Q:
                    GL.Translate(0, 0, -1);
                    break;
                case Keys.E:
                    GL.Translate(0, 0, 1);
                    break;
                case Keys.Z:
                    GL.Rotate(5, 0, 1, 0);
                    break;
                case Keys.C:
                    GL.Rotate(5, 0, -1, 0);
                    break;
            }

            gCtrl.Invalidate();
        }

        private void GCtrl_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //GL.LineWidth(2);
            //GL.Begin(PrimitiveType.Lines);
            //GL.Color3(Color.Red);
            //GL.Vertex3(0, 0, 0);
            //GL.Vertex3(100, 0, 0);

            //GL.Color3(Color.Green);
            //GL.Vertex3(0, 0, 0);
            //GL.Vertex3(0, 100, 0);

            //GL.Color3(Color.Blue);
            //GL.Vertex3(0, 0, 0);
            //GL.Vertex3(0, 0, 100);
            //GL.End();
            GL.Color3(Color.White);
            MyOl.Cube(-width, -width, -width, width, width, width);

            GL.LineWidth(1);

            GL.Color3(Color.Red);
            MyOl.Sphere(5, 16, 16);
            GL.Color3(Color.Blue);
            MyOl.Sphere(5, 16, 16, 20);

            GL.Color3(Color.Yellow);
            GL.Begin(PrimitiveType.Lines);
            var crg = electricField.GetChargeArray.Where(chrg => chrg.GetValue > 0d).First();
            electricField.DrawLines(crg, 0, 8, GL.Vertex3);
            GL.End();

            gCtrl.SwapBuffers();
        }

        private void GCtrl_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color.Black);
            GL.Enable(EnableCap.DepthTest);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)(80 * Math.PI / 180), 4/3, 5, 300);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

            Matrix4 modelwiev = Matrix4.LookAt(0, 0, 20, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelwiev);

            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
        }

        private int width = 50;
        private Field electricField;
    }
}
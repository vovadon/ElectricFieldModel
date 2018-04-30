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

            electricField.AddCharges(new Charge(new Coord3d(-10, 0, 0), 5, 4E-6), new Charge(new Coord3d(10, 0, 0), 5, -4E-6));

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
            MyOl.Sphere(5, 16, 16, -10);
            //MyOl.Sphere(5, 16, 16, 10, 20);

            GL.Color3(Color.Blue);
            MyOl.Sphere(5, 16, 16, 10);
            //MyOl.Sphere(5, 16, 16, -10, 20);

            GL.Color3(Color.Yellow);
            GL.Begin(PrimitiveType.Lines);

            var chargeCollection = electricField.GetChargeArray.Where(chrg => chrg.GetValue > 0d);
            foreach (var crg in chargeCollection)
            {
                electricField.DrawLines(crg, 2, 16, GL.Vertex3);
            }
            
            GL.End();
            
            gCtrl.SwapBuffers();
        }

        private void TestMethod()
        {
            var crgPos = electricField.GetChargeArray[0];
            var crgNeg = electricField.GetChargeArray[1];

            var posIdty = crgPos.GetTensionVector(new Coord3d(30, 0, 45));
            var negIdty = crgNeg.GetTensionVector(new Coord3d(30, 0, 45));

            var res = posIdty + negIdty;

            GL.Color3(Color.Green);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(posIdty.GetStartCoord.AsArray);
            GL.Vertex3(posIdty.GetEndCoord.AsArray);

            GL.Color3(Color.DarkOrange);
            GL.Vertex3(negIdty.GetStartCoord.AsArray);
            GL.Vertex3(negIdty.GetEndCoord.AsArray);

            GL.Color3(Color.Purple);
            GL.Vertex3(res.GetStartCoord.AsArray);
            GL.Vertex3(res.GetEndCoord.AsArray);
            GL.End();
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

        private int width = 100;
        private Field electricField;
    }
}
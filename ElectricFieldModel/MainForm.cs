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

            var electricField = new Field(new Coord3d(-width, -width, -width), new Coord3d(width, width, width));

            electricField.AddCharges(new Charge(new Coord3d(-10, 0, 0), 5, 4E-6), 
                new Charge(new Coord3d(10, 0, 0), 5, -4E-6),
                new Charge(new Coord3d(-10, 20, 0), 5, -4E-6),
                new Charge(new Coord3d(10, 20, 0), 5, 4E-6));

            vertex = CalculateVertex(electricField);

            gCtrl.Load += GCtrl_Load;
            gCtrl.Paint += GCtrl_Paint;
            gCtrl.KeyDown += GCtrl_KeyDown;
            gCtrl.MouseMove += GCtrl_MouseMove;

            angleTimer.Tick += AngleTimer_Tick;
        }

        private double[][] CalculateVertex(Field electricField)
        {
            var chargeCollection = electricField.GetChargeArray.Where(chrg => chrg.GetValue > 0d);

            var vertexArray = new double[chargeCollection.Count()][];
            var vertex = new List<double>();

            var i = 0;
            foreach (var crg in chargeCollection)
            {
                electricField.DrawLines(crg, 1, 16, vertex.AddRange);

                vertexArray[i++] = vertex.ToArray();
                vertex.Clear();
            }
            return vertexArray;
        }
        
        private void GCtrl_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void AngleTimer_Tick(object sender, EventArgs e)
        {
            int xt = Screen.PrimaryScreen.Bounds.Width / 2;
            int yt = Screen.PrimaryScreen.Bounds.Height / 2;

            angleX += (400 - mouseX) / 4;
            angleY += (304 - mouseY) / 4;

            if (angleY < -89.0) angleY = -89.0f;
            if (angleY > 89.0) angleY = 89.0f;

            Cursor.Position = new Point(xt, yt);

            Matrix4 modelwiev = Matrix4.LookAt(x, y, z, (float)(x - Math.Sin(angleX / 180 * Math.PI)),
                (float)(y + Math.Tan(angleY / 180 * Math.PI)), (float)(z - Math.Cos(angleX / 180 * Math.PI)), 0, 1, 0);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelwiev);

            gCtrl.Invalidate();
        }
        
        private void GCtrl_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    dx = (float)Math.Sin((angleX - 90) / 180 * Math.PI) * speed;
                    dz = (float)Math.Cos((angleX - 90) / 180 * Math.PI) * speed;
                    dy = 0;
                    break;
                case Keys.D:
                    dx = (float)Math.Sin((angleX + 90) / 180 * Math.PI) * speed;
                    dz = (float)Math.Cos((angleX + 90) / 180 * Math.PI) * speed;
                    dy = 0;
                    break;
                case Keys.W:
                    dx = -(float)Math.Sin(angleX / 180 * Math.PI) * speed;
                    dy = (float)Math.Tan(angleY / 180 * Math.PI) * speed;
                    dz = -(float)Math.Cos(angleX / 180 * Math.PI) * speed;
                    break;
                case Keys.S:
                    dx = (float)Math.Sin(angleX / 180 * Math.PI) * speed;
                    dy = -(float)Math.Tan(angleY / 180 * Math.PI) * speed;
                    dz = (float)Math.Cos(angleX / 180 * Math.PI) * speed;
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
            }

            x += dx;
            y += dy;
            z += dz;

            gCtrl.Invalidate();
        }

        private void GCtrl_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Глобальные оси координат
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
            MyOl.Sphere(5, 16, 16, 10, 20);

            GL.Color3(Color.Blue);
            MyOl.Sphere(5, 16, 16, 10);
            MyOl.Sphere(5, 16, 16, -10, 20);

            GL.Color3(Color.Yellow);
            GL.Begin(PrimitiveType.Lines);

            for (int i = 0; i < vertex.Length; i++)
            {
                int columnCount = vertex[i].Length;

                for (int j = 0; j < columnCount; j += 3)
                {
                    GL.Vertex3(vertex[i][j], vertex[i][j + 1], vertex[i][j + 2]);
                }
            }

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

            Matrix4 modelwiev = Matrix4.LookAt(x, y, z, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelwiev);

            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);

            Cursor.Hide();
            angleTimer.Start();
        }

        private int mouseX, mouseY;
        private float angleX, angleY;
        private float dx, dy, dz;
        private float x, y, z = 50;
        private float speed = 1.0f;
        
        private int width = 100;
        private double[][] vertex;
    }
}
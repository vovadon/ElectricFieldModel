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
        public MainForm(FormUI ui, int width, int height, bool fullScreen)
        {
            InitializeComponent(width, height);
            
            if (fullScreen) WindowState = FormWindowState.Maximized;

            FieldWidth = 100;
            Sensitivity = 4;
            SpherePolygon = 8;
            StepValue = 1.0;

            userInterface = ui;
            
            gCtrl.Load += GCtrl_Load;
            gCtrl.Paint += GCtrl_Paint;
            gCtrl.KeyDown += GCtrl_KeyDown;

            angleTimer.Tick += AngleTimer_Tick;
        }

        public void AddCharges(Charge[] charges)
        {
            electricField = new Field(new Coord3d(-FieldWidth, -FieldWidth, -FieldWidth), new Coord3d(FieldWidth, FieldWidth, FieldWidth));

            electricField.AddCharges(charges);

            vertex = CalculateVertex();
        }

        private double[][] CalculateVertex()
        {
            var chargeCollection = electricField.GetChargeArray.Where(chrg => chrg.GetValue > 0d);

            var vertexArray = new double[chargeCollection.Count()][];
            var vertex = new List<double>();

            var i = 0;
            foreach (var crg in chargeCollection)
            {
                electricField.DrawLines(crg, StepValue, SpherePolygon, vertex.AddRange);

                vertexArray[i++] = vertex.ToArray();
                vertex.Clear();
            }
            return vertexArray;
        }

        private void AngleTimer_Tick(object sender, EventArgs e)
        {
            int xt = Screen.PrimaryScreen.Bounds.Width / 2;
            int yt = Screen.PrimaryScreen.Bounds.Height / 2;

            angleX += (xt - Cursor.Position.X) / Sensitivity;
            angleY += (yt - Cursor.Position.Y) / Sensitivity;

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
                    Close();
                    Cursor.Show();
                    userInterface.Show();
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
            MyOl.Cube(-FieldWidth, -FieldWidth, -FieldWidth, FieldWidth, FieldWidth, FieldWidth);

            foreach (var crg in electricField.GetChargeArray)
            {
                var pos = crg.GetPosition;

                if (crg.GetValue > 0d)
                    GL.Color3(PositiveColor);
                else
                    GL.Color3(NegativeColor);

                MyOl.Sphere(5, 16, 16, (int)pos.X, (int)pos.Y, (int)pos.Z);
            }

            GL.Color3(LineColor);
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

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)(80 * Math.PI / 180), gCtrl.Width / gCtrl.Height, 5, 500);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

            Matrix4 modelwiev = Matrix4.LookAt(x, y, z, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelwiev);

            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            
            Cursor.Hide();
            angleTimer.Start();
        }

        public int FieldWidth { get; set; }
        public int Sensitivity { get; set; }
        public int SpherePolygon { get; set; }
        public double StepValue { get; set; }

        public Color PositiveColor { get; set; }
        public Color NegativeColor { get; set; }
        public Color LineColor { get; set; }

        private float angleX, angleY;
        private float dx, dy, dz;
        private float x, y, z = 50;
        private float speed = 1.0f;
        private double[][] vertex;

        private FormUI userInterface;
        private Field electricField;
    }
}
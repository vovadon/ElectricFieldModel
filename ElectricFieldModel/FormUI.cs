using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElectricFieldModel.Core;

namespace ElectricFieldModel
{
    public enum FieldType
    {
        single,
        dipole,
        quadrupole,
        octopole,
    }

    public partial class FormUI : Form
    {
        public FormUI()
        {
            InitializeComponent();
            FieldConfigurationInit();

            launchBut.Click += LaunchBut_Click;

            singleRBut.CheckedChanged += FieldTypeChangedChanged;
            dipoleRBut.CheckedChanged += FieldTypeChangedChanged;
            quadrupoleRBut.CheckedChanged += FieldTypeChangedChanged;
            octopoleRBut.CheckedChanged += FieldTypeChangedChanged;

            crgDistanceTxt.KeyDown += CrgDistanceTxt_KeyDown;

            crgValueTxt.KeyDown += CrgInfoTxt_KeyDown;
            xPosTxt.KeyDown += CrgInfoTxt_KeyDown;
            yPosTxt.KeyDown += CrgInfoTxt_KeyDown;
            zPosTxt.KeyDown += CrgInfoTxt_KeyDown;

            crgNumCmbBox.SelectedIndexChanged += CrgNumChanged;
        }
        
        private void FieldConfigurationInit()
        {
            chargeList = new List<Charge>();

            chargeList.Add(new Charge(new Coord3d(0, 0, 0), 5, 4E-6));

            distanceBetweenCharges = 20d;

            colors = new Dictionary<string, Color>
            {
                { "Красный", Color.Red },
                { "Синий", Color.Blue },
                { "Желтый", Color.Yellow },
                { "Зеленый", Color.Green },
                { "Оранжевый", Color.Orange },
                { "Белый", Color.White }
            };
        }

        private void CrgDistanceTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            if (!Regex.IsMatch(crgDistanceTxt.Text, @"^\d+((\,|E-)\d+)?$"))
            {
                MessageBox.Show("Неправильно введенные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            distanceBetweenCharges = Double.Parse(crgDistanceTxt.Text);
            MessageBox.Show("Расстояние между зарядами изменено на " + crgDistanceTxt.Text, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FieldTypeChangedChanged(this, EventArgs.Empty);
        }

        private void CrgInfoTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            if (!(regex.IsMatch(crgValueTxt.Text) && regex.IsMatch(xPosTxt.Text) && regex.IsMatch(yPosTxt.Text) && regex.IsMatch(zPosTxt.Text)))
            {
                MessageBox.Show("Неправильно введенные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int index = crgNumCmbBox.SelectedIndex;
            double value = Double.Parse(crgValueTxt.Text);
            double x_pos = Double.Parse(xPosTxt.Text);
            double y_pos = Double.Parse(yPosTxt.Text);
            double z_pos = Double.Parse(zPosTxt.Text);

            chargeList[index] = new Charge(new Coord3d(x_pos, y_pos, z_pos), 5, value);

            MessageBox.Show($"Данные заряда №{index + 1} изменены", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CrgNumChanged(object sender, EventArgs e)
        {
            var index = (sender as ComboBox).SelectedIndex;
            var crg = chargeList[index];
            var pos = crg.GetPosition;

            crgValueTxt.Text = crg.GetValue.ToString();
            xPosTxt.Text = pos.X.ToString();
            yPosTxt.Text = pos.Y.ToString();
            zPosTxt.Text = pos.Z.ToString();
        }

        private void FieldTypeChangedChanged(object sender, EventArgs e)
        {
            if (singleRBut.Checked)
                ConfigureField(FieldType.single);
            else if (dipoleRBut.Checked)
                ConfigureField(FieldType.dipole);
            else if (quadrupoleRBut.Checked)
                ConfigureField(FieldType.quadrupole);
            else if (octopoleRBut.Checked)
                ConfigureField(FieldType.octopole);
        }

        private void LaunchBut_Click(object sender, EventArgs e)
        {
            var resolution = GetResolution();

            MainForm mainForm = new MainForm(this, resolution.width, resolution.height, fullScreenCkBox.Checked);

            mainForm.FieldWidth = GetFieldWidth();
            mainForm.Sensitivity = sensitivityTrackBar.Value;
            mainForm.SpherePolygon = GetPointCount;
            mainForm.StepValue = GetStep();

            mainForm.PositiveColor = GetPositiveColor;
            mainForm.NegativeColor = GetNegativeColor;
            mainForm.LineColor = GetLineColor;

            mainForm.AddCharges(chargeList.ToArray());

            this.Hide();
            mainForm.Show();
        }

        private (int width, int height) GetResolution()
        {
            if (fullScreenCkBox.Checked)
                return (Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            int index = resolutionCmbBox.SelectedIndex;

            switch (index)
            {
                case 0:
                    return (400, 300);
                case 1:
                    return (800, 600);
                case 2:
                    return (1024, 768);
                case 3:
                    return (1280, 720);
                default:
                    return (800, 600);
            }
        }

        private void ConfigureField(FieldType fieldType)
        {
            chargeList.Clear();
            crgNumCmbBox.Items.Clear();
            double distance = distanceBetweenCharges / 2;

            switch (fieldType)
            {
                case FieldType.single:
                    chargeList.Add(new Charge(new Coord3d(0, 0, 0), 5, 4E-6));

                    crgNumCmbBox.Items.Add(1);
                    break;
                case FieldType.dipole:
                    chargeList.Add(new Charge(new Coord3d(-distance, 0, 0), 5, 4E-6));
                    chargeList.Add(new Charge(new Coord3d(distance, 0, 0), 5, -4E-6));

                    crgNumCmbBox.Items.AddRange(new object[] { 1, 2 });
                    break;
                case FieldType.quadrupole:
                    chargeList.Add(new Charge(new Coord3d(-distance, -distance, 0), 5, 4E-6));
                    chargeList.Add(new Charge(new Coord3d(distance, -distance, 0), 5, -4E-6));
                    chargeList.Add(new Charge(new Coord3d(-distance, distance, 0), 5, -4E-6));
                    chargeList.Add(new Charge(new Coord3d(distance, distance, 0), 5, 4E-6));

                    crgNumCmbBox.Items.AddRange(new object[] { 1, 2, 3, 4 });
                    break;
                case FieldType.octopole:
                    chargeList.Add(new Charge(new Coord3d(-distance, -distance, distance), 5, 4E-6));
                    chargeList.Add(new Charge(new Coord3d(-distance, -distance, -distance), 5, -4E-6));
                    chargeList.Add(new Charge(new Coord3d(-distance, distance, distance), 5, -4E-6));
                    chargeList.Add(new Charge(new Coord3d(-distance, distance, -distance), 5, 4E-6));

                    chargeList.Add(new Charge(new Coord3d(distance, -distance, distance), 5, -4E-6));
                    chargeList.Add(new Charge(new Coord3d(distance, -distance, -distance), 5, 4E-6));
                    chargeList.Add(new Charge(new Coord3d(distance, distance, distance), 5, 4E-6));
                    chargeList.Add(new Charge(new Coord3d(distance, distance, -distance), 5, -4E-6));

                    crgNumCmbBox.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8 });
                    break;
            }
        }

        private double GetStep()
        {
            if (!Regex.IsMatch(stepValueTxt.Text, @"^\d+((\,|E-)\d+)?$"))
            {
                MessageBox.Show("Неправильно введенные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }
            return Double.Parse(stepValueTxt.Text);
        }

        private int GetFieldWidth()
        {
            if (!Regex.IsMatch(fieldWidthTxt.Text, "^\\d+$"))
            {
                MessageBox.Show("Неправильно введенные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 100;
            }
            return Int32.Parse(fieldWidthTxt.Text);
        }

        private int GetPointCount => pointCountCmbBox.SelectedIndex == -1 ? 8 : Int32.Parse((String)pointCountCmbBox.SelectedItem);

        private Color GetPositiveColor
        {
            get => positiveColorCmbBox.SelectedIndex == -1 ? Color.Red : colors[(String)positiveColorCmbBox.SelectedItem];
        }

        private Color GetNegativeColor
        {
            get => negativeColorCmbBox.SelectedIndex == -1 ? Color.Blue : colors[(String)negativeColorCmbBox.SelectedItem];
        }

        private Color GetLineColor
        {
            get => lineColorCmbBox.SelectedIndex == -1 ? Color.Yellow : colors[(String)lineColorCmbBox.SelectedItem];
        }

        private double distanceBetweenCharges;

        private List<Charge> chargeList;
        private Dictionary<String, Color> colors;

        private Regex regex = new Regex(@"^-?\d+((\,|E-)\d+)?$");
    }
}

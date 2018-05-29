namespace ElectricFieldModel
{
    partial class FormUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.launchBut = new System.Windows.Forms.Button();
            this.fullScreenCkBox = new System.Windows.Forms.CheckBox();
            this.resolutionCmbBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.crgDistanceTxt = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.octopoleRBut = new System.Windows.Forms.RadioButton();
            this.quadrupoleRBut = new System.Windows.Forms.RadioButton();
            this.dipoleRBut = new System.Windows.Forms.RadioButton();
            this.singleRBut = new System.Windows.Forms.RadioButton();
            this.crgValueTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.zPosTxt = new System.Windows.Forms.TextBox();
            this.yPosTxt = new System.Windows.Forms.TextBox();
            this.xPosTxt = new System.Windows.Forms.TextBox();
            this.crgNumCmbBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.stepValueTxt = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pointCountCmbBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.sensitivityTrackBar = new System.Windows.Forms.TrackBar();
            this.fieldWidthTxt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lineColorCmbBox = new System.Windows.Forms.ComboBox();
            this.negativeColorCmbBox = new System.Windows.Forms.ComboBox();
            this.positiveColorCmbBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensitivityTrackBar)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // launchBut
            // 
            this.launchBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.launchBut.Location = new System.Drawing.Point(269, 306);
            this.launchBut.Name = "launchBut";
            this.launchBut.Size = new System.Drawing.Size(386, 74);
            this.launchBut.TabIndex = 0;
            this.launchBut.Text = "Старт";
            this.launchBut.UseVisualStyleBackColor = true;
            // 
            // fullScreenCkBox
            // 
            this.fullScreenCkBox.AutoSize = true;
            this.fullScreenCkBox.Location = new System.Drawing.Point(11, 59);
            this.fullScreenCkBox.Name = "fullScreenCkBox";
            this.fullScreenCkBox.Size = new System.Drawing.Size(203, 24);
            this.fullScreenCkBox.TabIndex = 1;
            this.fullScreenCkBox.Text = "Полноэкранный режим";
            this.fullScreenCkBox.UseVisualStyleBackColor = true;
            // 
            // resolutionCmbBox
            // 
            this.resolutionCmbBox.FormattingEnabled = true;
            this.resolutionCmbBox.Items.AddRange(new object[] {
            "400x300",
            "800x600",
            "1024x768",
            "1280x720"});
            this.resolutionCmbBox.Location = new System.Drawing.Point(120, 25);
            this.resolutionCmbBox.Name = "resolutionCmbBox";
            this.resolutionCmbBox.Size = new System.Drawing.Size(120, 28);
            this.resolutionCmbBox.TabIndex = 2;
            this.resolutionCmbBox.Text = "800x600";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Разрешение:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBox1.Controls.Add(this.resolutionCmbBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.fullScreenCkBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 207);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 93);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры окна";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox2.Controls.Add(this.pointCountCmbBox);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.fieldWidthTxt);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.octopoleRBut);
            this.groupBox2.Controls.Add(this.quadrupoleRBut);
            this.groupBox2.Controls.Add(this.dipoleRBut);
            this.groupBox2.Controls.Add(this.singleRBut);
            this.groupBox2.Controls.Add(this.stepValueTxt);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 189);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры поля";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(33, 129);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(314, 16);
            this.label15.TabIndex = 16;
            this.label15.Text = "После ввода значения нажмите клавишу Enter!";
            // 
            // crgDistanceTxt
            // 
            this.crgDistanceTxt.Location = new System.Drawing.Point(271, 94);
            this.crgDistanceTxt.Name = "crgDistanceTxt";
            this.crgDistanceTxt.Size = new System.Drawing.Size(100, 26);
            this.crgDistanceTxt.TabIndex = 15;
            this.crgDistanceTxt.Text = "20";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 97);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(259, 20);
            this.label14.TabIndex = 14;
            this.label14.Text = "Расстояние между зарядами (м):";
            // 
            // octopoleRBut
            // 
            this.octopoleRBut.AutoSize = true;
            this.octopoleRBut.Location = new System.Drawing.Point(121, 87);
            this.octopoleRBut.Name = "octopoleRBut";
            this.octopoleRBut.Size = new System.Drawing.Size(100, 24);
            this.octopoleRBut.TabIndex = 13;
            this.octopoleRBut.Text = "Октуполь";
            this.octopoleRBut.UseVisualStyleBackColor = true;
            // 
            // quadrupoleRBut
            // 
            this.quadrupoleRBut.AutoSize = true;
            this.quadrupoleRBut.Location = new System.Drawing.Point(121, 57);
            this.quadrupoleRBut.Name = "quadrupoleRBut";
            this.quadrupoleRBut.Size = new System.Drawing.Size(119, 24);
            this.quadrupoleRBut.TabIndex = 12;
            this.quadrupoleRBut.Text = "Квадруполь";
            this.quadrupoleRBut.UseVisualStyleBackColor = true;
            // 
            // dipoleRBut
            // 
            this.dipoleRBut.AutoSize = true;
            this.dipoleRBut.Location = new System.Drawing.Point(11, 87);
            this.dipoleRBut.Name = "dipoleRBut";
            this.dipoleRBut.Size = new System.Drawing.Size(85, 24);
            this.dipoleRBut.TabIndex = 11;
            this.dipoleRBut.Text = "Диполь";
            this.dipoleRBut.UseVisualStyleBackColor = true;
            // 
            // singleRBut
            // 
            this.singleRBut.AutoSize = true;
            this.singleRBut.Checked = true;
            this.singleRBut.Location = new System.Drawing.Point(11, 57);
            this.singleRBut.Name = "singleRBut";
            this.singleRBut.Size = new System.Drawing.Size(104, 24);
            this.singleRBut.TabIndex = 10;
            this.singleRBut.TabStop = true;
            this.singleRBut.Text = "Монополь";
            this.singleRBut.UseVisualStyleBackColor = true;
            // 
            // crgValueTxt
            // 
            this.crgValueTxt.Location = new System.Drawing.Point(284, 28);
            this.crgValueTxt.Name = "crgValueTxt";
            this.crgValueTxt.Size = new System.Drawing.Size(87, 26);
            this.crgValueTxt.TabIndex = 9;
            this.crgValueTxt.Text = "4E-06";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(157, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Значение (Кл):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(254, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Z:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "X:";
            // 
            // zPosTxt
            // 
            this.zPosTxt.Location = new System.Drawing.Point(283, 62);
            this.zPosTxt.Name = "zPosTxt";
            this.zPosTxt.Size = new System.Drawing.Size(88, 26);
            this.zPosTxt.TabIndex = 4;
            this.zPosTxt.Text = "0";
            // 
            // yPosTxt
            // 
            this.yPosTxt.Location = new System.Drawing.Point(160, 62);
            this.yPosTxt.Name = "yPosTxt";
            this.yPosTxt.Size = new System.Drawing.Size(88, 26);
            this.yPosTxt.TabIndex = 3;
            this.yPosTxt.Text = "0";
            // 
            // xPosTxt
            // 
            this.xPosTxt.Location = new System.Drawing.Point(36, 62);
            this.xPosTxt.Name = "xPosTxt";
            this.xPosTxt.Size = new System.Drawing.Size(88, 26);
            this.xPosTxt.TabIndex = 2;
            this.xPosTxt.Text = "0";
            // 
            // crgNumCmbBox
            // 
            this.crgNumCmbBox.FormattingEnabled = true;
            this.crgNumCmbBox.Location = new System.Drawing.Point(74, 28);
            this.crgNumCmbBox.Name = "crgNumCmbBox";
            this.crgNumCmbBox.Size = new System.Drawing.Size(77, 28);
            this.crgNumCmbBox.TabIndex = 1;
            this.crgNumCmbBox.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Заряд:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Величина шага:";
            // 
            // stepValueTxt
            // 
            this.stepValueTxt.Location = new System.Drawing.Point(143, 117);
            this.stepValueTxt.Name = "stepValueTxt";
            this.stepValueTxt.Size = new System.Drawing.Size(97, 26);
            this.stepValueTxt.TabIndex = 7;
            this.stepValueTxt.Text = "1";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightSalmon;
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.lineColorCmbBox);
            this.groupBox3.Controls.Add(this.negativeColorCmbBox);
            this.groupBox3.Controls.Add(this.positiveColorCmbBox);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(269, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(386, 130);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Параметры визуализации";
            // 
            // pointCountCmbBox
            // 
            this.pointCountCmbBox.FormattingEnabled = true;
            this.pointCountCmbBox.Items.AddRange(new object[] {
            "2",
            "4",
            "6",
            "8",
            "10",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "30",
            "32"});
            this.pointCountCmbBox.Location = new System.Drawing.Point(184, 149);
            this.pointCountCmbBox.Name = "pointCountCmbBox";
            this.pointCountCmbBox.Size = new System.Drawing.Size(56, 28);
            this.pointCountCmbBox.TabIndex = 19;
            this.pointCountCmbBox.Text = "8";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 152);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(172, 20);
            this.label13.TabIndex = 18;
            this.label13.Text = "Полигонов на сфере:";
            // 
            // sensitivityTrackBar
            // 
            this.sensitivityTrackBar.Location = new System.Drawing.Point(6, 25);
            this.sensitivityTrackBar.Minimum = 1;
            this.sensitivityTrackBar.Name = "sensitivityTrackBar";
            this.sensitivityTrackBar.Size = new System.Drawing.Size(239, 45);
            this.sensitivityTrackBar.TabIndex = 17;
            this.sensitivityTrackBar.Value = 4;
            // 
            // fieldWidthTxt
            // 
            this.fieldWidthTxt.Location = new System.Drawing.Point(148, 25);
            this.fieldWidthTxt.Name = "fieldWidthTxt";
            this.fieldWidthTxt.Size = new System.Drawing.Size(92, 26);
            this.fieldWidthTxt.TabIndex = 15;
            this.fieldWidthTxt.Text = "100";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(135, 20);
            this.label11.TabIndex = 14;
            this.label11.Text = "Размер поля (м):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(143, 20);
            this.label10.TabIndex = 13;
            this.label10.Text = "Цвет линий поля:";
            // 
            // lineColorCmbBox
            // 
            this.lineColorCmbBox.FormattingEnabled = true;
            this.lineColorCmbBox.Items.AddRange(new object[] {
            "Красный",
            "Синий",
            "Желтый",
            "Зеленый",
            "Оранжевый",
            "Белый"});
            this.lineColorCmbBox.Location = new System.Drawing.Point(257, 93);
            this.lineColorCmbBox.Name = "lineColorCmbBox";
            this.lineColorCmbBox.Size = new System.Drawing.Size(114, 28);
            this.lineColorCmbBox.TabIndex = 12;
            this.lineColorCmbBox.Text = "Желтый";
            // 
            // negativeColorCmbBox
            // 
            this.negativeColorCmbBox.FormattingEnabled = true;
            this.negativeColorCmbBox.Items.AddRange(new object[] {
            "Красный",
            "Синий",
            "Желтый",
            "Зеленый",
            "Оранжевый",
            "Белый"});
            this.negativeColorCmbBox.Location = new System.Drawing.Point(257, 59);
            this.negativeColorCmbBox.Name = "negativeColorCmbBox";
            this.negativeColorCmbBox.Size = new System.Drawing.Size(114, 28);
            this.negativeColorCmbBox.TabIndex = 11;
            this.negativeColorCmbBox.Text = "Синий";
            // 
            // positiveColorCmbBox
            // 
            this.positiveColorCmbBox.FormattingEnabled = true;
            this.positiveColorCmbBox.Items.AddRange(new object[] {
            "Красный",
            "Синий",
            "Желтый",
            "Зеленый",
            "Оранжевый",
            "Белый"});
            this.positiveColorCmbBox.Location = new System.Drawing.Point(257, 25);
            this.positiveColorCmbBox.Name = "positiveColorCmbBox";
            this.positiveColorCmbBox.Size = new System.Drawing.Size(114, 28);
            this.positiveColorCmbBox.TabIndex = 10;
            this.positiveColorCmbBox.Text = "Красный";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(242, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "Цвет отрицательных зарядов:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(245, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Цвет положительных зарядов:";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Khaki;
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.crgNumCmbBox);
            this.groupBox4.Controls.Add(this.xPosTxt);
            this.groupBox4.Controls.Add(this.crgDistanceTxt);
            this.groupBox4.Controls.Add(this.yPosTxt);
            this.groupBox4.Controls.Add(this.zPosTxt);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.crgValueTxt);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(269, 148);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(386, 152);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Параметры зарядов";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.LightCoral;
            this.groupBox5.Controls.Add(this.sensitivityTrackBar);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox5.Location = new System.Drawing.Point(12, 306);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(251, 74);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Чувствительность мыши";
            // 
            // FormUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 389);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.launchBut);
            this.Name = "FormUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Визуализация электрического поля 3D";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensitivityTrackBar)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button launchBut;
        private System.Windows.Forms.CheckBox fullScreenCkBox;
        private System.Windows.Forms.ComboBox resolutionCmbBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton octopoleRBut;
        private System.Windows.Forms.RadioButton quadrupoleRBut;
        private System.Windows.Forms.RadioButton dipoleRBut;
        private System.Windows.Forms.RadioButton singleRBut;
        private System.Windows.Forms.TextBox crgValueTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox zPosTxt;
        private System.Windows.Forms.TextBox yPosTxt;
        private System.Windows.Forms.TextBox xPosTxt;
        private System.Windows.Forms.ComboBox crgNumCmbBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox stepValueTxt;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox lineColorCmbBox;
        private System.Windows.Forms.ComboBox negativeColorCmbBox;
        private System.Windows.Forms.ComboBox positiveColorCmbBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox fieldWidthTxt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar sensitivityTrackBar;
        private System.Windows.Forms.ComboBox pointCountCmbBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox crgDistanceTxt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}
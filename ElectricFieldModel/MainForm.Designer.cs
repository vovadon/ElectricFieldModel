namespace ElectricFieldModel
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gCtrl = new OpenTK.GLControl();
            this.rotationTimer = new System.Windows.Forms.Timer(this.components);
            this.startTimerBut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gCtrl
            // 
            this.gCtrl.BackColor = System.Drawing.Color.Black;
            this.gCtrl.Location = new System.Drawing.Point(12, 12);
            this.gCtrl.Name = "gCtrl";
            this.gCtrl.Size = new System.Drawing.Size(350, 350);
            this.gCtrl.TabIndex = 0;
            this.gCtrl.VSync = false;
            // 
            // rotationTimer
            // 
            this.rotationTimer.Interval = 50;
            // 
            // startTimerBut
            // 
            this.startTimerBut.Location = new System.Drawing.Point(368, 12);
            this.startTimerBut.Name = "startTimerBut";
            this.startTimerBut.Size = new System.Drawing.Size(143, 23);
            this.startTimerBut.TabIndex = 2;
            this.startTimerBut.Text = "Запустить таймер";
            this.startTimerBut.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 376);
            this.Controls.Add(this.startTimerBut);
            this.Controls.Add(this.gCtrl);
            this.Name = "MainForm";
            this.Text = "CubeRotation";
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl gCtrl;
        private System.Windows.Forms.Timer rotationTimer;
        private System.Windows.Forms.Button startTimerBut;
    }
}


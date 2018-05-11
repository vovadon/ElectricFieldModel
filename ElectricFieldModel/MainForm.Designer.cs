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
            this.angleTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // gCtrl
            // 
            this.gCtrl.BackColor = System.Drawing.Color.Black;
            this.gCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCtrl.Location = new System.Drawing.Point(0, 0);
            this.gCtrl.Name = "gCtrl";
            this.gCtrl.Size = new System.Drawing.Size(800, 600);
            this.gCtrl.TabIndex = 0;
            this.gCtrl.VSync = false;
            // 
            // angleTimer
            // 
            this.angleTimer.Interval = 16;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.gCtrl);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Визуализация электрического поля 3D";
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl gCtrl;
        private System.Windows.Forms.Timer angleTimer;
    }
}


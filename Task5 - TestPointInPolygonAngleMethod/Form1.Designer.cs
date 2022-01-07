
namespace Task5___TestPointInPolygonAngleMethod
{
    partial class Form1
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Mode_None = new System.Windows.Forms.RadioButton();
            this.Mode_Polygon = new System.Windows.Forms.RadioButton();
            this.Mode_Point = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.MinVCUpDown = new System.Windows.Forms.NumericUpDown();
            this.MaxVCUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.MinVCUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxVCUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Mode_None
            // 
            this.Mode_None.AutoSize = true;
            this.Mode_None.Location = new System.Drawing.Point(706, 13);
            this.Mode_None.Name = "Mode_None";
            this.Mode_None.Size = new System.Drawing.Size(51, 17);
            this.Mode_None.TabIndex = 0;
            this.Mode_None.TabStop = true;
            this.Mode_None.Text = "None";
            this.Mode_None.UseVisualStyleBackColor = true;
            this.Mode_None.CheckedChanged += new System.EventHandler(this.ModeNone_CheckedChanged);
            // 
            // Mode_Polygon
            // 
            this.Mode_Polygon.AutoSize = true;
            this.Mode_Polygon.Location = new System.Drawing.Point(706, 37);
            this.Mode_Polygon.Name = "Mode_Polygon";
            this.Mode_Polygon.Size = new System.Drawing.Size(63, 17);
            this.Mode_Polygon.TabIndex = 1;
            this.Mode_Polygon.TabStop = true;
            this.Mode_Polygon.Text = "Polygon";
            this.Mode_Polygon.UseVisualStyleBackColor = true;
            this.Mode_Polygon.CheckedChanged += new System.EventHandler(this.ModePolygon_CheckedChanged);
            // 
            // Mode_Point
            // 
            this.Mode_Point.AutoSize = true;
            this.Mode_Point.Location = new System.Drawing.Point(706, 61);
            this.Mode_Point.Name = "Mode_Point";
            this.Mode_Point.Size = new System.Drawing.Size(49, 17);
            this.Mode_Point.TabIndex = 2;
            this.Mode_Point.TabStop = true;
            this.Mode_Point.Text = "Point";
            this.Mode_Point.UseVisualStyleBackColor = true;
            this.Mode_Point.CheckedChanged += new System.EventHandler(this.ModePoint_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(706, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "ArbitaryPolygon";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ArbitraryPolygon_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(706, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Clear_Click);
            // 
            // MinVCUpDown
            // 
            this.MinVCUpDown.Location = new System.Drawing.Point(706, 84);
            this.MinVCUpDown.Name = "MinVCUpDown";
            this.MinVCUpDown.Size = new System.Drawing.Size(60, 20);
            this.MinVCUpDown.TabIndex = 5;
            this.MinVCUpDown.ValueChanged += new System.EventHandler(this.MinVCUpDown_ValueChanged);
            // 
            // MaxVCUpDown
            // 
            this.MaxVCUpDown.Location = new System.Drawing.Point(706, 110);
            this.MaxVCUpDown.Name = "MaxVCUpDown";
            this.MaxVCUpDown.Size = new System.Drawing.Size(60, 20);
            this.MaxVCUpDown.TabIndex = 6;
            this.MaxVCUpDown.ValueChanged += new System.EventHandler(this.MaxVCUpDown_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MaxVCUpDown);
            this.Controls.Add(this.MinVCUpDown);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Mode_Point);
            this.Controls.Add(this.Mode_Polygon);
            this.Controls.Add(this.Mode_None);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ModePoint_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ModePoint_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ModePoint_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.MinVCUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxVCUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton Mode_None;
        private System.Windows.Forms.RadioButton Mode_Polygon;
        private System.Windows.Forms.RadioButton Mode_Point;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown MinVCUpDown;
        private System.Windows.Forms.NumericUpDown MaxVCUpDown;
    }
}


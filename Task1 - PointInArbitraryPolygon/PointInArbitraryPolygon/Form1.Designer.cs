
namespace PointInArbitraryPolygon
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
            this.ModeNone = new System.Windows.Forms.RadioButton();
            this.ModePolygon = new System.Windows.Forms.RadioButton();
            this.ModePoint = new System.Windows.Forms.RadioButton();
            this.Clear = new System.Windows.Forms.Button();
            this.ArbitraryPolygon = new System.Windows.Forms.Button();
            this.MinVCUpDown = new System.Windows.Forms.NumericUpDown();
            this.MaxVCUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MinVCUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxVCUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ModeNone
            // 
            this.ModeNone.AutoSize = true;
            this.ModeNone.Location = new System.Drawing.Point(705, 12);
            this.ModeNone.Name = "ModeNone";
            this.ModeNone.Size = new System.Drawing.Size(51, 17);
            this.ModeNone.TabIndex = 2;
            this.ModeNone.TabStop = true;
            this.ModeNone.Text = "None";
            this.ModeNone.UseVisualStyleBackColor = true;
            this.ModeNone.CheckedChanged += new System.EventHandler(this.ModeNone_CheckedChanged);
            // 
            // ModePolygon
            // 
            this.ModePolygon.AutoSize = true;
            this.ModePolygon.Location = new System.Drawing.Point(705, 35);
            this.ModePolygon.Name = "ModePolygon";
            this.ModePolygon.Size = new System.Drawing.Size(63, 17);
            this.ModePolygon.TabIndex = 3;
            this.ModePolygon.TabStop = true;
            this.ModePolygon.Text = "Polygon";
            this.ModePolygon.UseVisualStyleBackColor = true;
            this.ModePolygon.CheckedChanged += new System.EventHandler(this.ModePolygon_CheckedChanged);
            // 
            // ModePoint
            // 
            this.ModePoint.AutoSize = true;
            this.ModePoint.Location = new System.Drawing.Point(705, 58);
            this.ModePoint.Name = "ModePoint";
            this.ModePoint.Size = new System.Drawing.Size(49, 17);
            this.ModePoint.TabIndex = 4;
            this.ModePoint.TabStop = true;
            this.ModePoint.Text = "Point";
            this.ModePoint.UseVisualStyleBackColor = true;
            this.ModePoint.CheckedChanged += new System.EventHandler(this.ModePoint_CheckedChanged);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(705, 194);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 23);
            this.Clear.TabIndex = 5;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // ArbitraryPolygon
            // 
            this.ArbitraryPolygon.Location = new System.Drawing.Point(705, 165);
            this.ArbitraryPolygon.Name = "ArbitraryPolygon";
            this.ArbitraryPolygon.Size = new System.Drawing.Size(75, 23);
            this.ArbitraryPolygon.TabIndex = 6;
            this.ArbitraryPolygon.Text = "ArbitraryPolygon";
            this.ArbitraryPolygon.UseVisualStyleBackColor = true;
            this.ArbitraryPolygon.Click += new System.EventHandler(this.ArbitraryPolygon_Click);
            // 
            // MinVCUpDown
            // 
            this.MinVCUpDown.Location = new System.Drawing.Point(705, 100);
            this.MinVCUpDown.Name = "MinVCUpDown";
            this.MinVCUpDown.Size = new System.Drawing.Size(75, 20);
            this.MinVCUpDown.TabIndex = 7;
            this.MinVCUpDown.ValueChanged += new System.EventHandler(this.MinVCUpDown_ValueChanged);
            // 
            // MaxVCUpDown
            // 
            this.MaxVCUpDown.Location = new System.Drawing.Point(705, 139);
            this.MaxVCUpDown.Name = "MaxVCUpDown";
            this.MaxVCUpDown.Size = new System.Drawing.Size(75, 20);
            this.MaxVCUpDown.TabIndex = 8;
            this.MaxVCUpDown.ValueChanged += new System.EventHandler(this.MaxVCUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(702, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "MinVertexCount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(702, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "MaxVertexCount";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MaxVCUpDown);
            this.Controls.Add(this.MinVCUpDown);
            this.Controls.Add(this.ArbitraryPolygon);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.ModePoint);
            this.Controls.Add(this.ModePolygon);
            this.Controls.Add(this.ModeNone);
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
        private System.Windows.Forms.RadioButton ModeNone;
        private System.Windows.Forms.RadioButton ModePolygon;
        private System.Windows.Forms.RadioButton ModePoint;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button ArbitraryPolygon;
        private System.Windows.Forms.NumericUpDown MinVCUpDown;
        private System.Windows.Forms.NumericUpDown MaxVCUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}


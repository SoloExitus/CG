
namespace Task6___LocalizationPointInConvexPolygon
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
            this.RmaxUpDown = new System.Windows.Forms.NumericUpDown();
            this.RminUpDown = new System.Windows.Forms.NumericUpDown();
            this.QmaxUpDown = new System.Windows.Forms.NumericUpDown();
            this.QminUpDown = new System.Windows.Forms.NumericUpDown();
            this.TestConvexRes = new System.Windows.Forms.PictureBox();
            this.ConvexTest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RmaxUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RminUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QmaxUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QminUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestConvexRes)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Mode_None
            // 
            this.Mode_None.AutoSize = true;
            this.Mode_None.Location = new System.Drawing.Point(715, 12);
            this.Mode_None.Name = "Mode_None";
            this.Mode_None.Size = new System.Drawing.Size(51, 17);
            this.Mode_None.TabIndex = 7;
            this.Mode_None.TabStop = true;
            this.Mode_None.Text = "None";
            this.Mode_None.UseVisualStyleBackColor = true;
            this.Mode_None.CheckedChanged += new System.EventHandler(this.ModeNone_CheckedChanged);
            // 
            // Mode_Polygon
            // 
            this.Mode_Polygon.AutoSize = true;
            this.Mode_Polygon.Location = new System.Drawing.Point(715, 36);
            this.Mode_Polygon.Name = "Mode_Polygon";
            this.Mode_Polygon.Size = new System.Drawing.Size(63, 17);
            this.Mode_Polygon.TabIndex = 8;
            this.Mode_Polygon.TabStop = true;
            this.Mode_Polygon.Text = "Polygon";
            this.Mode_Polygon.UseVisualStyleBackColor = true;
            this.Mode_Polygon.CheckedChanged += new System.EventHandler(this.ModePolygon_CheckedChanged);
            // 
            // Mode_Point
            // 
            this.Mode_Point.AutoSize = true;
            this.Mode_Point.Location = new System.Drawing.Point(715, 60);
            this.Mode_Point.Name = "Mode_Point";
            this.Mode_Point.Size = new System.Drawing.Size(49, 17);
            this.Mode_Point.TabIndex = 9;
            this.Mode_Point.TabStop = true;
            this.Mode_Point.Text = "Point";
            this.Mode_Point.UseVisualStyleBackColor = true;
            this.Mode_Point.CheckedChanged += new System.EventHandler(this.ModePoint_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(715, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "ArbitaryPolygon";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Ganerate_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(715, 231);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Clear_Click);
            // 
            // RmaxUpDown
            // 
            this.RmaxUpDown.Location = new System.Drawing.Point(715, 172);
            this.RmaxUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.RmaxUpDown.Name = "RmaxUpDown";
            this.RmaxUpDown.Size = new System.Drawing.Size(59, 20);
            this.RmaxUpDown.TabIndex = 17;
            this.RmaxUpDown.ValueChanged += new System.EventHandler(this.RmaxUpDown_ValueChanged);
            // 
            // RminUpDown
            // 
            this.RminUpDown.Location = new System.Drawing.Point(715, 146);
            this.RminUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.RminUpDown.Name = "RminUpDown";
            this.RminUpDown.Size = new System.Drawing.Size(59, 20);
            this.RminUpDown.TabIndex = 16;
            this.RminUpDown.ValueChanged += new System.EventHandler(this.RminUpDown_ValueChanged);
            // 
            // QmaxUpDown
            // 
            this.QmaxUpDown.Location = new System.Drawing.Point(715, 115);
            this.QmaxUpDown.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.QmaxUpDown.Name = "QmaxUpDown";
            this.QmaxUpDown.Size = new System.Drawing.Size(59, 20);
            this.QmaxUpDown.TabIndex = 15;
            this.QmaxUpDown.ValueChanged += new System.EventHandler(this.QmaxUpDown_ValueChanged);
            // 
            // QminUpDown
            // 
            this.QminUpDown.Location = new System.Drawing.Point(715, 89);
            this.QminUpDown.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.QminUpDown.Name = "QminUpDown";
            this.QminUpDown.Size = new System.Drawing.Size(59, 20);
            this.QminUpDown.TabIndex = 14;
            this.QminUpDown.ValueChanged += new System.EventHandler(this.QminUpDown_ValueChanged);
            // 
            // TestConvexRes
            // 
            this.TestConvexRes.Location = new System.Drawing.Point(690, 289);
            this.TestConvexRes.Name = "TestConvexRes";
            this.TestConvexRes.Size = new System.Drawing.Size(100, 50);
            this.TestConvexRes.TabIndex = 19;
            this.TestConvexRes.TabStop = false;
            // 
            // ConvexTest
            // 
            this.ConvexTest.Location = new System.Drawing.Point(715, 260);
            this.ConvexTest.Name = "ConvexTest";
            this.ConvexTest.Size = new System.Drawing.Size(75, 23);
            this.ConvexTest.TabIndex = 18;
            this.ConvexTest.Text = "TestConvex";
            this.ConvexTest.UseVisualStyleBackColor = true;
            this.ConvexTest.Click += new System.EventHandler(this.ConvexTest_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TestConvexRes);
            this.Controls.Add(this.ConvexTest);
            this.Controls.Add(this.RmaxUpDown);
            this.Controls.Add(this.RminUpDown);
            this.Controls.Add(this.QmaxUpDown);
            this.Controls.Add(this.QminUpDown);
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
            ((System.ComponentModel.ISupportInitialize)(this.RmaxUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RminUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QmaxUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QminUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestConvexRes)).EndInit();
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
        private System.Windows.Forms.NumericUpDown RmaxUpDown;
        private System.Windows.Forms.NumericUpDown RminUpDown;
        private System.Windows.Forms.NumericUpDown QmaxUpDown;
        private System.Windows.Forms.NumericUpDown QminUpDown;
        private System.Windows.Forms.PictureBox TestConvexRes;
        private System.Windows.Forms.Button ConvexTest;
    }
}


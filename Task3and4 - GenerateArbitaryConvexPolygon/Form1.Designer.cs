
namespace GenerateArbitaryConvexPolygon
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
            this.QminUpDown = new System.Windows.Forms.NumericUpDown();
            this.QmaxUpDown = new System.Windows.Forms.NumericUpDown();
            this.RminUpDown = new System.Windows.Forms.NumericUpDown();
            this.RmaxUpDown = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ConvexTest = new System.Windows.Forms.Button();
            this.TestConvexRes = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.QminUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QmaxUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RminUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RmaxUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestConvexRes)).BeginInit();
            this.SuspendLayout();
            // 
            // QminUpDown
            // 
            this.QminUpDown.Location = new System.Drawing.Point(655, 24);
            this.QminUpDown.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.QminUpDown.Name = "QminUpDown";
            this.QminUpDown.Size = new System.Drawing.Size(59, 20);
            this.QminUpDown.TabIndex = 0;
            this.QminUpDown.ValueChanged += new System.EventHandler(this.QminUpDown_ValueChanged);
            // 
            // QmaxUpDown
            // 
            this.QmaxUpDown.Location = new System.Drawing.Point(655, 50);
            this.QmaxUpDown.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.QmaxUpDown.Name = "QmaxUpDown";
            this.QmaxUpDown.Size = new System.Drawing.Size(59, 20);
            this.QmaxUpDown.TabIndex = 1;
            this.QmaxUpDown.ValueChanged += new System.EventHandler(this.QmaxUpDown_ValueChanged);
            // 
            // RminUpDown
            // 
            this.RminUpDown.Location = new System.Drawing.Point(655, 101);
            this.RminUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.RminUpDown.Name = "RminUpDown";
            this.RminUpDown.Size = new System.Drawing.Size(59, 20);
            this.RminUpDown.TabIndex = 2;
            this.RminUpDown.ValueChanged += new System.EventHandler(this.RminUpDown_ValueChanged);
            // 
            // RmaxUpDown
            // 
            this.RmaxUpDown.Location = new System.Drawing.Point(655, 127);
            this.RmaxUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.RmaxUpDown.Name = "RmaxUpDown";
            this.RmaxUpDown.Size = new System.Drawing.Size(59, 20);
            this.RmaxUpDown.TabIndex = 3;
            this.RmaxUpDown.ValueChanged += new System.EventHandler(this.RmaxUpDown_ValueChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(655, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Ganerate_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(655, 184);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Clear_Click);
            // 
            // ConvexTest
            // 
            this.ConvexTest.Location = new System.Drawing.Point(655, 214);
            this.ConvexTest.Name = "ConvexTest";
            this.ConvexTest.Size = new System.Drawing.Size(75, 23);
            this.ConvexTest.TabIndex = 6;
            this.ConvexTest.Text = "TestConvex";
            this.ConvexTest.UseVisualStyleBackColor = true;
            this.ConvexTest.Click += new System.EventHandler(this.ConvexTest_Click);
            // 
            // TestConvexRes
            // 
            this.TestConvexRes.Location = new System.Drawing.Point(655, 243);
            this.TestConvexRes.Name = "TestConvexRes";
            this.TestConvexRes.Size = new System.Drawing.Size(100, 50);
            this.TestConvexRes.TabIndex = 7;
            this.TestConvexRes.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TestConvexRes);
            this.Controls.Add(this.ConvexTest);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RmaxUpDown);
            this.Controls.Add(this.RminUpDown);
            this.Controls.Add(this.QmaxUpDown);
            this.Controls.Add(this.QminUpDown);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QminUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QmaxUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RminUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RmaxUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestConvexRes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown QminUpDown;
        private System.Windows.Forms.NumericUpDown QmaxUpDown;
        private System.Windows.Forms.NumericUpDown RminUpDown;
        private System.Windows.Forms.NumericUpDown RmaxUpDown;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ConvexTest;
        private System.Windows.Forms.PictureBox TestConvexRes;
    }
}


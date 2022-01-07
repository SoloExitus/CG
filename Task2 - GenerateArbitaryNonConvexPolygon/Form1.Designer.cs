
namespace GenerateArbitaryNonConvexPolygon
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
            this.QminUpDown = new System.Windows.Forms.NumericUpDown();
            this.QmaxUpDown = new System.Windows.Forms.NumericUpDown();
            this.RminUpDown = new System.Windows.Forms.NumericUpDown();
            this.RmaxUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Ganerate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.QminUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QmaxUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RminUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RmaxUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // QminUpDown
            // 
            this.QminUpDown.Location = new System.Drawing.Point(668, 33);
            this.QminUpDown.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.QminUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.QminUpDown.Name = "QminUpDown";
            this.QminUpDown.Size = new System.Drawing.Size(64, 20);
            this.QminUpDown.TabIndex = 0;
            this.QminUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.QminUpDown.ValueChanged += new System.EventHandler(this.QminUpDown_ValueChanged);
            // 
            // QmaxUpDown
            // 
            this.QmaxUpDown.Location = new System.Drawing.Point(668, 60);
            this.QmaxUpDown.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.QmaxUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.QmaxUpDown.Name = "QmaxUpDown";
            this.QmaxUpDown.Size = new System.Drawing.Size(64, 20);
            this.QmaxUpDown.TabIndex = 1;
            this.QmaxUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.QmaxUpDown.ValueChanged += new System.EventHandler(this.QmaxUpDown_ValueChanged);
            // 
            // RminUpDown
            // 
            this.RminUpDown.Location = new System.Drawing.Point(668, 115);
            this.RminUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.RminUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RminUpDown.Name = "RminUpDown";
            this.RminUpDown.Size = new System.Drawing.Size(64, 20);
            this.RminUpDown.TabIndex = 2;
            this.RminUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RminUpDown.ValueChanged += new System.EventHandler(this.RminUpDown_ValueChanged);
            // 
            // RmaxUpDown
            // 
            this.RmaxUpDown.Location = new System.Drawing.Point(668, 142);
            this.RmaxUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.RmaxUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RmaxUpDown.Name = "RmaxUpDown";
            this.RmaxUpDown.Size = new System.Drawing.Size(64, 20);
            this.RmaxUpDown.TabIndex = 3;
            this.RmaxUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RmaxUpDown.ValueChanged += new System.EventHandler(this.RmaxUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(739, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Qmin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(739, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Qmax";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(742, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Rmin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(742, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Rmax";
            // 
            // Ganerate
            // 
            this.Ganerate.Location = new System.Drawing.Point(668, 186);
            this.Ganerate.Name = "Ganerate";
            this.Ganerate.Size = new System.Drawing.Size(75, 23);
            this.Ganerate.TabIndex = 8;
            this.Ganerate.Text = "Generate";
            this.Ganerate.UseVisualStyleBackColor = true;
            this.Ganerate.Click += new System.EventHandler(this.Ganerate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Ganerate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown QminUpDown;
        private System.Windows.Forms.NumericUpDown QmaxUpDown;
        private System.Windows.Forms.NumericUpDown RminUpDown;
        private System.Windows.Forms.NumericUpDown RmaxUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Ganerate;
    }
}


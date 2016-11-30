namespace LVQClientWithVisualization
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.nud_numOfCodeVectors = new System.Windows.Forms.NumericUpDown();
            this.nud_accuracy = new System.Windows.Forms.NumericUpDown();
            this.nud_learningRate = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_numOfCodeVectors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_accuracy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_learningRate)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(700, 700);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(747, 12);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 1;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(747, 42);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(75, 23);
            this.btn_reset.TabIndex = 2;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // nud_numOfCodeVectors
            // 
            this.nud_numOfCodeVectors.Location = new System.Drawing.Point(747, 85);
            this.nud_numOfCodeVectors.Name = "nud_numOfCodeVectors";
            this.nud_numOfCodeVectors.Size = new System.Drawing.Size(120, 22);
            this.nud_numOfCodeVectors.TabIndex = 4;
            this.nud_numOfCodeVectors.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // nud_accuracy
            // 
            this.nud_accuracy.DecimalPlaces = 2;
            this.nud_accuracy.Enabled = false;
            this.nud_accuracy.Location = new System.Drawing.Point(747, 160);
            this.nud_accuracy.Name = "nud_accuracy";
            this.nud_accuracy.Size = new System.Drawing.Size(120, 22);
            this.nud_accuracy.TabIndex = 5;
            // 
            // nud_learningRate
            // 
            this.nud_learningRate.DecimalPlaces = 4;
            this.nud_learningRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_learningRate.Location = new System.Drawing.Point(747, 114);
            this.nud_learningRate.Name = "nud_learningRate";
            this.nud_learningRate.Size = new System.Drawing.Size(120, 22);
            this.nud_learningRate.TabIndex = 6;
            this.nud_learningRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 621);
            this.Controls.Add(this.nud_learningRate);
            this.Controls.Add(this.nud_accuracy);
            this.Controls.Add(this.nud_numOfCodeVectors);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_numOfCodeVectors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_accuracy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_learningRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown nud_numOfCodeVectors;
        private System.Windows.Forms.NumericUpDown nud_accuracy;
        private System.Windows.Forms.NumericUpDown nud_learningRate;
    }
}


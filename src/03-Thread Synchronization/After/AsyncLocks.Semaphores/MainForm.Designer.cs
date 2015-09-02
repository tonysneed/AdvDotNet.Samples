namespace AsyncLocks.Semaphores
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.placesNumeric = new System.Windows.Forms.NumericUpDown();
            this.calcButton = new System.Windows.Forms.Button();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.placesNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Places:";
            // 
            // placesNumeric
            // 
            this.placesNumeric.Location = new System.Drawing.Point(68, 27);
            this.placesNumeric.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.placesNumeric.Name = "placesNumeric";
            this.placesNumeric.Size = new System.Drawing.Size(54, 20);
            this.placesNumeric.TabIndex = 1;
            this.placesNumeric.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // calcButton
            // 
            this.calcButton.Location = new System.Drawing.Point(128, 24);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(75, 23);
            this.calcButton.TabIndex = 2;
            this.calcButton.Text = "Calculate &Pi";
            this.calcButton.UseVisualStyleBackColor = true;
            this.calcButton.Click += new System.EventHandler(this.calcButton_Click);
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(68, 71);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.Size = new System.Drawing.Size(148, 20);
            this.resultTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pi:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 117);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.calcButton);
            this.Controls.Add(this.placesNumeric);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Async Locks";
            ((System.ComponentModel.ISupportInitialize)(this.placesNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown placesNumeric;
        private System.Windows.Forms.Button calcButton;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Label label2;
    }
}


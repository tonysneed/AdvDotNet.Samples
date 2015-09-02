namespace Leaky
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
            this.hogsUpDown = new System.Windows.Forms.NumericUpDown();
            this.createHogsButton = new System.Windows.Forms.Button();
            this.pigOutButton = new System.Windows.Forms.Button();
            this.killHogsButton = new System.Windows.Forms.Button();
            this.collectGarbageButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.hogsUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hogs:";
            // 
            // hogsUpDown
            // 
            this.hogsUpDown.Location = new System.Drawing.Point(54, 15);
            this.hogsUpDown.Name = "hogsUpDown";
            this.hogsUpDown.Size = new System.Drawing.Size(55, 20);
            this.hogsUpDown.TabIndex = 1;
            this.hogsUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // createHogsButton
            // 
            this.createHogsButton.Location = new System.Drawing.Point(54, 54);
            this.createHogsButton.Name = "createHogsButton";
            this.createHogsButton.Size = new System.Drawing.Size(94, 32);
            this.createHogsButton.TabIndex = 2;
            this.createHogsButton.Text = "&Create Hogs";
            this.createHogsButton.UseVisualStyleBackColor = true;
            this.createHogsButton.Click += new System.EventHandler(this.createHogsButton_Click);
            // 
            // pigOutButton
            // 
            this.pigOutButton.Location = new System.Drawing.Point(54, 110);
            this.pigOutButton.Name = "pigOutButton";
            this.pigOutButton.Size = new System.Drawing.Size(94, 32);
            this.pigOutButton.TabIndex = 3;
            this.pigOutButton.Text = "&Pig Out";
            this.pigOutButton.UseVisualStyleBackColor = true;
            this.pigOutButton.Click += new System.EventHandler(this.pigOutButton_Click);
            // 
            // killHogsButton
            // 
            this.killHogsButton.Location = new System.Drawing.Point(54, 165);
            this.killHogsButton.Name = "killHogsButton";
            this.killHogsButton.Size = new System.Drawing.Size(94, 32);
            this.killHogsButton.TabIndex = 4;
            this.killHogsButton.Text = "&Kill Hogs";
            this.killHogsButton.UseVisualStyleBackColor = true;
            this.killHogsButton.Click += new System.EventHandler(this.killHogsButton_Click);
            // 
            // collectGarbageButton
            // 
            this.collectGarbageButton.Location = new System.Drawing.Point(54, 218);
            this.collectGarbageButton.Name = "collectGarbageButton";
            this.collectGarbageButton.Size = new System.Drawing.Size(94, 32);
            this.collectGarbageButton.TabIndex = 5;
            this.collectGarbageButton.Text = "Collect &Garbage";
            this.collectGarbageButton.UseVisualStyleBackColor = true;
            this.collectGarbageButton.Click += new System.EventHandler(this.collectGarbageButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 282);
            this.Controls.Add(this.collectGarbageButton);
            this.Controls.Add(this.killHogsButton);
            this.Controls.Add(this.pigOutButton);
            this.Controls.Add(this.createHogsButton);
            this.Controls.Add(this.hogsUpDown);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leaky";
            ((System.ComponentModel.ISupportInitialize)(this.hogsUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown hogsUpDown;
        private System.Windows.Forms.Button createHogsButton;
        private System.Windows.Forms.Button pigOutButton;
        private System.Windows.Forms.Button killHogsButton;
        private System.Windows.Forms.Button collectGarbageButton;
    }
}


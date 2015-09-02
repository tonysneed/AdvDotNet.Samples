namespace Blocker.Client
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.primesListBox = new System.Windows.Forms.ListBox();
            this.asyncCheckBox = new System.Windows.Forms.CheckBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.clientsUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.goButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientsUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.asyncCheckBox);
            this.splitContainer1.Panel1.Controls.Add(this.stopButton);
            this.splitContainer1.Panel1.Controls.Add(this.clientsUpDown);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.goButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.primesListBox);
            this.splitContainer1.Size = new System.Drawing.Size(715, 369);
            this.splitContainer1.SplitterDistance = 46;
            this.splitContainer1.TabIndex = 8;
            // 
            // primesListBox
            // 
            this.primesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.primesListBox.FormattingEnabled = true;
            this.primesListBox.HorizontalScrollbar = true;
            this.primesListBox.Location = new System.Drawing.Point(0, 0);
            this.primesListBox.Name = "primesListBox";
            this.primesListBox.ScrollAlwaysVisible = true;
            this.primesListBox.Size = new System.Drawing.Size(715, 319);
            this.primesListBox.TabIndex = 3;
            // 
            // asyncCheckBox
            // 
            this.asyncCheckBox.AutoSize = true;
            this.asyncCheckBox.Location = new System.Drawing.Point(608, 17);
            this.asyncCheckBox.Name = "asyncCheckBox";
            this.asyncCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.asyncCheckBox.Size = new System.Drawing.Size(94, 17);
            this.asyncCheckBox.TabIndex = 15;
            this.asyncCheckBox.Text = "Async Service";
            this.asyncCheckBox.UseVisualStyleBackColor = true;
            // 
            // stopButton
            // 
            this.stopButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.stopButton.Location = new System.Drawing.Point(231, 12);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 14;
            this.stopButton.Text = "&Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // clientsUpDown
            // 
            this.clientsUpDown.Location = new System.Drawing.Point(85, 15);
            this.clientsUpDown.Name = "clientsUpDown";
            this.clientsUpDown.Size = new System.Drawing.Size(48, 20);
            this.clientsUpDown.TabIndex = 13;
            this.clientsUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Add Clients:";
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(146, 12);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 11;
            this.goButton.Text = "&Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 369);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Prime Numbers";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clientsUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox asyncCheckBox;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.NumericUpDown clientsUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.ListBox primesListBox;

    }
}


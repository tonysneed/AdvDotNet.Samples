namespace PickupDebugging
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
            this.goButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.responseTextBox = new System.Windows.Forms.TextBox();
            this.pickupLinesComboBox = new System.Windows.Forms.ComboBox();
            this.asyncCheckBox = new System.Windows.Forms.CheckBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pickup Line:";
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(85, 44);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 2;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Response:";
            // 
            // responseTextBox
            // 
            this.responseTextBox.Location = new System.Drawing.Point(85, 81);
            this.responseTextBox.Multiline = true;
            this.responseTextBox.Name = "responseTextBox";
            this.responseTextBox.Size = new System.Drawing.Size(248, 50);
            this.responseTextBox.TabIndex = 4;
            // 
            // pickupLinesComboBox
            // 
            this.pickupLinesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pickupLinesComboBox.FormattingEnabled = true;
            this.pickupLinesComboBox.Location = new System.Drawing.Point(85, 9);
            this.pickupLinesComboBox.Name = "pickupLinesComboBox";
            this.pickupLinesComboBox.Size = new System.Drawing.Size(195, 21);
            this.pickupLinesComboBox.TabIndex = 5;
            // 
            // asyncCheckBox
            // 
            this.asyncCheckBox.AutoSize = true;
            this.asyncCheckBox.Location = new System.Drawing.Point(286, 48);
            this.asyncCheckBox.Name = "asyncCheckBox";
            this.asyncCheckBox.Size = new System.Drawing.Size(55, 17);
            this.asyncCheckBox.TabIndex = 6;
            this.asyncCheckBox.Text = "Async";
            this.asyncCheckBox.UseVisualStyleBackColor = true;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(286, 9);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(47, 23);
            this.loadButton.TabIndex = 7;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.goButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 144);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.asyncCheckBox);
            this.Controls.Add(this.pickupLinesComboBox);
            this.Controls.Add(this.responseTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Pickup Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox responseTextBox;
        private System.Windows.Forms.ComboBox pickupLinesComboBox;
        private System.Windows.Forms.CheckBox asyncCheckBox;
        private System.Windows.Forms.Button loadButton;
    }
}


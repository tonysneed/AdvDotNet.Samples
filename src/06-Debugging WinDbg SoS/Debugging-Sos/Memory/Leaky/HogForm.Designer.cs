namespace Leaky
{
    partial class HogForm
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
            this.countLabel = new System.Windows.Forms.Label();
            this.unsubscribeCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // countLabel
            // 
            this.countLabel.BackColor = System.Drawing.Color.SandyBrown;
            this.countLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.countLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countLabel.Location = new System.Drawing.Point(55, 40);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(168, 70);
            this.countLabel.TabIndex = 0;
            this.countLabel.Text = "Count";
            this.countLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // unsubscribeCheckBox
            // 
            this.unsubscribeCheckBox.AutoSize = true;
            this.unsubscribeCheckBox.Location = new System.Drawing.Point(101, 128);
            this.unsubscribeCheckBox.Name = "unsubscribeCheckBox";
            this.unsubscribeCheckBox.Size = new System.Drawing.Size(91, 17);
            this.unsubscribeCheckBox.TabIndex = 1;
            this.unsubscribeCheckBox.Text = "Unscubscribe";
            this.unsubscribeCheckBox.UseVisualStyleBackColor = true;
            // 
            // HogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 170);
            this.Controls.Add(this.unsubscribeCheckBox);
            this.Controls.Add(this.countLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HogForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Hog";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HogForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.CheckBox unsubscribeCheckBox;
    }
}
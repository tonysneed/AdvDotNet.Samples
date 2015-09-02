namespace Buggy
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
            this.doItButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // doItButton
            // 
            this.doItButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doItButton.Location = new System.Drawing.Point(60, 47);
            this.doItButton.Name = "doItButton";
            this.doItButton.Size = new System.Drawing.Size(125, 104);
            this.doItButton.TabIndex = 0;
            this.doItButton.Text = "Do It";
            this.doItButton.UseVisualStyleBackColor = true;
            this.doItButton.Click += new System.EventHandler(this.doItButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 209);
            this.Controls.Add(this.doItButton);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button doItButton;
    }
}


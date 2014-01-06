namespace ScreenRotator
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
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonLandscape = new System.Windows.Forms.Button();
            this.buttonBlockInput = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Image = global::ScreenRotator.Properties.Resources.RotationDisplay270;
            this.button4.Location = new System.Drawing.Point(450, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(140, 140);
            this.button4.TabIndex = 3;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Image = global::ScreenRotator.Properties.Resources.RotationDisplay180;
            this.button3.Location = new System.Drawing.Point(304, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 140);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Image = global::ScreenRotator.Properties.Resources.RotationDisplay90;
            this.button2.Location = new System.Drawing.Point(158, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 140);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonLandscape
            // 
            this.buttonLandscape.Image = global::ScreenRotator.Properties.Resources.RotationDisplay0;
            this.buttonLandscape.Location = new System.Drawing.Point(12, 12);
            this.buttonLandscape.Name = "buttonLandscape";
            this.buttonLandscape.Size = new System.Drawing.Size(140, 140);
            this.buttonLandscape.TabIndex = 0;
            this.buttonLandscape.UseVisualStyleBackColor = true;
            this.buttonLandscape.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonBlockInput
            // 
            this.buttonBlockInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBlockInput.Image = global::ScreenRotator.Properties.Resources.Lock;
            this.buttonBlockInput.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBlockInput.Location = new System.Drawing.Point(12, 175);
            this.buttonBlockInput.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.buttonBlockInput.Name = "buttonBlockInput";
            this.buttonBlockInput.Size = new System.Drawing.Size(578, 44);
            this.buttonBlockInput.TabIndex = 4;
            this.buttonBlockInput.Text = "Lock keyboard & mouse (Double hit \'Esc\' or close window to unlock)";
            this.buttonBlockInput.UseMnemonic = false;
            this.buttonBlockInput.UseVisualStyleBackColor = true;
            this.buttonBlockInput.Click += new System.EventHandler(this.buttonBlockInput_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(668, 269);
            this.Controls.Add(this.buttonBlockInput);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonLandscape);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Screen Rotator";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLandscape;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonBlockInput;
    }
}


namespace customButton.Forms
{
    partial class Memorie
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
            this.button1 = new System.Windows.Forms.Button();
            this.customButton2 = new customButton.CustomButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(255, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 54);
            this.button1.TabIndex = 11;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // customButton2
            // 
            this.customButton2.Angle = 11F;
            this.customButton2.BorderRadius = 70;
            this.customButton2.Color0 = System.Drawing.Color.Gray;
            this.customButton2.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.customButton2.Location = new System.Drawing.Point(82, 144);
            this.customButton2.Name = "customButton2";
            this.customButton2.Size = new System.Drawing.Size(442, 17);
            this.customButton2.Start = false;
            this.customButton2.TabIndex = 10;
            this.customButton2.Click += new System.EventHandler(this.customButton2_Click);
            // 
            // Memorie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 415);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.customButton2);
            this.Name = "Memorie";
            this.Text = "Memorie";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private CustomButton customButton2;
    }
}
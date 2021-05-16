
namespace ProiectAC.Forms
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
            this.customButton1 = new proiectAC.CustomButton();
            this.SuspendLayout();
            // 
            // customButton1
            // 
            this.customButton1.Angle = 315F;
            this.customButton1.BorderRadius = 50;
            this.customButton1.Color0 = System.Drawing.Color.Blue;
            this.customButton1.Color1 = System.Drawing.Color.Red;
            this.customButton1.Location = new System.Drawing.Point(206, 115);
            this.customButton1.Name = "customButton1";
            this.customButton1.Size = new System.Drawing.Size(275, 31);
            this.customButton1.Start = true;
            this.customButton1.TabIndex = 0;
            // 
            // Memorie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.customButton1);
            this.Name = "Memorie";
            this.Text = "Memorie";
            this.ResumeLayout(false);

        }

        #endregion

        private proiectAC.CustomButton customButton1;
    }
}
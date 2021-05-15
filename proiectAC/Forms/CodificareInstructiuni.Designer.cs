namespace proiectAC.Forms {
    partial class CodificareInstructiuni {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tbExemplu = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbExemplu
            // 
            this.tbExemplu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbExemplu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbExemplu.Location = new System.Drawing.Point(0, 0);
            this.tbExemplu.Margin = new System.Windows.Forms.Padding(4);
            this.tbExemplu.Multiline = true;
            this.tbExemplu.Name = "tbExemplu";
            this.tbExemplu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbExemplu.Size = new System.Drawing.Size(1049, 771);
            this.tbExemplu.TabIndex = 1;
            // 
            // CodificareInstructiuni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 771);
            this.Controls.Add(this.tbExemplu);
            this.Name = "CodificareInstructiuni";
            this.Text = "OutputASM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbExemplu;
    }
}
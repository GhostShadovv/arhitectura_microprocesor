namespace proiectAC.Forms {
    partial class Editor {
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.LineNumberTextBox = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LineNumberTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(40, 452);
            this.panel1.TabIndex = 0;
            // 
            // LineNumberTextBox
            // 
            this.LineNumberTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LineNumberTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LineNumberTextBox.Location = new System.Drawing.Point(0, 0);
            this.LineNumberTextBox.Name = "LineNumberTextBox";
            this.LineNumberTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LineNumberTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.LineNumberTextBox.Size = new System.Drawing.Size(40, 452);
            this.LineNumberTextBox.TabIndex = 0;
            this.LineNumberTextBox.Text = "";
            this.LineNumberTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LineNumberTextBox_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(40, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(618, 452);
            this.panel2.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.AutoWordSelection = true;
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(618, 452);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            this.richTextBox1.VScroll += new System.EventHandler(this.RichTextBox1_VScroll);
            this.richTextBox1.FontChanged += new System.EventHandler(this.RichTextBox1_FontChanged);
            this.richTextBox1.SizeChanged += new System.EventHandler(this.RichTextBox1_FontChanged);
            this.richTextBox1.TextChanged += new System.EventHandler(this.RichTextBox1_TextChanged);
            this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RichTextBox1_KeyDown);
            this.richTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RichTextBox1_KeyPress);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 452);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Editor";
            this.Text = "Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Editor_FormClosing);
            this.Load += new System.EventHandler(this.Editor_Load);
            this.Resize += new System.EventHandler(this.Editor_Resize);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox LineNumberTextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
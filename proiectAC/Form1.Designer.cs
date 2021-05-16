namespace proiectAC {
    partial class Form1 {
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
            this.btnCodificareInstructiuni = new System.Windows.Forms.Button();
            this.btnArhitectura = new System.Windows.Forms.Button();
            this.pContent = new System.Windows.Forms.Panel();
            this.pEditor = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parsareCodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conversieHEXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnMemoria = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.btnMemoria);
            this.panel1.Controls.Add(this.btnCodificareInstructiuni);
            this.panel1.Controls.Add(this.btnArhitectura);
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1048, 48);
            this.panel1.TabIndex = 14;
            // 
            // btnCodificareInstructiuni
            // 
            this.btnCodificareInstructiuni.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCodificareInstructiuni.FlatAppearance.BorderSize = 0;
            this.btnCodificareInstructiuni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCodificareInstructiuni.ForeColor = System.Drawing.Color.DimGray;
            this.btnCodificareInstructiuni.Location = new System.Drawing.Point(177, 0);
            this.btnCodificareInstructiuni.Margin = new System.Windows.Forms.Padding(4);
            this.btnCodificareInstructiuni.Name = "btnCodificareInstructiuni";
            this.btnCodificareInstructiuni.Size = new System.Drawing.Size(254, 48);
            this.btnCodificareInstructiuni.TabIndex = 1;
            this.btnCodificareInstructiuni.Text = "Codificare Instructiuni";
            this.btnCodificareInstructiuni.UseVisualStyleBackColor = true;
            this.btnCodificareInstructiuni.Click += new System.EventHandler(this.btnCodificareInstructiuni_Click);
            // 
            // btnArhitectura
            // 
            this.btnArhitectura.BackColor = System.Drawing.Color.Silver;
            this.btnArhitectura.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnArhitectura.FlatAppearance.BorderSize = 0;
            this.btnArhitectura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArhitectura.ForeColor = System.Drawing.Color.DimGray;
            this.btnArhitectura.Location = new System.Drawing.Point(0, 0);
            this.btnArhitectura.Margin = new System.Windows.Forms.Padding(4);
            this.btnArhitectura.Name = "btnArhitectura";
            this.btnArhitectura.Size = new System.Drawing.Size(177, 48);
            this.btnArhitectura.TabIndex = 1;
            this.btnArhitectura.Text = "Arhitectura";
            this.btnArhitectura.UseVisualStyleBackColor = false;
            this.btnArhitectura.Click += new System.EventHandler(this.btnArhitectura_Click);
            this.btnArhitectura.Leave += new System.EventHandler(this.btnArhitectura_Leave);
            // 
            // pContent
            // 
            this.pContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pContent.Location = new System.Drawing.Point(0, 81);
            this.pContent.Margin = new System.Windows.Forms.Padding(4);
            this.pContent.Name = "pContent";
            this.pContent.Size = new System.Drawing.Size(1048, 809);
            this.pContent.TabIndex = 16;
            // 
            // pEditor
            // 
            this.pEditor.BackColor = System.Drawing.Color.LightGray;
            this.pEditor.Dock = System.Windows.Forms.DockStyle.Right;
            this.pEditor.Location = new System.Drawing.Point(1047, 28);
            this.pEditor.Margin = new System.Windows.Forms.Padding(4);
            this.pEditor.Name = "pEditor";
            this.pEditor.Size = new System.Drawing.Size(531, 862);
            this.pEditor.TabIndex = 15;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.parsareCodToolStripMenuItem,
            this.conversieHEXToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1578, 28);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.saveAsToolStripMenuItem.Text = "&Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // parsareCodToolStripMenuItem
            // 
            this.parsareCodToolStripMenuItem.Name = "parsareCodToolStripMenuItem";
            this.parsareCodToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
            this.parsareCodToolStripMenuItem.Text = "Parsare Cod";
            this.parsareCodToolStripMenuItem.Click += new System.EventHandler(this.parsareCodToolStripMenuItem_Click);
            // 
            // conversieHEXToolStripMenuItem
            // 
            this.conversieHEXToolStripMenuItem.Name = "conversieHEXToolStripMenuItem";
            this.conversieHEXToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.conversieHEXToolStripMenuItem.Text = "Conversie HEX";
            this.conversieHEXToolStripMenuItem.Click += new System.EventHandler(this.conversieHEXToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnMemoria
            // 
            this.btnMemoria.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMemoria.FlatAppearance.BorderSize = 0;
            this.btnMemoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemoria.ForeColor = System.Drawing.Color.DimGray;
            this.btnMemoria.Location = new System.Drawing.Point(431, 0);
            this.btnMemoria.Margin = new System.Windows.Forms.Padding(4);
            this.btnMemoria.Name = "btnMemoria";
            this.btnMemoria.Size = new System.Drawing.Size(186, 48);
            this.btnMemoria.TabIndex = 2;
            this.btnMemoria.Text = "Memoria";
            this.btnMemoria.UseVisualStyleBackColor = true;
            this.btnMemoria.Click += new System.EventHandler(this.btnMemoria_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1578, 890);
            this.Controls.Add(this.pEditor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pContent);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCodificareInstructiuni;
        private System.Windows.Forms.Button btnArhitectura;
        private System.Windows.Forms.Panel pContent;
        private System.Windows.Forms.Panel pEditor;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem parsareCodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conversieHEXToolStripMenuItem;
        private System.Windows.Forms.Button btnMemoria;
    }
}


namespace EDMXEditor
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonEDMX = new System.Windows.Forms.Button();
            this.textBoxEdmx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxEdmxNameSpace = new System.Windows.Forms.TextBox();
            this.buttonDiagram = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonEDMX
            // 
            this.buttonEDMX.Location = new System.Drawing.Point(43, 26);
            this.buttonEDMX.Name = "buttonEDMX";
            this.buttonEDMX.Size = new System.Drawing.Size(96, 32);
            this.buttonEDMX.TabIndex = 0;
            this.buttonEDMX.Text = "EDMX";
            this.buttonEDMX.UseVisualStyleBackColor = true;
            this.buttonEDMX.Click += new System.EventHandler(this.buttonEDMX_Click);
            // 
            // textBoxEdmx
            // 
            this.textBoxEdmx.Location = new System.Drawing.Point(145, 33);
            this.textBoxEdmx.Name = "textBoxEdmx";
            this.textBoxEdmx.Size = new System.Drawing.Size(100, 20);
            this.textBoxEdmx.TabIndex = 1;
            this.textBoxEdmx.Text = "_d";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "EDMX NameSpace";
            // 
            // textBoxEdmxNameSpace
            // 
            this.textBoxEdmxNameSpace.Location = new System.Drawing.Point(377, 33);
            this.textBoxEdmxNameSpace.Name = "textBoxEdmxNameSpace";
            this.textBoxEdmxNameSpace.Size = new System.Drawing.Size(308, 20);
            this.textBoxEdmxNameSpace.TabIndex = 3;
            this.textBoxEdmxNameSpace.Text = "http://schemas.microsoft.com/ado/2009/11/edmx";
            // 
            // buttonDiagram
            // 
            this.buttonDiagram.Location = new System.Drawing.Point(43, 75);
            this.buttonDiagram.Name = "buttonDiagram";
            this.buttonDiagram.Size = new System.Drawing.Size(96, 23);
            this.buttonDiagram.TabIndex = 4;
            this.buttonDiagram.Text = "Diagram";
            this.buttonDiagram.UseVisualStyleBackColor = true;
            this.buttonDiagram.Click += new System.EventHandler(this.buttonDiagram_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonDiagram);
            this.Controls.Add(this.textBoxEdmxNameSpace);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxEdmx);
            this.Controls.Add(this.buttonEDMX);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonEDMX;
        private System.Windows.Forms.TextBox textBoxEdmx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEdmxNameSpace;
        private System.Windows.Forms.Button buttonDiagram;
    }
}


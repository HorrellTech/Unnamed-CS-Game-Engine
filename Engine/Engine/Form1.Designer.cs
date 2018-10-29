namespace Engine
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
            this.glGameCanvas1 = new Engine.GameEngine.GLGameCanvas();
            this.SuspendLayout();
            // 
            // glGameCanvas1
            // 
            this.glGameCanvas1.BackColor = System.Drawing.Color.Black;
            this.glGameCanvas1.Location = new System.Drawing.Point(13, 13);
            this.glGameCanvas1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glGameCanvas1.Name = "glGameCanvas1";
            this.glGameCanvas1.Size = new System.Drawing.Size(448, 333);
            this.glGameCanvas1.TabIndex = 0;
            this.glGameCanvas1.VSync = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 628);
            this.Controls.Add(this.glGameCanvas1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private GameEngine.GLGameCanvas glGameCanvas1;
    }
}


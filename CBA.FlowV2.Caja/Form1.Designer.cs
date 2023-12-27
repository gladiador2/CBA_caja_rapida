namespace CBA.FlowV2.Caja
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
            this.buttonCBA1 = new CBA.FlowV2.Caja.CustomControles.ButtonCBA();
            this.SuspendLayout();
            // 
            // buttonCBA1
            // 
            this.buttonCBA1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.buttonCBA1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.buttonCBA1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonCBA1.BorderRadius = 10;
            this.buttonCBA1.BorderSize = 0;
            this.buttonCBA1.FlatAppearance.BorderSize = 0;
            this.buttonCBA1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCBA1.ForeColor = System.Drawing.Color.White;
            this.buttonCBA1.Location = new System.Drawing.Point(75, 72);
            this.buttonCBA1.Name = "buttonCBA1";
            this.buttonCBA1.Size = new System.Drawing.Size(333, 40);
            this.buttonCBA1.TabIndex = 0;
            this.buttonCBA1.Text = "buttonCBA1";
            this.buttonCBA1.TextColor = System.Drawing.Color.White;
            this.buttonCBA1.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCBA1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControles.ButtonCBA buttonCBA1;
    }
}
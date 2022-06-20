using System.ComponentModel;

namespace ytdl_ui
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.inputUrl = new System.Windows.Forms.TextBox();
            this.buttonMp4 = new System.Windows.Forms.Button();
            this.buttonMp3 = new System.Windows.Forms.Button();
            this.buttonThumbnail = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPrereqs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputUrl
            // 
            this.inputUrl.Location = new System.Drawing.Point(12, 35);
            this.inputUrl.Name = "inputUrl";
            this.inputUrl.Size = new System.Drawing.Size(368, 22);
            this.inputUrl.TabIndex = 0;
            this.inputUrl.TextChanged += new System.EventHandler(this.inputUrl_TextChanged);
            // 
            // buttonMp4
            // 
            this.buttonMp4.Location = new System.Drawing.Point(12, 63);
            this.buttonMp4.Name = "buttonMp4";
            this.buttonMp4.Size = new System.Drawing.Size(75, 33);
            this.buttonMp4.TabIndex = 1;
            this.buttonMp4.Text = ".mp4";
            this.buttonMp4.UseVisualStyleBackColor = true;
            this.buttonMp4.Click += new System.EventHandler(this.buttonMp4_Click);
            // 
            // buttonMp3
            // 
            this.buttonMp3.Location = new System.Drawing.Point(93, 63);
            this.buttonMp3.Name = "buttonMp3";
            this.buttonMp3.Size = new System.Drawing.Size(75, 33);
            this.buttonMp3.TabIndex = 2;
            this.buttonMp3.Text = ".mp3";
            this.buttonMp3.UseVisualStyleBackColor = true;
            this.buttonMp3.Click += new System.EventHandler(this.buttonMp3_Click);
            // 
            // buttonThumbnail
            // 
            this.buttonThumbnail.Location = new System.Drawing.Point(174, 63);
            this.buttonThumbnail.Name = "buttonThumbnail";
            this.buttonThumbnail.Size = new System.Drawing.Size(75, 33);
            this.buttonThumbnail.TabIndex = 3;
            this.buttonThumbnail.Text = "thumb";
            this.buttonThumbnail.UseVisualStyleBackColor = true;
            this.buttonThumbnail.Click += new System.EventHandler(this.buttonThumbnail_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter URL";
            // 
            // buttonPrereqs
            // 
            this.buttonPrereqs.Location = new System.Drawing.Point(255, 63);
            this.buttonPrereqs.Name = "buttonPrereqs";
            this.buttonPrereqs.Size = new System.Drawing.Size(125, 33);
            this.buttonPrereqs.TabIndex = 5;
            this.buttonPrereqs.Text = "install prereqs";
            this.buttonPrereqs.UseVisualStyleBackColor = true;
            this.buttonPrereqs.Click += new System.EventHandler(this.buttonPrereqs_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 121);
            this.Controls.Add(this.buttonPrereqs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonThumbnail);
            this.Controls.Add(this.buttonMp3);
            this.Controls.Add(this.buttonMp4);
            this.Controls.Add(this.inputUrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "(✿◡‿◡)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button buttonPrereqs;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Button buttonMp4;
        private System.Windows.Forms.Button buttonMp3;
        private System.Windows.Forms.Button buttonThumbnail;

        private System.Windows.Forms.TextBox inputUrl;

        #endregion
    }
}
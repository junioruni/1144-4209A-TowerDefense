﻿namespace TowerDefense
{
    partial class Main
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
            this.BtWeiter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtWeiter
            // 
            this.BtWeiter.Location = new System.Drawing.Point(12, 12);
            this.BtWeiter.Name = "BtWeiter";
            this.BtWeiter.Size = new System.Drawing.Size(75, 23);
            this.BtWeiter.TabIndex = 0;
            this.BtWeiter.Text = "Weiter";
            this.BtWeiter.UseVisualStyleBackColor = true;
            this.BtWeiter.Click += new System.EventHandler(this.BtWeiter_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.BtWeiter);
            this.Name = "Main";
            this.Text = "TowerDefense";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtWeiter;
    }
}


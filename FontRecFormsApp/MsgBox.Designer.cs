namespace FontRecFormsApp
{
    partial class MsgBox
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
            this.inputPictureBox = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.fontLabel = new System.Windows.Forms.Label();
            this.previewLabel = new System.Windows.Forms.Label();
            this.previewLabel2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inputPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // inputPictureBox
            // 
            this.inputPictureBox.Location = new System.Drawing.Point(66, 91);
            this.inputPictureBox.Name = "inputPictureBox";
            this.inputPictureBox.Size = new System.Drawing.Size(312, 138);
            this.inputPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.inputPictureBox.TabIndex = 0;
            this.inputPictureBox.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(136, 26);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(172, 31);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Scan Result";
            // 
            // fontLabel
            // 
            this.fontLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontLabel.Location = new System.Drawing.Point(64, 258);
            this.fontLabel.Name = "fontLabel";
            this.fontLabel.Size = new System.Drawing.Size(317, 41);
            this.fontLabel.TabIndex = 2;
            this.fontLabel.Text = "Font Name";
            this.fontLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // previewLabel
            // 
            this.previewLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previewLabel.Location = new System.Drawing.Point(12, 321);
            this.previewLabel.Name = "previewLabel";
            this.previewLabel.Size = new System.Drawing.Size(426, 119);
            this.previewLabel.TabIndex = 3;
            this.previewLabel.Text = "A quick brown fox jumps over the lazy dog";
            this.previewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // previewLabel2
            // 
            this.previewLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previewLabel2.Location = new System.Drawing.Point(12, 464);
            this.previewLabel2.Name = "previewLabel2";
            this.previewLabel2.Size = new System.Drawing.Size(426, 112);
            this.previewLabel2.TabIndex = 4;
            this.previewLabel2.Text = "A quick brown fox jumps over the lazy dog";
            this.previewLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CustomMsgBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 601);
            this.Controls.Add(this.previewLabel2);
            this.Controls.Add(this.previewLabel);
            this.Controls.Add(this.fontLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.inputPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomMsgBox";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Result";
            this.Load += new System.EventHandler(this.CustomMsgBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inputPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox inputPictureBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label fontLabel;
        private System.Windows.Forms.Label previewLabel;
        private System.Windows.Forms.Label previewLabel2;
    }
}
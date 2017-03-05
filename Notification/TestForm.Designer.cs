namespace ToastNotification
{
    partial class FormTest
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
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.buttonImage = new System.Windows.Forms.Button();
            this.buttonShow = new System.Windows.Forms.Button();
            this.buttonPickColor = new System.Windows.Forms.Button();
            this.pictureBoxColor = new System.Windows.Forms.PictureBox();
            this.buttonPickSound = new System.Windows.Forms.Button();
            this.numericUpDownSeconds = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTitle.Location = new System.Drawing.Point(11, 9);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(545, 20);
            this.textBoxTitle.TabIndex = 0;
            this.textBoxTitle.Text = "Title";
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMessage.Location = new System.Drawing.Point(11, 35);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(545, 40);
            this.textBoxMessage.TabIndex = 1;
            this.textBoxMessage.Text = "Text";
            // 
            // buttonImage
            // 
            this.buttonImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonImage.Location = new System.Drawing.Point(11, 81);
            this.buttonImage.Name = "buttonImage";
            this.buttonImage.Size = new System.Drawing.Size(75, 23);
            this.buttonImage.TabIndex = 2;
            this.buttonImage.Text = "SelectImage";
            this.buttonImage.UseVisualStyleBackColor = true;
            this.buttonImage.Click += new System.EventHandler(this.buttonImage_Click);
            // 
            // buttonShow
            // 
            this.buttonShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShow.Location = new System.Drawing.Point(483, 81);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(75, 23);
            this.buttonShow.TabIndex = 3;
            this.buttonShow.Text = "Show";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // buttonPickColor
            // 
            this.buttonPickColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPickColor.Location = new System.Drawing.Point(92, 81);
            this.buttonPickColor.Name = "buttonPickColor";
            this.buttonPickColor.Size = new System.Drawing.Size(75, 23);
            this.buttonPickColor.TabIndex = 4;
            this.buttonPickColor.Text = "Pick Color";
            this.buttonPickColor.UseVisualStyleBackColor = true;
            this.buttonPickColor.Click += new System.EventHandler(this.buttonPickColor_Click);
            // 
            // pictureBoxColor
            // 
            this.pictureBoxColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxColor.Location = new System.Drawing.Point(171, 82);
            this.pictureBoxColor.Name = "pictureBoxColor";
            this.pictureBoxColor.Size = new System.Drawing.Size(21, 21);
            this.pictureBoxColor.TabIndex = 5;
            this.pictureBoxColor.TabStop = false;
            // 
            // buttonPickSound
            // 
            this.buttonPickSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPickSound.Location = new System.Drawing.Point(402, 81);
            this.buttonPickSound.Name = "buttonPickSound";
            this.buttonPickSound.Size = new System.Drawing.Size(75, 23);
            this.buttonPickSound.TabIndex = 6;
            this.buttonPickSound.Text = "Pick Sound";
            this.buttonPickSound.UseVisualStyleBackColor = true;
            this.buttonPickSound.Click += new System.EventHandler(this.buttonPickSound_Click);
            // 
            // numericUpDownSeconds
            // 
            this.numericUpDownSeconds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownSeconds.Location = new System.Drawing.Point(343, 83);
            this.numericUpDownSeconds.Name = "numericUpDownSeconds";
            this.numericUpDownSeconds.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownSeconds.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Time in seconds (0 for none)";
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 116);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownSeconds);
            this.Controls.Add(this.buttonPickSound);
            this.Controls.Add(this.pictureBoxColor);
            this.Controls.Add(this.buttonPickColor);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.buttonImage);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.textBoxTitle);
            this.MinimumSize = new System.Drawing.Size(586, 155);
            this.Name = "FormTest";
            this.Text = "TestNotification";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Button buttonImage;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Button buttonPickColor;
        private System.Windows.Forms.PictureBox pictureBoxColor;
        private System.Windows.Forms.Button buttonPickSound;
        private System.Windows.Forms.NumericUpDown numericUpDownSeconds;
        private System.Windows.Forms.Label label1;
    }
}


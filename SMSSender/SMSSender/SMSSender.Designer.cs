namespace SMSSender
{
    partial class SMS
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMS));
            this.Time = new System.Windows.Forms.Timer(this.components);
            this.chkSmartUnicode = new System.Windows.Forms.CheckBox();
            this.txtConcatMessage = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtConcatNumber = new System.Windows.Forms.TextBox();
            this.btnSendConcatSMS = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Time
            // 
            this.Time.Interval = 5000;
            this.Time.Tick += new System.EventHandler(this.Time_Tick);
            // 
            // chkSmartUnicode
            // 
            this.chkSmartUnicode.Location = new System.Drawing.Point(223, 49);
            this.chkSmartUnicode.Name = "chkSmartUnicode";
            this.chkSmartUnicode.Size = new System.Drawing.Size(119, 24);
            this.chkSmartUnicode.TabIndex = 20;
            this.chkSmartUnicode.Text = "For Urdu SMS";
            this.chkSmartUnicode.Visible = false;
            // 
            // txtConcatMessage
            // 
            this.txtConcatMessage.Location = new System.Drawing.Point(79, 97);
            this.txtConcatMessage.MaxLength = 450;
            this.txtConcatMessage.Multiline = true;
            this.txtConcatMessage.Name = "txtConcatMessage";
            this.txtConcatMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConcatMessage.Size = new System.Drawing.Size(354, 214);
            this.txtConcatMessage.TabIndex = 17;
            this.txtConcatMessage.Visible = false;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(23, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 23);
            this.label11.TabIndex = 18;
            this.label11.Text = "Number:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Visible = false;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(23, 97);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 24);
            this.label12.TabIndex = 16;
            this.label12.Text = "Message:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label12.Visible = false;
            // 
            // txtConcatNumber
            // 
            this.txtConcatNumber.Location = new System.Drawing.Point(79, 49);
            this.txtConcatNumber.MaxLength = 30;
            this.txtConcatNumber.Name = "txtConcatNumber";
            this.txtConcatNumber.Size = new System.Drawing.Size(128, 20);
            this.txtConcatNumber.TabIndex = 19;
            this.txtConcatNumber.Visible = false;
            // 
            // btnSendConcatSMS
            // 
            this.btnSendConcatSMS.Location = new System.Drawing.Point(335, 336);
            this.btnSendConcatSMS.Name = "btnSendConcatSMS";
            this.btnSendConcatSMS.Size = new System.Drawing.Size(88, 38);
            this.btnSendConcatSMS.TabIndex = 21;
            this.btnSendConcatSMS.Text = "Send";
            this.btnSendConcatSMS.Visible = false;
            this.btnSendConcatSMS.Click += new System.EventHandler(this.btnSendConcatSMS_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Aqua;
            this.label1.Location = new System.Drawing.Point(53, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 31);
            this.label1.TabIndex = 64;
            this.label1.Text = "Auto SMS Sender";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Location = new System.Drawing.Point(769, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.TabIndex = 69;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(738, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.TabIndex = 70;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(26, 393);
            this.txtOutput.MaxLength = 0;
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(749, 184);
            this.txtOutput.TabIndex = 71;
            // 
            // SMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = global::SMSSender.Properties.Resources.FormMin;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSendConcatSMS);
            this.Controls.Add(this.chkSmartUnicode);
            this.Controls.Add(this.txtConcatMessage);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtConcatNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SMS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SMS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Time;
        private System.Windows.Forms.CheckBox chkSmartUnicode;
        private System.Windows.Forms.TextBox txtConcatMessage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtConcatNumber;
        private System.Windows.Forms.Button btnSendConcatSMS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtOutput;
    }
}


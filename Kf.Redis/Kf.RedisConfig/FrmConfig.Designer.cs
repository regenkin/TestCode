namespace Kf.RedisConfig
{
    partial class FrmConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReadUrl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWriteUrl = new System.Windows.Forms.TextBox();
            this.numExpire = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numReadPool = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numWritePool = new System.Windows.Forms.NumericUpDown();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkRun = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numExpire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReadPool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWritePool)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Redis写服务地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "持续时间";
            // 
            // txtReadUrl
            // 
            this.txtReadUrl.Location = new System.Drawing.Point(123, 19);
            this.txtReadUrl.Name = "txtReadUrl";
            this.txtReadUrl.Size = new System.Drawing.Size(120, 21);
            this.txtReadUrl.TabIndex = 1;
            this.txtReadUrl.Text = "127.0.0.1:6379";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Redis读服务地址";
            // 
            // txtWriteUrl
            // 
            this.txtWriteUrl.Location = new System.Drawing.Point(370, 19);
            this.txtWriteUrl.Name = "txtWriteUrl";
            this.txtWriteUrl.Size = new System.Drawing.Size(120, 21);
            this.txtWriteUrl.TabIndex = 2;
            this.txtWriteUrl.Text = "127.0.0.1:6379";
            // 
            // numExpire
            // 
            this.numExpire.Location = new System.Drawing.Point(123, 90);
            this.numExpire.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numExpire.Name = "numExpire";
            this.numExpire.Size = new System.Drawing.Size(120, 21);
            this.numExpire.TabIndex = 5;
            this.numExpire.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "最大读线程";
            // 
            // numReadPool
            // 
            this.numReadPool.Location = new System.Drawing.Point(123, 54);
            this.numReadPool.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numReadPool.Name = "numReadPool";
            this.numReadPool.Size = new System.Drawing.Size(120, 21);
            this.numReadPool.TabIndex = 3;
            this.numReadPool.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(289, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "最大写线程";
            // 
            // numWritePool
            // 
            this.numWritePool.Location = new System.Drawing.Point(370, 52);
            this.numWritePool.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numWritePool.Name = "numWritePool";
            this.numWritePool.Size = new System.Drawing.Size(120, 21);
            this.numWritePool.TabIndex = 4;
            this.numWritePool.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(11, 180);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(479, 122);
            this.txtLog.TabIndex = 3;
            this.txtLog.Text = "";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(11, 151);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 6;
            this.btnTest.Text = "测试Redis";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(415, 88);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存配制";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkRun
            // 
            this.chkRun.AutoSize = true;
            this.chkRun.Location = new System.Drawing.Point(280, 92);
            this.chkRun.Name = "chkRun";
            this.chkRun.Size = new System.Drawing.Size(126, 16);
            this.chkRun.TabIndex = 8;
            this.chkRun.Text = "启用Redis缓存模式";
            this.chkRun.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "密码";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(123, 119);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(120, 21);
            this.txtPassword.TabIndex = 1;
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 307);
            this.Controls.Add(this.chkRun);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.numWritePool);
            this.Controls.Add(this.numReadPool);
            this.Controls.Add(this.numExpire);
            this.Controls.Add(this.txtWriteUrl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtReadUrl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmConfig";
            this.Text = "Redis缓存服务配置";
            this.Load += new System.EventHandler(this.FrmConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numExpire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReadPool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWritePool)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReadUrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWriteUrl;
        private System.Windows.Forms.NumericUpDown numExpire;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numReadPool;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numWritePool;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkRun;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPassword;
    }
}
namespace Kf.MemCachedConfig
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
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
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
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPsd = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExpire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReadPool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWritePool)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Memcached服务地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "持续时间";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(139, 19);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(120, 21);
            this.txtUrl.TabIndex = 1;
            this.txtUrl.Text = "127.0.0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(356, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "端口";
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(402, 19);
            this.numPort.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(120, 21);
            this.numPort.TabIndex = 2;
            this.numPort.Value = new decimal(new int[] {
            11211,
            0,
            0,
            0});
            // 
            // numExpire
            // 
            this.numExpire.Location = new System.Drawing.Point(139, 90);
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
            this.label4.Location = new System.Drawing.Point(65, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "最小连接数";
            // 
            // numReadPool
            // 
            this.numReadPool.Location = new System.Drawing.Point(139, 54);
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
            this.label5.Location = new System.Drawing.Point(320, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "最大连接数";
            // 
            // numWritePool
            // 
            this.numWritePool.Location = new System.Drawing.Point(402, 52);
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
            this.txtLog.Location = new System.Drawing.Point(11, 188);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(518, 114);
            this.txtLog.TabIndex = 3;
            this.txtLog.Text = "";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(11, 156);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(138, 23);
            this.btnTest.TabIndex = 8;
            this.btnTest.Text = "测试Memcached服务";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(454, 156);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存配制";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkRun
            // 
            this.chkRun.AutoSize = true;
            this.chkRun.Location = new System.Drawing.Point(298, 162);
            this.chkRun.Name = "chkRun";
            this.chkRun.Size = new System.Drawing.Size(150, 16);
            this.chkRun.TabIndex = 9;
            this.chkRun.Text = "启用Memcached缓存模式";
            this.chkRun.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(77, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "用户名";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(139, 125);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(120, 21);
            this.txtUser.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(340, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "密码";
            // 
            // txtPsd
            // 
            this.txtPsd.Location = new System.Drawing.Point(402, 125);
            this.txtPsd.Name = "txtPsd";
            this.txtPsd.Size = new System.Drawing.Size(120, 21);
            this.txtPsd.TabIndex = 7;
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 307);
            this.Controls.Add(this.chkRun);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.numWritePool);
            this.Controls.Add(this.numReadPool);
            this.Controls.Add(this.numExpire);
            this.Controls.Add(this.numPort);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPsd);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmConfig";
            this.Text = "Memcached缓存服务配置";
            this.Load += new System.EventHandler(this.FrmConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExpire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReadPool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWritePool)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numPort;
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
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPsd;
    }
}
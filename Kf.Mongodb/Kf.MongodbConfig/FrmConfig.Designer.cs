namespace Kf.MongodbConfig
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
            this.numMaxConnectionLifeTime = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numMaxConnectionPoolSize = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numMaxConnectionIdleTime = new System.Windows.Forms.NumericUpDown();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPsd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numConnectTimeout = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numWaitQueueTimeout = new System.Windows.Forms.NumericUpDown();
            this.numWaitQueueSize = new System.Windows.Forms.NumericUpDown();
            this.numSocketTimeout = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDBName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxConnectionLifeTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxConnectionPoolSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxConnectionIdleTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numConnectTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWaitQueueTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWaitQueueSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSocketTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "最大存活时间(s)";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(123, 19);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(144, 21);
            this.txtUrl.TabIndex = 1;
            this.txtUrl.Text = "127.0.0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "端口";
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(383, 19);
            this.numPort.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(144, 21);
            this.numPort.TabIndex = 2;
            this.numPort.Value = new decimal(new int[] {
            27017,
            0,
            0,
            0});
            // 
            // numMaxConnectionLifeTime
            // 
            this.numMaxConnectionLifeTime.Location = new System.Drawing.Point(123, 79);
            this.numMaxConnectionLifeTime.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numMaxConnectionLifeTime.Name = "numMaxConnectionLifeTime";
            this.numMaxConnectionLifeTime.Size = new System.Drawing.Size(144, 21);
            this.numMaxConnectionLifeTime.TabIndex = 5;
            this.numMaxConnectionLifeTime.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "最大连接池";
            // 
            // numMaxConnectionPoolSize
            // 
            this.numMaxConnectionPoolSize.Location = new System.Drawing.Point(123, 49);
            this.numMaxConnectionPoolSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMaxConnectionPoolSize.Name = "numMaxConnectionPoolSize";
            this.numMaxConnectionPoolSize.Size = new System.Drawing.Size(144, 21);
            this.numMaxConnectionPoolSize.TabIndex = 3;
            this.numMaxConnectionPoolSize.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(285, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "最大闲置时间(s)";
            // 
            // numMaxConnectionIdleTime
            // 
            this.numMaxConnectionIdleTime.Location = new System.Drawing.Point(383, 49);
            this.numMaxConnectionIdleTime.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMaxConnectionIdleTime.Name = "numMaxConnectionIdleTime";
            this.numMaxConnectionIdleTime.Size = new System.Drawing.Size(144, 21);
            this.numMaxConnectionIdleTime.TabIndex = 4;
            this.numMaxConnectionIdleTime.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(11, 269);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(518, 115);
            this.txtLog.TabIndex = 3;
            this.txtLog.Text = "";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(11, 237);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(138, 23);
            this.btnTest.TabIndex = 8;
            this.btnTest.Text = "测试Mongodb服务";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(454, 237);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存配制";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(75, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "用户名";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(123, 199);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(144, 21);
            this.txtUser.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(351, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "密码";
            // 
            // txtPsd
            // 
            this.txtPsd.Location = new System.Drawing.Point(383, 204);
            this.txtPsd.Name = "txtPsd";
            this.txtPsd.Size = new System.Drawing.Size(144, 21);
            this.txtPsd.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(309, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "链接时间(s)";
            // 
            // numConnectTimeout
            // 
            this.numConnectTimeout.Location = new System.Drawing.Point(385, 79);
            this.numConnectTimeout.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numConnectTimeout.Name = "numConnectTimeout";
            this.numConnectTimeout.Size = new System.Drawing.Size(144, 21);
            this.numConnectTimeout.TabIndex = 5;
            this.numConnectTimeout.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "队列等待时间(s)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "等待队列大小";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(273, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "socket超时时间(s)";
            // 
            // numWaitQueueTimeout
            // 
            this.numWaitQueueTimeout.Location = new System.Drawing.Point(123, 139);
            this.numWaitQueueTimeout.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numWaitQueueTimeout.Name = "numWaitQueueTimeout";
            this.numWaitQueueTimeout.Size = new System.Drawing.Size(144, 21);
            this.numWaitQueueTimeout.TabIndex = 5;
            this.numWaitQueueTimeout.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // numWaitQueueSize
            // 
            this.numWaitQueueSize.Location = new System.Drawing.Point(123, 109);
            this.numWaitQueueSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numWaitQueueSize.Name = "numWaitQueueSize";
            this.numWaitQueueSize.Size = new System.Drawing.Size(144, 21);
            this.numWaitQueueSize.TabIndex = 3;
            this.numWaitQueueSize.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // numSocketTimeout
            // 
            this.numSocketTimeout.Location = new System.Drawing.Point(383, 109);
            this.numSocketTimeout.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSocketTimeout.Name = "numSocketTimeout";
            this.numSocketTimeout.Size = new System.Drawing.Size(144, 21);
            this.numSocketTimeout.TabIndex = 4;
            this.numSocketTimeout.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(51, 174);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "数据库名称";
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(123, 169);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(144, 21);
            this.txtDBName.TabIndex = 6;
            this.txtDBName.Text = "test";
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 389);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.numSocketTimeout);
            this.Controls.Add(this.numMaxConnectionIdleTime);
            this.Controls.Add(this.numWaitQueueSize);
            this.Controls.Add(this.numMaxConnectionPoolSize);
            this.Controls.Add(this.numConnectTimeout);
            this.Controls.Add(this.numWaitQueueTimeout);
            this.Controls.Add(this.numMaxConnectionLifeTime);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numPort);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPsd);
            this.Controls.Add(this.txtDBName);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmConfig";
            this.Text = "Mongodb服务配置";
            this.Load += new System.EventHandler(this.FrmConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxConnectionLifeTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxConnectionPoolSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxConnectionIdleTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numConnectTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWaitQueueTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWaitQueueSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSocketTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.NumericUpDown numMaxConnectionLifeTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numMaxConnectionPoolSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numMaxConnectionIdleTime;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPsd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numConnectTimeout;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numWaitQueueTimeout;
        private System.Windows.Forms.NumericUpDown numWaitQueueSize;
        private System.Windows.Forms.NumericUpDown numSocketTimeout;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDBName;
    }
}
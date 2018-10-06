namespace ExcelFileConverter
{
    partial class ConfForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxFirstIdNumber = new System.Windows.Forms.TextBox();
            this.txtBoxDollarExchangeRate = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBoxImagePrefix = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxFirstImageNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxMaxImageNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtBoxPathFile = new System.Windows.Forms.TextBox();
            this.btnSelectOutputFile = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxUserAgent = new System.Windows.Forms.TextBox();
            this.btnUpdateDollarRate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBoxTimeOut = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtBoxFTPNumThreads = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBoxFTPPass = new System.Windows.Forms.TextBox();
            this.txtBoxFTPUser = new System.Windows.Forms.TextBox();
            this.txtBoxFTPPort = new System.Windows.Forms.TextBox();
            this.txtBoxFTPServer = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtBoxMinPrice = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Начальный идентификатор товаров";
            // 
            // txtBoxFirstIdNumber
            // 
            this.txtBoxFirstIdNumber.Location = new System.Drawing.Point(219, 6);
            this.txtBoxFirstIdNumber.MaxLength = 9;
            this.txtBoxFirstIdNumber.Name = "txtBoxFirstIdNumber";
            this.txtBoxFirstIdNumber.Size = new System.Drawing.Size(96, 20);
            this.txtBoxFirstIdNumber.TabIndex = 4;
            this.txtBoxFirstIdNumber.Text = "1";
            this.txtBoxFirstIdNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxFirstIdNumber_KeyPress);
            // 
            // txtBoxDollarExchangeRate
            // 
            this.txtBoxDollarExchangeRate.Location = new System.Drawing.Point(219, 32);
            this.txtBoxDollarExchangeRate.Name = "txtBoxDollarExchangeRate";
            this.txtBoxDollarExchangeRate.Size = new System.Drawing.Size(96, 20);
            this.txtBoxDollarExchangeRate.TabIndex = 7;
            this.txtBoxDollarExchangeRate.Text = "65,50";
            this.txtBoxDollarExchangeRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxDollarExchangeRate_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Курс доллара";
            // 
            // txtBoxImagePrefix
            // 
            this.txtBoxImagePrefix.Location = new System.Drawing.Point(219, 58);
            this.txtBoxImagePrefix.Name = "txtBoxImagePrefix";
            this.txtBoxImagePrefix.Size = new System.Drawing.Size(96, 20);
            this.txtBoxImagePrefix.TabIndex = 10;
            this.txtBoxImagePrefix.Text = "a";
            this.txtBoxImagePrefix.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxImagePrefix_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Префикс картинки";
            // 
            // txtBoxFirstImageNumber
            // 
            this.txtBoxFirstImageNumber.Location = new System.Drawing.Point(219, 110);
            this.txtBoxFirstImageNumber.MaxLength = 19;
            this.txtBoxFirstImageNumber.Name = "txtBoxFirstImageNumber";
            this.txtBoxFirstImageNumber.Size = new System.Drawing.Size(96, 20);
            this.txtBoxFirstImageNumber.TabIndex = 9;
            this.txtBoxFirstImageNumber.Text = "1";
            this.txtBoxFirstImageNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxFirstIdNumber_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Начальный номер картинки";
            // 
            // txtBoxMaxImageNumber
            // 
            this.txtBoxMaxImageNumber.Location = new System.Drawing.Point(219, 136);
            this.txtBoxMaxImageNumber.MaxLength = 19;
            this.txtBoxMaxImageNumber.Name = "txtBoxMaxImageNumber";
            this.txtBoxMaxImageNumber.Size = new System.Drawing.Size(96, 20);
            this.txtBoxMaxImageNumber.TabIndex = 13;
            this.txtBoxMaxImageNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxFirstIdNumber_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Максимальный номер картинки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(412, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Путь к пустому файлу Excel, который используется как шаблон для результата";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtBoxPathFile
            // 
            this.txtBoxPathFile.Location = new System.Drawing.Point(15, 186);
            this.txtBoxPathFile.Name = "txtBoxPathFile";
            this.txtBoxPathFile.ReadOnly = true;
            this.txtBoxPathFile.Size = new System.Drawing.Size(340, 20);
            this.txtBoxPathFile.TabIndex = 17;
            // 
            // btnSelectOutputFile
            // 
            this.btnSelectOutputFile.Location = new System.Drawing.Point(361, 184);
            this.btnSelectOutputFile.Name = "btnSelectOutputFile";
            this.btnSelectOutputFile.Size = new System.Drawing.Size(63, 23);
            this.btnSelectOutputFile.TabIndex = 16;
            this.btnSelectOutputFile.Text = "Выбрать";
            this.btnSelectOutputFile.UseVisualStyleBackColor = true;
            this.btnSelectOutputFile.Click += new System.EventHandler(this.btnSelectOutputFile_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "User-agent бота";
            // 
            // txtBoxUserAgent
            // 
            this.txtBoxUserAgent.Location = new System.Drawing.Point(15, 282);
            this.txtBoxUserAgent.Multiline = true;
            this.txtBoxUserAgent.Name = "txtBoxUserAgent";
            this.txtBoxUserAgent.Size = new System.Drawing.Size(409, 56);
            this.txtBoxUserAgent.TabIndex = 19;
            this.txtBoxUserAgent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxUserAgent_KeyPress);
            // 
            // btnUpdateDollarRate
            // 
            this.btnUpdateDollarRate.Location = new System.Drawing.Point(342, 30);
            this.btnUpdateDollarRate.Name = "btnUpdateDollarRate";
            this.btnUpdateDollarRate.Size = new System.Drawing.Size(82, 22);
            this.btnUpdateDollarRate.TabIndex = 20;
            this.btnUpdateDollarRate.Text = "Обновить";
            this.btnUpdateDollarRate.UseVisualStyleBackColor = true;
            this.btnUpdateDollarRate.Visible = false;
            this.btnUpdateDollarRate.Click += new System.EventHandler(this.btnUpdateDollarRate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(320, 501);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(408, 38);
            this.label7.TabIndex = 22;
            this.label7.Text = "Временная задержка между запросам в миллисекундах (чтобы было похоже на обычного " +
    "пользователя)";
            // 
            // txtBoxTimeOut
            // 
            this.txtBoxTimeOut.Location = new System.Drawing.Point(15, 242);
            this.txtBoxTimeOut.MaxLength = 9;
            this.txtBoxTimeOut.Name = "txtBoxTimeOut";
            this.txtBoxTimeOut.Size = new System.Drawing.Size(96, 20);
            this.txtBoxTimeOut.TabIndex = 23;
            this.txtBoxTimeOut.Text = "1";
            this.txtBoxTimeOut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxFirstIdNumber_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtBoxFTPNumThreads);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtBoxFTPPass);
            this.groupBox1.Controls.Add(this.txtBoxFTPUser);
            this.groupBox1.Controls.Add(this.txtBoxFTPPort);
            this.groupBox1.Controls.Add(this.txtBoxFTPServer);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(15, 344);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 151);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки FTP";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 127);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Макс. число потокв";
            // 
            // txtBoxFTPNumThreads
            // 
            this.txtBoxFTPNumThreads.Location = new System.Drawing.Point(117, 124);
            this.txtBoxFTPNumThreads.MaxLength = 2;
            this.txtBoxFTPNumThreads.Name = "txtBoxFTPNumThreads";
            this.txtBoxFTPNumThreads.Size = new System.Drawing.Size(51, 20);
            this.txtBoxFTPNumThreads.TabIndex = 8;
            this.txtBoxFTPNumThreads.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxFirstIdNumber_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Пароль";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Пользователь";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Порт";
            // 
            // txtBoxFTPPass
            // 
            this.txtBoxFTPPass.Location = new System.Drawing.Point(117, 98);
            this.txtBoxFTPPass.Name = "txtBoxFTPPass";
            this.txtBoxFTPPass.Size = new System.Drawing.Size(286, 20);
            this.txtBoxFTPPass.TabIndex = 4;
            // 
            // txtBoxFTPUser
            // 
            this.txtBoxFTPUser.Location = new System.Drawing.Point(117, 71);
            this.txtBoxFTPUser.Name = "txtBoxFTPUser";
            this.txtBoxFTPUser.Size = new System.Drawing.Size(286, 20);
            this.txtBoxFTPUser.TabIndex = 3;
            // 
            // txtBoxFTPPort
            // 
            this.txtBoxFTPPort.Location = new System.Drawing.Point(117, 44);
            this.txtBoxFTPPort.MaxLength = 5;
            this.txtBoxFTPPort.Name = "txtBoxFTPPort";
            this.txtBoxFTPPort.Size = new System.Drawing.Size(108, 20);
            this.txtBoxFTPPort.TabIndex = 2;
            this.txtBoxFTPPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxFirstIdNumber_KeyPress);
            // 
            // txtBoxFTPServer
            // 
            this.txtBoxFTPServer.Location = new System.Drawing.Point(117, 17);
            this.txtBoxFTPServer.Name = "txtBoxFTPServer";
            this.txtBoxFTPServer.Size = new System.Drawing.Size(286, 20);
            this.txtBoxFTPServer.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Сервер";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtBoxMinPrice
            // 
            this.txtBoxMinPrice.Location = new System.Drawing.Point(219, 84);
            this.txtBoxMinPrice.Name = "txtBoxMinPrice";
            this.txtBoxMinPrice.Size = new System.Drawing.Size(96, 20);
            this.txtBoxMinPrice.TabIndex = 25;
            this.txtBoxMinPrice.Text = "0,0";
            this.txtBoxMinPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxDollarExchangeRate_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 87);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(173, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Минимальная стоимость товара";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(321, 87);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(27, 13);
            this.label15.TabIndex = 27;
            this.label15.Text = "руб.";
            // 
            // ConfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 533);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtBoxMinPrice);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtBoxTimeOut);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdateDollarRate);
            this.Controls.Add(this.txtBoxUserAgent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBoxPathFile);
            this.Controls.Add(this.btnSelectOutputFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBoxMaxImageNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxImagePrefix);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBoxFirstImageNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBoxDollarExchangeRate);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtBoxFirstIdNumber);
            this.Controls.Add(this.label1);
            this.Name = "ConfForm";
            this.Text = "Конфигурация";
            this.Load += new System.EventHandler(this.ConfForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxFirstIdNumber;
        private System.Windows.Forms.TextBox txtBoxDollarExchangeRate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBoxImagePrefix;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxFirstImageNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxMaxImageNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtBoxPathFile;
        private System.Windows.Forms.Button btnSelectOutputFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxUserAgent;
        private System.Windows.Forms.Button btnUpdateDollarRate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBoxTimeOut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBoxFTPPass;
        private System.Windows.Forms.TextBox txtBoxFTPUser;
        private System.Windows.Forms.TextBox txtBoxFTPPort;
        private System.Windows.Forms.TextBox txtBoxFTPServer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtBoxFTPNumThreads;
        private System.Windows.Forms.TextBox txtBoxMinPrice;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}
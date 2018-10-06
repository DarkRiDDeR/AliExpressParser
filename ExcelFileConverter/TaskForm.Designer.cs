namespace ExcelFileConverter
{
    partial class TaskForm
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
            this.groupBoxInputData = new System.Windows.Forms.GroupBox();
            this.numFirstPage = new System.Windows.Forms.NumericUpDown();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.numLastPage = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbPrice = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.chckBxSizeAvailable = new System.Windows.Forms.CheckBox();
            this.groupBoxSettingsProductName = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdBtnManufacturer = new System.Windows.Forms.RadioButton();
            this.rdBtnStyle = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBxSecondProductEnding = new System.Windows.Forms.TextBox();
            this.txtBxFirstProductEnding = new System.Windows.Forms.TextBox();
            this.txtBxInsertProductName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupOtherSettings = new System.Windows.Forms.GroupBox();
            this.txtBxImagePath = new System.Windows.Forms.TextBox();
            this.txtBoxPricePercent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBxCategoryNumber = new System.Windows.Forms.TextBox();
            this.groupBoxSettingsProductCharacteristics = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBxCharacteristicName = new System.Windows.Forms.TextBox();
            this.btnAddCharacteristic = new System.Windows.Forms.Button();
            this.btnRemoveCharacteristic = new System.Windows.Forms.Button();
            this.lstBxProductCharacteristics = new System.Windows.Forms.ListBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnOk = new System.Windows.Forms.Button();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxFTPPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxInputData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFirstPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLastPage)).BeginInit();
            this.groupBoxSettingsProductName.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupOtherSettings.SuspendLayout();
            this.groupBoxSettingsProductCharacteristics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxInputData
            // 
            this.groupBoxInputData.Controls.Add(this.numFirstPage);
            this.groupBoxInputData.Controls.Add(this.txtURL);
            this.groupBoxInputData.Controls.Add(this.label13);
            this.groupBoxInputData.Controls.Add(this.numLastPage);
            this.groupBoxInputData.Controls.Add(this.label14);
            this.groupBoxInputData.Controls.Add(this.label15);
            this.groupBoxInputData.Location = new System.Drawing.Point(12, 38);
            this.groupBoxInputData.Name = "groupBoxInputData";
            this.groupBoxInputData.Size = new System.Drawing.Size(626, 76);
            this.groupBoxInputData.TabIndex = 22;
            this.groupBoxInputData.TabStop = false;
            this.groupBoxInputData.Text = "Выбор исходных данных для парсинга с AliExprecss";
            // 
            // numFirstPage
            // 
            this.numFirstPage.Location = new System.Drawing.Point(140, 47);
            this.numFirstPage.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numFirstPage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFirstPage.Name = "numFirstPage";
            this.numFirstPage.Size = new System.Drawing.Size(109, 20);
            this.numFirstPage.TabIndex = 15;
            this.numFirstPage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(140, 20);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(480, 20);
            this.txtURL.TabIndex = 12;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "URL категории";
            // 
            // numLastPage
            // 
            this.numLastPage.Location = new System.Drawing.Point(304, 47);
            this.numLastPage.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numLastPage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLastPage.Name = "numLastPage";
            this.numLastPage.Size = new System.Drawing.Size(109, 20);
            this.numLastPage.TabIndex = 18;
            this.numLastPage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(114, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Парсить страницы с ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(266, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(19, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "по";
            // 
            // cmbPrice
            // 
            this.cmbPrice.FormattingEnabled = true;
            this.cmbPrice.Items.AddRange(new object[] {
            "Минимальную",
            "Среднюю",
            "Максимальную"});
            this.cmbPrice.Location = new System.Drawing.Point(140, 20);
            this.cmbPrice.Name = "cmbPrice";
            this.cmbPrice.Size = new System.Drawing.Size(109, 21);
            this.cmbPrice.TabIndex = 20;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(101, 13);
            this.label16.TabIndex = 19;
            this.label16.Text = "Брать цену товара";
            // 
            // chckBxSizeAvailable
            // 
            this.chckBxSizeAvailable.AutoSize = true;
            this.chckBxSizeAvailable.Checked = true;
            this.chckBxSizeAvailable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckBxSizeAvailable.Location = new System.Drawing.Point(14, 82);
            this.chckBxSizeAvailable.Name = "chckBxSizeAvailable";
            this.chckBxSizeAvailable.Size = new System.Drawing.Size(138, 17);
            this.chckBxSizeAvailable.TabIndex = 25;
            this.chckBxSizeAvailable.Text = "Присутствие размера";
            this.chckBxSizeAvailable.UseVisualStyleBackColor = true;
            // 
            // groupBoxSettingsProductName
            // 
            this.groupBoxSettingsProductName.Controls.Add(this.groupBox3);
            this.groupBoxSettingsProductName.Controls.Add(this.txtBxInsertProductName);
            this.groupBoxSettingsProductName.Controls.Add(this.label8);
            this.groupBoxSettingsProductName.Location = new System.Drawing.Point(12, 120);
            this.groupBoxSettingsProductName.Name = "groupBoxSettingsProductName";
            this.groupBoxSettingsProductName.Size = new System.Drawing.Size(310, 139);
            this.groupBoxSettingsProductName.TabIndex = 23;
            this.groupBoxSettingsProductName.TabStop = false;
            this.groupBoxSettingsProductName.Text = "Настройка названия товара";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdBtnManufacturer);
            this.groupBox3.Controls.Add(this.rdBtnStyle);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtBxSecondProductEnding);
            this.groupBox3.Controls.Add(this.txtBxFirstProductEnding);
            this.groupBox3.Location = new System.Drawing.Point(15, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(289, 74);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Источник названия";
            // 
            // rdBtnManufacturer
            // 
            this.rdBtnManufacturer.AutoSize = true;
            this.rdBtnManufacturer.Location = new System.Drawing.Point(6, 43);
            this.rdBtnManufacturer.Name = "rdBtnManufacturer";
            this.rdBtnManufacturer.Size = new System.Drawing.Size(104, 17);
            this.rdBtnManufacturer.TabIndex = 1;
            this.rdBtnManufacturer.Text = "Производитель";
            this.rdBtnManufacturer.UseVisualStyleBackColor = true;
            // 
            // rdBtnStyle
            // 
            this.rdBtnStyle.AutoSize = true;
            this.rdBtnStyle.Checked = true;
            this.rdBtnStyle.Location = new System.Drawing.Point(6, 20);
            this.rdBtnStyle.Name = "rdBtnStyle";
            this.rdBtnStyle.Size = new System.Drawing.Size(55, 17);
            this.rdBtnStyle.TabIndex = 0;
            this.rdBtnStyle.TabStop = true;
            this.rdBtnStyle.Text = "Стиль";
            this.rdBtnStyle.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(184, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Рабоч(-ий)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(123, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "-ый";
            // 
            // txtBxSecondProductEnding
            // 
            this.txtBxSecondProductEnding.Location = new System.Drawing.Point(248, 21);
            this.txtBxSecondProductEnding.Name = "txtBxSecondProductEnding";
            this.txtBxSecondProductEnding.Size = new System.Drawing.Size(25, 20);
            this.txtBxSecondProductEnding.TabIndex = 4;
            this.txtBxSecondProductEnding.Text = "ее";
            // 
            // txtBxFirstProductEnding
            // 
            this.txtBxFirstProductEnding.Location = new System.Drawing.Point(153, 20);
            this.txtBxFirstProductEnding.Name = "txtBxFirstProductEnding";
            this.txtBxFirstProductEnding.Size = new System.Drawing.Size(25, 20);
            this.txtBxFirstProductEnding.TabIndex = 4;
            this.txtBxFirstProductEnding.Text = "ое";
            // 
            // txtBxInsertProductName
            // 
            this.txtBxInsertProductName.Location = new System.Drawing.Point(75, 105);
            this.txtBxInsertProductName.Name = "txtBxInsertProductName";
            this.txtBxInsertProductName.Size = new System.Drawing.Size(100, 20);
            this.txtBxInsertProductName.TabIndex = 5;
            this.txtBxInsertProductName.Text = "Платье";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Название";
            // 
            // groupOtherSettings
            // 
            this.groupOtherSettings.Controls.Add(this.label3);
            this.groupOtherSettings.Controls.Add(this.txtBoxFTPPath);
            this.groupOtherSettings.Controls.Add(this.txtBxImagePath);
            this.groupOtherSettings.Controls.Add(this.txtBoxPricePercent);
            this.groupOtherSettings.Controls.Add(this.label1);
            this.groupOtherSettings.Controls.Add(this.label4);
            this.groupOtherSettings.Controls.Add(this.cmbPrice);
            this.groupOtherSettings.Controls.Add(this.label7);
            this.groupOtherSettings.Controls.Add(this.txtBxCategoryNumber);
            this.groupOtherSettings.Controls.Add(this.chckBxSizeAvailable);
            this.groupOtherSettings.Controls.Add(this.label16);
            this.groupOtherSettings.Location = new System.Drawing.Point(12, 265);
            this.groupOtherSettings.Name = "groupOtherSettings";
            this.groupOtherSettings.Size = new System.Drawing.Size(626, 112);
            this.groupOtherSettings.TabIndex = 24;
            this.groupOtherSettings.TabStop = false;
            this.groupOtherSettings.Text = "Прочие настройки";
            // 
            // txtBxImagePath
            // 
            this.txtBxImagePath.Location = new System.Drawing.Point(455, 43);
            this.txtBxImagePath.Name = "txtBxImagePath";
            this.txtBxImagePath.Size = new System.Drawing.Size(165, 20);
            this.txtBxImagePath.TabIndex = 4;
            this.txtBxImagePath.Text = "catalog/";
            // 
            // txtBoxPricePercent
            // 
            this.txtBoxPricePercent.Location = new System.Drawing.Point(140, 47);
            this.txtBoxPricePercent.Name = "txtBoxPricePercent";
            this.txtBoxPricePercent.Size = new System.Drawing.Size(45, 20);
            this.txtBoxPricePercent.TabIndex = 33;
            this.txtBoxPricePercent.Text = "20,0";
            this.txtBoxPricePercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxPricePercent_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Увеличить цену на, %";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(272, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Путь к картинкам";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(272, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Номер категории";
            // 
            // txtBxCategoryNumber
            // 
            this.txtBxCategoryNumber.Location = new System.Drawing.Point(455, 13);
            this.txtBxCategoryNumber.Name = "txtBxCategoryNumber";
            this.txtBxCategoryNumber.Size = new System.Drawing.Size(48, 20);
            this.txtBxCategoryNumber.TabIndex = 27;
            this.txtBxCategoryNumber.Text = "1";
            this.txtBxCategoryNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxCategoryNumber_KeyPress);
            // 
            // groupBoxSettingsProductCharacteristics
            // 
            this.groupBoxSettingsProductCharacteristics.Controls.Add(this.label11);
            this.groupBoxSettingsProductCharacteristics.Controls.Add(this.txtBxCharacteristicName);
            this.groupBoxSettingsProductCharacteristics.Controls.Add(this.btnAddCharacteristic);
            this.groupBoxSettingsProductCharacteristics.Controls.Add(this.btnRemoveCharacteristic);
            this.groupBoxSettingsProductCharacteristics.Controls.Add(this.lstBxProductCharacteristics);
            this.groupBoxSettingsProductCharacteristics.Location = new System.Drawing.Point(328, 120);
            this.groupBoxSettingsProductCharacteristics.Name = "groupBoxSettingsProductCharacteristics";
            this.groupBoxSettingsProductCharacteristics.Size = new System.Drawing.Size(311, 139);
            this.groupBoxSettingsProductCharacteristics.TabIndex = 34;
            this.groupBoxSettingsProductCharacteristics.TabStop = false;
            this.groupBoxSettingsProductCharacteristics.Text = "Настройка характеристик";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(136, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(174, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Название новой характеристики";
            // 
            // txtBxCharacteristicName
            // 
            this.txtBxCharacteristicName.Location = new System.Drawing.Point(139, 32);
            this.txtBxCharacteristicName.Name = "txtBxCharacteristicName";
            this.txtBxCharacteristicName.Size = new System.Drawing.Size(165, 20);
            this.txtBxCharacteristicName.TabIndex = 3;
            // 
            // btnAddCharacteristic
            // 
            this.btnAddCharacteristic.Location = new System.Drawing.Point(139, 58);
            this.btnAddCharacteristic.Name = "btnAddCharacteristic";
            this.btnAddCharacteristic.Size = new System.Drawing.Size(75, 23);
            this.btnAddCharacteristic.TabIndex = 2;
            this.btnAddCharacteristic.Text = "Добавить";
            this.btnAddCharacteristic.UseVisualStyleBackColor = true;
            this.btnAddCharacteristic.Click += new System.EventHandler(this.btnAddCharacteristic_Click);
            // 
            // btnRemoveCharacteristic
            // 
            this.btnRemoveCharacteristic.Location = new System.Drawing.Point(139, 92);
            this.btnRemoveCharacteristic.Name = "btnRemoveCharacteristic";
            this.btnRemoveCharacteristic.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveCharacteristic.TabIndex = 1;
            this.btnRemoveCharacteristic.Text = "Удалить";
            this.btnRemoveCharacteristic.UseVisualStyleBackColor = true;
            this.btnRemoveCharacteristic.Click += new System.EventHandler(this.btnRemoveCharacteristic_Click);
            // 
            // lstBxProductCharacteristics
            // 
            this.lstBxProductCharacteristics.FormattingEnabled = true;
            this.lstBxProductCharacteristics.Location = new System.Drawing.Point(10, 20);
            this.lstBxProductCharacteristics.Name = "lstBxProductCharacteristics";
            this.lstBxProductCharacteristics.Size = new System.Drawing.Size(120, 108);
            this.lstBxProductCharacteristics.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 392);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(148, 26);
            this.btnOk.TabIndex = 35;
            this.btnOk.Text = "Добавить задание";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(152, 6);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(273, 20);
            this.txtBoxName.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Название задания";
            // 
            // txtBoxFTPPath
            // 
            this.txtBoxFTPPath.Location = new System.Drawing.Point(455, 76);
            this.txtBoxFTPPath.Name = "txtBoxFTPPath";
            this.txtBoxFTPPath.Size = new System.Drawing.Size(165, 20);
            this.txtBoxFTPPath.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(272, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 28);
            this.label3.TabIndex = 35;
            this.label3.Text = "Путь FTP (если пусто, то не загружать на сервер через FTP)";
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 430);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBoxSettingsProductCharacteristics);
            this.Controls.Add(this.groupBoxSettingsProductName);
            this.Controls.Add(this.groupOtherSettings);
            this.Controls.Add(this.groupBoxInputData);
            this.Name = "TaskForm";
            this.Text = "Добавление задания";
            this.groupBoxInputData.ResumeLayout(false);
            this.groupBoxInputData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFirstPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLastPage)).EndInit();
            this.groupBoxSettingsProductName.ResumeLayout(false);
            this.groupBoxSettingsProductName.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupOtherSettings.ResumeLayout(false);
            this.groupOtherSettings.PerformLayout();
            this.groupBoxSettingsProductCharacteristics.ResumeLayout(false);
            this.groupBoxSettingsProductCharacteristics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxInputData;
        private System.Windows.Forms.NumericUpDown numFirstPage;
        private System.Windows.Forms.ComboBox cmbPrice;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numLastPage;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chckBxSizeAvailable;
        private System.Windows.Forms.GroupBox groupBoxSettingsProductName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdBtnManufacturer;
        private System.Windows.Forms.RadioButton rdBtnStyle;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBxSecondProductEnding;
        private System.Windows.Forms.TextBox txtBxFirstProductEnding;
        private System.Windows.Forms.TextBox txtBxInsertProductName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupOtherSettings;
        private System.Windows.Forms.TextBox txtBxImagePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxPricePercent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBxCategoryNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBoxSettingsProductCharacteristics;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBxCharacteristicName;
        private System.Windows.Forms.Button btnAddCharacteristic;
        private System.Windows.Forms.Button btnRemoveCharacteristic;
        private System.Windows.Forms.ListBox lstBxProductCharacteristics;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxFTPPath;
    }
}
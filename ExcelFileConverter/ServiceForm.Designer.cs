namespace ExcelFileConverter
{
    partial class ServiceForm
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
            this.btnClear = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnVacuum = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Шорт-лист загруженных ссылок имеет записей всего";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(16, 38);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(144, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Очистить шорт-лист";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(300, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // btnVacuum
            // 
            this.btnVacuum.Location = new System.Drawing.Point(16, 120);
            this.btnVacuum.Name = "btnVacuum";
            this.btnVacuum.Size = new System.Drawing.Size(172, 23);
            this.btnVacuum.TabIndex = 3;
            this.btnVacuum.Text = "Выполнить VACUUM для БД";
            this.btnVacuum.UseVisualStyleBackColor = true;
            this.btnVacuum.Click += new System.EventHandler(this.btnVacuum_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(418, 39);
            this.label2.TabIndex = 4;
            this.label2.Text = "VACUUM перестраивает всю базу данных, освобождая \"пустую\" память от уже удалённых" +
    " записей, и тем самым уменьшает размер файла базы данных";
            // 
            // LinksLoadedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 157);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnVacuum);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label1);
            this.Name = "LinksLoadedForm";
            this.Text = "Обслуживание";
            this.Load += new System.EventHandler(this.LinksLoadedForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnVacuum;
        private System.Windows.Forms.Label label2;
    }
}
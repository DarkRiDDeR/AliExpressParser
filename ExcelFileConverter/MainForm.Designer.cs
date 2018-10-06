namespace ExcelFileConverter
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.разовоеЗаданиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ошибкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обслуживаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.конфигурацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridTasks = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.btnEditTask = new System.Windows.Forms.Button();
            this.btnDelTask = new System.Windows.Forms.Button();
            this.btnParse = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.разовоеЗаданиеToolStripMenuItem,
            this.ошибкиToolStripMenuItem,
            this.обслуживаниеToolStripMenuItem,
            this.конфигурацияToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1032, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // разовоеЗаданиеToolStripMenuItem
            // 
            this.разовоеЗаданиеToolStripMenuItem.Name = "разовоеЗаданиеToolStripMenuItem";
            this.разовоеЗаданиеToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.разовоеЗаданиеToolStripMenuItem.Text = "Разовое задание";
            this.разовоеЗаданиеToolStripMenuItem.Click += new System.EventHandler(this.разовоеЗаданиеToolStripMenuItem_Click);
            // 
            // ошибкиToolStripMenuItem
            // 
            this.ошибкиToolStripMenuItem.Name = "ошибкиToolStripMenuItem";
            this.ошибкиToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.ошибкиToolStripMenuItem.Text = "Ошибки";
            this.ошибкиToolStripMenuItem.Click += new System.EventHandler(this.ошибкиToolStripMenuItem_Click);
            // 
            // обслуживаниеToolStripMenuItem
            // 
            this.обслуживаниеToolStripMenuItem.Name = "обслуживаниеToolStripMenuItem";
            this.обслуживаниеToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.обслуживаниеToolStripMenuItem.Text = "Обслуживание";
            this.обслуживаниеToolStripMenuItem.Click += new System.EventHandler(this.шортлистToolStripMenuItem_Click);
            // 
            // конфигурацияToolStripMenuItem
            // 
            this.конфигурацияToolStripMenuItem.Name = "конфигурацияToolStripMenuItem";
            this.конфигурацияToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.конфигурацияToolStripMenuItem.Text = "Конфигурация";
            this.конфигурацияToolStripMenuItem.Click += new System.EventHandler(this.конфигурацияToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // dataGridTasks
            // 
            this.dataGridTasks.AllowUserToAddRows = false;
            this.dataGridTasks.AllowUserToDeleteRows = false;
            this.dataGridTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column6,
            this.Column7,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridTasks.Location = new System.Drawing.Point(12, 27);
            this.dataGridTasks.MultiSelect = false;
            this.dataGridTasks.Name = "dataGridTasks";
            this.dataGridTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTasks.Size = new System.Drawing.Size(1008, 398);
            this.dataGridTasks.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Выбор";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 60;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "ID";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 60;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Дата";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Название";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Начал. стр.";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 60;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Конеч. стр.";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 60;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "URL категории";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 500;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddTask.Location = new System.Drawing.Point(12, 439);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(75, 23);
            this.btnAddTask.TabIndex = 2;
            this.btnAddTask.Text = "Добавить";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // btnEditTask
            // 
            this.btnEditTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditTask.Location = new System.Drawing.Point(93, 439);
            this.btnEditTask.Name = "btnEditTask";
            this.btnEditTask.Size = new System.Drawing.Size(113, 23);
            this.btnEditTask.TabIndex = 4;
            this.btnEditTask.Text = "Редактировать";
            this.btnEditTask.UseVisualStyleBackColor = true;
            this.btnEditTask.Click += new System.EventHandler(this.btnEditTask_Click);
            // 
            // btnDelTask
            // 
            this.btnDelTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelTask.Location = new System.Drawing.Point(212, 439);
            this.btnDelTask.Name = "btnDelTask";
            this.btnDelTask.Size = new System.Drawing.Size(75, 23);
            this.btnDelTask.TabIndex = 5;
            this.btnDelTask.Text = "Удалить";
            this.btnDelTask.UseVisualStyleBackColor = true;
            this.btnDelTask.Click += new System.EventHandler(this.btnDelTask_Click);
            // 
            // btnParse
            // 
            this.btnParse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnParse.Location = new System.Drawing.Point(378, 439);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(102, 23);
            this.btnParse.TabIndex = 6;
            this.btnParse.Text = "Парсить";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(73, 480);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(947, 19);
            this.progressBar1.TabIndex = 7;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // progressBar2
            // 
            this.progressBar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar2.Location = new System.Drawing.Point(73, 505);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(947, 19);
            this.progressBar2.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 480);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "ПАРСИНГ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 505);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "FTP";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 536);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.btnDelTask);
            this.Controls.Add(this.btnEditTask);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.dataGridTasks);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Парсер AliExpress";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTasks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem конфигурацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ошибкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem разовоеЗаданиеToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridTasks;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.ToolStripMenuItem обслуживаниеToolStripMenuItem;
        private System.Windows.Forms.Button btnEditTask;
        private System.Windows.Forms.Button btnDelTask;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ExcelFileConverter
{
    public partial class MainForm : Form
    {
        private static SQLiteConnection sqLiteCtn;
        private AboutBox1 aboutBox = null;
        private ErrorsForm errorsForm = null;
        private ServiceForm linksLoadedForm = null;
        private static int goodsId;
        private static List<string> idTasks = new List<string>();

        private static int pageCount = 0;
        private static int pagesNumber = 0;
        private static Dictionary<string, int> pagesNumberForTasks = new Dictionary<string, int>();

        public MainForm(SQLiteConnection connection)
        {
            InitializeComponent();
            sqLiteCtn = connection;
            readTasks();
        }

        private void readTasks()
        {
            using (SQLiteCommand command = new SQLiteCommand(sqLiteCtn))
            {
                command.CommandText = "SELECT * FROM [tasks] ORDER BY id;";
                command.CommandType = CommandType.Text;
                SQLiteDataReader reader = command.ExecuteReader();
                int i = 0;
                foreach (DbDataRecord record in reader)
                {
                    dataGridTasks.Rows.Add();
                    dataGridTasks.Rows[i].Cells[1].Value = record["id"].ToString();
                    dataGridTasks.Rows[i].Cells[2].Value = record["date"].ToString();
                    dataGridTasks.Rows[i].Cells[3].Value = record["task_name"].ToString();
                    dataGridTasks.Rows[i].Cells[4].Value = record["first_page"].ToString();
                    dataGridTasks.Rows[i].Cells[5].Value = record["last_page"].ToString();
                    dataGridTasks.Rows[i].Cells[6].Value = record["link"].ToString();
                    i++;
                }
                reader.Close();
            }
        }


        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (aboutBox == null || aboutBox.IsDisposed)
            { 
                this.aboutBox = new AboutBox1();
                aboutBox.Show();
            }
            else
            {
                aboutBox.Focus();
            }
        }

        private void разовоеЗаданиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new OneTimeTaskForm(sqLiteCtn)).Show();
        }

        private void конфигурацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new ConfForm(sqLiteCtn)).ShowDialog();
        }

        private void ошибкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (errorsForm == null || errorsForm.IsDisposed)
            {
                this.errorsForm = new ErrorsForm(sqLiteCtn);
                errorsForm.Show();
            }
            else
            {
                errorsForm.Focus();
            }
        }

        private void шортлистToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (linksLoadedForm == null || linksLoadedForm.IsDisposed)
            {
                this.linksLoadedForm = new ServiceForm(sqLiteCtn);
                linksLoadedForm.Show();
            }
            else
            {
                linksLoadedForm.Focus();
            }
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            (new TaskForm(sqLiteCtn)).ShowDialog();
            dataGridTasks.Rows.Clear();
            readTasks();
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            (new TaskForm(sqLiteCtn, dataGridTasks.Rows[dataGridTasks.CurrentCell.RowIndex].Cells[1].Value.ToString())).ShowDialog();
            dataGridTasks.Rows.Clear();
            readTasks();
        }

        private void btnDelTask_Click(object sender, EventArgs e)
        {
            string id = dataGridTasks.Rows[dataGridTasks.CurrentCell.RowIndex].Cells[1].Value.ToString();
            using (SQLiteCommand command = new SQLiteCommand(sqLiteCtn))
            {
                command.CommandText = @"DELETE FROM [characteristics] WHERE id = " + id + @";
                DELETE FROM [tasks] WHERE id = " + id +";";
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            dataGridTasks.Rows.RemoveAt(dataGridTasks.CurrentCell.RowIndex);
        }

        private void btnParse_Click(object sender, EventArgs e)
        {

            if (File.Exists(ConfForm.conf["path_empty_excel"]))
            {
                btnAddTask.Enabled = false;
                btnDelTask.Enabled = false;
                btnEditTask.Enabled = false;
                btnParse.Enabled = false;
                dataGridTasks.Enabled = false;
                конфигурацияToolStripMenuItem.Enabled = false;
                обслуживаниеToolStripMenuItem.Enabled = false;
                goodsId = int.Parse(ConfForm.conf["first_id_goods"].ToString());
                pageCount = 0;
                pagesNumber = 0;
                pagesNumberForTasks.Clear();
                idTasks.Clear();
                progressBar1.Value = 0;
                progressBar2.Value = 0;

                foreach (DataGridViewRow row in dataGridTasks.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        int pageNumberForTask = Convert.ToInt32(row.Cells[5].Value) - Convert.ToInt32(row.Cells[4].Value) + 1;
                        string id = row.Cells[1].Value.ToString();
                        idTasks.Add(id);
                        pagesNumberForTasks.Add(id, pageNumberForTask);
                        pagesNumber += pageNumberForTask;
                    }
                }
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Пустой файл Excel, который используется как шаблон для результата по адресу \"" + ConfForm.conf["path_empty_excel"] + "\" не существует. ", "Ошибка конфигурации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string path_empty_exel = ConfForm.conf["path_empty_excel"];
            double dollarRate = double.Parse(ConfForm.conf["dollar_rate"]);

            var task = new Task(sqLiteCtn);
            int taskNumber = 0;
            string path_exel;
            List<string> characteristics;
            foreach (string id in idTasks)
            {
                using (SQLiteCommand command = new SQLiteCommand(sqLiteCtn))
                {
                    command.CommandType = CommandType.Text;
                    characteristics = new List<string>();
                    command.CommandText = "SELECT * FROM [characteristics] WHERE id = " + id + ";";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        foreach (DbDataRecord record in reader)
                            characteristics.Add(record["name"].ToString());
                    }
                    command.CommandText = @"SELECT * FROM [tasks] WHERE id = " + id;
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        // copy excel
                        path_exel = Regex.Replace(path_empty_exel, "\\\\[^\\\\\\.]+?(\\..*?)$", "\\" + taskNumber + "$1");
                        File.Copy(path_empty_exel, path_exel, true);
                        task.settings(
                            id.ToString(), (string)reader["link"], (int)(long)reader["first_page"], (int)(long)reader["last_page"], path_exel,
                            ulong.Parse(ConfForm.conf["first_id_goods"]), (int)(long)reader["price"], dollarRate, double.Parse((string)reader["additive"]), (bool)reader["is_size"],
                            (string)reader["name_first_part"], (int)(long)reader["name_source"], (string)reader["name_style_first_ending"],
                            (string)reader["name_style_second_ending"], (string)reader["output_img_path"],
                            ConfForm.conf["img_prefix"], ulong.Parse(ConfForm.conf["img_first_number"]),
                            ulong.Parse(ConfForm.conf["img_max_number"]), reader["category_number"].ToString(),
                            characteristics.ToArray(),
                            (string)reader["ftp_path"]=="" ? null : "ftp://" + ConfForm.conf["ftp_server"]+":"+ConfForm.conf["ftp_port"]+"/"+(string)reader["ftp_path"],
                            backgroundWorker1, (double)pageCount / pagesNumber, pagesNumber
                            );
                    }
                    pageCount += pagesNumberForTasks[id];
                    task.perform();
                    ++taskNumber;
                }
                ConfForm.conf["first_id_goods"] = task.getNextIdNumber().ToString();
                ConfForm.conf["img_prefix"] = task.getImagePrefix();
                ConfForm.conf["img_first_number"] = task.getNextImageNumber().ToString();
            }
            ConfForm.save();

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            progressBar2.Value = Convert.ToInt32(e.UserState);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnAddTask.Enabled = true;
            btnDelTask.Enabled = true;
            btnEditTask.Enabled = true;
            btnParse.Enabled = true;
            dataGridTasks.Enabled = true;
            конфигурацияToolStripMenuItem.Enabled = true;
            обслуживаниеToolStripMenuItem.Enabled = true;

            progressBar1.Value = 100;
            progressBar2.Value = 100;
            MessageBox.Show("Парсинг данных успешно завершён.");
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExcelFileConverter
{
    public partial class ConfForm : Form
    {
        private static SQLiteConnection sqLiteCon;
        public static Dictionary<string, string> conf = new Dictionary<string, string>();

        public ConfForm(SQLiteConnection connection)
        {
            InitializeComponent();
            sqLiteCon = connection;
        }

        static public void readConf(SQLiteConnection connection)
        {
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                conf.Clear();
                command.CommandText = "SELECT * FROM [conf];";
                command.CommandType = CommandType.Text;
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    foreach (DbDataRecord record in reader)
                    {
                        conf.Add(record["name"].ToString(), record["value"].ToString());
                    }
                }
            }
        }

        private void setOnForm ()
        {
            string value;
            foreach (string name in conf.Keys)
            {
                value = conf[name];
                switch (name)
                {
                    case "first_id_goods":
                        txtBoxFirstIdNumber.Text = value;
                        break;
                    case "dollar_rate":
                        txtBoxDollarExchangeRate.Text = value;
                        break;
                    case "img_prefix":
                        txtBoxImagePrefix.Text = value;
                        break;
                    case "img_first_number":
                        txtBoxFirstImageNumber.Text = value;
                        break;
                    case "img_max_number":
                        txtBoxMaxImageNumber.Text = value;
                        break;
                    case "path_empty_excel":
                        txtBoxPathFile.Text = value;
                        break;
                    case "time_out":
                        txtBoxTimeOut.Text = value;
                        break;
                    case "user_agent":
                        txtBoxUserAgent.Text = value;
                        break;
                    case "ftp_server":
                        txtBoxFTPServer.Text = value;
                        break;
                    case "ftp_port":
                        txtBoxFTPPort.Text = value;
                        break;
                    case "ftp_user":
                        txtBoxFTPUser.Text = value;
                        break;
                    case "ftp_pass":
                        txtBoxFTPPass.Text = value;
                        break;
                    case "ftp_number_threads":
                        txtBoxFTPNumThreads.Text = value;
                        break;
                    case "min_price":
                        txtBoxMinPrice.Text = value;
                        break;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBoxFirstIdNumber.Text == "" || txtBoxDollarExchangeRate.Text == "" || 
            txtBoxImagePrefix.Text == "" || txtBoxFirstImageNumber.Text == "" ||
            txtBoxMaxImageNumber.Text == "" || txtBoxPathFile.Text == "" ||
            txtBoxUserAgent.Text.Trim() == "" || txtBoxMinPrice.Text == "")
            {
                MessageBox.Show("Не все данные введены");
                return;
            }
            double dollarExchangeRate;
            if (!double.TryParse(txtBoxDollarExchangeRate.Text, out dollarExchangeRate) || dollarExchangeRate == 0)
            {
                MessageBox.Show("Введено некорректное значение курса доллара");
                return;
            }
            double minPrice;
            if (!double.TryParse(txtBoxMinPrice.Text, out minPrice))
            {
                MessageBox.Show("Введено некорректное минимальной цены товара");
                return;
            }

            using (SQLiteCommand command = new SQLiteCommand(sqLiteCon))
            {
                command.CommandText = @"DELETE FROM [conf];
                INSERT INTO [conf] ('id', 'name', 'value')
                VALUES
                (1, 'first_id_goods', '" + txtBoxFirstIdNumber.Text + @"'),
                (2, 'dollar_rate', '" + dollarExchangeRate.ToString() + @"'),
                (3, 'min_price', '" + minPrice.ToString() + @"'),
                (4, 'img_prefix', '" + txtBoxImagePrefix.Text + @"'),
                (5, 'img_first_number', '" + txtBoxFirstImageNumber.Text + @"'),
                (6, 'img_max_number', '" + txtBoxMaxImageNumber.Text + @"'),
                (7, 'path_empty_excel', '" + txtBoxPathFile.Text.Replace("'", "''") + @"'),
                (8, 'time_out', '" + txtBoxTimeOut.Text + @"'),
                (9, 'user_agent', '" + txtBoxUserAgent.Text.Trim().Replace("'", "''") + @"'),
                (10, 'ftp_server', '" + txtBoxFTPServer.Text.Trim().Replace("'", "''") + @"'),
                (11, 'ftp_port', '" + txtBoxFTPPort.Text + @"'),
                (12, 'ftp_user', '" + txtBoxFTPUser.Text.Trim().Replace("'", "''") + @"'),
                (13, 'ftp_pass', '" + txtBoxFTPPass.Text.Trim().Replace("'", "''") + @"'),
                (14, 'ftp_number_threads', " + txtBoxFTPNumThreads.Text + @")
                ";
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            conf.Clear();
            readConf(sqLiteCon);
            this.Close();
        }

        public static void save()
        {
            using (SQLiteCommand command = new SQLiteCommand(sqLiteCon))
            {
                command.CommandType = CommandType.Text;
                command.CommandText = @"DELETE FROM [conf];
                INSERT INTO [conf] ('id', 'name', 'value')
                VALUES
                (1, 'first_id_goods', '" + conf["first_id_goods"] + @"'),
                (2, 'dollar_rate', '" + conf["dollar_rate"] + @"'),
                (3, 'min_price', '" + conf["min_price"] + @"'),
                (4, 'img_prefix', '" + conf["img_prefix"] + @"'),
                (5, 'img_first_number', '" + conf["img_first_number"] + @"'),
                (6, 'img_max_number', '" + conf["img_max_number"] + @"'),
                (7, 'path_empty_excel', '" + conf["path_empty_excel"] + @"'),
                (8, 'time_out', '" + conf["time_out"] + @"'),
                (9, 'user_agent', '" + conf["user_agent"] + @"'),
                (10, 'ftp_server', '" + conf["ftp_server"] + @"'),
                (11, 'ftp_port', '" + conf["ftp_port"] + @"'),
                (12, 'ftp_user', '" + conf["ftp_user"] + @"'),
                (13, 'ftp_pass', '" + conf["ftp_pass"] + @"'),
                (14, 'ftp_number_threads', " + conf["ftp_number_threads"] + @");
                ";
                command.ExecuteNonQuery();
            }
        }

        private void btnUpdateDollarRate_Click(object sender, EventArgs e)
        {
            
        }

        private void txtBoxFirstIdNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true; // Удаление символа 
        }

        private void txtBoxDollarExchangeRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)
                e.Handled = true; // Удаление символа 
        }

        private void txtBoxImagePrefix_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 65 || (e.KeyChar > 90 && e.KeyChar < 97) || e.KeyChar > 122) && e.KeyChar != 8)
                e.Handled = true; // Удаление всех символов кроме символов латинского алфавита
        }

        private void txtBoxUserAgent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 10 || e.KeyChar == 13)
                e.Handled = true; // Удаление символа перевода строки
        }

        private void btnSelectOutputFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "Книга Excel(*.xls;*.xslx)|*.xls;*.xlsx";
            openFileDlg.InitialDirectory = Environment.CurrentDirectory;

            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                txtBoxPathFile.Text = openFileDlg.FileName;
            }
        }

        private void ConfForm_Load(object sender, EventArgs e)
        {
            setOnForm();
        }
    }
}

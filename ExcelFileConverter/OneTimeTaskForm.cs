using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SQLite;

namespace ExcelFileConverter
{
    public partial class OneTimeTaskForm : Form
    {  
        private static string outputFilePath;

        private static ulong nextIdNumber;
        private static int priceType;
        private static string imagePath;
        private static string imagePrefix;
        private static int nextImageNumber;
        private static string categoryNumber;
        private static string firstProductEnding;
        private static string secondProductEnding;
        private static string insertProductName;
        private static double pricePercent;
        
        private static SQLiteConnection sqLiteCtn;


        public static List<string> listAcceptableSize = new List<string>() { };


        public OneTimeTaskForm(SQLiteConnection connection)
        {
            InitializeComponent();
            cmbPrice.SelectedIndex = 0; // значение выбора цены по умолчанию
            sqLiteCtn = connection;
        }


        private void btnStartConverting_Click(object sender, EventArgs e)
        {
            if (txtBxPathOutputFile.Text.Trim() == "" || txtURL.Text.Trim() == "" || txtBoxPricePercent.Text.Trim() == "" ||
                txtBxNextIdNumber.Text.Trim() == "" || txtBxNextImageNumber.Text.Trim() == "" ||
                txtBxImagePath.Text.Trim() == "" || txtBxImagePrefix.Text.Trim() == "" ||
                txtBxCategoryNumber.Text.Trim() == "" || txtBxInsertProductName.Text.Trim() == "" ||
                (rdBtnStyle.Checked && (txtBxFirstProductEnding.Text.Trim() == "" || txtBxSecondProductEnding.Text.Trim() == "")))
            {
                MessageBox.Show("Не все данные введены");
                return;
            }
            if (numFirstPage.Value > numLastPage.Value || numLastPage.Value < 1 || numFirstPage.Value < 1)
            {
                MessageBox.Show("Введены некорректные значение первой и последней страницы");
                return;
            }

            chckBxSizeAvailable.Enabled = false;
            btnStartConverting.Enabled = false;
            btnSelectOutputFile.Enabled = false;
            txtBxPathOutputFile.Enabled = false;
            txtBoxFTPPath.Enabled = false;
            txtBxNextIdNumber.Enabled = false;
            txtBxCategoryNumber.Enabled = false;
            txtBoxPricePercent.Enabled = false;
            groupBoxSettingsProductName.Enabled = false;
            groupBoxSettingImage.Enabled = false;
            groupBoxSettingsProductCharacteristics.Enabled = false;
            groupBoxInputData.Enabled = false;
            cmbPrice.Enabled = false;

            progressBar1.Value = 0;
            
            nextIdNumber = ulong.Parse(txtBxNextIdNumber.Text);
            imagePath = txtBxImagePath.Text.Trim();
            imagePrefix = txtBxImagePrefix.Text.Trim();
            nextImageNumber = int.Parse(txtBxNextImageNumber.Text);
            categoryNumber = txtBxCategoryNumber.Text.Trim();
            priceType = cmbPrice.SelectedIndex;

            firstProductEnding = txtBxFirstProductEnding.Text.Trim();
            secondProductEnding = txtBxSecondProductEnding.Text.Trim();
            insertProductName = txtBxInsertProductName.Text.Trim();

            if (!double.TryParse(txtBoxPricePercent.Text.Trim(), out pricePercent))
            {
                MessageBox.Show("Введено некорректное значение увеличение цены в процентах");
                return;
            }
            
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            var task = new Task(sqLiteCtn);
            string[] characteristics = new string[lstBxProductCharacteristics.Items.Count];
            int i = 0;
            foreach (var chs in lstBxProductCharacteristics.Items)
            {
                characteristics[i++] = chs.ToString().Trim();
            }
            task.settings(
                null, txtURL.Text.Trim(), (int)numFirstPage.Value, (int)numLastPage.Value, txtBxPathOutputFile.Text,
                nextIdNumber, priceType, double.Parse(ConfForm.conf["dollar_rate"]), pricePercent, chckBxSizeAvailable.Checked,
                txtBxInsertProductName.Text, rdBtnManufacturer.Checked ? 1 : 0, txtBxFirstProductEnding.Text,
                txtBxSecondProductEnding.Text, txtBxImagePath.Text,
                txtBxImagePrefix.Text, ulong.Parse(txtBxNextImageNumber.Text),
                ulong.Parse(txtBoxMaxImageNumber.Text), txtBxCategoryNumber.Text,
                characteristics,
                txtBoxFTPPath.Text.Trim()=="" ? null : "ftp://"+ConfForm.conf["ftp_server"]+":"+ConfForm.conf["ftp_port"]+"/"+txtBoxFTPPath.Text.Trim(),
                backgroundWorker1, 0, (int)(numLastPage.Value - numFirstPage.Value + 1)
                );
            task.perform();
        }


        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            progressBar2.Value = Convert.ToInt32(e.UserState);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            chckBxSizeAvailable.Enabled = true;
            btnStartConverting.Enabled = true;
            btnSelectOutputFile.Enabled = true;
            txtBxPathOutputFile.Enabled = true;
            txtBoxFTPPath.Enabled = true;
            txtBxNextIdNumber.Enabled = true;
            txtBxCategoryNumber.Enabled = true;
            txtBoxPricePercent.Enabled = true;
            groupBoxSettingsProductName.Enabled = true;
            groupBoxSettingImage.Enabled = true;
            groupBoxSettingsProductCharacteristics.Enabled = true;
            groupBoxInputData.Enabled = true;
            cmbPrice.Enabled = true;

            progressBar1.Value = 100;
            progressBar2.Value = 100;

            MessageBox.Show("Парсинг данных успешно завершён.");
        }

        private void txtBxNextIdNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true; // Удаление символа 
        }

        private void txtBxNextImageNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true; // Удаление символа 
        }

        //возвращает номер последней заполненной строки
        public static int LastRowCell(Excel.Application XL, int column)
        {
            try
            {
                int lastrow = XL.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;
                int lastNoNullRow = 0;
                for (int i = lastrow; i >= 1; i--)
                {
                    if (XL.Cells[i, column].Value != null)
                    {
                        lastNoNullRow = i;
                        break;
                    }
                }

                return lastNoNullRow;
            }
            catch
            {
                return 1;
            }
        }

        private static void GenerateProductName(ref string name)
        {
            string[] fields;
            if (name == "Рабочий")
            {
                name = "Рабоч" + secondProductEnding + " " + insertProductName.ToLower();
            }
            else
            {
                fields = name.Split(' ');
                name = "";

                for (int j = 0; j < fields.Length; j++)
                {
                    if (fields[j].Length > 2 && fields[j][fields[j].Length - 1] == 'й' && fields[j][fields[j].Length - 2] == 'ы')
                        name += fields[j].Substring(0, fields[j].Length - 2) + firstProductEnding + " ";
                    else
                        name += fields[j] + " ";
                }
                name += insertProductName.ToLower();
            }
        }


        private void btnSelectOutputFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "Книга Excel(*.xls;*.xslx)|*.xls;*.xlsx";
            openFileDlg.InitialDirectory = Environment.CurrentDirectory;

            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                outputFilePath = openFileDlg.FileName;
                txtBxPathOutputFile.Text = outputFilePath;
            }
        }

        private void ProductNameSourceChanged(object sender, EventArgs e)
        {
            if (rdBtnStyle.Checked)
            {
                label10.Visible = true;
                label9.Visible = true;
                txtBxFirstProductEnding.Visible = true;
                txtBxSecondProductEnding.Visible = true;
            }
            else
            {
                label10.Visible = false;
                label9.Visible = false;
                txtBxFirstProductEnding.Visible = false;
                txtBxSecondProductEnding.Visible = false;
            }
        }

        private void btnRemoveCharacteristic_Click(object sender, EventArgs e)
        {
            lstBxProductCharacteristics.Items.Remove(lstBxProductCharacteristics.SelectedItem);
        }

        private void btnAddCharacteristic_Click(object sender, EventArgs e)
        {
            string characteristicName = txtBxCharacteristicName.Text.Trim();
            if (characteristicName != "" && lstBxProductCharacteristics.FindStringExact(characteristicName) == -1)
            {
                lstBxProductCharacteristics.Items.Add(characteristicName);
            }

            txtBxCharacteristicName.Text = "";
        }

        private void txtBxDollarExchangeRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)
                e.Handled = true; // Удаление символа 
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}

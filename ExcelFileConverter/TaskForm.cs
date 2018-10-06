using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelFileConverter
{
    public partial class TaskForm : Form
    {
        private SQLiteConnection sqLiteCtn;
        private string idTask;

        public TaskForm(SQLiteConnection connection, string idTask = null)
        {
            InitializeComponent();
            this.sqLiteCtn = connection;
            cmbPrice.SelectedIndex = 0; // значение выбора цены по умолчанию
            this.idTask = idTask;
            if (idTask != null) // редактироваине задания
            {
                this.Text = "Редактирование задания";
                btnOk.Text = "Изменить задание";
                setFieldsOnForm();
            }
        }

        private void setFieldsOnForm ()
        {
            using (SQLiteCommand command = new SQLiteCommand(this.sqLiteCtn))
            {
                command.CommandText = "SELECT * FROM [tasks] WHERE id = " + this.idTask + ";";
                command.CommandType = CommandType.Text;
                using (SQLiteDataReader reader = command.ExecuteReader())
                { 
                    reader.Read();
                    txtBoxName.Text = reader["task_name"].ToString();
                    txtURL.Text = reader["link"].ToString();
                    numFirstPage.Value = decimal.Parse(reader["first_page"].ToString());
                    numLastPage.Value = decimal.Parse(reader["last_page"].ToString());

                    rdBtnStyle.Checked = reader["name_source"].ToString() == "0" ? true : false;
                    rdBtnManufacturer.Checked = !rdBtnStyle.Checked;
                    txtBxFirstProductEnding.Text = reader["name_style_first_ending"].ToString();
                    txtBxSecondProductEnding.Text = reader["name_style_second_ending"].ToString();
                    txtBxInsertProductName.Text = reader["name_first_part"].ToString();

                    cmbPrice.SelectedIndex = int.Parse(reader["price"].ToString());
                    txtBoxPricePercent.Text = (float.Parse(reader["additive"].ToString()) * 100).ToString();
                    txtBxCategoryNumber.Text = reader["category_number"].ToString();
                    txtBxImagePath.Text = reader["output_img_path"].ToString();
                    chckBxSizeAvailable.Checked = bool.Parse(reader["is_size"].ToString());
                    txtBoxFTPPath.Text = reader["ftp_path"].ToString();
                }

                command.CommandText = "SELECT * FROM [characteristics] WHERE id = " + this.idTask + ";";
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    foreach (DbDataRecord record in reader)
                    {
                        lstBxProductCharacteristics.Items.Add(record["name"].ToString());
                    }
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtURL.Text.Trim() == "" || txtBoxPricePercent.Text.Trim() == "" || txtBoxName.Text.Trim() == "" ||
            txtBxImagePath.Text.Trim() == "" || txtBxSecondProductEnding.Text.Trim() == "" ||
            txtBxCategoryNumber.Text.Trim() == "" || txtBxInsertProductName.Text.Trim() == "" ||
            (rdBtnStyle.Checked && (txtBxFirstProductEnding.Text.Trim() == "")))
            {
                MessageBox.Show("Не все данные введены");
                return;
            }
            if (numFirstPage.Value > numLastPage.Value || numLastPage.Value < 1 || numFirstPage.Value < 1)
            {
                MessageBox.Show("Введены некорректные значение первой и последней страницы");
                return;
            }
            float pricePercent;
            if (!float.TryParse(txtBoxPricePercent.Text.Trim(), out pricePercent))
            {
                MessageBox.Show("Введено некорректное значение увеличение цены в процентах");
                return;
            }
            using (SQLiteCommand command = new SQLiteCommand(this.sqLiteCtn))
            {
                int source = 0;
                string id;
                if (rdBtnManufacturer.Checked) source = 1; // источник названия производитель
                command.CommandType = CommandType.Text;

                if (idTask == null) //добавление задания
                {
                    command.CommandText = @"
                        INSERT INTO [tasks] ('task_name', 'link',
                            'first_page', 'last_page',
                            'price', 'category_number',
                            'additive', 'is_size',
                            'name_first_part', 'name_source',
                            'name_style_first_ending', 'name_style_second_ending',
                            'output_img_path', 'date',
                            'ftp_path')
                            VALUES('" +
                            txtBoxName.Text.Trim().Replace("'", "''") + "', '" + txtURL.Text.Trim().Replace("'", "''") + @"',
                            " + numFirstPage.Value + ", " + numLastPage.Value + @",
                            " + cmbPrice.SelectedIndex + ", " + txtBxCategoryNumber.Text + @",
                            '" + Math.Round(pricePercent / 100, 4) + "', " + (chckBxSizeAvailable.Checked ? "1" : "0") + @",
                            '" + txtBxInsertProductName.Text.Replace("'", "''") + "', '" + source + @"',
                            '" + txtBxFirstProductEnding.Text.Trim().Replace("'", "''") + "', '" + txtBxSecondProductEnding.Text.Trim().Replace("'", "''") + @"',
                            '" + txtBxImagePath.Text.Trim().Replace("'", "''") + "', datetime('now')" + @",
                            '" + txtBoxFTPPath.Text.Trim().Replace("'", "''") + "');";
                    command.ExecuteNonQuery();
                    command.CommandText = "SELECT last_insert_rowid();";
                    id = command.ExecuteScalar().ToString();
                }
                else // редактирование задания
                {
                    id = idTask;
                    command.CommandText = @"
                        UPDATE [tasks] SET
                          [task_name] = '" + txtBoxName.Text.Trim().Replace("'", "''") + @"',
                          [link] = '" + txtURL.Text.Trim().Replace("'", "''") + @"',
                          [first_page] = " + numFirstPage.Value + @",
                          [last_page] = " + numLastPage.Value + @",
                          [price] = " + cmbPrice.SelectedIndex + @",
                          [category_number] = " + txtBxCategoryNumber.Text + @",
                          [additive] = '" + Math.Round((double)(pricePercent / 100), 4) + @"',
                          [is_size] = " + (chckBxSizeAvailable.Checked ? "1" : "0") + @",
                          [name_first_part] = '" + txtBxInsertProductName.Text.Replace("'", "''") + @"',
                          [name_source] = '" + source + @"',
                          [name_style_first_ending] = '" + txtBxFirstProductEnding.Text.Trim().Replace("'", "''") + @"',
                          [name_style_second_ending] = '" + txtBxSecondProductEnding.Text.Trim().Replace("'", "''") + @"',
                          [output_img_path] = '" + txtBxImagePath.Text.Trim().Replace("'", "''") + @"',
                          [date] = datetime('now'),
                          [ftp_path] = '" + txtBoxFTPPath.Text.Trim().Replace("'", "''") + @"'
                        WHERE id = " + id + ";";
                    command.ExecuteNonQuery();
                    command.CommandText = @"DELETE FROM [characteristics] WHERE id = " + id;
                    command.ExecuteNonQuery();
                }

                if (lstBxProductCharacteristics.Items.Count > 0)
                {
                    command.CommandText = "INSERT INTO [characteristics] ('name', 'id') VALUES";
                    bool isr = false;
                    foreach (var characteristic in lstBxProductCharacteristics.Items)
                    {
                        if (isr) command.CommandText += ",";
                        command.CommandText += "('" + characteristic.ToString().Trim().Replace("'", "''") + "', " + id + ")";
                        isr = true;
                    }
                    command.CommandText += ";";
                    command.ExecuteNonQuery();
                }
            }
            this.Close();
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

        private void btnRemoveCharacteristic_Click(object sender, EventArgs e)
        {
            lstBxProductCharacteristics.Items.Remove(lstBxProductCharacteristics.SelectedItem);
        }

        private void txtBoxPricePercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)
                e.Handled = true; // Удаление символа 
        }

        private void txtBxCategoryNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true; // Удаление символа 
        }
    }
}

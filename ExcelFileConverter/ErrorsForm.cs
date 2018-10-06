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
    public partial class ErrorsForm : Form
    {
        private SQLiteConnection sqLiteCtn;

        public ErrorsForm(SQLiteConnection connection)
        {
            InitializeComponent();
            sqLiteCtn = connection;
            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            using (SQLiteCommand command = new SQLiteCommand(sqLiteCtn))
            {
                command.CommandText = "DELETE FROM [errors];";
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            dataGridView1.Rows.Clear();
        }

        private void ErrorsForm_Load(object sender, EventArgs e)
        {
            using (SQLiteCommand command = new SQLiteCommand(this.sqLiteCtn))
            {
                command.CommandText = "SELECT * FROM [errors];";
                command.CommandType = CommandType.Text;
                SQLiteDataReader reader = command.ExecuteReader();
                foreach (DbDataRecord record in reader)
                {
                    dataGridView1.Rows.Add(
                        record["id"].ToString(), 
                        record["date"].ToString(),
                        record["link"].ToString(),
                        record["error"].ToString()
                    );
                }
            }
        }
    }
}

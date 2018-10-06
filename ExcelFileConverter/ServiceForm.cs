using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelFileConverter
{
    public partial class ServiceForm : Form
    {
        private SQLiteConnection sqLiteCtn;

        public ServiceForm(SQLiteConnection connection)
        {
            InitializeComponent();
            sqLiteCtn = connection;
        }

        private void LinksLoadedForm_Load(object sender, EventArgs e)
        {
            using (SQLiteCommand command = new SQLiteCommand(this.sqLiteCtn))
            {
                command.CommandText = "SELECT COUNT(*) FROM [links_loaded];";
                command.CommandType = CommandType.Text;
                textBox1.Text = command.ExecuteScalar().ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            using (SQLiteCommand command = new SQLiteCommand(this.sqLiteCtn))
            {
                command.CommandText = "DELETE FROM [links_loaded];";
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                textBox1.Text = "0";
            }
        }

        private void btnVacuum_Click(object sender, EventArgs e)
        {
            using (SQLiteCommand command = new SQLiteCommand(this.sqLiteCtn))
            {
                command.CommandText = "VACUUM;";
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            MessageBox.Show("Команда успешно выполена");
        }
    }
}

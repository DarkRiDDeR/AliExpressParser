using System;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ExcelFileConverter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var isFile = false;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string baseName = "parseAliExpress.db3";
            if (!System.IO.File.Exists(baseName))
            {
                SQLiteConnection.CreateFile(baseName);
                isFile = true;
            }

            SQLiteFactory factory = (SQLiteFactory)DbProviderFactories.GetFactory("System.Data.SQLite");
            SQLiteConnection connection;
            using (connection = (SQLiteConnection)factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source = " + baseName + "; Version=3;";
                connection.Open();

                if (isFile)
                {
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                        CREATE TABLE tasks
                        (
                          [id] INTEGER NOT NULL
                                CONSTRAINT Key2 PRIMARY KEY AUTOINCREMENT,
                          [task_name] varchar,
                          [link] varchar NOT NULL,
                          [first_page] INTEGER NOT NULL,
                          [last_page] INTEGER NOT NULL,
                          [price] INTEGER NOT NULL DEFAULT 0,
                          [category_number] INTEGER NOT NULL,
                          [additive] varchar NOT NULL,
                          [is_size] boolean NOT NULL DEFAULT true,
                          [name_first_part] varchar NOT NULL,
                          [name_source] INTEGER NOT NULL DEFAULT 0,
                          [name_style_first_ending] varchar(10),
                          [name_style_second_ending] varchar(10),
                          [output_img_path] varchar(32767) NOT NULL,
                          [ftp_path] varchar,
                          [date] datetime NOT NULL
                        );

                        CREATE TABLE errors
                        (
                          [id_error] INTEGER NOT NULL
                                CONSTRAINT Key1 PRIMARY KEY AUTOINCREMENT,
                          [date] datetime NOT NULL,
                          [link] varchar NOT NULL,
                          [error] varchar NOT NULL,
                          [id] INTEGER,
                          CONSTRAINT Relationship1 FOREIGN KEY ([id]) REFERENCES tasks ([id])
                        );

                        CREATE INDEX IX_Relationship1 ON errors ([id]);

                        CREATE TABLE links_loaded
                        (
                          [id_loaded] INTEGER NOT NULL
                                CONSTRAINT Key3 PRIMARY KEY AUTOINCREMENT,
                          [link] varchar NOT NULL,
                          [id] INTEGER,
                          CONSTRAINT Relationship3 FOREIGN KEY ([id]) REFERENCES tasks ([id])
                        );

                        CREATE INDEX IX_Relationship3 ON links_loaded ([id]);

                        -- Table characteristics

                        CREATE TABLE characteristics
                        (
                          [id_ch] INTEGER NOT NULL
                                CONSTRAINT Key4 PRIMARY KEY AUTOINCREMENT,
                          [name] varchar NOT NULL,
                          [id] INTEGER,
                          CONSTRAINT Relationship2 FOREIGN KEY ([id]) REFERENCES tasks ([id])
                        );

                        CREATE INDEX IX_Relationship2 ON characteristics ([id]);

                        CREATE TABLE conf
                        (
                          [id] INTEGER NOT NULL
                                CONSTRAINT Key5 PRIMARY KEY AUTOINCREMENT,
                          [name] varchar(20) NOT NULL,
                          [value] varchar NOT NULL,
                          CONSTRAINT [name] UNIQUE ([name])
                        );

                        INSERT INTO [conf] ('name', 'value')
                        VALUES
                        ('first_id_goods', '1'),
                        ('dollar_rate', '65,5'),
                        ('min_price', '0'),
                        ('img_prefix', 'a'),
                        ('img_first_number', '1'),
                        ('img_max_number', '10000000'),
                        ('path_empty_excel', ''),
                        ('time_out', '20'),
                        ('user_agent', 'Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)'),
                        ('ftp_server', ''),
                        ('ftp_port', '21'),
                        ('ftp_user', ''),
                        ('ftp_pass', ''),
                        ('ftp_number_threads', 1);";
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                    }
                }
                ConfForm.readConf(connection);
                Application.Run(new MainForm(connection));
            }
        }
    }
}

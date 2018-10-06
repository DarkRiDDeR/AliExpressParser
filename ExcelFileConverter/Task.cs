using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelFileConverter
{
    class Task
    {
        private SQLiteConnection sqLiteCtn;
        private string idTask;

        //объекты для результирующего excel-файла
        private Excel.Application appOutputFile;
        private Excel.Workbook bookOutputFile;
        private Excel.Worksheet sheetProductsOutputFile;
        private Excel.Worksheet sheetAdditionalImagesOutputFile;
        private Excel.Worksheet sheetProductOptionsOutputFile;
        private Excel.Worksheet sheetProductOptionValuesOutputFile;
        private Excel.Worksheet sheetProductAttributesOutputFile;

        private int lastRow;
        private int lastrowSheetProductsOutputFile;
        private int lastrowSheetAdditionalImagesOutputFile;
        private int lastrowSheetProductOptionsOutputFile;
        private int lastrowSheetProductOptionValuesOutputFile;
        private int lastrowSheetProductAttributesOutputFile;

        private static ParseAliExpress parseAliExpress;
        private string url;
        private int numFirstPage;
        private int numLastPage;

        private ulong nextIdNumber;
        private string outputFilePath;
        private string categoryNumber;
        private double dollarExchangeRate;
        private double pricePercent;
        private int priceType;
        private bool isSize;

        private string imagePath;
        private string imagePrefix;
        private ulong nextImageNumber;
        private ulong maxImageNumber;

        private int nameSource;
        private string firstProductEnding;
        private string secondProductEnding;
        private string insertProductName;

        private string[] characteristics;
        private string ftpPath;
        private static int ftpCount = 0;
        private Object thisLock = new Object();
        private static CountdownEvent finishedFTPThread;
        private static NetworkCredential ftpCredential;

        private static BackgroundWorker bgWorker;
        private static double startProgress;
        private static int pageCount;
        private static int taskProgress;
        private static int ftpProgress;
        private static bool ftpBreak = false;


        public Task(SQLiteConnection connection)
        {
            this.sqLiteCtn = connection;
            ftpProgress = 0;
    }

        public void settings(
            string _idTask, string _url, int _numFirstPage, int _numLastPage, string _outputFilePath,
            ulong _nextIdNumber, int _priceType, double _dollarExchangeRate, double _pricePercent, bool _isSize,
            string _insertProductName, int _nameSource, string _firstProductEnding, string _secondProductEnding,
            string _imagePath, string _imagePrefix, ulong _nextImageNumber, ulong _maxImageNumber, string _categoryNumber,
            string[] _characteristics, string _ftpPath,
            BackgroundWorker _bgWorker, double _startProgress, int _pageCount
            )
        {
            idTask = _idTask;
            url = _url;
            outputFilePath = _outputFilePath;
            numFirstPage = _numFirstPage;
            numLastPage = _numLastPage;

            nextIdNumber = _nextIdNumber;
            priceType = _priceType;
            isSize = _isSize;
            imagePath = _imagePath;
            imagePrefix = _imagePrefix;
            nextImageNumber = _nextImageNumber;
            maxImageNumber = _maxImageNumber;

            nameSource = _nameSource;
            categoryNumber = _categoryNumber;
            firstProductEnding = _firstProductEnding;
            secondProductEnding = _secondProductEnding;
            insertProductName = _insertProductName;
            dollarExchangeRate = _dollarExchangeRate;
            pricePercent = _pricePercent;

            characteristics = _characteristics;
            ftpPath = _ftpPath;

            bgWorker = _bgWorker;
            startProgress = _startProgress;
            pageCount = _pageCount;
        }

        public void perform ()
        {
            List<string> productUrls = new List<string>();
            int productUrlsCount = 0;
            using (SQLiteCommand command = new SQLiteCommand(sqLiteCtn))
            {
                command.CommandText = "SELECT * FROM [links_loaded];";
                command.CommandType = CommandType.Text;
                using (SQLiteDataReader reader = command.ExecuteReader())
                    foreach (DbDataRecord record in reader)
                    {
                        productUrls.Add(record["link"].ToString());
                        productUrlsCount++;
                    }
            }
            
            appOutputFile = new Excel.Application();
            appOutputFile.Workbooks.Open(outputFilePath);
            bookOutputFile = appOutputFile.ActiveWorkbook;

            sheetProductsOutputFile = (Excel.Worksheet)bookOutputFile.Sheets["Products"];
            sheetAdditionalImagesOutputFile = (Excel.Worksheet)bookOutputFile.Sheets["AdditionalImages"];
            sheetProductOptionsOutputFile = (Excel.Worksheet)bookOutputFile.Sheets["ProductOptions"];
            sheetProductOptionValuesOutputFile = (Excel.Worksheet)bookOutputFile.Sheets["ProductOptionValues"];
            sheetProductAttributesOutputFile = (Excel.Worksheet)bookOutputFile.Sheets["ProductAttributes"];

            sheetProductsOutputFile.Activate();
            lastrowSheetProductsOutputFile = LastRowCell(appOutputFile, 1);

            sheetAdditionalImagesOutputFile.Activate();
            lastrowSheetAdditionalImagesOutputFile = LastRowCell(appOutputFile, 1);

            sheetProductOptionsOutputFile.Activate();
            lastrowSheetProductOptionsOutputFile = LastRowCell(appOutputFile, 1);

            sheetProductOptionValuesOutputFile.Activate();
            lastrowSheetProductOptionValuesOutputFile = LastRowCell(appOutputFile, 1);

            sheetProductAttributesOutputFile.Activate();
            lastrowSheetProductAttributesOutputFile = LastRowCell(appOutputFile, 1);

            DirectoryInfo dir = dir = Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath).CreateSubdirectory("images");
            Environment.CurrentDirectory = dir.FullName;

            ulong id;
            string name = "";
            double price = 0;
            string productUrl = "";
            bool isFTP = false;
            ftpCount = 0;

             (sheetProductsOutputFile.Cells[1, 16] as Excel.Range).EntireColumn.NumberFormat = "######0.00";
            (sheetProductsOutputFile.Cells[1, 18] as Excel.Range).EntireColumn.NumberFormat = "@";
            (sheetProductsOutputFile.Cells[1, 19] as Excel.Range).EntireColumn.NumberFormat = "@";
            (sheetProductsOutputFile.Cells[1, 20] as Excel.Range).EntireColumn.NumberFormat = "@";
            (sheetProductsOutputFile.Cells[1, 21] as Excel.Range).EntireColumn.NumberFormat = "######0.00";
            (sheetProductsOutputFile.Cells[1, 27] as Excel.Range).EntireColumn.NumberFormat = "@";
            (sheetProductsOutputFile.Cells[1, 36] as Excel.Range).EntireColumn.NumberFormat = "@";
            (sheetProductsOutputFile.Cells[1, 40] as Excel.Range).EntireColumn.NumberFormat = "@";


            (sheetProductOptionsOutputFile.Cells[1, 4] as Excel.Range).EntireColumn.NumberFormat = "@";

            (sheetProductOptionValuesOutputFile.Cells[1, 5] as Excel.Range).EntireColumn.NumberFormat = "@";
            (sheetProductOptionValuesOutputFile.Cells[1, 6] as Excel.Range).EntireColumn.NumberFormat = "######0.00";
            (sheetProductOptionValuesOutputFile.Cells[1, 10] as Excel.Range).EntireColumn.NumberFormat = "######0.00";
            
            string imageName = "";

            try
            {
                int sleep = int.Parse(ConfForm.conf["time_out"]);
                parseAliExpress = new ParseAliExpress();
                parseAliExpress.userAgent = ConfForm.conf["user_agent"];
                parseAliExpress.open(url, numFirstPage, numLastPage); // открываем парсер для работы с сайтом

                lastRow = parseAliExpress.getNumberOnPage() * (numLastPage - numFirstPage + 1);
                Goods item;
                //FTP
                if (ftpPath != "" && ftpPath != null)
                {
                    ftpPath = Regex.Replace(ftpPath, "/+?$", "") + "/";
                    ftpCredential = new NetworkCredential(ConfForm.conf["ftp_user"], ConfForm.conf["ftp_pass"]);
                    int maxTreads = int.Parse(ConfForm.conf["ftp_number_threads"]);
                    isFTP = true;
                    int workerThreads, completionPortThreads;
                    ThreadPool.GetMaxThreads(out workerThreads, out completionPortThreads);
                    if (maxTreads < workerThreads)
                    {
                        workerThreads = maxTreads;
                    }
                    ThreadPool.SetMaxThreads(workerThreads, completionPortThreads);
                    finishedFTPThread = new CountdownEvent(1);
                }
                double minPrice = double.Parse(ConfForm.conf["min_price"]);

                for (int i = 0; i < lastRow; ++i)
                {
                    item = parseAliExpress.getNext(); // получаем данные о следующем товаре
                    if (item == null)
                        continue;
                    productUrl = item.url;

                    if (!productUrls.Contains(productUrl))
                    {
                        if (item.bigImages.Length > 0)
                        {
                            imageName = parseAliExpress.getImage(item.bigImages[0], nextImageNumber, imagePrefix);
                            if (isFTP) // загружает на сервер через FTP
                            {
                                if (ftpBreak) break;
                                finishedFTPThread.AddCount();
                                ThreadPool.QueueUserWorkItem(new WaitCallback(ftpUpLoad), imageName);
                            }
                            if (maxImageNumber == nextImageNumber)
                            {
                                imagePrefix = (++imagePrefix.ToCharArray()[0]) + imagePrefix.Substring(1);
                                nextImageNumber = 1;
                            }
                            else
                                nextImageNumber++;
                        }

                        #region Products
                        id = nextIdNumber++;
                        lastrowSheetProductsOutputFile++;

                        string manufacturer = "";
                        if (item.propertis.ContainsKey("производитель"))
                            manufacturer = " " + item.propertis["производитель"];

                        if (nameSource == 0)
                        {
                            if (item.propertis.ContainsKey("стиль")) name = item.propertis["стиль"];
                            if (name == "") GenerateProductName(ref name);

                        }
                        if (name == "") name = (insertProductName + manufacturer).Trim();

                        TwoPrice twoPrice = item.price;
                        if (item.discount_price != null && item.discount_price.min != -1) // берём за основную цену, которая со скидкой
                            twoPrice = item.discount_price;

                        if (priceType == 1 && twoPrice.max != -1) // цена средняя
                            price = (twoPrice.min + twoPrice.max) / 2;
                        else if (priceType == 2 && twoPrice.max != -1) // максимальная
                            price = twoPrice.max;
                        else // минимальная
                            price = twoPrice.min;

                        price = price + price * (pricePercent / 100); // увеличение цены по проценту
                        if (price < minPrice) price = minPrice;
                        if (dollarExchangeRate != 0)
                            price = Math.Round(price / dollarExchangeRate, 2);
                        price = Math.Round(price, 2);

                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 1] = id;
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 2] = name;
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 3] = categoryNumber;
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 11] = "1";
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 12] = name;
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 14] = imagePath + imageName;

                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 15] = "yes";
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 16] = price;
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 17] = "0";
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 18] = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 19] = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 20] = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 21] = "1";
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 22] = "kg";
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 23] = "0";
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 24] = "0";
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 25] = "0";
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 26] = "cm";
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 27] = "true";
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 28] = "0";
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 30] = productUrl;
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 31] = name;
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 34] = "6";
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 35] = "0";
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 36] = "0:";
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 38] = name;
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 39] = "1";
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 40] = "false";
                        sheetProductsOutputFile.Cells[lastrowSheetProductsOutputFile, 41] = "1";
                        #endregion

                        #region AdditionalImages
                        int max = item.bigImages.Length;
                        for (int j = 1; j < max; ++j)
                        {
                            lastrowSheetAdditionalImagesOutputFile++;
                            sheetAdditionalImagesOutputFile.Cells[lastrowSheetAdditionalImagesOutputFile, 1] = id;
                            sheetAdditionalImagesOutputFile.Cells[lastrowSheetAdditionalImagesOutputFile, 2] = item.bigImages[j];
                            sheetAdditionalImagesOutputFile.Cells[lastrowSheetAdditionalImagesOutputFile, 3] = "0";
                        }
                        #endregion

                        #region ProductOptions and ProductOptionValues
                        // ProductOptions
                        lastrowSheetProductOptionsOutputFile++;
                        sheetProductOptionsOutputFile.Cells[lastrowSheetProductOptionsOutputFile, 1] = id;
                        sheetProductOptionsOutputFile.Cells[lastrowSheetProductOptionsOutputFile, 2] = "Цвет";
                        sheetProductOptionsOutputFile.Cells[lastrowSheetProductOptionsOutputFile, 4] = "true";

                        if (isSize && item.mainPropertis.ContainsKey("размер"))
                        {
                            lastrowSheetProductOptionsOutputFile++;
                            sheetProductOptionsOutputFile.Cells[lastrowSheetProductOptionsOutputFile, 1] = id;
                            sheetProductOptionsOutputFile.Cells[lastrowSheetProductOptionsOutputFile, 2] = "Размер";
                            sheetProductOptionsOutputFile.Cells[lastrowSheetProductOptionsOutputFile, 4] = "true";

                            // ProductOptionValues
                            // foreach(var value in item.mainPropertis["размер"])
                            // {
                            lastrowSheetProductOptionValuesOutputFile++;
                            sheetProductOptionValuesOutputFile.Cells[lastrowSheetProductOptionValuesOutputFile, 1] = id;
                            sheetProductOptionValuesOutputFile.Cells[lastrowSheetProductOptionValuesOutputFile, 2] = "Размер";
                            sheetProductOptionValuesOutputFile.Cells[lastrowSheetProductOptionValuesOutputFile, 3] = "L";// value;
                            sheetProductOptionValuesOutputFile.Cells[lastrowSheetProductOptionValuesOutputFile, 4] = "500";
                            sheetProductOptionValuesOutputFile.Cells[lastrowSheetProductOptionValuesOutputFile, 5] = "true";
                            sheetProductOptionValuesOutputFile.Cells[lastrowSheetProductOptionValuesOutputFile, 6] = "0";
                            sheetProductOptionValuesOutputFile.Cells[lastrowSheetProductOptionValuesOutputFile, 7] = "+";
                            sheetProductOptionValuesOutputFile.Cells[lastrowSheetProductOptionValuesOutputFile, 8] = "0";
                            sheetProductOptionValuesOutputFile.Cells[lastrowSheetProductOptionValuesOutputFile, 9] = "+";
                            sheetProductOptionValuesOutputFile.Cells[lastrowSheetProductOptionValuesOutputFile, 10] = "0";
                            sheetProductOptionValuesOutputFile.Cells[lastrowSheetProductOptionValuesOutputFile, 11] = "+";
                            // }
                        }
                        #endregion

                        #region ProductAttributes
                        string prName;
                        foreach (var characteristic in characteristics)
                        {
                            prName = characteristic.ToLower();
                            if (item.propertis.ContainsKey(prName))
                            {
                                lastrowSheetProductAttributesOutputFile++;
                                sheetProductAttributesOutputFile.Cells[lastrowSheetProductAttributesOutputFile, 1] = id;
                                sheetProductAttributesOutputFile.Cells[lastrowSheetProductAttributesOutputFile, 2] = "Характеристики";
                                sheetProductAttributesOutputFile.Cells[lastrowSheetProductAttributesOutputFile, 3] = characteristic.ToString();
                                sheetProductAttributesOutputFile.Cells[lastrowSheetProductAttributesOutputFile, 4] = item.propertis[prName];
                            }
                            else if (item.mainPropertis.ContainsKey(prName))
                            {
                                lastrowSheetProductAttributesOutputFile++;
                                sheetProductAttributesOutputFile.Cells[lastrowSheetProductAttributesOutputFile, 1] = id;
                                sheetProductAttributesOutputFile.Cells[lastrowSheetProductAttributesOutputFile, 2] = "Характеристики";
                                sheetProductAttributesOutputFile.Cells[lastrowSheetProductAttributesOutputFile, 3] = characteristic.ToString();
                                sheetProductAttributesOutputFile.Cells[lastrowSheetProductAttributesOutputFile, 4] = item.listToStr(item.mainPropertis[prName]);
                            }
                        }
                        #endregion

                        productUrls.Add(productUrl);
                    }
                    taskProgress = (int)((startProgress + (double)i / pageCount / parseAliExpress.getNumberOnPage()) * 100);
                    bgWorker.ReportProgress(taskProgress, ftpProgress);
                    Thread.Sleep(sleep);
                }
            }
            catch (Exception e)
            {
                using (SQLiteCommand command = new SQLiteCommand(sqLiteCtn))
                {
                    command.CommandText = @"INSERT INTO [errors] ('id', 'link', 'error', 'date')
                        VALUES (" + 
                        (idTask == null ? "NULL" : "'"+idTask+"'") + @",
                        '" + url.Replace("'", "''") + @"',
                        '" + e.ToString().Replace("'", "''") + @"', 
                        datetime('now'));";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                //MessageBox.Show("Ошибка: " + eMes.ToString(), "Ошибка парсинга", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #region Сохранение ссылок загруженных страниц
            using (SQLiteCommand command = new SQLiteCommand(sqLiteCtn))
            {
                command.CommandType = CommandType.Text;
                for (int i = productUrlsCount; i < productUrls.Count; ++i)
                {
                    command.CommandText = @"INSERT INTO [links_loaded] ('link')
                        VALUES ('" + productUrls[i] + "')";
                    command.ExecuteNonQuery();
                }
            }
            #endregion

            #region Сохранение файла
            object misValue = Type.Missing;
            appOutputFile.DisplayAlerts = false;

            //сохраняем файл
            bookOutputFile.SaveAs(outputFilePath, Excel.XlFileFormat.xlOpenXMLWorkbook,
                                        misValue, misValue, false, false, Excel.XlSaveAsAccessMode.xlNoChange,
                                        Excel.XlSaveConflictResolution.xlUserResolution, true, misValue, misValue, misValue);
            //освобождаем ресурсы
            bookOutputFile.Close(true, misValue, misValue);
            appOutputFile.Quit();

            Marshal.FinalReleaseComObject(sheetProductsOutputFile);
            Marshal.FinalReleaseComObject(sheetAdditionalImagesOutputFile);
            Marshal.FinalReleaseComObject(sheetProductOptionsOutputFile);
            Marshal.FinalReleaseComObject(sheetProductOptionValuesOutputFile);
            Marshal.FinalReleaseComObject(sheetProductAttributesOutputFile);
            Marshal.FinalReleaseComObject(bookOutputFile);
            Marshal.FinalReleaseComObject(appOutputFile);
            #endregion

            // завершение загрузки через FTP
            if (isFTP)
            {
                finishedFTPThread.Signal();
                finishedFTPThread.Wait();
            }
            parseAliExpress.close(); // закрываем соединение. Сброс данных
        }

        private void ftpUpLoad(object imageName)
        {
            try
            {
                string name = imageName.ToString();
                var ftpClien = new WebClient();
                ftpClien.Credentials = ftpCredential;
                ftpClien.UploadFile(ftpPath + name, "STOR", name);
                File.Delete(name);
                lock (thisLock)
                {
                    ftpProgress = (int)((startProgress + (double)ftpCount / pageCount / parseAliExpress.getNumberOnPage()) * 100);
                    ftpCount++;
                    bgWorker.ReportProgress(taskProgress, ftpProgress);
                }
            }
            catch (Exception e)
            {
                lock (thisLock)
                {
                    ftpBreak = true;
                    MessageBox.Show(e.ToString(), "Ошибка FTP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                finishedFTPThread.Signal();
            }
        }

        public ulong getNextIdNumber()
        {
            return nextIdNumber;
        }
        public string getImagePrefix()
        {
            return imagePrefix;
        }
        public ulong getNextImageNumber()
        {
            return nextImageNumber;
        }

        //возвращает номер последней заполненной строки
        protected int LastRowCell(Excel.Application XL, int column)
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

        private void GenerateProductName(ref string name)
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
    }
}

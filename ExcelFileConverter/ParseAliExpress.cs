using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace ExcelFileConverter
{
    class ParseAliExpress
    {
        protected string url = null;
        protected string urlParams = null;
        public string userAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
        protected int firstPage = 1;
        protected int lastPage = 1;
        protected int numberOnPage; // кол-во товаров на странице
        protected bool isFirstLoadPage = true;
        protected string textPage = null; // код страницы с товаром
        protected List<string> itemsURL; // список адресов товаров
        protected int index = -1;
        protected int itemNumber = -1;
        protected int pageNumber;


        public bool open(string url, int firstPage, int lastPage)
        {
            this.url = parseURL(url, ref this.urlParams);
            this.firstPage = this.pageNumber = firstPage;
            this.lastPage = lastPage;
            if (isFirstLoadPage)
            {
                string page = getPage(this.url + this.firstPage + ".html" + this.urlParams);
                if (page == null) return false;
                itemsURL = parsePageItems(page);
                this.numberOnPage = itemsURL.Count;
                this.isFirstLoadPage = false;
            }
            return true;
        }


        protected string parseURL(string url, ref string urlParams)
        {
            url = Regex.Replace(url, "^https?://", "", RegexOptions.IgnoreCase);
            string[] ar = url.Split(new char[] { '?' }, 2);
            url = ar[0];
            if (ar.Length > 1)
                urlParams = "?" + ar[1].Replace("&amp;", "&");
            url = Regex.Replace(url, "((\\.html)|/)$", "", RegexOptions.IgnoreCase) + "/";
            return "http://" + url;
        }

        public Goods getNext()
        {
            ++this.index;
            this.textPage = null;
            this.pageNumber = this.index / this.numberOnPage + 1;
            if ((itemNumber + 1) == this.numberOnPage && !isFirstLoadPage)
            {
                string page = getPage(this.url + this.pageNumber + ".html" + this.urlParams);
                if (page == null) return null;
                itemsURL = parsePageItems(page);
                this.itemNumber = -1;
            }
            ++this.itemNumber;
            this.textPage = getPage(itemsURL[itemNumber]);
            if (this.textPage == null) return null;
            return parsePageItem(textPage, itemsURL[itemNumber]);
        }

        public int getIndex()
        {
            return this.index;
        }
        public int getNumberOnPage()
        {
            return this.numberOnPage;
        }
        public int getItemNumber()
        {
            return this.itemNumber;
        }
        public int getPageNumber()
        {
            return this.pageNumber;
        }
        public string getTextPage()
        {
            return this.textPage;
        }

        // парсинг страницы с товарами
        protected List<string> parsePageItems(string Text)
        {
            var itemsURL = new List<string>();
            var parser = new HtmlParser();
            var document = parser.Parse(Text);
            var ul = document.GetElementById("list-items"); //ul с товарами
            var items = ul.GetElementsByTagName("li");
            foreach (var item in items) // парсим товары
            {
                var h3 = item.GetElementsByTagName("h3")[0];
                var a = h3.GetElementsByTagName("a")[0];
                itemsURL.Add("http:" + a.GetAttribute("href").Split('?')[0]);
            }
            return itemsURL;
        }

        // парсинг страницы с товаром
        protected Goods parsePageItem(string Text, string url)
        {
            //string[] bigImages;
            var goods = new Goods();
            goods.url = url;

            // ссылки на изображения
            Match mImagesURL = Regex.Match(Text, "imageBigViewURL=\\[(.*?)\\]", RegexOptions.Singleline);
            if (mImagesURL.Groups.Count > 0)
            {
                goods.bigImages = mImagesURL.Groups[1].Value.Replace("\"", "").Split(',');
                int i = 0;
                foreach (var img in goods.bigImages)
                {
                    goods.bigImages[i++] = img.Trim();
                }
            }

            // парсим
            var parser = new HtmlParser();
            var document = parser.Parse(Text);
            var detail = document.GetElementById("j-product-detail-bd");
            if (detail == null)
                return null;
            goods.name = detail.QuerySelector("h1.product-name").TextContent; // название
            string str_price = document.GetElementById("j-sku-price").TextContent;
            var discount_price = document.GetElementById("j-sku-discount-price");
            goods.price = strToPrice(str_price); // цена
            if (discount_price != null)
                goods.discount_price = strToPrice(discount_price.TextContent); // цена со скидкой

            var product_info_sku = document.GetElementById("j-product-info-sku"); // блок с основной инфой: размер, цвет и прочее
            var sku_items = product_info_sku.QuerySelectorAll("dl");
            foreach (var item in sku_items) // основные свойства
            {
                string item_title = item.QuerySelector("dt").TextContent.Trim().Replace(":", "").Trim().ToLower();
                var li_values = item.QuerySelectorAll("dd ul li");
                List<string> prValues = new List<string>();
                foreach (var value in li_values)
                {
                    var selA = value.QuerySelector("a");
                    if (selA != null)
                    {
                        var selImg = selA.QuerySelector("img");
                        if (selImg != null)
                        {
                            prValues.Add(selImg.GetAttribute("title"));
                        }
                        else
                        {
                            var attr = selA.GetAttribute("title");
                            if (attr != null) prValues.Add(attr);
                            else prValues.Add(value.TextContent);
                        }
                    }
                    else
                    {
                        prValues.Add(value.TextContent);
                    }
                }
                goods.mainPropertis.Add(item_title, prValues);
            }

            var product_desc = document.GetElementById("j-product-desc"); // блок с характеристиками товара
            var property_list = product_desc.QuerySelector("ul.product-property-list");
            var li_propertis = property_list.GetElementsByTagName("li"); // свойства товаров
            string title;
            foreach (var li_property in li_propertis)
            {
                title = li_property.QuerySelector("span.propery-title").TextContent.Replace(":", "").Trim().ToLower();
                if (!goods.propertis.ContainsKey(title))
                {
                    goods.propertis.Add(title, li_property.QuerySelector("span.propery-des").TextContent);
                }
            }
            return goods;
        }

        public string getPage(string url)
        {
            string text = "";
            /*try
            {*/
                WebClient client = new WebClient();
                client.Encoding = Encoding.GetEncoding("utf-8");
                client.Headers.Add("user-agent", this.userAgent);
                text = client.DownloadString(url);
           /* }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка загрузки страницы. " + e.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }*/
            return text;
        }

        public string getImage(string imageUrl, ulong nextImageNumber, string imagePrefix)
        {
            string extention;
            string imageName = "";
            
            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent", this.userAgent);

            if (imageUrl.LastIndexOf('.') == -1)
                return "";

            extention = imageUrl.Substring(imageUrl.LastIndexOf('.'));
            imageName = imagePrefix + nextImageNumber + extention;

            /*try
            {*/
                Regex rgx = new Regex("[/*:?\"<>|]");
                imageName = rgx.Replace(imageName, "-").Replace("\\", "-");
                webClient.DownloadFile(imageUrl, imageName);
           /* }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка загрузки картинки. " + e.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }*/
            return imageName;
        }

        public TwoPrice strToPrice(string price)
        {
            var twoPrice = new TwoPrice();
            if (price == null)
                return twoPrice;
            price = price.Replace(" ", "");
            var ar = price.Split('-');
            twoPrice.min = Convert.ToSingle(ar[0]);
            if (ar.Length == 2)
                twoPrice.max = Convert.ToSingle(ar[1]);
            return twoPrice;
        }

        public void close()
        {
            url = null;
            firstPage = 1;
            lastPage = 1;
            numberOnPage = 0;
            isFirstLoadPage = true;
            textPage = null;
            itemsURL = null;
            index = -1;
            itemNumber = -1;
            pageNumber = 0;
        }
    }



    /// <summary>
    /// Класс описания товара
    /// </summary>
    class Goods
    {
        public string name = "";
        public string url = "";
        public TwoPrice price = null;
        public TwoPrice discount_price = null;
        public Dictionary<string, List<string>> mainPropertis = new Dictionary<string, List<string>>();
        public Dictionary<string, string> propertis = new Dictionary<string, string>();
        public string[] bigImages = null;

        public string listToStr(List<string> list)
        {
            string result = "";
            foreach (var value in list)
            {
                if (result != "") result += ", ";
                result += value;
            }
            return result;
        }
    }

    /// <summary>
    /// Класс описания цены минимальной и максимальной
    /// </summary>
    class TwoPrice
    {
        float[] array;
        public TwoPrice()
        {
            array = new float[2] { -1, -1 };
        }
        /// <summary>
        /// -1 - цена не установлена
        /// </summary>
        public float this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                array[index] = value;
            }
        }
        /// <summary>
        /// -1 - цена не установлена
        /// </summary>
        public float min
        {
            get
            {
                return array[0];
            }
            set
            {
                array[0] = value;
            }
        }
        /// <summary>
        /// -1 - цена не установлена
        /// </summary>
        public float max
        {
            get
            {
                return array[1];
            }
            set
            {
                array[1] = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CsvHelper;

namespace HelloworkPDFTool
{
    public class Settings
    {
        public List<HWField> hwFields;

        private string appDataPath;
        private string configFolderPath;
        private string configPath;

        /// <summary>
        /// Initialization
        /// </summary>
        public Settings()
        {
            hwFields = new List<HWField>();
            appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            configFolderPath = Path.Combine(appDataPath, "RisingFood","HelloworkPDFTool"); ;
            configPath = Path.Combine(configFolderPath, "config.xml");
        }

        /// <summary>
        /// Load settings from Application Data
        /// </summary>
        public bool LoadSettings()
        {
            if(File.Exists(configPath))
            {
                hwFields.Clear();

                //Load Settings
                XmlDocument xml = new XmlDocument();
                xml.Load(configPath);
                var nodes = xml.SelectNodes("/settings/fields/item");

                if (nodes != null)
                {
                    foreach(XmlNode node in nodes)
                    {
                        //add empty HWField
                        HWField hwField = new HWField();

                        XmlNode readNode = node.SelectSingleNode("name");
                        if (readNode != null)
                        {
                            hwField.name = readNode.InnerText;
                        }

                        readNode = node.SelectSingleNode("page");
                        if (readNode != null)
                        {
                            hwField.pageNumber = int.Parse(readNode.InnerText);
                        }

                        readNode = node.SelectSingleNode("x");
                        if (readNode != null)
                        {
                            hwField.rect.X = int.Parse(readNode.InnerText);
                        }

                        readNode = node.SelectSingleNode("y");
                        if (readNode != null)
                        {
                            hwField.rect.Y = int.Parse(readNode.InnerText);
                        }

                        readNode = node.SelectSingleNode("w");
                        if (readNode != null)
                        {
                            hwField.rect.Width = int.Parse(readNode.InnerText);
                        }

                        readNode = node.SelectSingleNode("h");
                        if (readNode != null)
                        {
                            hwField.rect.Height = int.Parse(readNode.InnerText);
                        }

                        //Add an item to HWFields
                        hwFields.Add(hwField);
                    }
                }    
            }
            else
            {
                //Save an XML with default settings
                LoadFactorySettings();
                SaveSettings();
            }

            return true;
        }

        /// <summary>
        /// Save settings to binary Application Data
        /// </summary>
        public bool SaveSettings()
        {
            if(!Directory.Exists(configFolderPath))
            {
                //Create new directory
                Directory.CreateDirectory(configFolderPath);
            }

            XmlWriterSettings xws = new XmlWriterSettings { Indent = true};

            using (var xw = XmlWriter.Create(configPath,xws))
            {
                xw.WriteStartDocument();
                xw.WriteStartElement("settings");

                xw.WriteStartElement("fields");

                //Write HWFields
                foreach(HWField hwField in hwFields)
                {
                    xw.WriteStartElement("item");
                    xw.WriteElementString("name", hwField.name);
                    xw.WriteElementString("page", hwField.pageNumber.ToString());
                    xw.WriteElementString("x", hwField.rect.X.ToString());
                    xw.WriteElementString("y", hwField.rect.Y.ToString());
                    xw.WriteElementString("w", hwField.rect.Width.ToString());
                    xw.WriteElementString("h", hwField.rect.Height.ToString());
                    xw.WriteEndElement();
                }

                xw.WriteEndElement();

                xw.WriteEndElement();

                xw.WriteEndDocument();
            }
            
            return true;
        }

        /// <summary>
        /// Load settings from Application Data
        /// </summary>
        public void LoadFactorySettings()
        {
            hwFields.Clear();
            hwFields.Add(new HWField("職種",new Rectangle(30, 250, 260, 30), 0));
            hwFields.Add(new HWField("仕事内容", new Rectangle(30, 270, 260, 120), 0));
            hwFields.Add(new HWField("求人番号", new Rectangle(0, 50, 200, 10), 0));
            hwFields.Add(new HWField("受付年月日", new Rectangle(300, 0, 100, 40), 0));
            hwFields.Add(new HWField("紹介期限日", new Rectangle(450, 0, 100, 40), 0));
        }
        public void ApplySettings(List<HWField> hwfs)
        {
            hwFields.Clear();

            foreach (HWField hwf in hwfs)
            {
                hwFields.Add(new HWField(hwf.name, hwf.rect, hwf.pageNumber));

            }

            SaveSettings();
        }
    }
    public class HWField
    {
        public string name;
        public int pageNumber;
        public Rectangle rect;
        
        /// <summary>
        /// Initialization
        /// </summary>
        public HWField()
        {
            rect = new Rectangle(0,0,0,0);
        }
        public HWField(string s, Rectangle r,int p)
        {
            name = s;
            rect = r;
            pageNumber = p;
        }
    }
}

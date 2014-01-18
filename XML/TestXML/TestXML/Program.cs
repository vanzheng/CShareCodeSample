using System;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.IO;
using System.Text;

namespace TestXML
{
    class Program
    {
        static void Main(string[] args)
        {
            XMLCURD();
            //TestXmlTransform();
            OutputHtmlTransform();
            TestXPathNavigator();
            TestXmlReader();
            Console.ReadKey();
        }

        public static void OutputHtmlTransform() 
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string xmlFile = path + "CityData.xml";
            string xsltFile = path + "CityData.xslt";
            xslt.Load(xsltFile);
            StringWriter writer = new StringWriter();
            xslt.Transform(xmlFile, null, writer);
            Console.WriteLine(writer.ToString());
        }

        public static void TestXmlReader() 
        {
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string xmlFile = path + "CityData.xml";
            using (XmlReader reader = XmlReader.Create(xmlFile))
            {
                reader.MoveToContent();
                int i = 0;
                while (reader.Read()) 
                {
                    i++;
                    switch (reader.NodeType) 
                    {
                        case XmlNodeType.Element:
                            Console.WriteLine(i + ". " + reader.Name);
                            if (reader.HasAttributes)
                            {
                                Console.Write("attributes: ");
                                while (reader.MoveToNextAttribute())
                                {
                                    Console.Write(reader.Name + "=" + reader.Value + "  ");
                                }
                            }
                            break;
                    }
                }
            }
            
        }

        public static void TestXPathNavigator() 
        {
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string xmlFile = path + "CityData.xml";
            XPathDocument doc = new XPathDocument(xmlFile);
            XPathNavigator navigator = doc.CreateNavigator();
            XPathNodeIterator nodes = navigator.Select("root/province/city");

            Console.WriteLine("===========================Start Navigator============================");
            int i = 0;
            
            while(nodes.MoveNext())
            {
                i++;
                XPathNavigator node = nodes.Current;
                Console.WriteLine(i + ". " + node.Value);
                if (node.MoveToFirstAttribute()) 
                {
                    Console.WriteLine("attribute: " + node.Name + "=" + node.Value);
                }
                while (node.MoveToNextAttribute()) 
                {
                    Console.WriteLine("attribute: " + node.Name + "=" + node.Value);
                }
            }
            Console.WriteLine("===========================End Navigator==============================");
        }

        public static void TestXmlTransform() 
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string xmlFile = path + "CityData.xml";
            string xsltFile = path + "CityData.xslt";
            xslt.Load(xsltFile);
            xslt.Transform(xmlFile, path + "CityData.html");
        }

        #region Xml CURD

        public static void XMLCURD() 
        {
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string fileName = path + "CityData.xml";
            CreateXmlDoc(fileName);
            string addFileName = path + "CityData-Add.xml";
            string editFileName = path + "CityData-Edit.xml";
            string deleteFileName = path + "CityData-Delete.xml";
            File.Copy(fileName, addFileName, true);
            File.Copy(fileName, editFileName, true);
            File.Copy(fileName, deleteFileName, true);
            Add(addFileName);
            Edit(editFileName);
            Delete(deleteFileName);
        }

        public static void CreateXmlDoc(string fullFileName) 
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmlDecl = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(xmlDecl);
            XmlElement root = doc.CreateElement("root");
            doc.AppendChild(root);

            XmlElement beijing= doc.CreateElement("province");
            
            beijing.InnerText = "Beijing";
            beijing.SetAttribute("population", "20000000");
            XmlElement shanghai = doc.CreateElement("province");
            shanghai.InnerText = "Shanghai";
            XmlElement tianjing = doc.CreateElement("province");
            tianjing.InnerText = "Tianjing";

            XmlElement zhejiang = doc.CreateElement("province");
            zhejiang.SetAttribute("name", "Zhejiang");
            zhejiang.SetAttribute("citynum", "10");

            XmlElement wenzhou = doc.CreateElement("city");
            wenzhou.InnerText = "Wenzhou";
            XmlElement taizhou = doc.CreateElement("city");
            taizhou.InnerText = "Taizhou";
            XmlElement hangzhou = doc.CreateElement("city");
            hangzhou.InnerText = "Hangzhou";
            hangzhou.SetAttribute("population", "8000000");
            zhejiang.AppendChild(hangzhou);
            zhejiang.AppendChild(taizhou);
            zhejiang.AppendChild(wenzhou);

            root.AppendChild(beijing);
            root.AppendChild(shanghai);
            root.AppendChild(tianjing);
            root.AppendChild(zhejiang);

            doc.Save(fullFileName);
        }

        public static void Add(string fullFileName) 
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fullFileName);
            XmlElement root = doc.DocumentElement;
            XmlNode node = root.SelectSingleNode("province[last()]");
            XmlElement jianhua = doc.CreateElement("city");
            jianhua.InnerText = "Jianhua";
            jianhua.SetAttribute("tag", "new");
            node.AppendChild(jianhua);
            doc.Save(fullFileName);
        }

        public static void Edit(string fullFileName) 
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fullFileName);
            XmlElement root = doc.DocumentElement;
            XmlNode node = root.SelectSingleNode("province[text()='Beijing']");
            node.Attributes["population"].Value = "20000001";
            doc.Save(fullFileName);
        }

        public static void Delete(string fullFileName) 
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fullFileName);
            XmlElement root = doc.DocumentElement;
            XmlNode node = root.SelectSingleNode("province[last()]/city[text()='Wenzhou']");
            node.ParentNode.RemoveChild(node);
            doc.Save(fullFileName);
        }

        #endregion
    }


}
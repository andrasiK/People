using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace People
{
    public class XmlOperations
    {
        //  XML file path
        string filePath = @"C:\Users\andra\Programming\Kristof\Files\XML\People.xml";
        public void Save(Person p)
        {
            /*
             XML document needs to initialize before first use, with the nodes!
             Here I don't initialize it in the program if it's empty
             */
            XmlDocument peopleXml = new XmlDocument();
            
            if (peopleXml.ChildNodes.Count == 0)
            {
                string initialText = "<People></People>";
                File.AppendAllText(filePath, initialText);
                
            }
            FileStream inpFile = new FileStream(filePath, FileMode.Open);       // read file
            peopleXml.Load(inpFile);                                              //load file to XML

            XmlElement humanElement = peopleXml.CreateElement("Human");           //create new element with attribute
            humanElement.SetAttribute("ID", p.Id.ToString());
            XmlElement name = peopleXml.CreateElement("Name");                    //create new elements with textnode
            XmlText nameText = peopleXml.CreateTextNode(p.Name.ToString());
            XmlElement gender = peopleXml.CreateElement("Gender");
            XmlText genderText = peopleXml.CreateTextNode(p.Gender.ToString());

            name.AppendChild(nameText);                                       //append textnodes and elements to XML file
            humanElement.AppendChild(name);
            gender.AppendChild(genderText);
            humanElement.AppendChild(gender);
            peopleXml.DocumentElement.AppendChild(humanElement);
            inpFile.Close();
            peopleXml.Save(filePath);

        }

        public string[] Load(int id)
        {
            XmlDocument peopleFile = new XmlDocument();
            FileStream inpFile = new FileStream(filePath, FileMode.Open);                     // open the file
            peopleFile.Load(inpFile);                                                         // load into xmldocument instance
            string[] loadedHuman = new string[3];
            XmlNodeList listFromNodes = peopleFile.GetElementsByTagName("Human");             // find out the number of elements available in xml file
            for (int i = 0; i < listFromNodes.Count; i++)                                     //navigate through each and every node
            {
                XmlElement hmn = (XmlElement)peopleFile.GetElementsByTagName("Human")[i];     // retrieve mode
                                                                                              //  XmlElement hmnid = (XmlElement)peopleFile.GetElementsByTagName("ID")[i];
                XmlElement hmnnm = (XmlElement)peopleFile.GetElementsByTagName("Name")[i];
                XmlElement hmngndr = (XmlElement)peopleFile.GetElementsByTagName("Gender")[i];

                if ((hmn.GetAttribute("ID")) == id.ToString())
                {
                    loadedHuman[0] = id.ToString();
                    loadedHuman[1] = hmnnm.InnerText;
                    loadedHuman[2] = hmngndr.InnerText;
                    break;
                }
            }
            inpFile.Close();
            return loadedHuman;
        }

    }
}

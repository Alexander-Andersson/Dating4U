using Dating4U.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Dating4U.Data
{
    public class SerializeXML
    {
        public void ExportProfileToXml(XmlProfile profile, string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(profile.GetType());
            using (FileStream outFile = new FileStream(fileName, FileMode.Create,
                FileAccess.Write))
            {
                xmlSerializer.Serialize(outFile, profile);
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace gSeer.Util {
    public static class IO {

        public static void Export(object obj) {
            XmlSerializer serializer;

            serializer = new XmlSerializer(obj.GetType());
            serializer.Serialize(new System.IO.StreamWriter(@"c:\temp\text.xml"), obj);
 
        }
    }
}

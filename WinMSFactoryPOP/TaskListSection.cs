using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml;

namespace WinMSFactoryPOP
{
    public class TaskListSection : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            List<taskItem> myConfigObject = new List<taskItem>();

            foreach (XmlNode childNode in section.ChildNodes)
            {
                string staskID = "", shostIP = "", shostPort = "", sremark = "", sprocessId = "";
                foreach (XmlAttribute attrib in childNode.Attributes)
                {
                    if (attrib.Name.Equals("taskID")) staskID = attrib.Value;
                    if (attrib.Name.Equals("hostIP")) shostIP = attrib.Value;
                    if (attrib.Name.Equals("hostPort")) shostPort = attrib.Value;
                    if (attrib.Name.Equals("remark")) sremark = attrib.Value;
                    if (attrib.Name.Equals("processId")) sprocessId = attrib.Value;
                }

                myConfigObject.Add(new taskItem() { taskID = staskID, hostIP = shostIP, hostPort = shostPort, remark = sremark, processId = sprocessId });
            }
            return myConfigObject;
        }
    }

    public class taskItem
    {
        public string taskID { get; set; }
        public string hostIP { get; set; }
        public string hostPort { get; set; }
        public string remark { get; set; }
        public string processId { get; set; }
    }
}

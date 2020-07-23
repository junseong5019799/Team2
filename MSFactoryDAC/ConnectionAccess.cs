using Encrypt;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MSFactoryDAC
{
	public abstract class ConnectionAccess
	{
		//public static LoggingUtility log;

		protected string ConnectionString
		{
			get
			{
				return new AES().AESDecrypt256(GetXmlText("MyDB"));
			}
		}

		public static XmlDocument LoadXml()
		{
			XmlDocument configXml = new XmlDocument();
			configXml.Load(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/MSFactory_DEV.xml");

			return configXml;
		}

		public static string GetXmlText(string key)
		{
			string str = "";
			XmlDocument configXml = LoadXml();
			XmlNodeList addNodes = configXml.SelectNodes("configuration/settings/add");

			foreach (XmlNode xmlNode in addNodes)
			{
				if (xmlNode.Attributes["key"].InnerText == key)
				{
					str = ((XmlCDataSection)xmlNode.ChildNodes[0]).InnerText;
					break;
				}
			}

			return str;
		}

		//public static LoggingUtility GetLogger()
		//{
		//	if (log == null)
		//	{
		//		if (!int.TryParse(GetXmlText("logDay"), out int logDay))
		//			logDay = 30;

		//		log = new LoggingUtility("MSFactory", Level.Debug, logDay);
		//	}

		//	return log;
		//}
	}
}

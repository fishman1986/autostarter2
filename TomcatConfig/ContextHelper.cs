using System;
using System.Collections.Generic;
using System.Text;
using TomcatConfig.model;
using System.Xml;

namespace TomcatConfig
{
    public class ContextHelper
    {
        public static Context parse(XmlDocument xdt)
        {
            if (xdt.GetElementsByTagName("Context").Count > 0)
            {
                XmlNode xmlContext = xdt.GetElementsByTagName("Context")[0];
                Context context = new Context();
                if (xmlContext.Attributes["docBase"] != null)
                {
                    context.docBase = xmlContext.Attributes["docBase"].Value;
                    context.path = xmlContext.Attributes["path"].Value;
                    return context;
                }
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace SerializeXmlManipulation.Application_Class
{
    [XmlRoot(ElementName="Employees")]
    public class Employees : List<Employee>
    {        
    }
}
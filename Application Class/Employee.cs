using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;


namespace SerializeXmlManipulation.Application_Class
{
    [Serializable]    
    public class Employee 
    {
       
        [XmlElement("Name")]        
        public string Name { get; set; }
       
        [XmlElement("Age")]
        public int Age { get; set; }
       
        [XmlElement("Salary")]
        public double Salary { get; set; }      
       
    }
}


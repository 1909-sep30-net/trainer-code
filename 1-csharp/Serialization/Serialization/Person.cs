using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Serialization
{
    // this is something called "POCO" plain old clr object
    // a class with just public get-set properties and a default constructor
    // "DTO" data transfer object
    public class Person
    {
        [XmlAttribute]
        public int Id { get; set; }

        [XmlElement(ElementName = "FirstName")]
        public string Name { get; set; }

        public Address Address { get; set; }
    }
}

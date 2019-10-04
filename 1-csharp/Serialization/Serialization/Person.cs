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
        private int _id;

        [XmlAttribute] // will do "Id="15"" instead of "<Id>15</Id>"
        public int Id { get => _id; set => _id = value; }

        [XmlElement(ElementName = "FirstName")] // change the name of the element used in the XML
        public string Name { get; set; }

        //[XmlIgnore] hide this property from XMLSerializer entirely
        public Address Address { get; set; }
    }
}

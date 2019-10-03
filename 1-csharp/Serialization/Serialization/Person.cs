using System;
using System.Collections.Generic;
using System.Text;

namespace Serialization
{
    // this is something called "POCO" plain old clr object
    // a class with just public get-set properties and a default constructor
    // "DTO" data transfer object
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}

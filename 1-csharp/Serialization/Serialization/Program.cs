using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Serialization
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // "" strings you need to escape some characters with \
            // @"" strings you don't
            var xmlFilePath = @"C:\revature\persons.xml";

            //var data = GetInitialData();

            var data = DeserializeXmlFromFile(xmlFilePath);

            ModifyData(data);

            SerializeXmlToFile(xmlFilePath, data);
        }

        public static void ModifyData(List<Person> data)
        {
            var person = data[0];
            person.Id += 10;
        }

        public static List<Person> DeserializeXmlFromFile(string xmlFilePath)
        {
            var serializer = new XmlSerializer(typeof(List<Person>));

            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(xmlFilePath, FileMode.Open);

                return (List<Person>)serializer.Deserialize(fileStream);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error while opening {xmlFilePath} for writing: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error while serializing: {ex.Message}");
            }
            finally // finally block always runs whether, no-exception, handled-exception, or unhandled-exception
            {
                // this "do something if not null"
                //if (fileStream != null)
                //{
                //    fileStream.Dispose();
                //}
                fileStream?.Dispose(); // is exact same as commented-out code above
                // null-conditional operator
            }
            return null;
        }

        public static void SerializeXmlToFile(string xmlFilePath, List<Person> data)
        {
            // XmlSerializer was made pre-generics and has not been updated
            var serializer = new XmlSerializer(typeof(List<Person>));

            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(xmlFilePath, FileMode.Create);

                serializer.Serialize(fileStream, data);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error while opening {xmlFilePath} for writing: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error while serializing: {ex.Message}");
            }
            finally // finally block always runs whether, no-exception, handled-exception, or unhandled-exception
            {
                if (fileStream != null)
                {
                    fileStream.Dispose();
                }
            }
        }

        public static List<Person> GetInitialData()
        {
            return new List<Person>
            {
                new Person
                {
                    Id = 1,
                    Name = "Billy",
                    Address = new Address
                    {
                        Street = "123 Main St",
                        City = "Dallas",
                        State = "TX"
                    }
                },
                new Person
                {
                    Id = 2,
                    Name = "Sam"
                }
            };
        }
    }
}

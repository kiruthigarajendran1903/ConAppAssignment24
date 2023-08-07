using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ConAppEmployeeLib;
namespace ConAppAssignment24
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Employee employee = new Employee();
            Console.WriteLine("Enter Employee Id ");
            employee.Id=int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Employee First Name");
            employee.FName=Console.ReadLine();
            Console.WriteLine("Enter Employee Last Name ");
            employee.LName=Console.ReadLine();
            Console.WriteLine("Enter employee Salary");
            employee.Salary=double.Parse(Console.ReadLine());

            //Binary Serialization
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("D:\\SimpliLearn\\Day-21\\Employee.bin", FileMode.Create))
            {
                formatter.Serialize(fs, employee);
            }
            Console.WriteLine("Created & Serialized");

            //Binary DeSerialization


            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream bs = new FileStream("D:\\SimpliLearn\\Day-21\\Employee.bin", FileMode.Open))
            {
                Employee dsPerson = (Employee)binaryFormatter.Deserialize(bs);
                Console.WriteLine("Serializable object is ID:" + dsPerson.Id + "\nFirst Name :" + dsPerson.FName + "\nLast Name :" + dsPerson.LName + "\nSalary :" + dsPerson.Salary);
            }

            //XML Serialization

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));
            //Serialize the object to XML

            using (TextWriter writer = new StreamWriter("D:\\SimpliLearn\\Day-21\\Employee.xml"))
            {
               xmlSerializer.Serialize(writer, employee);
            }
            Console.WriteLine("***Done***");

            //XML Deserialization
            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            using (TextReader reader = new StreamReader("\"D:\\SimpliLearn\\Day-21\\Employee.xml"))
            {
                Employee ep = (Employee)serializer.Deserialize(reader);
                Console.WriteLine($"ID: {ep.Id}, First Name: {ep.FName}, LastName: {ep.LName}");
                Console.WriteLine($"Salary: {ep.Salary}");

            }

            Console.ReadKey();
        }
    }
    }


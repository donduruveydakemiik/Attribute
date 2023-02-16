using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Custumer custumer = new Custumer();
            custumer.Name = "Rüveyda";
            CustomerDal customerDal = new CustomerDal();
            customerDal.Add(custumer);

        }

       [ToTable("Customers")] //veri tabanından bak
        class Custumer
        {
            public int Id { get; set; } //Property 

            [RequiredProperty] //Attriibute name zorunlu olarak gir.
            public string Name { get; set; } //Property 

            [RequiredProperty] //Attriibute yaşı zorunlu olarak gir.
            public int Age { get; set; }//Property 
        }

        class CustomerDal
        {
            [Obsolete("Dont use this method . Please use AddNew Method")] // hazır attribute
            public void Add(Custumer custumer)
            {
                Console.WriteLine("{0},{1},{2}  Added.",custumer.Id,custumer.Name,custumer.Age);
                Console.ReadLine();
            }


            public void AddNew(Custumer custumer)
            {
                Console.WriteLine("{0},{1},{2}  Added.", custumer.Id, custumer.Name, custumer.Age);
                Console.ReadLine();
            }

        }
        [AttributeUsage(AttributeTargets.Property)] //Bu attribute sadece property olanlarda kullanılır.
        class RequiredPropertyAttribute : Attribute
        {

        }

        [AttributeUsage(AttributeTargets.Class)] //Bu attribute sadece class olanlarda kullanılır.
        class ToTableAttribute : Attribute 
        {
            private string _tableName;
            public ToTableAttribute(string tableName)
            {
                _tableName = tableName;
            }
        }
    }
}

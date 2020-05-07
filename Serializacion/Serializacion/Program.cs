using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace Serializacion
{
    [Serializable]
    class Program
    {
        static void Main(string[] args)
        {
            string respuesta = "si";
            List<Person> personas = new List<Person>();
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Tarea.txt", FileMode.Create, FileAccess.Write, FileShare.None);

            Console.WriteLine("Seleccione una opcion");
            Console.WriteLine("1. Crear personas");
            Console.WriteLine("2. Ver personas");
            Console.WriteLine("3. Cargar personas");
            Console.WriteLine("4. Guardar personas");
            int respuesta1 = Convert.ToInt32(Console.ReadLine());

            while (respuesta1 == 1 || respuesta1 == 2 || respuesta1 == 3 || respuesta1 == 4)
            {
                if (respuesta1 == 1)
                {
                    respuesta = "si";
                    while (respuesta == "si")
                    {
                        Console.WriteLine("Ingrese un nombre:");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese un apellido:");
                        string apellido = Console.ReadLine();
                        Console.WriteLine("Ingrese la edad:");
                        int edad = Convert.ToInt32(Console.ReadLine());
                        Person p1 = new Person(nombre, apellido, edad);
                        personas.Add(p1);
                        Console.WriteLine("Quieres agregar otra persona? si/no");
                        respuesta = Console.ReadLine();
                    }
                }
                if (respuesta1 == 2)
                {
                   foreach (Person persona in personas)
                   {
                        Console.WriteLine("nombre: " + persona.nombre + ", apellido: " + persona.apellido + ", edad: " + persona.edad);
                   }
                }
                if (respuesta1 == 3)
                {
                    formatter.Serialize(stream, personas);
                    stream.Close();
                }
                if (respuesta1 == 4)
                {
                    Person perosnas = (Person)formatter.Deserialize(stream);
                    stream.Close();
                }
                
                Console.WriteLine("1. Crear personas");
                Console.WriteLine("2. Ver personas");
                Console.WriteLine("3. Cargar personas");
                Console.WriteLine("4. Guardar personas");
                respuesta1 = Convert.ToInt32(Console.ReadLine());

            }
            


            Console.ReadKey();
        }
    }
}
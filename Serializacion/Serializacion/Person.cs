using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serializacion
{   
    [Serializable]
    public class Person
    {
     
        public string nombre;
        public string apellido;
        public int edad;

        public Person(string nombre, string apellido, int edad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
        }
       
            
    }

    

}

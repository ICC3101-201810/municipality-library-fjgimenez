using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // COMO PUEDEN VER NO SÉ QUE PASÓ CON MI ARCHIVO DLL PERO ME LEE SÓLO LAS CLAVES NATIVAS, 
            // PROBANDO CON EL OTRO DLL test.dll (EJEMPLO CLASES) SI LEE LOS MÉTODOS :(

            var DLL = Assembly.LoadFrom(@"C:\Users\Fede\Desktop\Lab 10\municipality-library-fjgimenez\ClassLibrary1.dll");
            var types = DLL.GetExportedTypes(); //[Persona, Propiedad, Automovil]

            foreach (Type type in types)
            {

                PropertyInfo[] properties = type.GetProperties();
                MethodInfo[] methods = type.GetMethods();
                string sb = "";
                sb += ("================================================================\n");
                sb += (String.Format("Type Name: {0}\n", type.Name));
                if (type.IsClass) {
                    sb += "CLASS\n";
                    sb += ("================================================================\n");

                    //iterate the properties and write output
                    foreach (PropertyInfo property in properties)
                    {
                        sb += ("----------------------------------------------------------------\n");
                        sb += (String.Format("Property Name: {0}\n", property.Name));
                        sb += ("----------------------------------------------------------------\n");

                        sb += (String.Format("Property Type Name: {0}\n", property.PropertyType.Name));
                        sb += (String.Format("Property Type FullName: {0}\n", property.PropertyType.FullName));

                        sb += (String.Format("Can we read the property?: {0}\n", property.CanRead.ToString()));
                        sb += (String.Format("Can we write the property?: {0}\n", property.CanWrite.ToString()));
                    }
                    sb += ("******************************\n");
                    //iterate the methods and write output
                    foreach (MethodInfo method in methods)
                    {

                        sb += (String.Format("Method info: {0}\n", type.GetMethod(method.Name)));
                        sb += ("***\n");

                    }

                    Console.WriteLine(sb);
                }
                    
               
            }

            while (true)
            {
                Console.WriteLine("Bienvenido, ingrese su opción:\n");
                Console.WriteLine("1) Inscribir Persona");
                Console.WriteLine("2) Inscribir Propiedad");
                Console.WriteLine("3) Inscribir Automóvil\n");
                Console.WriteLine("Opción");
                var option = Console.ReadLine();
                while (option != "1" && option != "2" && option != "3")
                {
                    Console.WriteLine("Opción no válida, ingrese nuevamente:");
                    option = Console.ReadLine();
                }
                if (option == "1")
                {
                    Console.WriteLine("Inscribiendo Persona\n");
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Nombre:");
                    var nombre = Console.ReadLine();
                    Console.WriteLine("Apellido:");
                    var apellido = Console.ReadLine();
                    Console.WriteLine("RUT:");
                    var rut = Console.ReadLine();
                    Console.WriteLine("E-mail:");
                    var email = Console.ReadLine();
                    var personaType = types[0];
                    var c = Activator.CreateInstance(personaType);
                    // var m_inscribir = personaType.GetMethod("Inscribir");
                    // m_inscribir.Invoke(c, new object[] { nombre, apellido, rut, email });
                    Console.WriteLine("Persona inscrita correctamente\n");
                    Console.ReadLine();
                }
                else if (option == "2")
                {
                    Console.WriteLine("Inscribiendo Propiedad\n");
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Dirección:");
                    var direcc = Console.ReadLine();
                    Console.WriteLine("Número:");
                    var numero = Console.ReadLine();
                    Console.WriteLine("Departamento:");
                    var departamento = Console.ReadLine();
                    Console.WriteLine("Titular:");
                    var titular = Console.ReadLine();
                    var propiedadType = types[1];
                    var c = Activator.CreateInstance(propiedadType);
                    // var m_inscribir = propiedadType.GetMethod("Inscribir");
                    // m_inscribir.Invoke(c, new object[] { direcc, numero, departamento, titular });
                    Console.WriteLine("Propiedad inscrita correctamente\n");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Inscribiendo Automóvil\n");
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Marca:");
                    var marca = Console.ReadLine();
                    Console.WriteLine("Modelo:");
                    var modelo = Console.ReadLine();
                    Console.WriteLine("Patente:");
                    var patente = Console.ReadLine();
                    Console.WriteLine("Año:");
                    var año = Console.ReadLine();
                    var automovilType = types[2];
                    var c = Activator.CreateInstance(automovilType);
                    // var m_inscribir = automovilType.GetMethod("Inscribir");
                    // m_inscribir.Invoke(c, new object[] { marca, modelo, patente, año });
                    Console.WriteLine("Automovil inscrita correctamente\n");
                    Console.ReadLine();
                }
                
            }
        }
    }
}

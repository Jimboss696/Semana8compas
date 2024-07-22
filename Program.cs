using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana8compas
{
    // Clase principal del programa
    class Program
    {
        // Función para mostrar la carátula del menú
        static void Caratula()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("+             UNIVERSIDAD ESTATAL AMAZÓNICA           +");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine();
            Console.WriteLine("           Menú de opciones - Teatro Risa Triste");
            Console.WriteLine();
            Console.WriteLine("                     Escriba un número");
            Console.WriteLine();
            Console.ResetColor();
        }

        static void Main()
        {
            // Crea una instancia de AsignacionAsientos
            AsignacionAsientos asignacionAsientos = new AsignacionAsientos();

            while (true) // Bucle principal del programa
            {
                Caratula(); // Llama a la función Caratula para mostrar la carátula del menú

                // Muestra el menú principal
                Console.WriteLine("Menu Principal:");
                Console.WriteLine("1. Agregar persona a la cola de espera 1");
                Console.WriteLine("2. Agregar persona a la cola de espera 2");
                Console.WriteLine("3. Asignar asientos en orden de llegada");
                Console.WriteLine("4. Imprimir asientos asignados");
                Console.WriteLine("5. Simulación de llenado de teatro");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");
                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out int opcionPrincipal)) // Valida que la entrada sea un número
                {
                    switch (opcionPrincipal)
                    {
                        case 1:
                            // Agregar persona a la cola de espera 1
                            Console.Write("Ingrese el nombre de la persona: ");
                            string nombre1 = Console.ReadLine();
                            asignacionAsientos.AgregarPersonaCola1(nombre1);
                            break;
                        case 2:
                            // Agregar persona a la cola de espera 2
                            Console.Write("Ingrese el nombre de la persona: ");
                            string nombre2 = Console.ReadLine();
                            asignacionAsientos.AgregarPersonaCola2(nombre2);
                            break;
                        case 3:
                            // Asignar asientos en orden de llegada
                            asignacionAsientos.AsignarAsientos();
                            break;
                        case 4:
                            // Imprimir lista de asientos asignados
                            asignacionAsientos.ImprimirAsientosAsignados();
                            break;
                        case 5:
                            // Simulación de llenado de teatro
                            asignacionAsientos.SimularLlenadoTeatro();
                            break;
                        case 6:
                            // Salir del programa
                            return;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor ingrese un número.");
                }

                // Pausar para permitir ver el resultado antes de volver al menú
                Console.WriteLine("Presione cualquier tecla para regresar al menú...");
                Console.ReadKey();
            }
        }
    }
}

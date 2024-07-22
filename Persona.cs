using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana8compas
{
    // Clase que representa una Persona
    class Persona
    {
        public string Nombre { get; set; } // Nombre de la persona

        // Constructor que inicializa una persona con su nombre
        public Persona(string nombre)
        {
            Nombre = nombre;
        }
    }

    // Clase que maneja la asignación de asientos en el teatro
    class AsignacionAsientos
    {
        // Colas para manejar la espera de las personas, una por cada registrador
        private Queue<Persona> colaEspera1 = new Queue<Persona>();
        private Queue<Persona> colaEspera2 = new Queue<Persona>();
        // Lista para registrar los asientos asignados
        private List<string> asientosAsignados = new List<string>();
        // Número total de asientos disponibles
        private int totalAsientos = 100;

        // Método para agregar una persona a la cola de espera del registrador 1
        public void AgregarPersonaCola1(string nombre)
        {
            if (asientosAsignados.Count < totalAsientos) // Verifica si aún hay asientos disponibles
            {
                colaEspera1.Enqueue(new Persona(nombre)); // Agrega a la persona a la cola de espera 1
                Console.WriteLine($"{nombre} agregado a la cola de espera 1.");
            }
            else
            {
                Console.WriteLine("Todos los asientos están asignados. No se pueden agregar más personas.");
            }
        }

        // Método para agregar una persona a la cola de espera del registrador 2
        public void AgregarPersonaCola2(string nombre)
        {
            if (asientosAsignados.Count < totalAsientos) // Verifica si aún hay asientos disponibles
            {
                colaEspera2.Enqueue(new Persona(nombre)); // Agrega a la persona a la cola de espera 2
                Console.WriteLine($"{nombre} agregado a la cola de espera 2.");
            }
            else
            {
                Console.WriteLine("Todos los asientos están asignados. No se pueden agregar más personas.");
            }
        }

        // Método para asignar asientos en orden de llegada desde ambas colas
        public void AsignarAsientos()
        {
            // Alterna entre las dos colas para asignar los asientos
            while ((colaEspera1.Count > 0 || colaEspera2.Count > 0) && asientosAsignados.Count < totalAsientos)
            {
                if (colaEspera1.Count > 0)
                {
                    Persona persona1 = colaEspera1.Dequeue(); // Saca a la persona de la cola 1
                    asientosAsignados.Add(persona1.Nombre); // Agrega su nombre a la lista de asientos asignados
                    Console.WriteLine($"{persona1.Nombre} ha sido asignado al asiento {asientosAsignados.Count}.");
                }

                if (colaEspera2.Count > 0 && asientosAsignados.Count < totalAsientos)
                {
                    Persona persona2 = colaEspera2.Dequeue(); // Saca a la persona de la cola 2
                    asientosAsignados.Add(persona2.Nombre); // Agrega su nombre a la lista de asientos asignados
                    Console.WriteLine($"{persona2.Nombre} ha sido asignado al asiento {asientosAsignados.Count}.");
                }
            }

            if (asientosAsignados.Count == totalAsientos)
            {
                Console.WriteLine("Todos los asientos han sido asignados.");
            }
        }

        // Método para imprimir la lista de asientos asignados
        public void ImprimirAsientosAsignados()
        {
            Console.WriteLine("Lista de asientos asignados:");
            for (int i = 0; i < asientosAsignados.Count; i++)
            {
                // Imprime el número del asiento y el nombre de la persona asignada a ese asiento
                Console.WriteLine($"Asiento {i + 1}: {asientosAsignados[i]}");
            }
        }

        // Método para simular el llenado del teatro
        public void SimularLlenadoTeatro()
        {
            Queue<string> nombres = new Queue<string>();

            // Llenado de nombres simulados
            for (int i = 0; i < 100; i++)
            {
                nombres.Enqueue("Usuario - " + i.ToString());
            }

            // Encolar los nombres simulados en las colas de espera
            int contador = 0;
            while (nombres.Count > 0)
            {
                string nombre = nombres.Dequeue();
                if (contador % 2 == 0)
                {
                    AgregarPersonaCola1(nombre);
                }
                else
                {
                    AgregarPersonaCola2(nombre);
                }
                contador++;
            }

            // Asignar los asientos en orden de llegada
            AsignarAsientos();

            // Imprimir la lista de asientos asignados
            ImprimirAsientosAsignados();
        }
    }
}

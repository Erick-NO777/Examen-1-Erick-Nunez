using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_1_Erick_Nunez
{
    // Clase Cita para gestionar las citas
    public class Cita
    {
        // Atributos
        public Cliente cliente;
        public Vehiculo vehiculo;
        public Servicio servicio;
        public DateTime fechaHora;
        public Mecanico mecanico;

        // Metodo
        public void RegistrarCita()
        {
            cliente = new Cliente();
            vehiculo = new Vehiculo();
            servicio = new Servicio();
            mecanico = new Mecanico();

            Console.WriteLine("\nRegistrar Nueva Cita\n");

            // Informacion del cliente
            Console.Write("Nombre del cliente: ");
            cliente.nombre = Console.ReadLine();

            Console.Write("Direccion del cliente: ");
            cliente.direccion = Console.ReadLine();

            Console.Write("Telefono del cliente: ");
            cliente.telefono = Console.ReadLine();

            Console.Write("Correo electronico del cliente: ");
            cliente.correoElectronico = Console.ReadLine();

            // Informacion del vehiculo
            Console.Write("Marca del vehiculo: ");
            vehiculo.marca = Console.ReadLine();

            Console.Write("Modelo del vehiculo: ");
            vehiculo.modelo = Console.ReadLine();

            Console.Write("Año del vehiculo: ");
            vehiculo.anio = Convert.ToInt32(Console.ReadLine());

            Console.Write("VIN del vehiculo: ");
            vehiculo.vin = Console.ReadLine();
            vehiculo.propietario = cliente;

            // Informacion del servicio
            Console.Write("Nombre del servicio: ");
            servicio.nombre = Console.ReadLine();

            Console.Write("Descripcion del servicio: ");
            servicio.descripcion = Console.ReadLine();

            Console.Write("Costo del servicio: ");
            servicio.costo = Convert.ToDouble(Console.ReadLine());

            // Informacion del mecanico
            Console.Write("Nombre del mecanico: ");
            mecanico.nombre = Console.ReadLine();
            mecanico.disponibilidad = true;

            Console.Write("Especialidad: ");
            mecanico.especialidad = Console.ReadLine();

            // Fecha y hora de la cita
            Console.Write("Fecha y hora de la cita (dd/mm/yyyy hh:mm): ");
            fechaHora = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("\nLa cita ha sido registrada con exito.");
        }

        public void ModificarCita()
        {
            //Verificar si no hay citas a modificar
            if (cliente == null || vehiculo == null || servicio == null || mecanico == null)
            {
                Console.WriteLine("\nNo hay citas para modificar.");
                return;
            }

            Console.WriteLine("\nModificar Cita\n");

            // Modificar nombre del cliente
            Console.Write("Nuevo nombre del cliente (deje en blanco para no cambiar): ");
            string nuevoNombreCliente = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoNombreCliente))
            {
                cliente.nombre = nuevoNombreCliente;
            }

            // Modificar fecha y hora de la cita
            Console.Write("Nueva fecha y hora de la cita (dd/mm/yyyy hh:mm, deje en blanco para no cambiar): ");
            string nuevaFechaHora = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevaFechaHora))
            {
                fechaHora = DateTime.Parse(nuevaFechaHora);
            }

            Console.WriteLine("\nCita modificada exitosamente.");
        }

        public void CancelarCita()
        {
            if (cliente == null || vehiculo == null || servicio == null || mecanico == null)
            {
                Console.WriteLine("\nNo hay citas para cancelar.");
                return;
            }

            Console.WriteLine("\nCancelar Cita\n");

            Console.Write("Ingrese la fecha y hora de la cita a cancelar (dd/mm/yyyy hh:mm): ");
            string fechaHoraStr = Console.ReadLine();

            // Verificar si el campo esta vacio
            if (string.IsNullOrEmpty(fechaHoraStr))
            {
                Console.WriteLine("\nNo se puede dejar el campo de fecha y hora en blanco. Inténtelo de nuevo.");
                return;
            }

            // Intentar parsear la fecha y hora proporcionada
            DateTime fechaHoraCancelar;
            if (!DateTime.TryParse(fechaHoraStr, out fechaHoraCancelar))
            {
                Console.WriteLine("\nFormato de fecha y hora no válido. Use el formato dd/mm/yyyy hh:mm.");
                return;
            }

            // Comparar la fecha y hora ingresada con la fecha y hora de la cita actual
            if (fechaHora == fechaHoraCancelar)
            {
                cliente = null;
                vehiculo = null;
                servicio = null;
                mecanico = null;
                fechaHora = default(DateTime);
                Console.WriteLine("\nCita cancelada exitosamente.");
            }
            else
            {
                Console.WriteLine("\nCita no encontrada.");
            }
        }

        public void ObtenerDetalles()
        {
            if (cliente == null || vehiculo == null || servicio == null || mecanico == null)
            {
                Console.WriteLine("\nNo hay citas programadas.");
                return;
            }

            //Mostrar los detalles de la cita
            Console.WriteLine("\nDetalles de la Cita:\n");
            Console.WriteLine($"Cliente: {cliente.nombre}");
            Console.WriteLine($"Vehiculo: {vehiculo.marca} {vehiculo.modelo}, Año: {vehiculo.anio}, VIN: {vehiculo.vin}");
            Console.WriteLine($"Servicio: {servicio.nombre}, Descripcion: {servicio.descripcion}, Costo: {servicio.costo}");
            Console.WriteLine($"Fecha y Hora: {fechaHora}");
            Console.WriteLine($"Mecanico: {mecanico.nombre}, Especialidad: {mecanico.especialidad}\n");
        }
    }

    // Clase Cliente para gestionar los clientes
    public class Cliente
    {
        public string nombre;
        public string direccion;
        public string telefono;
        public string correoElectronico;

        public void RegistrarCliente()
        {
            Console.WriteLine("\nRegistrar cliente\n");
            Console.Write("Nombre: ");
            nombre = Console.ReadLine();
            Console.Write("Direccion: ");
            direccion = Console.ReadLine();
            Console.Write("Telefono: ");
            telefono = Console.ReadLine();
            Console.Write("Correo electronico: ");
            correoElectronico = Console.ReadLine();
        }

        public void ActualizarInformacion()
        {
            Console.WriteLine("\nActualizar informacion del cliente\n");
            Console.Write("Nuevo nombre (deje en blanco para no cambiar): ");
            string nuevoNombre = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoNombre))
            {
                nombre = nuevoNombre;
            }
            // Similar a los otros campos
        }

        public void ObtenerDetalles()
        {
            Console.WriteLine($"Cliente: {nombre}, Direccion: {direccion}, Telefono: {telefono}, Correo electronico: {correoElectronico}");
        }
    }

    // Clase Vehiculo para gestionar los vehiculos
    public class Vehiculo
    {
        public string marca;
        public string modelo;
        public int anio;
        public string vin;
        public Cliente propietario;

        public void RegistrarVehiculo()
        {
            Console.WriteLine("\nRegistrar vehiculo\n");
            Console.Write("Marca: ");
            marca = Console.ReadLine();
            Console.Write("Modelo: ");
            modelo = Console.ReadLine();
            Console.Write("Año: ");
            anio = Convert.ToInt32(Console.ReadLine());
            Console.Write("VIN: ");
            vin = Console.ReadLine();
        }

        public void ActualizarInformacion()
        {
            Console.WriteLine("\nActualizar informacion del vehiculo\n");
            // Similar a Cliente
        }

        public void ObtenerDetalles()
        {
            Console.WriteLine($"Vehiculo: {marca} {modelo}, Año: {anio}, VIN: {vin}");
        }
    }

    // Clase Servicio para gestionar los servicios
    public class Servicio
    {
        public string nombre;
        public string descripcion;
        public double costo;

        public void RegistrarServicio()
        {
            Console.WriteLine("\nRegistrar servicio\n");
            Console.Write("Nombre: ");
            nombre = Console.ReadLine();
            Console.Write("Descripcion: ");
            descripcion = Console.ReadLine();
            Console.Write("Costo: ");
            costo = Convert.ToDouble(Console.ReadLine());
        }

        public void ActualizarServicio()
        {
            Console.WriteLine("\nActualizar servicio\n");
            // Similar a Cliente
        }

        public void ObtenerDetalles()
        {
            Console.WriteLine($"Servicio: {nombre}, Descripcion: {descripcion}, Costo: {costo}");
        }
    }

    // Clase Mecanico para gestionar los mecanicos
    public class Mecanico
    {
        public string nombre;
        public string especialidad;
        public bool disponibilidad;

        public void RegistrarMecanico()
        {
            Console.WriteLine("\nRegistrar mecanico\n");
            Console.Write("Nombre: ");
            nombre = Console.ReadLine();
            Console.Write("Especialidad: ");
            especialidad = Console.ReadLine();
            disponibilidad = true; // Asumimos que el mecanico esta disponible inicialmente
        }

        public void ActualizarInformacion()
        {
            Console.WriteLine("\nActualizar informacion del mecanico\n");
            // Similar a Cliente
        }

        public void ObtenerDisponibilidad()
        {
            Console.WriteLine($"Mecanico: {nombre}, Especialidad: {especialidad}, Disponibilidad: {(disponibilidad ? "Si" : "No")}");
        }

        public void AsignarTarea()
        {
            disponibilidad = false; // Al asignar una tarea, el mecanico ya no esta disponible
        }
    }

    // Clase Pantalla para la consola
    public class Pantalla
    {
        public static Cita cita = new Cita();

        public static void Main(string[] args)
        {
            string opcion;

            do
            {
                Console.WriteLine("\nTaller Mecanico AutoSoluciones");
                Console.WriteLine("\nGestion de citas\n");
                Console.WriteLine("1 - Registrar nueva cita");
                Console.WriteLine("2 - Modificar cita");
                Console.WriteLine("3 - Cancelar cita");
                Console.WriteLine("4 - Ver cita programada");
                Console.WriteLine("5 - Salir");
                Console.Write("\nSeleccione una opcion: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        cita.RegistrarCita();
                        break;
                    case "2":
                        cita.ModificarCita();
                        break;
                    case "3":
                        cita.CancelarCita();
                        break;
                    case "4":
                        cita.ObtenerDetalles();
                        break;
                    case "5":
                        Console.WriteLine("\nCerrando...\n");
                        break;
                    default:
                        Console.WriteLine("\nOpcion no valida.");
                        break;
                }

            } while (opcion != "5");
        }
    }
}


#region Especialidades
List<Especialidad> especialidades = new List<Especialidad>
            {
                new Especialidad("Cardiología"),
                new Especialidad("Dermatología"),
                new Especialidad("Pediatría"),
                new Especialidad("Ginecología"),
                new Especialidad("Oftalmología")
            };
#endregion

#region Pacientes
List<Paciente> pacientes = new List<Paciente>
            {
                new Paciente(12345678, "Juan Pérez"),
                new Paciente(87654321, "Ana Gómez"),
                new Paciente(11223344, "Luis Martínez"),
                new Paciente(44332211, "María López"),
                new Paciente(55667788, "Carlos Fernández")
            };
#endregion

#region Hospital
Hospital miHospital = new Hospital
(
    pacientes,
    especialidades,
    new List<string> { "Dr. Pedro", "Dra. Juan", "Dr. Roberto", "Dra. Diana", "Dr. Jose" }
);
#endregion

#region Citas Medicas
List<CitaMedica> citaMedicas = new List<CitaMedica>
            {
                new CitaMedica(1, pacientes[0], especialidades[0], "Dr. Pedro", DateTime.Now.AddDays(1)),
                new CitaMedica(2, pacientes[1], especialidades[1], "Dra. Juan", DateTime.Now.AddDays(2)),
                new CitaMedica(3, new Paciente(), especialidades[2], "Dr. Roberto", DateTime.Now.AddDays(3)),
                new CitaMedica(4, new Paciente(), especialidades[3], "Dra. Diana", DateTime.Now.AddDays(4)),
                new CitaMedica(5, pacientes[4], especialidades[4], "Dr. Jose", DateTime.Now.AddDays(5)),
                new CitaMedica(6, new Paciente(), especialidades[1], "Dr. Pedro", DateTime.Now.AddDays(6)),
            };

#endregion



bool salir = false;
while (salir == false)
{
    Console.WriteLine("Bienvenido al sistema de citas médicas del hospital");
    Console.WriteLine("1. Registrar Paciente");
    Console.WriteLine("2. Ver pacientes");
    Console.WriteLine("3. Agendar cita médica");
    Console.WriteLine("4. Ver citas médicas agendadas");
    Console.WriteLine("5. Salir");
    Console.Write("Seleccione una opción: ");
    int opcion = int.Parse(Console.ReadLine()!);
    Console.WriteLine("----------------------------------------------------------\n");

    switch (opcion)
    {
        case 1:
            //  Registrar Paciente
            Console.WriteLine("Nuevo Paciente");
            Console.Write("Ingrese el nombre del paciente:");
            string nombrePaciente = Console.ReadLine()!;
            Console.Write("Ingrese el DNI del paciente:");
            int nuevoDni = Convert.ToInt32(Console.ReadLine());
            Paciente nuevoPaciente = new Paciente(nuevoDni, nombrePaciente);
            miHospital.Pacientes.Add(nuevoPaciente);

            Console.WriteLine($"→ Paciente {nuevoPaciente.Nombre} registrado con éxito. Nro Historia: {nuevoPaciente.NroHistoria}");
            Console.WriteLine("----------------------------------------------------------\n");
            break;
        case 2:
            //  Ver pacientes
            Console.WriteLine("Pacientes registrados:");
            if (miHospital.Pacientes.Count == 0)
            {
                Console.WriteLine("No hay pacientes registrados.");
            }
            else
            {
                foreach (var paciente in miHospital.Pacientes)
                {
                    Console.WriteLine($"DNI: {paciente.Dni.ToString().PadRight(10, ' ')}, Nombre: {paciente.Nombre.PadRight(15, ' ')}, Nro Historia: {paciente.NroHistoria}");
                }
            }
            Console.WriteLine("----------------------------------------------------------\n");
            break;
        case 3:
            //  Agendar cita médica
            Console.WriteLine("Ingrese el DNI del paciente:");
            int dni = Convert.ToInt32(Console.ReadLine());
            Paciente pacienteEncontrado = miHospital.Pacientes.FirstOrDefault(p => p.Dni == dni)!;

            //  Verificar si el paciente existe y crear paciente
            if (pacienteEncontrado == null)
            {
                Console.WriteLine("Paciente no encontrado. Primero debemos registrar al paciente.");
                break;
            }

            Console.WriteLine($"→ Paciente: {pacienteEncontrado.Nombre}");

            //  ESPECIALIDAD
            Console.WriteLine("Especialidades Disponibles:");
            for (int i = 0; i < miHospital.Especialdades.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {miHospital.Especialdades[i].Nombre}");
            }
            Console.Write("Seleccione una especialidad:");
            int especialidadSeleccionada = Convert.ToInt32(Console.ReadLine()) - 1;
            Especialidad especialidad = miHospital.Especialdades[especialidadSeleccionada];


            //  DOCTOR
            Console.WriteLine("Doctores disponibles:");
            for (int i = 0; i < miHospital.Doctores.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {miHospital.Doctores[i]}");
            }
            Console.Write("Seleccione un doctor:");
            int doctorSeleccionado = Convert.ToInt32(Console.ReadLine()) - 1;
            string doctor = miHospital.Doctores[doctorSeleccionado];


            //  CITAS EXISTENTES QUE CUMPLAN CON ESPECIALIDAD Y DOCTOR
            List<CitaMedica> citasDisponibles = citaMedicas
                .Where(c => c.Especialidad.Nombre == especialidad.Nombre && c.Doctor == doctor && c.Paciente.Nombre == "---")
                .ToList();

            //  MOSTRAR CITAS DISPONIBLES
            if (citasDisponibles.Count == 0)
            {
                Console.WriteLine("No hay citas disponibles para esta especialidad y doctor.\n");
            }
            else
            {
                Console.WriteLine("Citas disponibles:");
                foreach (var cita in citasDisponibles)
                {
                    Console.WriteLine($"ID: {cita.Id}, Especialidad: {cita.Especialidad.Nombre}, Fecha: {cita.Horario}");
                }

                //  SELECCIONAR CITA POR ID
                Console.Write("Deseas seleccionar alguna cita disponible? (S/N)");
                string seleccionarCita = Console.ReadLine()!.ToUpper();
                if (seleccionarCita != "S")
                {
                    Console.WriteLine("No se ha seleccionado ninguna cita disponible.");
                    return;
                }
                else
                {
                    Console.Write("Seleccione una cita por ID: ");
                    int idSeleccionado = Convert.ToInt32(Console.ReadLine());
                    CitaMedica citaSeleccionada = citasDisponibles.FirstOrDefault(c => c.Id == idSeleccionado)!;
                    if (citaSeleccionada != null)
                    {
                        //  SE ACTUALIZA LA CITA CON EL PACIENTE
                        citaSeleccionada.Paciente = pacienteEncontrado;
                        //  SE ACTUALIZA EL NOMBRE DEL PACIENTE EN LA CITA
                        pacienteEncontrado.Nombre = pacienteEncontrado.Nombre;

                        Console.WriteLine($"Cita agendada exitosamente para {pacienteEncontrado.Nombre} el {citaSeleccionada.Horario} con el doctor {citaSeleccionada.Doctor}.");
                        Console.WriteLine("----------------------------------------------------------\n");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Cita no encontrada.");
                        Console.WriteLine("----------------------------------------------------------\n");
                        return;
                    }
                }


            }

            Console.WriteLine("¿Desea agendar una cita para otra fecha? (S/N)");
            string respuesta = Console.ReadLine()!.ToUpper();
            if (respuesta == "S")
            {
                //  HORARIO
                Console.WriteLine("Ingrese la fecha y hora de la cita (formato: dd/MM/yyyy HH:mm):");
                DateTime fechaHoraCita = DateTime.Parse(Console.ReadLine()!);

                //  ID
                int idCita = citaMedicas.Count + 1;

                //  CREAR CITA
                CitaMedica nuevaCita = new CitaMedica(idCita, pacienteEncontrado, especialidad, doctor, fechaHoraCita);
                citaMedicas.Add(nuevaCita);

                Console.WriteLine($"Cita agendada exitosamente para {pacienteEncontrado.Nombre} el {fechaHoraCita} con el doctor {doctor}.");
            }
            else
            {
                Console.WriteLine("No se ha agendado ninguna cita.");
            }

            Console.WriteLine("----------------------------------------------------------\n");
            break;
        case 4:
            //  Ver citas médicas agendadas
            Console.WriteLine("Citas médicas agendadas:");
            if (citaMedicas.Count == 0)
            {
                Console.WriteLine("No hay citas médicas agendadas.");
            }
            else
            {
                foreach (var cita in citaMedicas)
                {
                    Console.WriteLine($"ID: {cita.Id}, Paciente: {cita.Paciente.Nombre}, Especialidad: {cita.Especialidad.Nombre}, Doctor: {cita.Doctor}, Fecha: {cita.Horario}");
                }
            }

            Console.WriteLine("----------------------------------------------------------\n");
            break;



        case 5:
            Console.WriteLine("Saliendo del sistema...");
            Console.WriteLine("----------------------------------------------------------\n");
            salir = true;
            break;
        default:
            break;
    }

}

public class Especialidad
{
    public string Nombre { get; set; }

    public Especialidad(string nombre)
    {
        Nombre = nombre;
    }
}

public class Paciente
{
    public int Dni { get; set; }
    public string Nombre { get; set; }
    public int NroHistoria { get; set; }

    //  Contructor
    public Paciente(int dni, string nombre)
    {
        Dni = dni;
        Nombre = nombre;
        NroHistoria = new Random().Next(1, 10000);
    }
    // Constructor vacío 
    public Paciente()
    {
        Nombre = "---";
    }

}

public class Hospital
{
    public List<Paciente> Pacientes { get; set; }
    public List<Especialidad> Especialdades { get; set; }

    public List<string> Doctores { get; set; }

    //  Constructor
    public Hospital(List<Paciente> pacientes, List<Especialidad> especialidades, List<string> doctores)
    {
        Pacientes = pacientes;
        Especialdades = especialidades;
        Doctores = doctores;
    }
}

public class CitaMedica
{
    public int Id { get; set; }
    public Paciente Paciente { get; set; }
    public Especialidad Especialidad { get; set; }
    public string Doctor { get; set; }
    public DateTime Horario { get; set; }

    // Constructor
    public CitaMedica(int id, Paciente paciente, Especialidad especialidad, string doctor, DateTime horario)
    {
        Id = id;
        Paciente = paciente;
        Especialidad = especialidad;
        Doctor = doctor;
        Horario = horario;
    }
}

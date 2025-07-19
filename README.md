Descripcion de ConsoleApp004: Sistema de gestion de hospital

Funcionalidades:
- Registrar paciente
    * Solicita los datos necesarios para registrar un nuevo paciente (Dni, Nombre)
    * Genera el N° de Historia de forma automática
    * Guarda al paciente en la Base de Datos
    <img width="543" height="128" alt="image" src="https://github.com/user-attachments/assets/edae3103-52f1-4491-aa20-e2ab507410a4" />

- Ver registro de pacientes
    * Muestra todos los pacientes de la Base de Datos
    <img width="578" height="313" alt="image" src="https://github.com/user-attachments/assets/89f416b5-1a00-4a51-bc23-42ddd202ec35" /> 
 
- Agendar cita médica
    * Solicita el DNI del paciente
    * Corrobora que este registrado en la Base de Datos
    * Solicita la Especialidad y el Doctor de interés en la cita
    * Muestra las citas disponibles que cumplan con la informacion brindada
    * Se selecciona la cita y se registra en la Base de Datos
    * Opcional: En caso de no contar con citas disponibles → Solicitar los datos necesarios para registrar una nueva cita (Paciente, Especialidad, Doctor, Horario)
- Ver citas médicas agendadas
    * Muestra todos las citas agendadas

Clases desarrolladas:
- Especialidad
    * Nombre
- Paciente
    * Dni
    * Nombre
    * NroHistoria
- Hospital
    * Lista de Pacientes
    * Lista de Especialidades
    * Lista de Doctores
- CitaMedica
    * Id
    * Paciente
    * Especialidad
    * Doctor
    * Horario

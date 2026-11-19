 Agenda Médica, Medical Dreams

Aplicación de escritorio desarrollada en C# que se conecta a una base de datos MySQL para gestionar pacientes, personal hospitalario, turnos y citas médicas.

 Descripción

El sistema centraliza la información de un centro médico y permite organizar la atención de los pacientes y la planificación del personal. La persistencia de datos se realiza en MySQL mediante el conector oficial `MySql.Data`.

Funcionalidades

- Pacientes: registro y consulta de datos personales, contacto y estado (activo o inactivo).
- Personal: consulta del personal del hospital por departamento, rol y especialidad.
- Turnos y horarios:definición de turnos (mañana, tarde y noche) y asignación de horarios por persona y fecha.
- Citas médicas:programación de citas con un médico, con tipo (presencial, virtual o urgencia), nivel de gravedad y estado (programada, confirmada, atendida, cancelada, no asistió o reprogramada).
- Intercambios y relevos: solicitud de cambios de turno entre compañeros y registro de entregas de turno.

 Requisitos

| Componente | Versión |
|---|---|
| Visual Studio | Con la carga de trabajo de escritorio de .NET |
| MySQL Server | 8.0 o superior |
| MySQL Workbench | Para ejecutar el script de la base de datos |
| Paquete NuGet | MySql.Data |

Instalación

1. Abrir MySQL Workbench y ejecutar el script `agenda_medica_completo.sql`. Este crea la base de datos `agenda_medica`, sus tablas y los datos iniciales.
2. Abrir la solución en Visual Studio.
3. Verificar que el paquete NuGet `MySql.Data` esté instalado.
4. Configurar en la cadena de conexión el usuario y la contraseña del servidor MySQL local.
5. Compilar la solución (Build > Rebuild Solution) y ejecutarla (Start).

Base de datos

La base de datos `agenda_medica` está compuesta por nueve tablas:

| Tabla | Descripción |
|---|---|
| `pacientes` | Datos de los pacientes |
| `personal` | Médicos, enfermería y personal administrativo |
| `departamentos` | Áreas del hospital |
| `roles` | Puestos del personal e indicador de atención de citas |
| `turnos` | Hora de inicio y fin de cada turno |
| `horarios` | Asignación de turnos al personal por fecha |
| `citas` | Citas entre pacientes y médicos |
| `intercambios` | Solicitudes de cambio de turno |
| `relevos` | Entregas de turno entre compañeros |

El script incluye datos iniciales para todas las tablas, excepto `citas`, que se completa desde la aplicación.

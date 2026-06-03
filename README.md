# SistemaNomina — Sistema Bancario

## Resumen

**SistemaNomina** es una aplicación de gestión bancaria desarrollada en .NET Framework 4.7.2 que administra clientes, cuentas bancarias y trabajadores/empleados. Implementa principios de diseño orientado a objetos con herencia, clases abstractas y polimorfismo para modelar las entidades del dominio bancario.

## Propósito

- Demostrar patrones OOP en un contexto bancario (herencia de Persona, cuentas polimórficas, roles de empleados).
- Gestionar operaciones bancarias: apertura de cuentas, transacciones, estado de clientes.
- Proporcionar interfaz administrativo mediante Windows Forms para gestión integral del banco.

## Características principales

- **Gestión de Clientes**: Crear, editar, listar clientes del banco.
- **Gestión de Cuentas**: Abrir y administrar cuentas bancarias (ahorros, corriente, inversión, etc.).
- **Gestión de Trabajadores/Empleados**: Administrar empleados del banco con roles diferenciados.
- **Transacciones**: Registrar operaciones bancarias (depósitos, retiros, transferencias).
- **Interfaz Administrativa**: Formulario principal (frmAdmin) para operaciones CRUD.

## Estructura del proyecto

```
HerenciaSistemaNomina/
├── Formularios/
│   ├── frmAdmin.cs               (Formulario administrativo principal)
│   ├── frmAdmin.Designer.cs
│   └── frmAdmin.resx
├── Modelos/                       (Clases de dominio esperadas)
│   ├── Persona.cs                (Clase abstracta base)
│   ├── Cliente.cs                (Hereda de Persona)
│   ├── Empleado.cs               (Hereda de Persona)
│   ├── Cuenta.cs                 (Clase abstracta base)
│   └── [Tipos de Cuenta].cs      (CuentaAhorros, CuentaCorriente, etc.)
├── Servicios/                     (Lógica de negocio)
│   ├── ClienteService.cs
│   ├── CuentaService.cs
│   └── EmpleadoService.cs
├── Datos/                         (Acceso a datos)
│   ├── RepositorioCliente.cs
│   ├── RepositorioCuenta.cs
│   └── RepositorioEmpleado.cs
├── Program.cs
├── App.config
└── ClaseAbstractaSistemaNomina.csproj
```

## Tecnologías y configuración

| Característica | Valor |
|---|---|
| **Plataforma** | .NET Framework 4.7.2 |
| **Interfaz** | Windows Forms (WinForms) |
| **IDE** | Visual Studio 2019 o superior (Community Edition válida) |
| **Control de versiones** | Git |
| **Repositorio** | https://github.com/bojeda227/SistemaNomina |
| **Rama principal** | main |

## Conceptos clave del diseño

### Clases abstractas
- **Persona**: Clase base abstracta con propiedades comunes (Nombre, Apellido, DNI/ID, Teléfono, Email).
  - Métodos abstractos: `ObtenerInformacion()`, posiblemente `CalcularComisión()` o similar.

- **Cuenta**: Clase base abstracta para diferentes tipos de cuentas bancarias.
  - Propiedades: Número de cuenta, Saldo, Titular, Fecha de apertura, Tasa de interés.
  - Métodos abstractos: `Depositar()`, `Retirar()`, `CalcularInteres()`.

### Entidades principales
- **Cliente** (Persona): Titular de cuentas, cliente del banco.
- **Empleado** (Persona): Trabajador del banco con rol específico (ejecutivo, gerente, operario, etc.).
- **Cuenta**: Producto bancario asociado a un cliente.
- **Transacción**: Registro de movimientos (depósitos, retiros, transferencias).

### Patrones de diseño
- **Herencia**: Cliente y Empleado heredan de Persona.
- **Polimorfismo**: Múltiples tipos de cuentas con comportamientos específicos.
- **Repository Pattern** (esperado): Separación de acceso a datos.
- **Service Layer** (esperado): Lógica de negocio en servicios.

## Cómo ejecutar

1. **Clonar el repositorio**:
```powershell
git clone https://github.com/bojeda227/SistemaNomina.git
cd SistemaNomina
```

2. **Abrir en Visual Studio**:
   - Abrir `HerenciaSistemaNomina\ClaseAbstractaSistemaNomina.csproj`
   - Verificar que el framework objetivo es .NET Framework 4.7.2

3. **Compilar**:
   - Build → Build Solution (Ctrl+Shift+B)

4. **Ejecutar**:
   - Debug → Start Debugging (F5)
   - Se abrirá el formulario administrativo (`frmAdmin`)

5. **Usar la aplicación**:
   - Crear clientes en el sistema
   - Abrir cuentas bancarias para los clientes
   - Registrar empleados del banco
   - Realizar transacciones bancarias

## Guía de uso rápida

### Crear un Cliente
1. Ir a menú **Clientes** → **Nuevo**
2. Completar datos personales (nombre, apellido, DNI)
3. Guardar cliente

### Abrir una Cuenta
1. Ir a menú **Cuentas** → **Nueva**
2. Seleccionar cliente titular
3. Elegir tipo de cuenta (Ahorros, Corriente, Inversión)
4. Establecer saldo inicial
5. Guardar cuenta

### Realizar una Transacción
1. Ir a menú **Transacciones** → **Nueva**
2. Seleccionar cuenta de origen
3. Indicar tipo (Depósito, Retiro, Transferencia)
4. Ingresar monto
5. Confirmar operación

### Gestionar Empleados
1. Ir a menú **Empleados** → **Nuevo**
2. Completar datos del empleado
3. Asignar rol (Ejecutivo, Gerente, Operario)
4. Guardar

## Cómo extender el proyecto

### Añadir un nuevo tipo de cuenta
1. Crear nueva clase que herede de `Cuenta` (ej: `CuentaPlazoFijo.cs`)
2. Implementar métodos abstractos con lógica específica
3. Registrar en `CuentaService`
4. Añadir opción en formulario de creación de cuentas

### Añadir funcionalidad de intereses
1. Implementar método `CalcularInteres()` en cada tipo de cuenta
2. Crear servicio de cálculo de intereses diarios/mensuales
3. Ejecutar en tarea programada o manualmente desde menú

### Integrar base de datos
1. Crear modelo Entity Framework
2. Reemplazar repositorios en-memoria con `DbContext`
3. Configurar cadena de conexión en `App.config`
4. Ejecutar migraciones

### Añadir reportes
1. Crear formulario de reportes (`frmReportes.cs`)
2. Implementar métodos para generar:
   - Estado de cuentas
   - Historial de transacciones
   - Resumen de clientes
   - Análisis de empleados

## Validaciones recomendadas

- Verificar DNI único para clientes y empleados
- Validar saldo suficiente antes de retiros
- Evitar cuentas duplicadas para un cliente
- Controlar límites de transacciones por tipo de cuenta
- Registrar intentos fallidos de transacciones
- Validar roles de empleados antes de operaciones críticas

## Estructura de datos esperada

### Tabla Personas (base)
```
- IdPersona (PK)
- Nombre
- Apellido
- DNI
- Teléfono
- Email
- Tipo (Cliente/Empleado)
- FechaRegistro
```

### Tabla Clientes
```
- IdCliente (FK a Personas)
- Estado (Activo/Inactivo)
- FechaAfiliacion
- LímiteCrédito (opcional)
```

### Tabla Empleados
```
- IdEmpleado (FK a Personas)
- Rol (Ejecutivo/Gerente/Operario)
- Salario
- FechaContratacion
- Departamento
```

### Tabla Cuentas
```
- NumeroCuenta (PK)
- IdCliente (FK)
- Tipo (Ahorros/Corriente/Inversión)
- Saldo
- TasaInteres
- FechaApertura
- Estado (Activa/Inactiva)
```

### Tabla Transacciones
```
- IdTransaccion (PK)
- NumeroCuenta (FK)
- Tipo (Depósito/Retiro/Transferencia)
- Monto
- Fecha
- IdEmpleado (FK, quien procesa)
- Descripción
```

## Notas de mantenimiento

- Mantener reglas de negocio en clases de servicio, no en formularios
- Documentar métodos públicos con comentarios XML
- Usar enums para estados, tipos de cuenta, roles de empleado, etc.
- Implementar logging para operaciones críticas (transacciones)
- Validar todas las entradas antes de procesar

## Estructura de carpetas sugerida (si no existe)

```
HerenciaSistemaNomina/
├── Modelos/
├── Servicios/
├── Datos/
├── Formularios/
├── Excepciones/
├── Constantes/
└── Utilidades/
```

## Requisitos previos

- Visual Studio 2019 o superior (Community Edition válida)
- .NET Framework 4.7.2 instalado
- Git

## Contribuciones

Las contribuciones son bienvenidas. Por favor:
1. Fork el repositorio
2. Crear rama para tu feature (`git checkout -b feature/NuevaFuncionalidad`)
3. Commit tus cambios (`git commit -m 'Añadir nueva funcionalidad'`)
4. Push a la rama (`git push origin feature/NuevaFuncionalidad`)
5. Abrir Pull Request con descripción clara

## Roadmap futuro

- [ ] Integración con base de datos SQL Server
- [ ] Sistema de autenticación de usuarios
- [ ] Control de permisos por rol de empleado
- [ ] Generación de reportes en PDF
- [ ] API REST para acceso remoto
- [ ] Integración con servicios de terceros
- [ ] Módulo de auditoría y cumplimiento normativo

## Contacto y soporte

- **Repositorio**: https://github.com/bojeda227/SistemaNomina
- **Rama principal**: main
- **Issues**: Reportar bugs en la sección de Issues del repositorio
- **Licencia**: Especificar según tus necesidades (MIT, Apache 2.0, etc.)

---

**Nota**: Este proyecto es de carácter educativo y demostrativo. Para producción, considerar implementar medidas de seguridad, encriptación, auditoría y cumplimiento de normativas bancarias.


# ESPECIFICACIONES DEL SISTEMA BANCARIO

## Versión: 1.0
## Fecha: 2024
## Estado: Activo

---

## 1. DESCRIPCIÓN GENERAL

**SistemaNomina** es una aplicación de gestión bancaria desarrollada en .NET Framework 4.7.2 con interfaz Windows Forms. El sistema permite administrar clientes, cuentas bancarias y transacciones básicas.

---

## 2. REQUISITOS FUNCIONALES

### 2.1 Gestión de Clientes

#### RF2.1.1: Crear Cliente
- **Descripción**: El sistema debe permitir crear un nuevo cliente en el banco.
- **Datos requeridos**:
  - Nombre
  - Apellidos
  - Cédula/DNI (único en el sistema)
  - Fecha de nacimiento
  - Sexo
  - Estado civil
  - Dirección
  - Teléfono
  - Fecha de afiliación (automática al crear)
  - Estado (por defecto: "Activo")

#### RF2.1.2: Editar Cliente
- **Descripción**: Modificar información de un cliente existente.
- **Restricciones**:
  - No se puede cambiar la cédula si ya existe otra con ese valor
  - La fecha de afiliación no se puede modificar

#### RF2.1.3: Listar Clientes
- **Descripción**: Mostrar todos los clientes del sistema.
- **Información mostrada**:
  - ID de cliente
  - Nombre completo
  - Cédula
  - Estado (Activo/Inactivo)
  - Cantidad de cuentas asociadas

#### RF2.1.4: Eliminar Cliente (CON CASCADA)
- **Descripción**: Eliminar un cliente del sistema.
- **Comportamiento especial**:
  - **CRÍTICO**: Al eliminar un cliente, DEBEN eliminarse TODAS las cuentas asociadas.
  - Se deben registrar todos los movimientos antes de eliminar.
  - Validar que no existan transacciones pendientes.

#### RF2.1.5: Consultar Datos de Cliente
- **Descripción**: Ver información detallada de un cliente.
- **Información incluida**:
  - Datos personales
  - Cantidad de cuentas activas
  - Saldo total en todas sus cuentas
  - Fecha de última transacción

---

### 2.2 Gestión de Cuentas

#### RF2.2.1: Crear Cuenta
- **Descripción**: Abrir una nueva cuenta bancaria para un cliente.
- **Datos requeridos**:
  - Cliente titular (obligatorio)
  - Tipo de cuenta (Ahorros, Corriente, Inversión, etc.)
  - Saldo inicial (puede ser 0)
  - Tasa de interés (por defecto según tipo)

#### RF2.2.2: Número de Cuenta Automático
- **Descripción**: El número de cuenta debe generarse automáticamente.
- **Formato del número de cuenta**:
  - Estructura: `AAAA-BBBBB`
  - Donde:
	- `AAAA` = Año actual (ej: 2024)
	- `BBBBB` = Secuencial único de 5 dígitos (ej: 00001, 00002, etc.)
  - Ejemplo: `2024-00001`, `2024-00002`, `2024-01250`, etc.
- **Características**:
  - Número único en el sistema
  - Generado automáticamente sin intervención del usuario
  - No editable
  - Persiste durante toda la vida útil de la cuenta

#### RF2.2.3: Una Cuenta Pertenece a UN Cliente
- **Descripción**: Una cuenta bancaria es propiedad de un único cliente.
- **Relación**: N cuentas pueden pertenecer a 1 cliente (relación 1:N)
- **Restricciones**:
  - Una cuenta no puede cambiar de titular
  - Una cuenta no puede pertenecer a múltiples clientes

#### RF2.2.4: Un Cliente Puede Tener Múltiples Cuentas
- **Descripción**: Un cliente puede abrir varias cuentas en el banco.
- **Límites**:
  - Sin límite máximo de cuentas por cliente
  - Se deben mostrar todas las cuentas del cliente en su perfil

#### RF2.2.5: Eliminar Cuenta
- **Descripción**: Cerrar/eliminar una cuenta bancaria específica.
- **Validaciones**:
  - No se puede eliminar si tiene saldo positivo (excepto con confirmación)
  - Se registra la fecha de cierre
  - Se mantiene en el sistema como "Cerrada"

#### RF2.2.6: Listar Cuentas por Cliente
- **Descripción**: Mostrar todas las cuentas de un cliente específico.
- **Información mostrada**:
  - Número de cuenta
  - Tipo de cuenta
  - Saldo actual
  - Tasa de interés
  - Estado (Activa/Cerrada)
  - Fecha de apertura

#### RF2.2.7: Consultar Saldo de Cuenta
- **Descripción**: Obtener el saldo actual de una cuenta.
- **Dato retornado**: Saldo en formato decimal (dos decimales)

---

### 2.3 Transacciones

#### RF2.3.1: Depósito
- **Descripción**: Ingresar dinero en una cuenta.
- **Validaciones**:
  - Monto > 0
  - Cuenta debe estar activa
- **Registro**: Se registra en historial de movimientos

#### RF2.3.2: Retiro
- **Descripción**: Sacar dinero de una cuenta.
- **Validaciones**:
  - Monto > 0
  - Monto ≤ Saldo actual
  - Cuenta debe estar activa
- **Registro**: Se registra en historial de movimientos

#### RF2.3.3: Transferencia
- **Descripción**: Transferir dinero entre cuentas.
- **Validaciones**:
  - Cuenta origen debe tener saldo suficiente
  - Ambas cuentas deben estar activas
  - Cuenta origen ≠ Cuenta destino
- **Registro**: Se registra en ambas cuentas

#### RF2.3.4: Historial de Movimientos
- **Descripción**: Registrar cada transacción en una cuenta.
- **Información por movimiento**:
  - Fecha y hora (formato: dd/MM/yyyy HH:mm:ss)
  - Tipo de movimiento (Depósito, Retiro, Transferencia)
  - Monto
  - Saldo resultante
  - Descripción (si aplica)

---

### 2.4 Eliminación en Cascada (CRÍTICO)

#### RF2.4.1: Cascada de Eliminación
- **Escenario**: Cuando se elimina un cliente
- **Acción automática**:
  - Se identifican todas las cuentas del cliente
  - Se valida que se puedan eliminar
  - Se registra información de eliminación
  - Se eliminan TODAS las cuentas
  - Se elimina el cliente del sistema
- **No se puede hacer**: No se puede eliminar un cliente sin eliminar sus cuentas primero

#### RF2.4.2: Transacciones Relacionadas
- **Descripción**: Al eliminar cuenta, se mantiene historial
- **Comportamiento**:
  - Los movimientos no se eliminan (solo si se especifica)
  - Se marca la cuenta como "Eliminada"
  - Se guarda timestamp de eliminación

---

## 3. REQUISITOS NO FUNCIONALES

### 3.1 Rendimiento
- Carga de cliente con todas sus cuentas: < 100 ms
- Búsqueda de cliente: < 50 ms
- Generar número de cuenta: < 10 ms

### 3.2 Seguridad
- Validar entrada de datos
- No permitir caracteres especiales en ciertos campos
- Encriptar datos sensibles (si futura mejora)

### 3.3 Disponibilidad
- Sistema debe estar disponible durante horario bancario
- Mantenimiento máximo 1 hora por semana

### 3.4 Escalabilidad
- Soportar hasta 10,000 clientes
- Soportar hasta 100,000 cuentas
- Soportar hasta 1,000,000 transacciones

---

## 4. ESTRUCTURA DE DATOS

### 4.1 Clase Persona (Abstracta - Base)

```csharp
public abstract class Persona
{
	- IdCodigo: string (identificador único)
	- Cedula: string (único en sistema)
	- Nombre: string
	- Apellidos: string
	- FechaNacimiento: DateTime
	- Sexo: char (M/F)
	- EstadoCivil: string
	- Direccion: string
	- Telefono: string
	- Tipo: string (discriminador)
}
```

### 4.2 Clase Cliente (Hereda de Persona)

```csharp
public class Cliente : Persona
{
	- Cuentas: List<Cuenta> (colección de cuentas)
	- FechaAfiliacion: DateTime (no editable)
	- Estado: string (Activo/Inactivo)

	Métodos:
	+ AñadirCuenta(Cuenta): void
	+ ObtenerCuenta(numeroCuenta): Cuenta
	+ EliminarTodasLasCuentas(): void (CASCADA)
	+ ObtenerSaldoTotal(): decimal
}
```

### 4.3 Clase Cuenta

```csharp
public class Cuenta
{
	- NumeroCuenta: string (generado automáticamente, formato AAAA-BBBBB)
	- Saldo: decimal
	- FechaApertura: DateTime
	- Tipo: string (Ahorros/Corriente/Inversión/etc)
	- TasaInteres: decimal
	- Estado: string (Activa/Cerrada)
	- Movimientos: List<string> (historial)

	Métodos:
	+ GenerarNumeroCuenta(): string (estático)
	+ Depositar(monto): bool
	+ Retirar(monto): bool
	+ CalcularInteres(): decimal
	+ AplicarInteres(): void
	+ ObtenerHistorialMovimientos(): List<string>
}
```

### 4.4 Relaciones de Entidades

```
┌─────────────┐         1 ──→ N      ┌──────────┐
│   Cliente   │ ◄─────────────────→  │ Cuenta   │
└─────────────┘                      └──────────┘
	(Persona)              
```

- **Relación**: Uno a Muchos (1:N)
- **Cliente**: Puede tener 0 o más cuentas
- **Cuenta**: Pertenece a exactamente 1 cliente
- **Integridad Referencial**: Al eliminar cliente, se eliminan sus cuentas

---

## 5. FLUJOS DE NEGOCIO CRÍTICOS

### 5.1 Crear Cliente y Cuenta

```
1. Usuario selecciona "Crear Cliente"
2. Ingresa datos personales
3. Valida que cédula sea única
4. Guarda cliente en sistema
5. Sistema asigna IdCodigo automático
6. Usuario puede crear cuentas para el cliente
7. Al crear cuenta:
   a. Sistema genera NumeroCuenta (AAAA-BBBBB)
   b. Valida datos de la cuenta
   c. Asigna cuenta al cliente
   d. Guarda en sistema
```

### 5.2 Eliminar Cliente (CON CASCADA)

```
1. Usuario selecciona cliente a eliminar
2. Sistema valida que sea posible eliminar
3. Sistema identifica TODAS las cuentas del cliente
4. Para cada cuenta:
   a. Registra información (movimientos, saldo, etc.)
   b. Marca como "eliminada" o la quita del sistema
5. Elimina todas las cuentas de la lista del cliente
6. Elimina el cliente del sistema
7. Muestra confirmación de éxito
```

### 5.3 Realizar Transacción

```
1. Usuario selecciona cuenta
2. Elige tipo de transacción (Depósito/Retiro/Transferencia)
3. Ingresa monto
4. Sistema valida:
   - Monto > 0
   - Cuenta activa
   - Saldo suficiente (si retiro/transferencia)
5. Ejecuta transacción
6. Registra en historial de movimientos
7. Actualiza saldo
8. Muestra confirmación
```

---

## 6. REGLAS DE NEGOCIO

| Regla | Descripción | Validación |
|-------|-------------|-----------|
| RN-001 | Un cliente puede tener N cuentas | No hay límite superior |
| RN-002 | Cédula de cliente es única | Validar antes de crear |
| RN-003 | Número de cuenta se genera automático | Formato: AAAA-BBBBB |
| RN-004 | Al eliminar cliente, se eliminan sus cuentas | Cascada obligatoria |
| RN-005 | Saldo de cuenta no puede ser negativo | Validar en retiros |
| RN-006 | Transacción válida si monto > 0 | Rechazar montos ≤ 0 |
| RN-007 | Cuenta activa para transacciones | No transaccionar en cerradas |
| RN-008 | Historial es inmutable | No editar movimientos históricos |
| RN-009 | Estado de cliente: Activo/Inactivo | Validar antes de operar |
| RN-010 | Tasa de interés por tipo de cuenta | Valor por defecto según tipo |

---

## 7. CASOS DE USO PRINCIPALES

### Caso de Uso 1: Crear Cliente
- **Actor**: Usuario administrativo
- **Precondición**: Usuario autenticado
- **Flujo Principal**:
  1. Usuario selecciona "Nuevo Cliente"
  2. Completa formulario
  3. Sistema valida datos
  4. Sistema crea cliente con IdCodigo único
  5. Muestra éxito
- **Postcondición**: Cliente creado en sistema

### Caso de Uso 2: Abrir Cuenta
- **Actor**: Usuario administrativo
- **Precondición**: Cliente existe
- **Flujo Principal**:
  1. Usuario selecciona cliente
  2. Elige "Nueva Cuenta"
  3. Completa datos de cuenta
  4. Sistema genera NumeroCuenta automático
  5. Sistema asigna cuenta al cliente
  6. Muestra número de cuenta generado
- **Postcondición**: Cuenta abierta y asociada a cliente

### Caso de Uso 3: Eliminar Cliente
- **Actor**: Usuario administrativo
- **Precondición**: Cliente existe
- **Flujo Principal**:
  1. Usuario selecciona cliente
  2. Elige "Eliminar Cliente"
  3. Sistema solicita confirmación
  4. Sistema identifica todas las cuentas
  5. Sistema elimina todas las cuentas (CASCADA)
  6. Sistema elimina cliente
  7. Muestra confirmación de eliminación
- **Postcondición**: Cliente y todas sus cuentas eliminadas

### Caso de Uso 4: Realizar Transacción
- **Actor**: Usuario administrativo/Cliente
- **Precondición**: Cuenta activa existe
- **Flujo Principal**:
  1. Usuario selecciona cuenta
  2. Elige tipo de transacción
  3. Ingresa monto
  4. Sistema valida
  5. Sistema ejecuta transacción
  6. Sistema registra en historial
  7. Muestra confirmación
- **Postcondición**: Transacción registrada

---

## 8. VALIDACIONES Y RESTRICCIONES

### 8.1 Validaciones de Cliente
- ✓ Nombre: 2-100 caracteres, solo letras y espacios
- ✓ Apellidos: 2-100 caracteres, solo letras y espacios
- ✓ Cédula: 10 dígitos, único en sistema
- ✓ Teléfono: 7-15 dígitos
- ✓ Edad mínima: 18 años
- ✓ Edad máxima: 120 años

### 8.2 Validaciones de Cuenta
- ✓ Tipo de cuenta: valores predefinidos (Ahorros, Corriente, Inversión)
- ✓ Saldo inicial: ≥ 0
- ✓ Tasa de interés: 0-15%
- ✓ Número de cuenta: no editable

### 8.3 Validaciones de Transacciones
- ✓ Monto: > 0
- ✓ Saldo suficiente: para retiros y transferencias
- ✓ Cuenta activa: no transaccionar en cuentas cerradas
- ✓ Cuenta existe: validar número de cuenta

---

## 9. INTERFAZ DE USUARIO

### 9.1 Formulario Principal (frmAdmin)

**Elementos**:
- Menú de navegación
- Opciones: Clientes, Cuentas, Transacciones, Reportes
- DataGridView para listar datos
- Botones: Crear, Editar, Eliminar, Ver Detalle

### 9.2 Formulario de Cliente

**Campos**:
- Nombre
- Apellidos
- Cédula
- Fecha Nacimiento
- Sexo (ComboBox)
- Estado Civil (ComboBox)
- Dirección
- Teléfono
- Estado (Activo/Inactivo)

**Botones**:
- Guardar
- Cancelar
- Mostrar Cuentas

### 9.3 Formulario de Cuenta

**Campos**:
- Cliente (ComboBox - automático)
- Número Cuenta (solo lectura, generado)
- Tipo (ComboBox: Ahorros, Corriente, Inversión)
- Saldo Inicial
- Tasa Interés (solo lectura o automático)
- Estado (solo lectura)

**Botones**:
- Crear Cuenta
- Cancelar

### 9.4 Formulario de Transacción

**Campos**:
- Número Cuenta (ComboBox/búsqueda)
- Tipo Transacción (ComboBox: Depósito, Retiro, Transferencia)
- Monto
- Descripción (opcional)

**Botones**:
- Ejecutar
- Cancelar

---

## 10. REGLAS DE ELIMINACIÓN EN CASCADA

### 10.1 Eliminación de Cliente

| Acción | Tipo | Descripción |
|--------|------|-------------|
| Eliminar Cliente | Principal | Se elimina el registro de cliente |
| Eliminar Cuentas | Cascada | Se eliminan TODAS las cuentas vinculadas |
| Registrar Log | Auditoría | Se registra quién y cuándo eliminó |

### 10.2 Secuencia de Eliminación

```
1. Validar que cliente existe
2. Validar que se puede eliminar
3. Obtener todas las cuentas del cliente
4. Para cada cuenta:
   - Registrar información de eliminación
   - Guardar en log/auditoría
   - Marcar como eliminada o remover
5. Limpiar lista de cuentas del cliente
6. Eliminar cliente del sistema
7. Registrar evento de eliminación
8. Retornar confirmación
```

---

## 11. ESPECIFICACIONES TÉCNICAS

### 11.1 Generación de Número de Cuenta

```csharp
// Formato esperado: AAAA-BBBBB
// Ejemplo: 2024-00001, 2024-00002, etc.

private static int contadorCuentas = 1000;

private static string GenerarNumeroCuenta()
{
	contadorCuentas++;
	return $"{DateTime.Now.Year}-{contadorCuentas:D5}";
}
```

### 11.2 Método de Eliminación en Cascada

```csharp
public bool EliminarCliente(string idCodigo)
{
	var cliente = ObtenerClientePorId(idCodigo);
	if (cliente != null)
	{
		// CASCADA: Eliminar todas las cuentas
		cliente.EliminarTodasLasCuentas();

		// Eliminar cliente del sistema
		listaClientes.Remove(cliente);
		return true;
	}
	return false;
}
```

---

## 12. EJEMPLOS DE DATOS

### 12.1 Cliente Ejemplo

```
IdCodigo: CLI-001
Cedula: 1723456789
Nombre: Juan
Apellidos: Pérez García
FechaNacimiento: 1990-05-15
Sexo: M
EstadoCivil: Soltero
Dirección: Av. Principal 123
Teléfono: 0998765432
FechaAfiliacion: 2024-01-15
Estado: Activo
```

### 12.2 Cuentas del Cliente

```
Cuenta 1:
  NumeroCuenta: 2024-00001
  Tipo: Ahorros
  Saldo: $5,000.00
  TasaInteres: 3.5%
  FechaApertura: 2024-01-20
  Estado: Activa

Cuenta 2:
  NumeroCuenta: 2024-00002
  Tipo: Corriente
  Saldo: $15,750.50
  TasaInteres: 0%
  FechaApertura: 2024-02-01
  Estado: Activa

Cuenta 3:
  NumeroCuenta: 2024-00003
  Tipo: Inversión
  Saldo: $25,000.00
  TasaInteres: 7.5%
  FechaApertura: 2024-03-10
  Estado: Activa
```

---

## 13. CONSIDERACIONES DE IMPLEMENTACIÓN

### 13.1 Almacenamiento
- Actualmente: en memoria (List<>)
- Futuro: Base de datos relacional (SQL Server, SQLite)
- Entity Framework para mapeo O/R

### 13.2 Persistencia
- Guardar datos en archivo (XML/JSON) como respaldo
- Implementar serialización
- Manejar excepciones de I/O

### 13.3 Validación
- Validar en formulario (UI)
- Validar en lógica de negocio (Controladores)
- Doble validación para integridad

### 13.4 Logging
- Registrar operaciones CRUD
- Registrar eliminaciones (especialmente cascadas)
- Auditoría de transacciones

---

## 14. ROADMAP FUTURO

- [ ] Persistencia en base de datos
- [ ] Autenticación de usuarios
- [ ] Reportes PDF/Excel
- [ ] API REST
- [ ] Integración con servicios externos
- [ ] Cálculo automático de intereses
- [ ] Notificaciones por email
- [ ] Backup automático
- [ ] Seguridad mejorada (encriptación)
- [ ] Módulo de auditoría completo

---

## 15. CONTACTO Y REFERENCIAS

**Repositorio**: https://github.com/bojeda227/SistemaNomina  
**Rama**: main  
**Versión**: 1.0  
**Última actualización**: 2024  

---

**Fin del Documento de Especificaciones**

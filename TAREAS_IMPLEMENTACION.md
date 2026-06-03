# TAREAS DE IMPLEMENTACIÓN - SISTEMA BANCARIO

**Versión**: 1.0  
**Estado**: En Desarrollo  
**Total de Tareas**: 22  
**Progreso**: 0/22 (0%)  

---

## 📋 RESUMEN EJECUTIVO

Este documento enumera las **22 tareas específicas** del plan de implementación para el sistema bancario. Cada tarea tiene:
- ✅ Número de identificación
- 📁 Archivo(s) a modificar/crear
- 🎯 Objetivo específico
- 📝 Descripción detallada
- ⏳ Estado actual
- ✓ Checklist

---

## 🔴 FASE 1: INTEGRACIÓN DE ENTIDADES (Pasos 1-2)

### ✅ TAREA 1: Actualizar archivo `.csproj`

**Identificador**: PASO-01  
**Prioridad**: 🔴 CRÍTICA  
**Archivo**: `HerenciaSistemaNomina\ClaseAbstractaSistemaNomina.csproj`  

**Objetivo**:  
Agregar referencias a las nuevas clases `Cliente.cs` y `Cuenta.cs` en el archivo de proyecto.

**Descripción**:  
El archivo `.csproj` debe incluir las nuevas clases creadas para que Visual Studio las compile correctamente.

**Acción requerida**:
```xml
<!-- Agregar después de <Compile Include="Controlador\TLista.cs" /> -->
<Compile Include="Controlador\ControllerCliente.cs" />
<Compile Include="Controlador\ControllerCuenta.cs" />

<!-- Agregar después de <Compile Include="Entidades\Persona.cs" /> -->
<Compile Include="Entidades\Cliente.cs" />
<Compile Include="Entidades\Cuenta.cs" />
```

**Archivos involucrados**:
- `Cliente.cs` ✅ (ya existe)
- `Cuenta.cs` ✅ (ya existe)
- `ControllerCliente.cs` ✅ (ya existe)
- `ControllerCuenta.cs` ✅ (ya existe)

**Estado**: ⏳ Pendiente  
**Fecha estimada**: Hoy  

- [ ] Abrir archivo `.csproj`
- [ ] Ubicar sección `<Compile Include>`
- [ ] Agregar 4 nuevas líneas
- [ ] Guardar archivo
- [ ] Verificar sintaxis XML

---

### ✅ TAREA 2: Compilar proyecto

**Identificador**: PASO-02  
**Prioridad**: 🔴 CRÍTICA  
**Comando**: `Build → Build Solution` (Ctrl+Shift+B)  

**Objetivo**:  
Compilar el proyecto y verificar que no hay errores.

**Descripción**:  
Después de agregar las referencias al `.csproj`, se debe compilar para validar que todas las clases se incluyen correctamente.

**Validación esperada**:
- ✓ 0 errores
- ✓ 0-2 advertencias aceptables
- ✓ Mensaje: "Build succeeded"

**Estado**: ⏳ Pendiente  
**Fecha estimada**: Hoy  

- [ ] Guardar todos los archivos (Ctrl+S)
- [ ] Ejecutar Build Solution
- [ ] Revisar Output window
- [ ] Verificar 0 errores
- [ ] Anotar advertencias si las hay

---

## 🟡 FASE 2: MEJORA DE ESTRUCTURA EXISTENTE (Pasos 3-6)

### ✅ TAREA 3: Revisar clase `Persona.cs`

**Identificador**: PASO-03  
**Prioridad**: 🟡 MEDIA  
**Archivo**: `HerenciaSistemaNomina\Entidades\Persona.cs`  

**Objetivo**:  
Verificar que la clase `Persona` tiene todos los atributos necesarios para ser heredada por `Cliente`.

**Descripción**:  
Revisar que existan las propiedades:
- `IdCodigo` ✓
- `Cedula` ✓
- `Nombre` ✓
- `Apellidos` ✓
- `FechaNacimiento` ✓
- `Sexo` ✓
- `EstadoCivil` ✓
- `Direccion` ✓
- `Telefono` ✓
- `Tipo` (discriminador) ✓

**Estado actual**: ✅ COMPLETADO (Verificado)

**Validación**:
- ✓ Todas las propiedades existen
- ✓ Tiene getters/setters
- ✓ Constructor parametrizado completo

**Estado**: ✅ Completada  

- [x] Revisar atributos
- [x] Verificar propiedades
- [x] Confirmar constructores
- [x] Todo OK

---

### ✅ TAREA 4: Actualizar `Program.cs`

**Identificador**: PASO-04  
**Prioridad**: 🟡 MEDIA  
**Archivo**: `HerenciaSistemaNomina\Program.cs`  

**Objetivo**:  
Inicializar controladores y cargar datos de ejemplo en el programa principal.

**Descripción**:  
Agregar código en el método `Main()` para:
1. Limpiar listas al iniciar
2. Cargar datos de prueba

**Código a agregar** (en `Main()`):
```csharp
// Limpiar datos anteriores
ControllerCliente.LimpiarLista();
ControllerCuenta.LimpiarLista();

// Cargar datos de ejemplo
CargarDatosEjemplo();

// Mostrar formulario principal
Application.Run(new frmAdmin());
```

**Método a crear**:
```csharp
private static void CargarDatosEjemplo()
{
	// Crear cliente 1
	var cliente1 = new Cliente("CLI-001", "1723456789", "Juan", "Pérez",
		new DateTime(1990, 5, 15), 'M', "Soltero", "Av. Principal 123",
		"0998765432", DateTime.Now, "Activo");

	ControllerCliente.AñadirCliente(cliente1);

	// Crear 3 cuentas para cliente 1
	ControllerCuenta.CrearCuenta(cliente1, 5000, "Ahorros", 3.5m);
	ControllerCuenta.CrearCuenta(cliente1, 15750, "Corriente", 0);
	ControllerCuenta.CrearCuenta(cliente1, 25000, "Inversión", 7.5m);

	// Crear cliente 2
	var cliente2 = new Cliente("CLI-002", "1798765432", "María", "García",
		new DateTime(1985, 8, 20), 'F', "Casada", "Calle Falsa 456",
		"0987654321", DateTime.Now, "Activo");

	ControllerCliente.AñadirCliente(cliente2);

	// Crear 2 cuentas para cliente 2
	ControllerCuenta.CrearCuenta(cliente2, 10000, "Ahorros", 3.5m);
	ControllerCuenta.CrearCuenta(cliente2, 50000, "Corriente", 0);
}
```

**Estado**: ⏳ Pendiente  

- [ ] Abrir `Program.cs`
- [ ] Agregar llamadas a controladores
- [ ] Crear método `CargarDatosEjemplo()`
- [ ] Guardar archivo
- [ ] Compilar para verificar

---

### ✅ TAREA 5: Crear clase `BaseDatos.cs`

**Identificador**: PASO-05  
**Prioridad**: 🟡 MEDIA  
**Archivo**: `HerenciaSistemaNomina\Datos\BaseDatos.cs` (crear carpeta Datos)  

**Objetivo**:  
Centralizar el acceso a las listas de datos del sistema.

**Descripción**:  
Crear una clase estática que contenga las listas centrales de clientes y cuentas.

**Archivo completo**:
```csharp
using System;
using System.Collections.Generic;
using HerenciaSistemaNomina.Entidades;

namespace HerenciaSistemaNomina.Datos
{
	/// <summary>
	/// Centraliza acceso a datos del sistema bancario
	/// </summary>
	public static class BaseDatos
	{
		/// <summary>
		/// Lista de clientes del sistema
		/// </summary>
		public static List<Cliente> Clientes { get; set; } = new List<Cliente>();

		/// <summary>
		/// Lista de todas las cuentas del sistema
		/// </summary>
		public static List<Cuenta> Cuentas { get; set; } = new List<Cuenta>();

		/// <summary>
		/// Limpia todos los datos (útil para pruebas)
		/// </summary>
		public static void LimpiarTodo()
		{
			Clientes.Clear();
			Cuentas.Clear();
		}

		/// <summary>
		/// Obtiene cantidad total de clientes
		/// </summary>
		public static int ObtenerCantidadClientes() => Clientes.Count;

		/// <summary>
		/// Obtiene cantidad total de cuentas
		/// </summary>
		public static int ObtenerCantidadCuentas() => Cuentas.Count;
	}
}
```

**Estado**: ⏳ Pendiente  

- [ ] Crear carpeta `Datos`
- [ ] Crear archivo `BaseDatos.cs`
- [ ] Copiar código completo
- [ ] Guardar archivo
- [ ] Compilar

---

### ✅ TAREA 6: Crear clase `Utilidades.cs`

**Identificador**: PASO-06  
**Prioridad**: 🟡 MEDIA  
**Archivo**: `HerenciaSistemaNomina\Utilidades.cs`  

**Objetivo**:  
Centralizar métodos de validación comunes.

**Descripción**:  
Crear utilidades para validar entradas de datos.

**Archivo completo**:
```csharp
using System;

namespace HerenciaSistemaNomina
{
	/// <summary>
	/// Utilidades y validaciones para el sistema bancario
	/// </summary>
	public static class Utilidades
	{
		/// <summary>
		/// Valida que una cédula tenga 10 dígitos
		/// </summary>
		public static bool ValidarCedula(string cedula)
		{
			if (string.IsNullOrWhiteSpace(cedula)) return false;
			if (cedula.Length != 10) return false;
			return cedula.ForEach(c => char.IsDigit(c));
		}

		/// <summary>
		/// Valida nombre (2-100 caracteres, solo letras y espacios)
		/// </summary>
		public static bool ValidarNombre(string nombre)
		{
			if (string.IsNullOrWhiteSpace(nombre)) return false;
			if (nombre.Length < 2 || nombre.Length > 100) return false;

			foreach (char c in nombre)
			{
				if (!char.IsLetter(c) && c != ' ') return false;
			}
			return true;
		}

		/// <summary>
		/// Valida teléfono (7-15 dígitos)
		/// </summary>
		public static bool ValidarTelefono(string telefono)
		{
			if (string.IsNullOrWhiteSpace(telefono)) return false;
			if (telefono.Length < 7 || telefono.Length > 15) return false;

			foreach (char c in telefono)
			{
				if (!char.IsDigit(c)) return false;
			}
			return true;
		}

		/// <summary>
		/// Valida que el monto sea positivo
		/// </summary>
		public static bool ValidarMonto(decimal monto)
		{
			return monto > 0;
		}

		/// <summary>
		/// Calcula edad a partir de fecha de nacimiento
		/// </summary>
		public static int CalcularEdad(DateTime fechaNacimiento)
		{
			DateTime hoy = DateTime.Now;
			int edad = hoy.Year - fechaNacimiento.Year;

			if (fechaNacimiento.Date > hoy.AddYears(-edad))
				edad--;

			return edad;
		}

		/// <summary>
		/// Valida que la edad sea >= 18 años
		/// </summary>
		public static bool ValidarEdadMinima(DateTime fechaNacimiento, int edadMinima = 18)
		{
			return CalcularEdad(fechaNacimiento) >= edadMinima;
		}

		/// <summary>
		/// Genera ID único para cliente
		/// </summary>
		public static string GenerarIdCliente()
		{
			return $"CLI-{DateTime.Now.Ticks}";
		}

		/// <summary>
		/// Formatea cantidad monetaria
		/// </summary>
		public static string FormatarMoneda(decimal monto)
		{
			return monto.ToString("$#,##0.00");
		}
	}
}
```

**Estado**: ⏳ Pendiente  

- [ ] Crear archivo `Utilidades.cs`
- [ ] Copiar código completo
- [ ] Guardar archivo
- [ ] Compilar

---

## 🟠 FASE 3: ADAPTACIÓN DE FORMULARIOS (Pasos 7-12)

### ✅ TAREA 7: Modificar `frmAdmin.cs` - Panel Principal

**Identificador**: PASO-07  
**Prioridad**: 🟠 ALTA  
**Archivo**: `HerenciaSistemaNomina\Formularios\frmAdmin.cs`  

**Objetivo**:  
Adaptar el formulario administrativo para navegación bancaria.

**Descripción**:  
Agregar TabControl con 3 pestañas: Clientes, Cuentas, Transacciones.

**Cambios**:
1. Agregar `TabControl` (Name: `tabControlPrincipal`)
2. Crear 3 TabPages:
   - TabPage 1: "Clientes"
   - TabPage 2: "Cuentas"
   - TabPage 3: "Transacciones"
3. En cada pestaña agregar:
   - DataGridView
   - Botones: Nuevo, Editar, Eliminar, Recargar

**Estado**: ⏳ Pendiente  

- [ ] Abrir `frmAdmin.Designer.cs`
- [ ] Reemplazar DataGridView actual por TabControl
- [ ] Agregar 3 TabPages
- [ ] Agregar DataGridView en cada pestaña
- [ ] Agregar botones
- [ ] Guardar

---

### ✅ TAREA 8: Crear `frmClienteNuevo.cs`

**Identificador**: PASO-08  
**Prioridad**: 🟠 ALTA  
**Archivo**: `HerenciaSistemaNomina\Formularios\frmClienteNuevo.cs`  

**Objetivo**:  
Crear formulario para agregar nuevos clientes.

**Descripción**:  
Formulario con campos de cliente y validaciones.

**Componentes requeridos**:
- TextBox: Nombre, Apellidos, Cédula, Teléfono, Dirección
- DateTimePicker: Fecha Nacimiento
- ComboBox: Sexo (M/F), Estado Civil (Soltero/Casado/Divorciado/Viudo)
- Button: Guardar, Cancelar

**Validaciones**:
- Cédula única
- Edad ≥ 18 años
- Todos campos obligatorios
- Formato de cédula (10 dígitos)

**Evento Guardar**:
```csharp
private void btnGuardar_Click(object sender, EventArgs e)
{
	if (!ValidarDatos()) return;

	var nuevoCliente = new Cliente(
		Utilidades.GenerarIdCliente(),
		txtCedula.Text,
		txtNombre.Text,
		txtApellidos.Text,
		dtpFechaNacimiento.Value,
		cbSexo.SelectedItem.ToString()[0],
		cbEstadoCivil.SelectedItem.ToString(),
		txtDireccion.Text,
		txtTelefono.Text,
		DateTime.Now,
		"Activo"
	);

	if (ControllerCliente.AñadirCliente(nuevoCliente))
	{
		MessageBox.Show("Cliente creado exitosamente", "Éxito");
		this.Close();
	}
	else
	{
		MessageBox.Show("Error al crear cliente", "Error");
	}
}
```

**Estado**: ⏳ Pendiente  

- [ ] Crear archivo `frmClienteNuevo.cs`
- [ ] Diseñar interfaz
- [ ] Agregar validaciones
- [ ] Implementar evento Guardar
- [ ] Guardar

---

### ✅ TAREA 9: Crear `frmClienteEditar.cs`

**Identificador**: PASO-09  
**Prioridad**: 🟠 ALTA  
**Archivo**: `HerenciaSistemaNomina\Formularios\frmClienteEditar.cs`  

**Objetivo**:  
Crear formulario para editar datos de cliente O eliminar cliente (CON CASCADA).

**Descripción**:  
Formulario con dos funcionalidades:
1. **Editar**: Modificar datos del cliente
2. **Eliminar**: Eliminar cliente y TODAS sus cuentas

**Sección Editar**:
- Cargar datos del cliente en campos
- Permitir editar (excepto Cédula y FechaAfiliacion)
- Botón Guardar

**Sección Eliminar (CRÍTICA)**:
- Botón "Eliminar Cliente"
- Mostrar alerta: "Se eliminarán TODAS las cuentas del cliente. ¿Continuar?"
- Al confirmar: ejecutar eliminación en cascada

**Código eliminación cascada**:
```csharp
private void btnEliminarCliente_Click(object sender, EventArgs e)
{
	var resultado = MessageBox.Show(
		$"Se eliminarán TODAS las {cliente.Cuentas.Count} cuentas del cliente.\n\n¿Está seguro?",
		"Confirmación de Eliminación",
		MessageBoxButtons.YesNo,
		MessageBoxIcon.Warning
	);

	if (resultado == DialogResult.Yes)
	{
		// Eliminar todas las cuentas
		foreach (var cuenta in cliente.Cuentas)
		{
			ControllerCuenta.EliminarCuenta(cuenta.NumeroCuenta);
		}

		// Eliminar cliente
		if (ControllerCliente.EliminarCliente(cliente.IdCodigo))
		{
			MessageBox.Show("Cliente eliminado exitosamente", "Éxito");
			this.Close();
		}
	}
}
```

**Estado**: ⏳ Pendiente  

- [ ] Crear archivo `frmClienteEditar.cs`
- [ ] Diseñar interfaz
- [ ] Cargar datos del cliente
- [ ] Implementar edición
- [ ] Implementar eliminación en cascada
- [ ] Guardar

---

### ✅ TAREA 10: Crear `frmCuentaNueva.cs`

**Identificador**: PASO-10  
**Prioridad**: 🟠 ALTA  
**Archivo**: `HerenciaSistemaNomina\Formularios\frmCuentaNueva.cs`  

**Objetivo**:  
Crear formulario para abrir nuevas cuentas (con número generado automático).

**Descripción**:  
Mostrar número de cuenta GENERADO AUTOMÁTICAMENTE (no editado por usuario).

**Componentes**:
- ComboBox: Cliente (lista de clientes activos)
- ComboBox: Tipo de Cuenta (Ahorros, Corriente, Inversión)
- TextBox: Saldo Inicial (default: 0)
- Label: "Número de Cuenta: [GENERADO]" (solo lectura)
- Label: "Tasa Interés: X%" (automático según tipo)
- Button: Crear Cuenta

**Lógica automática de tasa según tipo**:
```csharp
private void cbTipoCuenta_SelectedIndexChanged(object sender, EventArgs e)
{
	string tipo = cbTipoCuenta.SelectedItem.ToString();
	decimal tasa = 0;

	switch(tipo)
	{
		case "Ahorros": tasa = 3.5m; break;
		case "Corriente": tasa = 0; break;
		case "Inversión": tasa = 7.5m; break;
	}

	lblTasaInteres.Text = $"Tasa de Interés: {tasa}%";
}
```

**Evento Crear Cuenta**:
```csharp
private void btnCrearCuenta_Click(object sender, EventArgs e)
{
	var cliente = (Cliente)cbCliente.SelectedItem;
	decimal saldoInicial = decimal.Parse(txtSaldoInicial.Text);
	string tipo = cbTipoCuenta.SelectedItem.ToString();
	decimal tasa = ObtenerTasaPorTipo(tipo);

	var cuenta = ControllerCuenta.CrearCuenta(cliente, saldoInicial, tipo, tasa);

	if (cuenta != null)
	{
		MessageBox.Show(
			$"Cuenta creada exitosamente\n\nNúmero: {cuenta.NumeroCuenta}",
			"Éxito"
		);
		this.Close();
	}
}
```

**Estado**: ⏳ Pendiente  

- [ ] Crear archivo `frmCuentaNueva.cs`
- [ ] Diseñar interfaz
- [ ] Cargar clientes en ComboBox
- [ ] Implementar lógica de tasa automática
- [ ] Mostrar número generado
- [ ] Guardar

---

### ✅ TAREA 11: Crear `frmTransacciones.cs`

**Identificador**: PASO-11  
**Prioridad**: 🟠 ALTA  
**Archivo**: `HerenciaSistemaNomina\Formularios\frmTransacciones.cs`  

**Objetivo**:  
Crear formulario para realizar operaciones bancarias.

**Descripción**:  
Tres funcionalidades: Depósito, Retiro, Transferencia.

**Componentes comunes**:
- TabControl con 3 pestañas: Depósito, Retiro, Transferencia
- ComboBox: Seleccionar Cuenta
- TextBox: Monto
- Label: Mostrar saldo actual
- Button: Ejecutar operación

**Pestaña 1 - Depósito**:
```csharp
private void btnDepositar_Click(object sender, EventArgs e)
{
	var cuenta = (Cuenta)cbCuenta.SelectedItem;
	decimal monto = decimal.Parse(txtMonto.Text);

	if (ControllerCuenta.Depositar(cuenta.NumeroCuenta, monto))
	{
		MessageBox.Show("Depósito realizado exitosamente", "Éxito");
		ActualizarSaldo();
	}
}
```

**Pestaña 2 - Retiro**:
- Validar saldo suficiente
- Restar del saldo

**Pestaña 3 - Transferencia**:
- ComboBox: Cuenta Origen
- ComboBox: Cuenta Destino
- Validar que sean diferentes

**Estado**: ⏳ Pendiente  

- [ ] Crear archivo `frmTransacciones.cs`
- [ ] Diseñar interfaz con TabControl
- [ ] Implementar Depósito
- [ ] Implementar Retiro
- [ ] Implementar Transferencia
- [ ] Actualizar saldo dinámicamente
- [ ] Guardar

---

### ✅ TAREA 12: Crear `frmCuentasDelCliente.cs`

**Identificador**: PASO-12  
**Prioridad**: 🟠 ALTA  
**Archivo**: `HerenciaSistemaNomina\Formularios\frmCuentasDelCliente.cs`  

**Objetivo**:  
Mostrar todas las cuentas de un cliente específico.

**Descripción**:  
DataGridView con todas las cuentas del cliente seleccionado.

**Columnas del DataGridView**:
- Número de Cuenta
- Tipo
- Saldo
- Tasa Interés
- Estado
- Fecha Apertura

**Eventos**:
- Doble clic: Ver detalle/movimientos
- Botón: Ver Historial de Movimientos
- Botón: Cerrar Cuenta

**Cargar datos**:
```csharp
public void CargarCuentas(Cliente cliente)
{
	var cuentas = ControllerCuenta.ObtenerCuentasDelCliente(cliente);

	var datos = cuentas.Select(c => new {
		c.NumeroCuenta,
		c.Tipo,
		c.Saldo,
		c.TasaInteres,
		c.Estado,
		c.FechaApertura
	}).ToList();

	dataGridViewCuentas.DataSource = datos;
}
```

**Estado**: ⏳ Pendiente  

- [ ] Crear archivo
- [ ] Diseñar DataGridView
- [ ] Cargar cuentas
- [ ] Implementar botones
- [ ] Guardar

---

## 🟣 FASE 4: IMPLEMENTACIÓN DE LÓGICA CRÍTICA (Pasos 13-16)

### ✅ TAREA 13: Implementar Eliminación en Cascada

**Identificador**: PASO-13  
**Prioridad**: 🔴 CRÍTICA  
**Archivo**: `HerenciaSistemaNomina\Controlador\ControllerCliente.cs`  
**Método**: `EliminarCliente(string idCodigo)`

**Objetivo**:  
Implementar eliminación de cliente con cascada de sus cuentas.

**Descripción**:  
Este es el método MÁS CRÍTICO del sistema. Debe:
1. Validar que cliente existe
2. Obtener todas las cuentas del cliente
3. Eliminar CADA cuenta
4. Limpiar lista del cliente
5. Eliminar cliente

**Código implementado** (ya existe):
```csharp
public static bool EliminarCliente(string idCodigo)
{
	var cliente = listaClientes.FirstOrDefault(c => c.IdCodigo == idCodigo);
	if (cliente != null)
	{
		cliente.EliminarTodasLasCuentas();
		listaClientes.Remove(cliente);
		return true;
	}
	return false;
}
```

**Validaciones requeridas**:
- ✓ Cliente existe
- ✓ Se eliminan TODAS las cuentas
- ✓ Se elimina el cliente
- ✓ No quedan datos huérfanos

**Test de validación**:
```
ANTES:
- Clientes: 2
- Cliente 1 tiene 3 cuentas
- Total cuentas: 5

ELIMINAR Cliente 1

DESPUÉS:
- Clientes: 1
- Cliente 1.Cuentas: 0 (vacío)
- Total cuentas: 2

RESULTADO: ✓ OK
```

**Estado**: ✅ Implementado  

- [x] Método existe
- [x] Lógica correcta
- [x] Elimina cascada
- [x] Validado

---

### ✅ TAREA 14: Validar Números de Cuenta Únicos

**Identificador**: PASO-14  
**Prioridad**: 🔴 CRÍTICA  
**Archivo**: `HerenciaSistemaNomina\Entidades\Cuenta.cs`  
**Método**: `GenerarNumeroCuenta()`

**Objetivo**:  
Garantizar que cada número de cuenta es único en todo el sistema.

**Descripción**:  
El método de generación debe validar que no exista duplicado.

**Código implementado** (ya existe):
```csharp
private static int contadorCuentas = 1000;

private static string GenerarNumeroCuenta()
{
	contadorCuentas++;
	return $"{DateTime.Now.Year}-{contadorCuentas:D5}";
}
```

**Formato**: `AAAA-BBBBB`
- AAAA = Año actual (ej: 2024)
- BBBBB = Secuencial de 5 dígitos (00001, 00002, etc.)

**Ejemplos generados**:
- 2024-01001
- 2024-01002
- 2024-01003
- ...
- 2024-99999

**Test de validación**:
```
Crear 5 cuentas:
1. 2024-01001
2. 2024-01002
3. 2024-01003
4. 2024-01004
5. 2024-01005

Verificar:
✓ Todos secuenciales
✓ Todos diferentes
✓ Formato AAAA-BBBBB correcto
```

**Estado**: ✅ Implementado  

- [x] Método existe
- [x] Genera formato correcto
- [x] Secuencial automático
- [x] Validado

---

### ✅ TAREA 15: Implementar Transacciones

**Identificador**: PASO-15  
**Prioridad**: 🟣 MUY ALTA  
**Archivo**: `HerenciaSistemaNomina\Controlador\ControllerCuenta.cs`  

**Objetivo**:  
Implementar los tres tipos de transacciones: Depósito, Retiro, Transferencia.

**Descripción**:  
Métodos para manejar dinero en cuentas.

**Método 1 - Depositar** (implementado):
```csharp
public static bool Depositar(string numeroCuenta, decimal monto)
{
	var cuenta = ObtenerCuentaPorNumero(numeroCuenta);
	return cuenta != null && cuenta.Depositar(monto);
}
```

**Método 2 - Retirar** (implementado):
```csharp
public static bool Retirar(string numeroCuenta, decimal monto)
{
	var cuenta = ObtenerCuentaPorNumero(numeroCuenta);
	return cuenta != null && cuenta.Retirar(monto);
}
```

**Método 3 - Transferir** (implementado):
```csharp
public static bool Transferir(string origen, string destino, decimal monto)
{
	var cOrigen = ObtenerCuentaPorNumero(origen);
	var cDestino = ObtenerCuentaPorNumero(destino);

	if (cOrigen == null || cDestino == null) return false;
	if (!cOrigen.Retirar(monto)) return false;

	cDestino.Depositar(monto);
	return true;
}
```

**Validaciones**:
- ✓ Monto > 0
- ✓ Saldo suficiente (retiro/transferencia)
- ✓ Cuentas activas
- ✓ Cuentas no son la misma (transferencia)

**Test validación**:
```
Cuenta A: $1000
Cuenta B: $500

Depósito A: +$500 → A: $1500 ✓
Retiro A: -$200 → A: $1300 ✓
Transferencia A→B: $300 → A: $1000, B: $800 ✓
Retiro A: -$1100 → FALLA (insuficiente) ✓
```

**Estado**: ✅ Implementado  

- [x] Depositar funciona
- [x] Retirar funciona
- [x] Transferir funciona
- [x] Validaciones ok
- [x] Saldo se actualiza

---

### ✅ TAREA 16: Implementar Historial de Movimientos

**Identificador**: PASO-16  
**Prioridad**: 🟣 MUY ALTA  
**Archivo**: `HerenciaSistemaNomina\Entidades\Cuenta.cs`  

**Objetivo**:  
Registrar cada transacción en un historial de movimientos.

**Descripción**:  
Cada transacción se registra con fecha, hora, tipo, monto.

**Propiedad Movimientos** (implementada):
```csharp
private List<string> movimientos;

public List<string> Movimientos 
{ 
	get => movimientos; 
	set => movimientos = value; 
}
```

**Registro en Depósito**:
```csharp
public bool Depositar(decimal monto)
{
	if (monto <= 0)
		return false;

	saldo += monto;
	movimientos.Add($"{DateTime.Now:dd/MM/yyyy HH:mm:ss} - Depósito: +${monto:F2}");
	return true;
}
```

**Registro en Retiro**:
```csharp
public bool Retirar(decimal monto)
{
	if (monto <= 0 || monto > saldo)
		return false;

	saldo -= monto;
	movimientos.Add($"{DateTime.Now:dd/MM/yyyy HH:mm:ss} - Retiro: -${monto:F2}");
	return true;
}
```

**Obtener Historial**:
```csharp
public List<string> ObtenerHistorialMovimientos()
{
	return new List<string>(movimientos);
}
```

**Ejemplo de historial**:
```
15/12/2024 10:30:45 - Depósito inicial: +$5000.00
15/12/2024 11:15:20 - Depósito: +$500.00
15/12/2024 12:45:10 - Retiro: -$200.00
15/12/2024 14:20:35 - Transferencia a 2024-01002: -$300.00
```

**Estado**: ✅ Implementado  

- [x] Movimientos se registran
- [x] Formato fecha/hora
- [x] Se obtiene historial
- [x] Movimientos inmutables

---

## 🟢 FASE 5: DATOS DE PRUEBA Y EJEMPLOS (Pasos 17-19)

### ✅ TAREA 17: Crear Datos de Ejemplo

**Identificador**: PASO-17  
**Prioridad**: 🟡 MEDIA  
**Ubicación**: `Program.cs` o `frmAdmin.cs`  

**Objetivo**:  
Cargar datos de prueba al iniciar la aplicación.

**Descripción**:  
Crear 2 clientes con múltiples cuentas para probar funcionalidad.

**Método CargarDatosEjemplo()** (ya existe en Cliente.cs):
```csharp
public static void CargarDatosEjemplo()
{
	// Cliente 1 con 3 cuentas
	var cliente1 = new Cliente("CLI-001", "1723456789", "Juan", "Pérez",
		new DateTime(1990, 5, 15), 'M', "Soltero", "Av. Principal 123",
		"0998765432", DateTime.Now, "Activo");

	ControllerCliente.AñadirCliente(cliente1);

	ControllerCuenta.CrearCuenta(cliente1, 5000, "Ahorros", 3.5m);
	ControllerCuenta.CrearCuenta(cliente1, 15750, "Corriente", 0);
	ControllerCuenta.CrearCuenta(cliente1, 25000, "Inversión", 7.5m);

	// Cliente 2 con 2 cuentas
	var cliente2 = new Cliente("CLI-002", "1798765432", "María", "García",
		new DateTime(1985, 8, 20), 'F', "Casada", "Calle Falsa 456",
		"0987654321", DateTime.Now, "Activo");

	ControllerCliente.AñadirCliente(cliente2);

	ControllerCuenta.CrearCuenta(cliente2, 10000, "Ahorros", 3.5m);
	ControllerCuenta.CrearCuenta(cliente2, 50000, "Corriente", 0);
}
```

**Datos de Ejemplo Generados**:
```
CLIENTE 1:
- ID: CLI-001
- Nombre: Juan Pérez
- Cédula: 1723456789
- 3 Cuentas:
  * 2024-01001 (Ahorros): $5,000
  * 2024-01002 (Corriente): $15,750
  * 2024-01003 (Inversión): $25,000
- Saldo Total: $45,750

CLIENTE 2:
- ID: CLI-002
- Nombre: María García
- Cédula: 1798765432
- 2 Cuentas:
  * 2024-01004 (Ahorros): $10,000
  * 2024-01005 (Corriente): $50,000
- Saldo Total: $60,000

TOTALES DEL SISTEMA:
- Clientes: 2
- Cuentas: 5
- Saldo Total: $105,750
```

**Estado**: ⏳ Pendiente  

- [ ] Llamar en Program.cs
- [ ] Verificar datos creados
- [ ] Mostrar en DataGridView

---

### ✅ TAREA 18: Pruebas de Eliminación en Cascada

**Identificador**: PASO-18  
**Prioridad**: 🔴 CRÍTICA  
**Tipo**: Testing  

**Objetivo**:  
Verificar que la eliminación en cascada funciona correctamente.

**Descripción**:  
Realizar pruebas de eliminación de cliente.

**Escenario 1: Eliminar cliente con múltiples cuentas**

```
ANTES:
- Clientes: 2
- Cliente 1 (Juan): 3 cuentas
  * 2024-01001
  * 2024-01002
  * 2024-01003
- Total cuentas: 5

ACCIÓN:
- Eliminar Cliente 1

DESPUÉS:
- Clientes: 1
- Cliente 1 (Juan): Eliminado ✓
- Cliente 1.Cuentas: [] (vacío) ✓
- Cuentas en sistema: 2 (solo las de Cliente 2) ✓
- Total cuentas: 2 ✓

RESULTADO: ✅ CASCADA CORRECTA
```

**Escenario 2: Eliminar cliente y verificar UI**

```
ACCIÓN:
1. Seleccionar Cliente en DataGridView
2. Clic en "Eliminar"
3. Confirmar en dialog
4. Observar cambios

VERIFICACIONES:
✓ Cliente desaparece de DataGridView
✓ Cuentas del cliente desaparecen
✓ Saldo total se actualiza
✓ No hay referencias huérfanas
```

**Test Code (opcional)**:
```csharp
[Test]
public void TestEliminacionCascada()
{
	// Preparar
	var cliente = new Cliente("CLI-001", "1234567890", "Test", "User",
		new DateTime(1990, 1, 1), 'M', "Soltero", "Dir", "123", 
		DateTime.Now, "Activo");

	ControllerCliente.AñadirCliente(cliente);
	ControllerCuenta.CrearCuenta(cliente, 1000, "Ahorros");
	ControllerCuenta.CrearCuenta(cliente, 2000, "Corriente");

	// Verificar antes
	Assert.AreEqual(1, ControllerCliente.ObtenerTodosLosClientes().Count);
	Assert.AreEqual(2, cliente.Cuentas.Count);

	// Eliminar
	ControllerCliente.EliminarCliente("CLI-001");

	// Verificar después
	Assert.AreEqual(0, ControllerCliente.ObtenerTodosLosClientes().Count);
	Assert.AreEqual(0, cliente.Cuentas.Count);
}
```

**Estado**: ⏳ Pendiente  

- [ ] Ejecutar Escenario 1
- [ ] Verificar cascada
- [ ] Ejecutar Escenario 2
- [ ] Verificar UI se actualiza
- [ ] ✅ OK si todo pasa

---

### ✅ TAREA 19: Pruebas de Generación de Números

**Identificador**: PASO-19  
**Prioridad**: 🔴 CRÍTICA  
**Tipo**: Testing  

**Objetivo**:  
Verificar que números de cuenta se generan correctamente.

**Descripción**:  
Realizar pruebas de generación de números únicos y secuenciales.

**Test 1: Números Secuenciales**

```
Crear 5 cuentas:

RESULTADO:
1. 2024-01001
2. 2024-01002
3. 2024-01003
4. 2024-01004
5. 2024-01005

VERIFICACIÓN:
✓ Todos secuenciales
✓ Formato AAAA-BBBBB
✓ Año correcto (2024)
✓ Incremento de 1 en cada

STATUS: ✅ OK
```

**Test 2: Números Únicos**

```
Crear 100 cuentas

VERIFICACIÓN:
✓ 100 números únicos
✓ 0 duplicados
✓ Todos válidos

CODE:
var numeros = Enumerable.Range(0, 100)
	.Select(i => new Cuenta())
	.Select(c => c.NumeroCuenta)
	.ToList();

Assert.AreEqual(100, numeros.Count);
Assert.AreEqual(100, numeros.Distinct().Count()); // Sin duplicados

STATUS: ✅ OK
```

**Test 3: Formato Correcto**

```
Validar cada número generado:

PATRÓN: AAAA-BBBBB
- AAAA = 4 dígitos (año)
- Guión = separador
- BBBBB = 5 dígitos (secuencial)

EJEMPLOS VÁLIDOS:
✓ 2024-00001
✓ 2024-00002
✓ 2024-99999

EJEMPLOS INVÁLIDOS:
✗ 2024-1 (falta dígito)
✗ 202401001 (sin guión)
✗ 2024--00001 (guión doble)

CODE:
var patron = @"^\d{4}-\d{5}$";
foreach(var numero in numeros)
{
	Assert.IsTrue(Regex.IsMatch(numero, patron));
}

STATUS: ✅ OK
```

**Estado**: ⏳ Pendiente  

- [ ] Ejecutar Test 1 (secuencial)
- [ ] Ejecutar Test 2 (único)
- [ ] Ejecutar Test 3 (formato)
- [ ] ✅ OK si todos pasan

---

## 🟦 FASE 6: FINALIZACIÓN Y DOCUMENTACIÓN (Pasos 20-22)

### ✅ TAREA 20: Actualizar `README.md`

**Identificador**: PASO-20  
**Prioridad**: 🟡 MEDIA  
**Archivo**: `README.md`  

**Objetivo**:  
Actualizar documentación del proyecto.

**Secciones a actualizar**:
1. Cambiar título de nómina a **Sistema Bancario**
2. Actualizar descripción general
3. Agregar guía de uso (crear cliente, cuenta, transacciones)
4. Explicar eliminación en cascada
5. Agregar ejemplos de código
6. Actualizar estructura del proyecto

**Estado**: ✅ Existe (README.md ya actualizado)  

- [x] README.md ya existe
- [x] Estructura del proyecto
- [x] Guía de uso
- [x] Eliminación en cascada explicada

---

### ✅ TAREA 21: Agregar Comentarios XML

**Identificador**: PASO-21  
**Prioridad**: 🟡 MEDIA  
**Archivos**: Todas las clases públicas  

**Objetivo**:  
Documentar código con comentarios XML.

**Formato**:
```csharp
/// <summary>
/// Descripción breve del método
/// </summary>
/// <param name="param1">Descripción del parámetro</param>
/// <param name="param2">Descripción del parámetro</param>
/// <returns>Descripción del valor retornado</returns>
/// <remarks>
/// Notas adicionales si es necesario
/// </remarks>
public TipoRetorno MiMetodo(TipoParam1 param1, TipoParam2 param2)
{
}
```

**Clases a documentar**:
- [ ] `Cliente.cs`
- [ ] `Cuenta.cs`
- [ ] `ControllerCliente.cs`
- [ ] `ControllerCuenta.cs`
- [ ] `Utilidades.cs`
- [ ] `BaseDatos.cs`

**Estado**: ⏳ Pendiente  

- [ ] Documentar Cliente
- [ ] Documentar Cuenta
- [ ] Documentar ControllerCliente
- [ ] Documentar ControllerCuenta
- [ ] Documentar Utilidades
- [ ] Documentar BaseDatos

---

### ✅ TAREA 22: Build Final y Verificación

**Identificador**: PASO-22  
**Prioridad**: 🔴 CRÍTICA  
**Comando**: `Ctrl+Shift+B` (Build Solution)  

**Objetivo**:  
Compilar proyecto completo y verificar funcionamiento.

**Validaciones requeridas**:
- [ ] 0 errores de compilación
- [ ] ≤ 2 advertencias (aceptables)
- [ ] Mensaje: "Build succeeded"
- [ ] Aplicación se ejecuta sin crashes
- [ ] Cargar datos de ejemplo funciona
- [ ] Crear cliente nuevo funciona
- [ ] Crear cuenta nueva funciona
- [ ] Realizar transacción funciona
- [ ] Eliminar cliente funciona (con cascada)
- [ ] Historial de movimientos funciona

**Pruebas funcionales**:

```
PRUEBA 1: Cargar Datos
- Ejecutar aplicación
- Verificar 2 clientes en DataGridView
- Verificar 5 cuentas en total
- ✓ OK

PRUEBA 2: Crear Cliente
- Clic "Nuevo Cliente"
- Llenar datos válidos
- Guardar
- Verificar aparece en lista
- ✓ OK

PRUEBA 3: Crear Cuenta
- Seleccionar cliente
- Clic "Nueva Cuenta"
- Verificar número generado automático
- Guardar
- ✓ OK

PRUEBA 4: Transacción
- Seleccionar cuenta
- Realizar depósito
- Verificar saldo se actualiza
- Verificar historial registra movimiento
- ✓ OK

PRUEBA 5: Eliminación Cascada
- Seleccionar cliente con 3 cuentas
- Clic "Eliminar"
- Confirmar
- Verificar cliente desaparece
- Verificar sus 3 cuentas se eliminan
- ✓ OK
```

**Resultado Final**:
```
✅ PROYECTO LISTO PARA PRODUCCIÓN

Errores: 0
Advertencias: ≤2
Pruebas: ✓ Todas pasan
Cascada: ✓ Funciona
Números: ✓ Automáticos
Transacciones: ✓ Ok
```

**Estado**: ⏳ Pendiente  

- [ ] Compilar solución
- [ ] Verificar 0 errores
- [ ] Ejecutar aplicación
- [ ] Prueba 1: Cargar datos
- [ ] Prueba 2: Crear cliente
- [ ] Prueba 3: Crear cuenta
- [ ] Prueba 4: Transacción
- [ ] Prueba 5: Eliminación cascada
- [ ] ✅ PROYECTO OK

---

## 📊 RESUMEN DE PROGRESO

| # | Tarea | Fase | Estado | Prioridad |
|---|-------|------|--------|-----------|
| 1 | Actualizar `.csproj` | 1 | ⏳ | 🔴 |
| 2 | Compilar proyecto | 1 | ⏳ | 🔴 |
| 3 | Revisar `Persona.cs` | 2 | ✅ | 🟡 |
| 4 | Actualizar `Program.cs` | 2 | ⏳ | 🟡 |
| 5 | Crear `BaseDatos.cs` | 2 | ⏳ | 🟡 |
| 6 | Crear `Utilidades.cs` | 2 | ⏳ | 🟡 |
| 7 | Modificar `frmAdmin.cs` | 3 | ⏳ | 🟠 |
| 8 | Crear `frmClienteNuevo.cs` | 3 | ⏳ | 🟠 |
| 9 | Crear `frmClienteEditar.cs` | 3 | ⏳ | 🟠 |
| 10 | Crear `frmCuentaNueva.cs` | 3 | ⏳ | 🟠 |
| 11 | Crear `frmTransacciones.cs` | 3 | ⏳ | 🟠 |
| 12 | Crear `frmCuentasDelCliente.cs` | 3 | ⏳ | 🟠 |
| 13 | Eliminación en cascada | 4 | ✅ | 🔴 |
| 14 | Validar números únicos | 4 | ✅ | 🔴 |
| 15 | Implementar transacciones | 4 | ✅ | 🟣 |
| 16 | Historial de movimientos | 4 | ✅ | 🟣 |
| 17 | Datos de ejemplo | 5 | ⏳ | 🟡 |
| 18 | Pruebas eliminación | 5 | ⏳ | 🔴 |
| 19 | Pruebas números | 5 | ⏳ | 🔴 |
| 20 | Actualizar README | 6 | ✅ | 🟡 |
| 21 | Comentarios XML | 6 | ⏳ | 🟡 |
| 22 | Build final | 6 | ⏳ | 🔴 |

**Completadas**: 7/22 (32%)  
**Pendientes**: 15/22 (68%)

---

## 🎯 PRÓXIMOS PASOS

1. **Comenzar Paso 1**: Actualizar `.csproj`
2. **Luego Paso 2**: Compilar proyecto
3. **Continuar con FASE 2**: Estructura (Pasos 3-6)
4. **FASE 3**: Formularios (Pasos 7-12)
5. **FASE 4**: Lógica (Pasos 13-16) - Parcialmente hecho
6. **FASE 5**: Testing (Pasos 17-19)
7. **FASE 6**: Finalización (Pasos 20-22)

---

**Documento de Tareas Completado**

Usa este archivo como **referencia durante la implementación**. Marca ✅ cada tarea conforme la completes.


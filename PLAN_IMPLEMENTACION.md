# PLAN DE IMPLEMENTACIÓN - SISTEMA BANCARIO

**Versión**: 1.0  
**Estado**: En Desarrollo  
**Última Actualización**: 2024  
**Repositorio**: https://github.com/bojeda227/SistemaNomina

---

## 📌 OBJETIVO DEL PLAN

Implementar un sistema bancario completo en .NET Framework 4.7.2 que permita:
- ✅ Gestionar clientes con múltiples cuentas
- ✅ Generar números de cuenta automáticamente (formato: AAAA-BBBBB)
- ✅ Realizar transacciones (depósitos, retiros, transferencias)
- ✅ **Eliminar cliente con cascada** (se eliminan todas sus cuentas)

---

## 📊 FASES Y PASOS

### **FASE 1: INTEGRACIÓN DE ENTIDADES CREADAS** (PREPARACIÓN)
**Objetivo**: Asegurar que todas las nuevas clases se compilen correctamente.

#### Paso 1: Actualizar archivo `.csproj`
- **Archivo**: `HerenciaSistemaNomina\ClaseAbstractaSistemaNomina.csproj`
- **Acción**: Agregar referencias a las nuevas clases
- **Nuevas líneas a añadir**:
  ```xml
  <Compile Include="Entidades\Cliente.cs" />
  <Compile Include="Entidades\Cuenta.cs" />
  <Compile Include="Controlador\ControllerCliente.cs" />
  <Compile Include="Controlador\ControllerCuenta.cs" />
  ```
- **Estado**: ⏳ Pendiente

#### Paso 2: Compilar proyecto
- **Comando**: `Build → Build Solution` (Ctrl+Shift+B)
- **Validación**: Debe compilar sin errores
- **Esperado**: 0 errores, 0 advertencias (o máximo 1-2 advertencias)
- **Estado**: ⏳ Pendiente

---

### **FASE 2: MEJORA DE ESTRUCTURA EXISTENTE** (ADAPTACIÓN)
**Objetivo**: Preparar la infraestructura necesaria para el sistema.

#### Paso 3: Revisar clase `Persona.cs`
- **Archivo**: `HerenciaSistemaNomina\Entidades\Persona.cs`
- **Acción**: Verificar que tenga todos los atributos necesarios
- **Requerimientos**:
  - `IdCodigo` (identificador único)
  - `Cedula` (único)
  - `Nombre`, `Apellidos`
  - `FechaNacimiento`
  - `Sexo`, `EstadoCivil`
  - `Direccion`, `Telefono`
  - Tipo (discriminador)
- **Nota**: Si falta algo, agregar propiedades y getters/setters
- **Estado**: ⏳ Pendiente

#### Paso 4: Actualizar `Program.cs`
- **Archivo**: `HerenciaSistemaNomina\Program.cs`
- **Acción**: Inicializar controladores y datos
- **Código a añadir**:
  ```csharp
  // En Program.cs, agregar en Main():
  ControllerCliente.LimpiarLista(); // Limpiar lista
  CargarDatosEjemplo(); // Cargar datos de prueba
  ```
- **Estado**: ⏳ Pendiente

#### Paso 5: Crear clase `BaseDatos.cs` (Central)
- **Archivo**: `HerenciaSistemaNomina\Datos\BaseDatos.cs` (crear carpeta Datos si no existe)
- **Propósito**: Centralizar acceso a listas de datos
- **Contenido**:
  ```csharp
  public static class BaseDatos
  {
	  public static List<Cliente> Clientes { get; set; } = new List<Cliente>();
	  public static List<Cuenta> Cuentas { get; set; } = new List<Cuenta>();

	  public static void LimpiarTodo()
	  {
		  Clientes.Clear();
		  Cuentas.Clear();
	  }
  }
  ```
- **Estado**: ⏳ Pendiente

#### Paso 6: Crear clase `Utilidades.cs`
- **Archivo**: `HerenciaSistemaNomina\Utilidades.cs`
- **Propósito**: Métodos de validación comunes
- **Validaciones a incluir**:
  - `ValidarCedula(cedula)`: Solo 10 dígitos
  - `ValidarNombre(nombre)`: 2-100 caracteres
  - `ValidarTelefono(telefono)`: 7-15 dígitos
  - `ValidarMonto(monto)`: Positivo
  - `CalcularEdad(fechaNacimiento)`: Mayor de 18 años
- **Estado**: ⏳ Pendiente

---

### **FASE 3: ADAPTACIÓN DE FORMULARIOS** (UI - COMPONENTES BANCARIOS)
**Objetivo**: Crear interfaz para gestión bancaria.

#### Paso 7: Modificar `frmAdmin.cs` - Panel Principal
- **Archivo**: `HerenciaSistemaNomina\Formularios\frmAdmin.cs`
- **Acción**: Agregar controles para navegación
- **Componentes a añadir**:
  - TabControl con 3 pestañas: Clientes, Cuentas, Transacciones
  - DataGridView en cada pestaña
  - Botones: Nuevo, Editar, Eliminar, Recargar
  - Barra de estado
- **Estado**: ⏳ Pendiente

#### Paso 8: Crear `frmClienteNuevo.cs`
- **Archivo**: `HerenciaSistemaNomina\Formularios\frmClienteNuevo.cs`
- **Propósito**: Formulario para crear nuevo cliente
- **Campos requeridos**:
  - TextBox: Nombre, Apellidos, Cédula, Teléfono, Dirección
  - DateTimePicker: Fecha Nacimiento
  - ComboBox: Sexo (M/F), Estado Civil
  - Botones: Guardar, Cancelar
- **Validación**:
  - Cédula única
  - Edad ≥ 18 años
  - Todos los campos obligatorios
- **Acción al guardar**: Crear Cliente y llamar `ControllerCliente.AñadirCliente()`
- **Estado**: ⏳ Pendiente

#### Paso 9: Crear `frmClienteEditar.cs`
- **Archivo**: `HerenciaSistemaNomina\Formularios\frmClienteEditar.cs`
- **Propósito**: Editar datos de cliente O eliminar cliente
- **Funcionalidad 1 - Editar**:
  - Cargar datos del cliente en formulario
  - Permitir editar todos los campos (excepto Cédula y FechaAfiliacion)
  - Botón Guardar: Llamar `ControllerCliente.ActualizarCliente()`

- **Funcionalidad 2 - Eliminar (CASCADA)**:
  - Botón "Eliminar Cliente"
  - Mostrar alerta: "Se eliminarán TODAS las cuentas del cliente. ¿Continuar?"
  - Al confirmar:
	```csharp
	// Obtener todas las cuentas del cliente
	foreach(var cuenta in cliente.Cuentas)
	{
		ControllerCuenta.Eliminar(cuenta.NumeroCuenta);
	}
	// Eliminar cliente
	ControllerCliente.EliminarCliente(cliente.IdCodigo);
	```
  - Mostrar confirmación de eliminación

- **Estado**: ⏳ Pendiente

#### Paso 10: Crear `frmCuentaNueva.cs`
- **Archivo**: `HerenciaSistemaNomina\Formularios\frmCuentaNueva.cs`
- **Propósito**: Crear nueva cuenta para cliente
- **Campos requeridos**:
  - ComboBox: Seleccionar Cliente (solo lectura si viene de detalle)
  - ComboBox: Tipo de Cuenta (Ahorros, Corriente, Inversión)
  - TextBox: Saldo Inicial (default: 0)
  - Label: "Número de Cuenta: [GENERADO AUTOMÁTICAMENTE]" (solo lectura, mostrar después de crear)
  - Label: "Tasa Interés: X%" (automático según tipo)

- **Lógica**:
  1. Usuario selecciona cliente
  2. Usuario selecciona tipo de cuenta
  3. Usuario ingresa saldo inicial
  4. Al hacer clic "Crear Cuenta":
	 - Sistema llama `ControllerCuenta.CrearCuenta(cliente, saldo, tipo, tasa)`
	 - Número se genera automáticamente
	 - Se muestra el número generado
	 - Se agrega a DataGridView

- **Estado**: ⏳ Pendiente

#### Paso 11: Crear `frmTransacciones.cs`
- **Archivo**: `HerenciaSistemaNomina\Formularios\frmTransacciones.cs`
- **Propósito**: Realizar operaciones bancarias
- **Funcionalidad 1 - Depósito**:
  - ComboBox: Seleccionar Cuenta
  - TextBox: Monto a depositar
  - Botón: Depositar
  - Al ejecutar: `ControllerCuenta.Depositar(numeroCuenta, monto)`

- **Funcionalidad 2 - Retiro**:
  - ComboBox: Seleccionar Cuenta
  - TextBox: Monto a retirar
  - Botón: Retirar
  - Validar: Saldo suficiente
  - Al ejecutar: `ControllerCuenta.Retirar(numeroCuenta, monto)`

- **Funcionalidad 3 - Transferencia**:
  - ComboBox: Cuenta Origen
  - ComboBox: Cuenta Destino
  - TextBox: Monto
  - Botón: Transferir
  - Al ejecutar: `ControllerCuenta.Transferir(origen, destino, monto)`

- **En todos los casos**:
  - Mostrar confirmación de éxito/error
  - Actualizar saldo en pantalla
  - Registrar en historial

- **Estado**: ⏳ Pendiente

#### Paso 12: Crear `frmCuentasDelCliente.cs`
- **Archivo**: `HerenciaSistemaNomina\Formularios\frmCuentasDelCliente.cs`
- **Propósito**: Ver todas las cuentas de un cliente
- **Datos mostrados** (DataGridView):
  - Número de Cuenta
  - Tipo
  - Saldo
  - Tasa Interés
  - Estado
  - Fecha Apertura

- **Funcionalidad**:
  - Doble clic en fila: Ver detalle/movimientos
  - Botón: Ver Historial de Movimientos
  - Botón: Cerrar Cuenta

- **Lógica de carga**:
  ```csharp
  var cuentas = ControllerCuenta.ObtenerCuentasDelCliente(cliente);
  dataGridView.DataSource = cuentas;
  ```

- **Estado**: ⏳ Pendiente

---

### **FASE 4: IMPLEMENTACIÓN DE LÓGICA CRÍTICA** (NEGOCIO)
**Objetivo**: Implementar reglas de negocio principales.

#### Paso 13: Implementar Eliminación en Cascada
- **Archivo**: `HerenciaSistemaNomina\Controlador\ControllerCliente.cs`
- **Método**: `EliminarCliente(string idCodigo)`
- **Lógica requerida**:
  ```csharp
  public static bool EliminarCliente(string idCodigo)
  {
	  var cliente = listaClientes.FirstOrDefault(c => c.IdCodigo == idCodigo);
	  if (cliente != null)
	  {
		  // PASO 1: Registrar información de eliminación (opcional)
		  RegistrarEliminacion(cliente);

		  // PASO 2: Obtener todas las cuentas
		  var cuentas = cliente.Cuentas;

		  // PASO 3: Eliminar cada cuenta del sistema general
		  foreach(var cuenta in cuentas)
		  {
			  ControllerCuenta.EliminarCuenta(cuenta.NumeroCuenta);
		  }

		  // PASO 4: Limpiar lista de cuentas del cliente
		  cliente.EliminarTodasLasCuentas();

		  // PASO 5: Eliminar cliente
		  listaClientes.Remove(cliente);

		  return true;
	  }
	  return false;
  }
  ```

- **Validación**:
  - ✓ Cliente existe
  - ✓ Se eliminan TODAS las cuentas
  - ✓ Se elimina el cliente
  - ✓ No queda data huérfana

- **Estado**: ⏳ Pendiente

#### Paso 14: Validar Números de Cuenta Únicos
- **Archivo**: `HerenciaSistemaNomina\Entidades\Cuenta.cs`
- **Método**: `GenerarNumeroCuenta()`
- **Validación**:
  ```csharp
  private static int contadorCuentas = 1000;

  private static string GenerarNumeroCuenta()
  {
	  contadorCuentas++;
	  string numero = $"{DateTime.Now.Year}-{contadorCuentas:D5}";

	  // Validar que no exista
	  while(ObtenerCuentaPorNumero(numero) != null)
	  {
		  contadorCuentas++;
		  numero = $"{DateTime.Now.Year}-{contadorCuentas:D5}";
	  }

	  return numero;
  }
  ```

- **Garantía**: Cada número es único
- **Formato**: AAAA-BBBBB (ej: 2024-00001)
- **Estado**: ⏳ Pendiente

#### Paso 15: Implementar Transacciones
- **Archivo**: `HerenciaSistemaNomina\Controlador\ControllerCuenta.cs`
- **Métodos a implementar**:

  1. **Depositar**:
	 ```csharp
	 public static bool Depositar(string numeroCuenta, decimal monto)
	 {
		 var cuenta = ObtenerCuentaPorNumero(numeroCuenta);
		 return cuenta != null && cuenta.Depositar(monto);
	 }
	 ```

  2. **Retirar**:
	 ```csharp
	 public static bool Retirar(string numeroCuenta, decimal monto)
	 {
		 var cuenta = ObtenerCuentaPorNumero(numeroCuenta);
		 return cuenta != null && cuenta.Retirar(monto);
	 }
	 ```

  3. **Transferir**:
	 ```csharp
	 public static bool Transferir(string origen, string destino, decimal monto)
	 {
		 var cOrigen = ObtenerCuentaPorNumero(origen);
		 var cDestino = ObtenerCuentaPorNumero(destino);

		 if(cOrigen == null || cDestino == null) return false;
		 if(!cOrigen.Retirar(monto)) return false;

		 cDestino.Depositar(monto);
		 return true;
	 }
	 ```

- **Validaciones**:
  - Monto > 0
  - Saldo suficiente (retiro/transferencia)
  - Cuentas activas
  - Cuentas no son la misma (transferencia)

- **Estado**: ⏳ Pendiente

#### Paso 16: Implementar Historial de Movimientos
- **Archivo**: `HerenciaSistemaNomina\Entidades\Cuenta.cs`
- **Propiedad**: `Movimientos: List<string>`
- **Agregar registro en cada transacción**:
  ```csharp
  public bool Depositar(decimal monto)
  {
	  if(monto <= 0) return false;
	  saldo += monto;
	  movimientos.Add($"{DateTime.Now:dd/MM/yyyy HH:mm:ss} - Depósito: +${monto:F2}");
	  return true;
  }
  ```

- **Ver historial**:
  ```csharp
  public List<string> ObtenerHistorialMovimientos()
  {
	  return new List<string>(movimientos);
  }
  ```

- **Estado**: ⏳ Pendiente

---

### **FASE 5: DATOS DE PRUEBA Y EJEMPLOS** (TESTING)
**Objetivo**: Verificar funcionamiento correcto.

#### Paso 17: Crear Datos de Ejemplo
- **Archivo**: `HerenciaSistemaNomina\Formularios\frmAdmin.cs` o `Program.cs`
- **Método**: `CargarDatosEjemplo()`
- **Datos a crear**:
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

- **Resultado esperado**:
  - 2 clientes creados
  - Cliente 1 tiene 3 cuentas
  - Cliente 2 tiene 2 cuentas
  - Números de cuenta generados automáticamente

- **Estado**: ⏳ Pendiente

#### Paso 18: Pruebas de Eliminación en Cascada
- **Escenario 1**: Eliminar cliente con múltiples cuentas
  - Verificar: Se eliminan todas las cuentas
  - Verificar: El cliente es removido
  - Verificar: No quedan cuentas huérfanas

- **Escenario 2**: Eliminar cliente y verificar UI
  - Verificar: DataGridView de clientes se actualiza
  - Verificar: DataGridView de cuentas se limpia

- **Código de prueba**:
  ```csharp
  // Antes
  var clientesAntes = ControllerCliente.ObtenerTodosLosClientes().Count;
  var cliente = ControllerCliente.ObtenerClientePorId("CLI-001");
  var cuentasCliente = cliente.Cuentas.Count; // 3

  // Ejecutar eliminación
  ControllerCliente.EliminarCliente("CLI-001");

  // Después
  var clientesDespues = ControllerCliente.ObtenerTodosLosClientes().Count;
  var cuentasEliminadas = ControllerCuenta.ObtenerTodasLasCuentas()
	  .Count(c => c.NumeroCuenta.EndsWith("CLientes no tiene cuentas"));

  // Verificaciones
  Assert: clientesDespues == clientesAntes - 1
  Assert: cliente.Cuentas.Count == 0
  Assert: cuentasEliminadas == 3
  ```

- **Estado**: ⏳ Pendiente

#### Paso 19: Pruebas de Generación de Números
- **Test 1**: Números secuenciales
  - Crear 5 cuentas
  - Verificar: 2024-00001, 2024-00002, 2024-00003, etc.

- **Test 2**: Números únicos
  - Crear 100 cuentas
  - Verificar: No hay duplicados

- **Test 3**: Formato correcto
  - Cada número tiene formato AAAA-BBBBB
  - Año es correcto
  - Secuencial es de 5 dígitos

- **Estado**: ⏳ Pendiente

---

### **FASE 6: FINALIZACIÓN Y DOCUMENTACIÓN** (CIERRE)
**Objetivo**: Pulir y documentar el proyecto.

#### Paso 20: Actualizar `README.md`
- **Archivo**: `README.md`
- **Secciones a actualizar**:
  - Descripción: Sistema bancario, no nómina
  - Guía de uso: Instrucciones para crear cliente, cuenta y transacciones
  - Eliminación en cascada: Explicar comportamiento
  - Ejemplos de código

- **Estado**: ⏳ Pendiente

#### Paso 21: Agregar Comentarios XML
- **En todas las clases públicas**:
  ```csharp
  /// <summary>
  /// Breve descripción
  /// </summary>
  /// <param name="param1">Descripción del parámetro</param>
  /// <returns>Lo que retorna</returns>
  public void MiMetodo(string param1)
  {
  }
  ```

- **Clases a documentar**:
  - `Cliente.cs`
  - `Cuenta.cs`
  - `ControllerCliente.cs`
  - `ControllerCuenta.cs`
  - `Utilidades.cs`

- **Estado**: ⏳ Pendiente

#### Paso 22: Build Final y Verificación
- **Compilar**: `Ctrl+Shift+B`
- **Validaciones**:
  - ✓ 0 errores
  - ✓ ≤ 2 advertencias (aceptables)
  - ✓ Ejecutar aplicación sin crashes
  - ✓ Cargar datos de ejemplo
  - ✓ Crear cliente nueva
  - ✓ Crear cuenta nueva
  - ✓ Realizar transacción
  - ✓ Eliminar cliente (verificar cascada)

- **Resultado**: Proyecto listo para usar
- **Estado**: ⏳ Pendiente

---

## 📈 PROGRESO DEL PLAN

| Fase | Estado | Progreso |
|------|--------|----------|
| **FASE 1: Integración** | ⏳ No iniciada | 0% |
| **FASE 2: Estructura** | ⏳ No iniciada | 0% |
| **FASE 3: Formularios** | ⏳ No iniciada | 0% |
| **FASE 4: Lógica** | ⏳ No iniciada | 0% |
| **FASE 5: Testing** | ⏳ No iniciada | 0% |
| **FASE 6: Documentación** | ⏳ No iniciada | 0% |
| **TOTAL** | **⏳ No iniciada** | **0%** |

---

## 🔄 DEPENDENCIAS ENTRE FASES

```
┌─────────────────────────┐
│  FASE 1: Integración    │ (Compilación de clases nuevas)
└────────────┬────────────┘
			 ↓
┌─────────────────────────┐
│  FASE 2: Estructura     │ (Infraestructura y utilidades)
└────────────┬────────────┘
			 ↓
┌─────────────────────────┐
│  FASE 3: Formularios    │ (Interfaz de usuario)
└────────────┬────────────┘
			 ↓
┌─────────────────────────┐
│  FASE 4: Lógica         │ (Reglas de negocio)
└────────────┬────────────┘
			 ↓
┌─────────────────────────┐
│  FASE 5: Testing        │ (Verificación)
└────────────┬────────────┘
			 ↓
┌─────────────────────────┐
│  FASE 6: Documentación  │ (Finalización)
└─────────────────────────┘
```

---

## ⚠️ RIESGOS Y MITIGACIÓN

| Riesgo | Probabilidad | Impacto | Mitigación |
|--------|-------------|--------|-----------|
| Errores de compilación | Media | Medio | Compilar frecuentemente |
| Números de cuenta duplicados | Baja | Alto | Validar con contador compartido |
| Eliminación cascada fallida | Baja | Crítico | Pruebas exhaustivas antes |
| Referencias circulares | Baja | Medio | Revisar dependencias |
| DataGridView no se actualiza | Media | Bajo | Refrescar después de cambios |

---

## ✅ CRITERIOS DE ÉXITO

- ✓ Proyecto compila sin errores
- ✓ Se pueden crear clientes
- ✓ Se pueden crear múltiples cuentas por cliente
- ✓ Números de cuenta se generan automáticamente (AAAA-BBBBB)
- ✓ Al eliminar cliente, se eliminan TODAS sus cuentas
- ✓ Se pueden realizar transacciones (depósito, retiro, transferencia)
- ✓ Historial de movimientos funciona
- ✓ Documentación completa
- ✓ 0 crashes en operaciones básicas

---

## 📝 NOTAS IMPORTANTES

1. **Eliminación en Cascada (CRÍTICO)**:
   - Esta es la funcionalidad más importante
   - Debe ser 100% confiable
   - Probar exhaustivamente antes de marcar como lista

2. **Números de Cuenta**:
   - Formato: AAAA-BBBBB (ej: 2024-00001)
   - Secuencial automático
   - No editable por usuario
   - Debe ser único en todo el sistema

3. **Relación Cliente-Cuenta**:
   - 1 cliente puede tener N cuentas
   - 1 cuenta pertenece a 1 cliente
   - Al cambiar cliente, no se puede cambiar cuenta de un cliente a otro

4. **Datos en Memoria**:
   - Actualmente se usan List<> en memoria
   - Para producción, migrar a base de datos
   - Guardar datos en archivo JSON/XML como respaldo

---

## 📞 CONTACTO

- **Repositorio**: https://github.com/bojeda227/SistemaNomina
- **Rama**: main
- **IDE**: Visual Studio Community 2026
- **Framework**: .NET Framework 4.7.2

---

**Fin del Plan de Implementación**

---

## 📋 CHECKLIST RÁPIDO

- [ ] Paso 1: Actualizar `.csproj`
- [ ] Paso 2: Compilar proyecto
- [ ] Paso 3: Revisar `Persona.cs`
- [ ] Paso 4: Actualizar `Program.cs`
- [ ] Paso 5: Crear `BaseDatos.cs`
- [ ] Paso 6: Crear `Utilidades.cs`
- [ ] Paso 7: Modificar `frmAdmin.cs`
- [ ] Paso 8: Crear `frmClienteNuevo.cs`
- [ ] Paso 9: Crear `frmClienteEditar.cs`
- [ ] Paso 10: Crear `frmCuentaNueva.cs`
- [ ] Paso 11: Crear `frmTransacciones.cs`
- [ ] Paso 12: Crear `frmCuentasDelCliente.cs`
- [ ] Paso 13: Implementar eliminación cascada
- [ ] Paso 14: Validar números únicos
- [ ] Paso 15: Implementar transacciones
- [ ] Paso 16: Implementar historial
- [ ] Paso 17: Crear datos de ejemplo
- [ ] Paso 18: Pruebas de eliminación
- [ ] Paso 19: Pruebas de números
- [ ] Paso 20: Actualizar `README.md`
- [ ] Paso 21: Agregar comentarios XML
- [ ] Paso 22: Build final


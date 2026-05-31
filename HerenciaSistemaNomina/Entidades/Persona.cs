using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HerenciaSistemaNomina.Entidades
{
    public abstract class Persona
    {
        private string idCodigo;
        private string cedula;
        private string nombre;
        private string apellidos;
        private DateTime fechaNacimiento;
        private char sexo;
        private string estadoCivil;
        private string direccion;
        private string telefono;
        private string tipo;

        public Persona()
        {

        }

        public Persona(string idCodigo, string cedula, string nombre, string apellidos, DateTime fechaNacimiento,
            char sexo, string estadoCivil, string direccion, string telefono, string tipo)
        {
            this.IdCodigo = idCodigo;
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.FechaNacimiento = fechaNacimiento;
            this.Sexo = sexo;
            this.EstadoCivil = estadoCivil;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Tipo = tipo;
        }

        public string IdCodigo { get => idCodigo; set => idCodigo = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public char Sexo { get => sexo; set => sexo = value; }
        public string EstadoCivil { get => estadoCivil; set => estadoCivil = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Tipo { get => tipo; set => tipo = value; }

        public int Edad
        {
            get
            {
                DateTime fechaActual = DateTime.Now;
                int edad = fechaActual.Year - this.fechaNacimiento.Year;
                if (fechaActual.Month < this.fechaNacimiento.Month || (fechaActual.Month == this.fechaNacimiento.Month && fechaActual.Day < this.fechaNacimiento.Day))
                {
                    edad--;
                }
                return edad;
            }
        }
        public string EdadCompleta()
        {
            DateTime fechaActual = DateTime.Now;
            int edad = fechaActual.Year - this.fechaNacimiento.Year;
            if (fechaActual.Month < this.fechaNacimiento.Month || (fechaActual.Month == this.fechaNacimiento.Month && fechaActual.Day < this.fechaNacimiento.Day))
            {
                edad--;
            }
            int meses = (fechaActual.Month - this.fechaNacimiento.Month + 12) % 12;
            int dias = (fechaActual.Day - this.fechaNacimiento.Day + DateTime.DaysInMonth(this.fechaNacimiento.Year, this.fechaNacimiento.Month)) % DateTime.DaysInMonth(this.fechaNacimiento.Year, this.fechaNacimiento.Month);
            return $"{edad} años, {meses} meses y {dias} días";
        }
        public void Imprimir1()
        {
            MessageBox.Show($"Código: {this.idCodigo}\n" +
                            $"Cédula: {this.cedula}\n" +
                            $"Nombre: {this.nombre} {this.apellidos}\n" +
                            $"Edad: {this.Edad}\n" +
                            $"Edad Completa: {this.EdadCompleta()}\n" +
                            $"Sexo: {this.sexo}\n" +
                            $"Estado Civil: {this.estadoCivil}\n" +
                            $"Dirección: {this.direccion}\n" +
                            $"Teléfono: {this.telefono}");
        }
        public string ImprimirCadena()
        {
            return ($"Código: {this.idCodigo}\n" +
                            $"Cédula: {this.cedula}\n" +
                            $"Nombre: {this.nombre} {this.apellidos}\n" +
                            $"Edad: {this.Edad}\n" +
                            $"Edad Completa: {this.EdadCompleta()}\n" +
                            $"Sexo: {this.sexo}\n" +
                            $"Estado Civil: {this.estadoCivil}\n" +
                            $"Dirección: {this.direccion}\n" +
                            $"Teléfono: {this.telefono}");
        }

        public double BonoAntiguedad
        {
            get
            {
                double bono = 0;
                if (Edad >= 60)
                {
                    bono = 50;
                }
                return bono;
            }
        }

        public double bonoCumpleanios
        {
            get
            {
                double bono = 0;
                DateTime fechaActual = DateTime.Now;
                if (fechaActual.Month == this.fechaNacimiento.Month)
                {
                    bono = 100;
                }

                return bono;
            }
        }

        public int Antiguedad
        {
            get
            {
                return Edad;
            }
        }

        public abstract double CalcularSueldo { get; }
        public abstract void Imprimir2();
    }
}

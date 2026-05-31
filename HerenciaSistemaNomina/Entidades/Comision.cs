using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HerenciaSistemaNomina.Entidades
{
    public class Comision : Persona
    {
        private double ventas;
        private double porcentage;

        public Comision()
            : base()
        {

        }

        public Comision(string idCodigo, string cedula, string nombre, string apellidos, DateTime fechaNacimiento,
            char sexo, string estadoCivil, string direccion, string telefono, string tipo, double ventas, double porcentage)
            : base(idCodigo, cedula, nombre, apellidos, fechaNacimiento, sexo, estadoCivil, direccion, telefono, tipo)
        {
            this.Ventas = ventas;
            this.Porcentage = porcentage;
        }

        public double Ventas { get => ventas; set => ventas = value; }
        public double Porcentage { get => porcentage; set => porcentage = value; }

        public override double CalcularSueldo
        {
            get
            {
                return (Ventas * Porcentage/100) + BonoAntiguedad + bonoCumpleanios;
            }
        }

        public override void Imprimir2()
        {
            MessageBox.Show(base.ImprimirCadena() + "Ventas: " + Ventas +
                "\nPorcentage: " + Porcentage +
                "\nSueldo Neto: " + CalcularSueldo);
        }
    }
}

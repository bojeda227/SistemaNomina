using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HerenciaSistemaNomina.Entidades
{
    public class Comisionado : Comision
    {
        private double salario;

        public Comisionado()
            : base()
        {

        }

        public Comisionado(string idCodigo, string cedula, string nombre, string apellidos, DateTime fechaNacimiento,
            char sexo, string estadoCivil, string direccion, string telefono, string tipo, double ventas, double porcentage, double salario)
            : base(idCodigo, cedula, nombre, apellidos, fechaNacimiento, sexo, estadoCivil, direccion, telefono, tipo, ventas, porcentage)
        {
            this.Salario = salario;
        }

        public double Salario { get => salario; set => salario = value; }

        public override double CalcularSueldo
        {
            get
            {
                return (Ventas * Porcentage / 100) + BonoAntiguedad + bonoCumpleanios;
            }
        }

        public override void Imprimir2()
        {
            MessageBox.Show(base.ImprimirCadena() + "Salario: " + Salario +
                "\nVentas: " + Ventas +
                "\nPorcentage: " + Porcentage +
                "\nSueldo Neto: " + CalcularSueldo);
        }
    }
}

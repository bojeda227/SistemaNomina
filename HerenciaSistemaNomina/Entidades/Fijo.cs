using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HerenciaSistemaNomina.Entidades
{
    public class Fijo : Persona
    {
        private double salario;
        private double iess;
        private double anticipo;

        public Fijo()
            : base()
        {

        }

        public Fijo(string idCodigo, string cedula, string nombre, string apellidos, DateTime fechaNacimiento,
            char sexo, string estadoCivil, string direccion, string telefono, string tipo, double salario, double iess, double anticipo)
            : base(idCodigo, cedula, nombre, apellidos, fechaNacimiento, sexo, estadoCivil, direccion, telefono, tipo)
        {
            this.Salario = salario;
            this.Iess = iess;

            if(anticipo <= (salario * 0.50))
            {
                this.Anticipo = anticipo;
            }
        }

        public double Salario { get => salario; set => salario = value; }
        public double Iess { get => iess; set => iess = value; }
        public double Anticipo { get => anticipo; set => anticipo = value; }

        //Propiedades de calculo
        public double CalcularIess => Salario * 0.0932;

        public override double CalcularSueldo
        {
            get
            {
                double total = Salario - CalcularIess - Anticipo
                               + BonoAntiguedad + bonoCumpleanios;

                return Math.Round(total, 2);
            }
        }

        public override void Imprimir2()
        {
            MessageBox.Show(base.ImprimirCadena() +"Salario: " + Salario +
                "\nIess: " + CalcularIess +
                "\nAnticipo: " + Anticipo +
                "\nBono Antiguedad: " + BonoAntiguedad +
                "\nBono Cumpleaños: " + bonoCumpleanios +
                "\nSueldo Neto: " + CalcularSueldo);
        }


    }
}

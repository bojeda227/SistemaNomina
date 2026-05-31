using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaSistemaNomina.Entidades
{
    public class Contratado: Persona
    {
        private double hora;
        private double costo;
        private double iess;

        public Contratado()
            : base()
        {
        }

        public Contratado(string idCodigo, string cedula, string nombre, string apellidos, DateTime fechaNacimiento,
            char sexo, string estadoCivil, string direccion, string telefono, string tipo, double hora, double costo, double iess)
            : base(idCodigo, cedula, nombre, apellidos, fechaNacimiento, sexo, estadoCivil, direccion, telefono, tipo)
        {
            this.Hora = hora;
            this.Costo = costo;
            this.Iess = iess;
        }

        public double Hora { get => hora; set => hora = value; }
        public double Costo { get => costo; set => costo = value; }
        public double Iess { get => iess; set => iess = value; }

        public double CalcularIess
            {
            get
            {
                double calculoiess = 0;

                if(hora >= 160)
                {
                    calculoiess = (hora * costo * iess / 100); 
                }
                return calculoiess;
            }
        }

        public override double CalcularSueldo
        {
            get
            {
                double total = Hora * Costo;

                if (Hora > 160)
                    total -= total * (Iess / 100);

                return total + BonoAntiguedad + bonoCumpleanios;
            }
        }

        public override void Imprimir2()
        {
            Console.WriteLine(base.ImprimirCadena() + "Hora: " + Hora +
                "\nCosto: " + Costo +
                "\nIess: " + CalcularIess +
                "\nBono Antiguedad: " + BonoAntiguedad +
                "\nBono Cumpleaños: " + bonoCumpleanios +
                "\nSueldo Neto: " + CalcularSueldo);
        }
    }
}

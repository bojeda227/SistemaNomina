using HerenciaSistemaNomina.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaSistemaNomina.Controlador
{
    public class TLista
    {
        public static List<Persona> lista = new List<Persona>();

        public static void Agregar(Persona op)
        {
            lista.Add(op);
        }

        public static void Modificar(int pos, Persona op)
        {
            if (pos >= 0 && pos < lista.Count)
            {
                lista[pos] = op;
            }
        }

        public static void Eliminar(int pos)
        {
            if (pos >= 0 && pos < lista.Count)
            {
                lista.RemoveAt(pos);
            }
        }

        public static int Buscar(string idCodigo)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].IdCodigo.Equals(idCodigo))
                {
                    return i;
                }
            }
            return -1;
        }
        public static Persona getPersona(int pos)
        {
            if (pos >= 0 && pos < lista.Count)
            {
                return lista[pos];
            }
            return null;
        }

        public static List<Fijo> ListarFijos()
        {

            List<Fijo> fijos = new List<Fijo>();

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Tipo.Equals("Fijo"))
                {

                    fijos.Add((Fijo)getPersona(i));
                }
            }
            return fijos;
        }

        public static List<Contratado> ListarContratados()
        {

            List<Contratado> contratados = new List<Contratado>();

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Tipo.Equals("Contratado"))
                {

                    contratados.Add((Contratado)getPersona(i));
                }
            }
            return contratados;
        }

        public static List<Comision> ListarComision()
        {

            List<Comision> comisiones = new List<Comision>();

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Tipo.Equals("Comision"))
                {

                    comisiones.Add((Comision)getPersona(i));
                }
            }
            return comisiones;
        }

        public static List<Comisionado> ListarComisionado()
        {

            List<Comisionado> comisionados = new List<Comisionado>();

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Tipo.Equals("Comisionado"))
                {

                    comisionados.Add((Comisionado)getPersona(i));
                }
            }
            return comisionados;
        }
    }
}

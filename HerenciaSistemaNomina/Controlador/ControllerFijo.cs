using HerenciaSistemaNomina.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaSistemaNomina.Controlador
{
    public class ControllerFijo
    {
        public static List<Fijo> listaFijo = new List<Fijo>();

        public static void Agregar(Fijo of)
        {
            listaFijo.Add(of);
        }

        public static void Modificar(int pos, Fijo of)
        {
            if (pos >= 0 && pos < listaFijo.Count)
            {
                listaFijo[pos] = of;
            }
        }

        public static void Eliminar(int pos)
        {
            if (pos >= 0 && pos < listaFijo.Count)
            {
                listaFijo.RemoveAt(pos);
            }
        }

        public static int Buscar(string idCodigo)
        {
            for (int i = 0; i < listaFijo.Count; i++)
            {
                if (listaFijo[i].IdCodigo.Equals(idCodigo))
                {
                    return i;
                }
            }
            return -1;
        }

        public static Fijo getFijo(int pos)
        {
            if (pos >= 0 && pos < listaFijo.Count)
            {
                return listaFijo[pos];
            }
            return null;
        }
    }
}

using HerenciaSistemaNomina.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaSistemaNomina.Controlador
{
    public class ControllerComision
    {
        public static List<Comision> listaComision = new List<Comision>();
        public static void Agregar(Comision of)
        {
            listaComision.Add(of);
        }
        public static void Modificar(int pos, Comision of)
        {
            if (pos >= 0 && pos < listaComision.Count)
            {
                listaComision[pos] = of;
            }
        }
        public static void Eliminar(int pos)
        {
            if (pos >= 0 && pos < listaComision.Count)
            {
                listaComision.RemoveAt(pos);
            }
        }
        public static int Buscar(string idCodigo)
        {
            for (int i = 0; i < listaComision.Count; i++)
            {
                if (listaComision[i].IdCodigo.Equals(idCodigo))
                {
                    return i;
                }
            }
            return -1;
        }
        public static Comision getComision(int pos)
        {
            if (pos >= 0 && pos < listaComision.Count)
            {
                return listaComision[pos];
            }
            return null;
        }
    }
}

using HerenciaSistemaNomina.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaSistemaNomina.Controlador
{
    public class ControllerComisionado
    {
        public static List<Comisionado> listaComisionado = new List<Comisionado>();
        public static void Agregar(Comisionado of)
        {
            listaComisionado.Add(of);
        }
        public static void Modificar(int pos, Comisionado of)
        {
            if (pos >= 0 && pos < listaComisionado.Count)
            {
                listaComisionado[pos] = of;
            }
        }
        public static void Eliminar(int pos)
        {
            if (pos >= 0 && pos < listaComisionado.Count)
            {
                listaComisionado.RemoveAt(pos);
            }
        }
        public static int Buscar(string idCodigo)
        {
            for (int i = 0; i < listaComisionado.Count; i++)
            {
                if (listaComisionado[i].IdCodigo.Equals(idCodigo))
                {
                    return i;
                }
            }
            return -1;
        }
        public static Comisionado getComisionado(int pos)
        {
            if (pos >= 0 && pos < listaComisionado.Count)
            {
                return listaComisionado[pos];
            }
            return null;
        }
    }
}

using HerenciaSistemaNomina.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaSistemaNomina.Controlador
{
    public class ControllerContratado
    {
       public static List<Contratado> listaContratado = new List<Contratado>();
        public static void Agregar(Contratado of)
        {
            listaContratado.Add(of);
        }

        public static void Modificar(int pos, Contratado of)
        {
            if (pos >= 0 && pos < listaContratado.Count)
            {
                listaContratado[pos] = of;
            }
        }

        public static void Eliminar(int pos)
        {
            if (pos >= 0 && pos < listaContratado.Count)
            {
                listaContratado.RemoveAt(pos);
            }
        }

        public static int Buscar(string idCodigo)
        {
            for (int i = 0; i < listaContratado.Count; i++)
            {
                if (listaContratado[i].IdCodigo.Equals(idCodigo))
                {
                    return i;
                }
            }
            return -1;
        }

        public static Contratado getContratado(int pos)
        {
            if (pos >= 0 && pos < listaContratado.Count)
            {
                return listaContratado[pos];
            }
            return null;
        }
    }
}

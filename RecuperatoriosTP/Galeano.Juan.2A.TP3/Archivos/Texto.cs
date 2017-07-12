using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivos<string>
    {
        /// <summary>
        /// Guarda en un archivo de texto los parametros recibidos
        /// </summary>
        /// <param name="archivos"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool guardar(string archivos, string datos)
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(archivos))
                escritor.WriteLine(datos);
                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }

        /// <summary>
        /// Lee de un archivo de texto 
        /// </summary>
        /// <param name="archivos"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool leer(string archivos, out string datos)
        {
            string Recuperado;
            StringBuilder bloque = new StringBuilder();
            try
            {
                using (StreamReader lector = new StreamReader(archivos))
                {
                    while ((Recuperado = lector.ReadLine()) != null)
                    {
                        bloque.AppendLine(Recuperado);
                    }
                }
                datos = bloque.ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }
    }
}

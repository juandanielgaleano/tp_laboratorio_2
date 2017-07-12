using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Excepciones;
using ClasesInstanciables;


namespace Archivos
{
    public class Xml<t> : IArchivos<t>
    {
        public bool guardar(string archivos, t datos)
        {
            XmlSerializer XmlS = new XmlSerializer(typeof(Universidad));
            try
            {
                using (StreamWriter sw = new StreamWriter(archivos, true))
                    XmlS.Serialize(sw, datos);
                return true;
            }
            catch (ArchivosException ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lee de un archivo XML los datos de una universidad
        /// y los devuelve por out.
        /// </summary>
        /// <param name="archivos">Direccion del archivo.</param>
        /// <param name="datos">Salida de la universidad.</param>
        /// <returns>Devuelve true si leyo con exito o lanza una
        /// excepcion si no pudo</returns>
        public bool leer(string archivos, out t datos)
        {
            XmlSerializer XmlS = new XmlSerializer(typeof(Universidad));
            try
            {
                using (StreamReader sr = new StreamReader(archivos))
                    datos = (t)XmlS.Deserialize(sr);
                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }
    }
}


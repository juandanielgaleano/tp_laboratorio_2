using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivos<t>
    {
        /// <summary>
        /// Interface para guardar archivos, true si guardo
        /// </summary>
        /// <param name="Archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool guardar(string archivo, t datos);
        /// <summary>
        /// Interface para leer archivos, true si pudo leer.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool leer(string archivo, out t datos);


    }
}

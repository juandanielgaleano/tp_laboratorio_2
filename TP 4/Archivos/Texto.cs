using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _archivo;

        public Texto(string archivo)
        {
            this._archivo = archivo;
        }

        public bool guardar(string datos)
        {

            try
            {
                StreamWriter escritor = new StreamWriter(this._archivo, true);
                escritor.Write(datos);
                escritor.Close();
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool leer(out List<string> datos)
        {
            try
            {
                string line;
                StreamReader lector = new StreamReader(this._archivo);
                datos = new List<string>();

                while ((line = lector.ReadLine()) != null)
                {
                    datos.Add(line);
                }

                lector.Close();
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }            
        }
    }
}

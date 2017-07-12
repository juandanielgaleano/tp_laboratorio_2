using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClasesInstanciables
{
    /// <summary>
    /// Atributos Profesor, Clase y Alumnos que toman dicha clase.  
    /// </summary>
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }
        public Universidad.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }
        public Profesor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; }
        }
        /// Se inicializará la lista de alumnos en el constructor por defecto.
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno item in j._alumnos)
            {
                if (item == a)
                    return true;
            }
            return false;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// Agregar Alumnos a la clase por medio del operador +
        ///, validando que no estén previamente cargados.
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j._alumnos.Add(a);
            }
            return j;
        }
        /// ToString mostrará todos los datos de la Jornada.
        public override string ToString()
        {
            StringBuilder bloque = new StringBuilder();
            bloque.AppendLine("JORNADA: ");
            bloque.AppendLine("CLASE DE " + this._clase + " POR " + this._instructor.ToString());
            bloque.AppendLine("ALUMNOS: ");

            foreach (Alumno item in this._alumnos)
                bloque.AppendLine(item.ToString());

            bloque.AppendLine("<------------------------------------------------>");

            return bloque.ToString();
        }

        /// Guardar de clase guardará los datos de la Jornada en un archivo de texto.
        public static bool Guardar(Jornada miJornada)
        {
            using (StreamWriter escritor = new StreamWriter("Jornada.txt"))
            {
                escritor.WriteLine(miJornada.ToString());
            }
            return true;
        }
        /// Leer de clase retornará los datos de la Jornada como texto
        public static string Leer()
        {
            StringBuilder bloque = new StringBuilder();
            using (StreamReader lector = new StreamReader("Jornada.txt"))
            {
                while (lector!=null)
                {
                    bloque.AppendLine(lector.ReadLine());
                }                
            }
            return bloque.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj is Jornada)
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

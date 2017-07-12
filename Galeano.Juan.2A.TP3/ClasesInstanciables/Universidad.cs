using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Xml.Serialization;
using System.IO;

namespace ClasesInstanciables
{
    /// <summary>
    ///  Atributos Alumnos (lista de inscriptos), Profesores (lista de quienes pueden dar clases) 
    /// y Jornadas.   
    /// </summary>
    
    public class Universidad
    {
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }
        private List<Alumno> _alumnos;
        private List<Jornada> _jornada;
        private List<Profesor> _profesores;
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }

            set { this._alumnos = value; }
        }
        public List<Jornada> Jornada
        {
            get { return this._jornada; }
            set { this._jornada = value; }
        }
        public List<Profesor> Profesores
        {
            get { return this._profesores; }
            set { this._profesores = value; }
        }
        /// Se accederá a una Jornada específica a través de un indexador.   
        public Jornada this[int i]
        {
            get {return this._jornada[i] ;}
            set {this._jornada[i]=value ;}
        }
        public Universidad()
        {
            this._alumnos = new List<Alumno>();
            this._jornada = new List<ClasesInstanciables.Jornada>();
            this._profesores = new List<Profesor>();
        }


        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno item in g._alumnos)
            {
                if (item == a)
                    return true;
            }
            return false;
        }
        public static bool operator!=(Universidad g,Alumno a)
        {
            return !(g==a);
        }
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor item in g._profesores)
            {
                if (item == i)
                    return true;
            }
            return false;
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g==i);
        }
        /// Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada
        ///indicando la clase, un Profesor que pueda darla (según su atributo ClasesDelDia) y la 
        ///lista de alumnos que la toman(todos los que coincidan en su campo ClaseQueToma).
        public static Universidad operator +(Universidad g, Universidad.EClases clase)
        {
            Jornada miJornada = new ClasesInstanciables.Jornada(clase, g == clase);            
            foreach (Alumno item in g._alumnos)
            {
                if (item==clase)
                {
                    miJornada.Alumnos.Add(item);
                    g._jornada.Add(miJornada);
                }
            }
            return g;            
        }
        /// Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén 
        ///previamente cargados.
        public static Universidad operator +(Universidad g, Alumno a)
        {
              if (g==a)
                {
                throw new AlumnoRepetidoException();
                }            
            g._alumnos.Add(a);
            return g;
        }
        public static Universidad operator +(Universidad g, Profesor i)
        {
               if (g!=i)
                {
                    g._profesores.Add(i);
                    return g;
                }            
            return g;
        }
        /// La igualación entre un Universidad y una Clase retornará el primer Profesor capaz
        ///de dar esa clase.Sino, lanzará la Excepción SinProfesorException. El distinto retornará
        ///el primer Profesor que no pueda dar la clase.
        
        public static Profesor operator ==(Universidad g,EClases clase)
        {
              foreach (Profesor item in g._profesores)
                {
                    if (item != clase)
                        return item;
                }          
                throw new SinProfesorException();           
        }
        /// <summary>
        /// El distinto retornará
        ///el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator!=(Universidad g,EClases clase)
        {           
                foreach (Profesor item in g._profesores)
                {
                    if (item == clase)
                        return item;
                }
            throw new SinProfesorException();
        }
        /// MostrarDatos será privado y de clase.
        ///Los datos del Universidad se harán públicos mediante
        ///ToString.
        private string MostrarDatos(Universidad gim)
        {
            StringBuilder bloque = new StringBuilder();
            for (int i = 0; i < gim._jornada.Count; i++)
            {
                //if(gim._jornada[i]!= null)
                bloque.AppendLine(gim._jornada[i].ToString());
            }
            return bloque.ToString();               
        }
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        /// Guardar de clase serializará los datos del Universidad en un XML
        ///, incluyendo todos los datos de sus Profesores, Alumnos y Jornadas.
        /// Leer de clase retornará un Universidad
        ///con todos los datos previamente serializados.

        public static bool Guardar(Universidad gim)
        {
            XmlSerializer XmlS = new XmlSerializer(typeof(Universidad));
            try
            {
                using (StreamWriter Escritor = new StreamWriter("Universidad.xml"))
                {
                    XmlS.Serialize(Escritor, gim);
                }
                return true;
            }
            catch (ArchivosException ex)
            {
                throw ex;
            }
        }


        public override bool Equals(object obj)
        {
            if (obj is Universidad)
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

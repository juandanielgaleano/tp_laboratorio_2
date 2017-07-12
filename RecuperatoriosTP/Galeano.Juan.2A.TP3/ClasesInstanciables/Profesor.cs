using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
namespace ClasesInstanciables
{
    [Serializable]
    public class Profesor:Universitario
    {
        /// <summary>
        /// Atributos ClasesDelDia del tipo Cola y random del tipo Random
        /// y estático.      
        /// </summary>
        protected Queue<Universidad.EClases> _clasesDelDia;
        protected static Random _random;

        private void _randomClases()
        {
            this._clasesDelDia.Enqueue((Universidad.EClases)_random.Next(0, 4));
            this._clasesDelDia.Enqueue((Universidad.EClases)_random.Next(0, 4));
        }
        /// Se inicializará a Random sólo en un constructor.
        static Profesor()
        {
            _random = new Random();
        }
        protected Profesor()
        {
            
        }
        /// En el constructor de instancia se inicializará ClasesDelDia
        ///y se asignarán dos clases al azar al Profesor mediante el 
        ///método randomClases.Las dos clases pueden o no ser la misma.
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();   
            

        }
        /// Sobrescribir el método MostrarDatos con todos los datos 
        ///del alumno.
        protected override string MostrarDatos()
        {
            return base.MostrarDatos();
        }
        /// ParticiparEnClase retornará la cadena "CLASES DEL DÍA " 
        ///junto al nombre de la clases que da.
        protected override string ParticiparEnClase()
        {
            StringBuilder bloque = new StringBuilder();
            bloque.AppendLine("CLASE DEL DIA: ");
            foreach (Universidad.EClases item in this._clasesDelDia)
            {
                bloque.AppendLine(" "+item);
            }
            return bloque.ToString();
        }
        /// Un Profesor será igual a un EClase si da esa clase
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases item in i._clasesDelDia)
            {
                if (item == clase)
                    return true;
            }          
            return false;
        }
        public static bool operator!=(Profesor i, Universidad.EClases clase)
        {
            return !(i==clase);
        }
        /// ToString hará públicos los datos del Profesor.
        public override string ToString()
        {
            StringBuilder bloque = new StringBuilder();
            bloque.AppendLine(base.ToString());
            bloque.AppendLine("LEGAJO NUMERO: "+this._legajo);
            bloque.AppendLine(this.ParticiparEnClase());
            return bloque.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj is Profesor)
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

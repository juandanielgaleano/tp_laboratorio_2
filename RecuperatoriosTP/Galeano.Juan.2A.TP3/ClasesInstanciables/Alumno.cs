using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
namespace ClasesInstanciables
{
    public class Alumno:Universitario
    {
        public enum EEstadoCuenta
        {
            Becado, Deudor, AlDia
        }
        /// <summary>
        /// Atributos ClaseQueToma del tipo EClase y EstadoCuenta del 
        /// tipo EEstadoCuenta.       
        /// </summary>
        protected Universidad.EClases _claseQueToma;
        protected EEstadoCuenta _estadoCuenta;
        

        public Alumno()
        { }
        public Alumno(int id, string nombre, string apellido, string dni,ENacionalidad nacionalidad, Universidad.EClases claseQueToma):base(id,nombre,apellido,dni,nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta):this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        /// ParticiparEnClase retornará la cadena "TOMA CLASE DE " 
        ///junto al nombre de la clase que toma.
        protected override string ParticiparEnClase()
        {
            StringBuilder bloque = new StringBuilder();
            bloque.AppendLine("TOMA CLASES DE " +this._claseQueToma);
            return bloque.ToString();
        }
        /// Un Alumno será igual a un EClase si toma esa clase y su 
        ///estado de cuenta no es Deudor.
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
                return true;
            return false;
        }
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase.
        public static bool operator !=(Alumno a,Universidad.EClases clase)
        {
            if (a._claseQueToma != clase)
                return true;
            return false;
        }
        /// Sobreescribirá el método MostrarDatos con todos los datos
        ///del alumno.
        /// ToString hará públicos los datos del Alumno.
        public override string ToString()
        {
            StringBuilder bloque = new StringBuilder();
            bloque.AppendLine(base.ToString());
            bloque.AppendLine("LEGAJO NUMERO: " + this._legajo);
            bloque.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta);
            bloque.AppendLine("CLASE QUE TOMA: "+this._claseQueToma);
            
            return bloque.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj is Alumno)
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

 
}


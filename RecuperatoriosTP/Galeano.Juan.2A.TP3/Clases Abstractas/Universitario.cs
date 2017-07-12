using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario:Persona
    {
        /// <summary>
        ///  Abstracta, con el atributo Legajo.
        /// /// </summary>
        protected int _legajo;

        public Universitario()
        { }
        public Universitario(int legajo,string nombre,string apellido,string dni,ENacionalidad nacionalidad):base(nombre,apellido,dni,nacionalidad)
        {
            this._legajo = legajo;
        }
        /// Método protegido y virtual MostrarDatos retornará 
        ///todos los datos del Universitario.

        protected virtual string MostrarDatos()
        {
            StringBuilder bloque = new StringBuilder();
            bloque.AppendLine(base.ToString());                        
            return bloque.ToString();
         }
        /// Método protegido y abstracto ParticiparEnClase.
        protected abstract string ParticiparEnClase();
        /// Dos Universitario serán iguales si y sólo si son del
        ///mismo Tipo y su Legajo o DNI son iguales.
        public static bool operator ==(Universitario pg1,Universitario pg2)
        {
            if (pg1._legajo == pg2._legajo || pg1._dni == pg2._dni)
                return true;
            return false;
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return (pg1 == pg2);
              
        }
        public override bool Equals(object obj)
        {
            if (obj is Universitario)
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}


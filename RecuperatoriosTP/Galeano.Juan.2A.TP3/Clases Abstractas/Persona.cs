using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        /// <summary>
        ///  Abstracta, con los atributos
        /// Nombre, Apellido, Nacionalidad y DNI.       
        /// Validará que los nombres sean cadenas
        ///con caracteres válidos para
        ///nombres.Caso contrario, no se cargará.        
        /// </summary>
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        protected string _apellido;
        protected string _nombre;
        protected int _dni;
        protected ENacionalidad _nacionalidad;
        /// <summary>
        /// Apellido de la persona
        /// </summary>
        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = value;}
        }
        /// <summary>
        /// Nombre de la persona
        /// </summary>
        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; } 
        }
        /// <summary>
        /// Dni de la persona, asigna dni a travez del metodo ValidarDni entero
        /// Sólo se realizarán las validaciones dentro de las propiedades.
        /// </summary>
        public int DNI
        {
            get { return this._dni; }
            set { this._dni = this.ValidarDni(this._nacionalidad, value);}
        }
        /// <summary>
        /// Nacionalidad de la persona
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }
        /// <summary>
        /// Asigna Dni a la persona a traves del metodo ValidarDni string
        /// </summary>
        public string StringToDNI
        {
            set {this._dni = this.ValidarDni(this._nacionalidad, value);}
        }
        /// <summary>
        /// Constructor de Persona
        /// </summary>
        protected Persona()
        { }
        /// <summary>
        /// Constructor de instancias de clase Persona
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="Apellido"></param>
        /// <param name="Nacionalidad"></param>
        protected Persona(string Nombre, string Apellido,ENacionalidad Nacionalidad)
        {
            this._nombre = Nombre;
            this._apellido = Apellido;
            this._nacionalidad = Nacionalidad;
        }
        /// <summary>
        /// Constructor de instancias de Persona
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="Apellido"></param>
        /// <param name="DNI"></param>
        /// <param name="Nacionalidad"></param>
        protected Persona(string Nombre, string Apellido, int DNI, ENacionalidad Nacionalidad):this(Nombre,Apellido,Nacionalidad)
        {
            this.DNI = DNI;
        }
        /// <summary>
        /// Constructor de instancias, 
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="Apellido"></param>
        /// <param name="DNI"></param>
        /// <param name="Nacionalidad"></param>
        protected Persona(string Nombre, string Apellido, string DNI, ENacionalidad Nacionalidad):this(Nombre,Apellido,Nacionalidad)
        {
            this.StringToDNI = DNI;           
        }
        /// <summary>
        /// Metodo privado ValidarDni, Se deberá validar que el DNI sea correcto, teniendo en cuenta su
        /// nacionalidad.Argentino entre 1 y 89999999. Caso contrario, se lanzará 
        /// la excepción DniInvalidoException.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato">int</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Extranjero && dato >= 1 && dato <= 89999999)
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se coincide con el numero de DNI");
            }
            if (nacionalidad==ENacionalidad.Argentino && dato>=1 && dato<= 89999999)
               return dato;
            if (nacionalidad == ENacionalidad.Extranjero &&  dato > 89999999)
                return dato;
                throw new DniInvalidoException("La nacionalidad no se coincide con el numero de DNI");
        }
        /// <summary>
        /// Metodo privado ValidarDni, Se deberá validar que el DNI sea correcto, teniendo en cuenta su
        /// nacionalidad.Argentino entre 1 y 89999999. Caso contrario, se lanzará 
        /// la excepción DniInvalidoException.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato">string</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retorno = 0;
                         
            if (int.TryParse(dato, out retorno))
            {
                retorno = ValidarDni(nacionalidad, retorno);
                return retorno;
            }
            if (nacionalidad != ENacionalidad.Argentino && retorno >= 1 && retorno <= 89999999)
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se coincide con el numero de DNI");
            }
            throw new DniInvalidoException("La nacionalidad no se coincide con el numero de DNI");

        }
        /// ToString retornará los datos de la Persona
        public override string ToString()
        {
            StringBuilder bloque = new StringBuilder();
            bloque.Append("NOMBRE COMPLETO: " + this._apellido);
            bloque.AppendLine(","+ this._nombre);
            bloque.AppendLine("NACIONALIDAD : " + this._nacionalidad);           
            return bloque.ToString();            
        }
    }    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    class Numero
    {        
            public double numero;
            /// <summary>
            /// Constructor por defecto, inicializa el atributo numero en 0
            /// </summary>
            public Numero()
            {
                this.numero = 0;
            }
            /// <summary>
            /// Recibe un double y se carga en numero
            /// </summary>
            /// <param name="numero"></param>
            public Numero(double numero)
            {
                this.numero = numero;
            }
            /// <summary>
            /// Recibe un string que se validara y se cargara en numero
            /// </summary>
            /// <param name="numero"></param>
            public Numero(string numero)
            {
                this.numero = setter(numero);
            }/// <summary>
             /// Validará que se trate de un double válido, caso contrario
             ///  retornará 0.
             /// </summary>
             /// <param name="numero"></param>
             /// <returns></returns>
            private static double validarNumero(string numero)
            {
                double retorno = 0;

                if (double.TryParse(numero, out retorno))
                {
                    return retorno;
                }
                else
                {
                    return 0;
                }
            }
        /// <summary>
        /// método privado del tipo setter. Este será el único lugar
        ///donde se podrá utilizar el método validarNumero.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
            private double setter(string numero)
            {
                return this.numero = validarNumero(numero);

            }
        }
    }



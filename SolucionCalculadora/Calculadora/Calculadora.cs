using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    class Calculadora
    {
        /// <summary>
        /// Recibe dos objetos y del tipo numero
        /// y un String llamado operador.Su valor de retorno será del tipo double. Si no puede operar
        ///(división por 0), retornará 0.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double operar(Numero numero1, Numero numero2, string operador)
            {
                double retorno = 0;

                switch (operador)
                {
                    case "+":
                        retorno = numero1.numero + numero2.numero;
                        break;
                    case "-":
                        retorno = numero1.numero - numero2.numero;
                        break;
                    case "*":
                        retorno = numero1.numero * numero2.numero;
                        break;
                    case "/":
                        if (numero2.numero != 0)
                            retorno = numero1.numero / numero2.numero;
                        else
                            return retorno;
                        break;
                }
                return retorno;
            }

        /// <summary>
        /// Validará que el operador sea un caracter válido, caso contrario
        ///retornará “+”.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
            public static string validarOperador(string operador)
            {
                if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
                {
                    return operador;
                }

                return "+";
            }
        }
    }



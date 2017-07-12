﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException:Exception
    {
        private string _mensajeBase;

        public DniInvalidoException():base()
        { }
        public DniInvalidoException (Exception e)
        { }
        public DniInvalidoException(string message)
        {
            this._mensajeBase = message;
        }
        public DniInvalidoException(string message, Exception e):this()
        { }
            
    }
}

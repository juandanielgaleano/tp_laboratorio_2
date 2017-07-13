using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using ClasesInstanciables;
using EntidadesAbstractas;

namespace testUnitarios
{
    [TestClass]
    public class test
    {
        [TestMethod]
        public void testAlumnoRepetido()
        {
            Universidad miUniversidad = new Universidad();

            Alumno miAlumno = new Alumno(0, "a", "a", "1", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            miUniversidad += miAlumno;
            Alumno miAlumno1 = new Alumno(0, "a", "a", "1", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            try
            {
                miUniversidad += miAlumno1;
            }
            catch (AlumnoRepetidoException e)
            {
                Console.WriteLine(e.Message);                               
            }
        }
        [TestMethod]
        public void NacionalidadInvalida()
        {
            Universidad gim = new Universidad();
            try
            {
                Alumno a2 = new Alumno(2, "Juana", "Martinez", "12234458", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Deudor);
                gim += a2;
            }
            catch (NacionalidadInvalidaException e)
            {
                Console.WriteLine(e.Message);
            }
        }

         [TestMethod]
        public void NumeroInvalido()
        {
            int num = 32;
            if (num != 32)
            {
                Console.WriteLine("Invalido.");
            }
        }

        [TestMethod]
        public void AlumnoInvalido()
        {
            Alumno a = new Alumno(15, "ABCD", "aaa", "109", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
            a.Nombre = "ak";
            try
            {
                if (a.Nombre != "ABCD")
                { }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

    }
}


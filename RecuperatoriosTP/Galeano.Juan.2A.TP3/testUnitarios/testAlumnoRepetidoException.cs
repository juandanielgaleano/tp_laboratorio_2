using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using ClasesInstanciables;
using EntidadesAbstractas;

namespace testUnitarios
{
    [TestClass]
    public class testAlumnoRepetidoException
    {
        [TestMethod]
        public void testAlumnoRepetido()
        {
            Universidad miUniversidad = new Universidad();

            Alumno miAlumno = new Alumno(0, "", "", "", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            miUniversidad += miAlumno;
            Alumno miAlumno1 = new Alumno(0, "", "", "", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            try
            {
                miUniversidad += miAlumno1;
                Assert.Fail();

            }
            catch (AlumnoRepetidoException)
            {
                               
            }
        }
    }
}

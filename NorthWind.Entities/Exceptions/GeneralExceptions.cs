using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Exceptions
{
    public class GeneralExceptions : Exception
    {
        //Exception es una clase que contiene Exceptiones
        public string Detail { get; set; } // En esta prop se guardan las expetions

        public GeneralExceptions() { }

        public GeneralExceptions(string message) : base(message) { }

        public GeneralExceptions(string message, 
            Exception innerException) : base(message, innerException) { } //Este ctor espera un Exption

        //Con este ctor guardamos en el Detail
        public GeneralExceptions(string title, string details) :
            base(title) => Detail = details;

        //Nota: en esta carpeta podemos tener las validaciones, ejemplo con la libreria
        //FluentValidation

    }
}

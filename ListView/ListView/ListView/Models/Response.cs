using System;
using System.Collections.Generic;
using System.Text;

namespace ListView.Models
{
    public class Response           // Aqui poner pulic para evitar errores
    {
        public bool IsSuccess
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public object Result
        {
            get;
            set;
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adminAlumnos.BLL
{
    internal class MaestroBLL
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set;}
        public string SegundoApellido { get; set;}
        public string Correo { get; set; }
        public int Edad { get; set; }
        public string Nivel { get; set; }
    }
}

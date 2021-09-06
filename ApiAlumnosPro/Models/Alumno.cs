using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlumnosPro.Models
{
    public class Alumno
    {
        [Key]
        public int id { get; set; }
        public int idM { get; set; }
        public string name { get; set; }
        public string lastnamep { get; set; }
        public string lastnamem { get; set; }
    }
}

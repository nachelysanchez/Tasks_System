using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks_System.Entidades
{
    public class Tareas
    {
        [Key]
        public int TareaId { get; set; }
        public string NombreTarea { get; set; }
        public string Descripcion { get; set; }
    }
}

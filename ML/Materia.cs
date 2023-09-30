using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Materia
    {
        public int IdMateria { get; set; }
        [Required(ErrorMessage ="Capo requerido.")]
        [StringLength(50,ErrorMessage ="Cantidad máxima de 50 caracteres.")]
        [RegularExpression("[A-Za-z ]*", ErrorMessage = "Sólo se permiten letras.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="Campo requerido.")]
        [Range(0,999, ErrorMessage ="Fuera del rango permitido (0-999).")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$",ErrorMessage ="Solo se permiten dos decimales.")]
        public decimal Costo { get; set; }
        public List<object> Materias { get; set; }
    }
}

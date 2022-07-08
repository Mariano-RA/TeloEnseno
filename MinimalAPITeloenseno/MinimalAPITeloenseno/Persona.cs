using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPITeloenseno
{
    public class Persona
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonaID { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public string DNI { get; set; } = string.Empty;

        public string Correo { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;


        public IList<PersonaCurso> PersonaCursos { get; set; }





    }
}


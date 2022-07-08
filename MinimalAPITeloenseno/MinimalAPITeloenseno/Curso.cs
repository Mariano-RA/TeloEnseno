using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPITeloenseno
{
    public class Curso
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CursoId { get; set; }
        public string Titulo { get; set; } = string.Empty;

        public string Categoria { get; set; } = string.Empty;

        public int Duracion { get; set; } = 0;

        public string Descripcion { get; set; } = string.Empty;

        public string Contenido { get; set; } = string.Empty;

        public int Precio { get; set; } = 0;

        public int Profesor { get; set; } = 0;

        public IList<PersonaCurso> PersonaCursos { get; set; }


    }
}

// Harol R. Paredes Perez
// Matricula colegial: 2026-0187

namespace CRUD_PERSONAS.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
    }
}

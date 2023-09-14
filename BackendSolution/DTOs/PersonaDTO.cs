using System;
using System.Collections.Generic;
using System.Linq;

namespace DTOs
{
    public class PersonaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string? Telefono { get; set; }
    }
}

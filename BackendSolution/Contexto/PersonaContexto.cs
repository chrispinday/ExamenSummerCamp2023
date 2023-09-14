using Entities;
using Microsoft.EntityFrameworkCore;

namespace Contexto
{
    public class PersonaContexto:DbContext
    {
        public PersonaContexto(DbContextOptions<PersonaContexto> opciones) : base(opciones)
        {

        }

        public DbSet<Persona> Persona { get; set; }


    }
}

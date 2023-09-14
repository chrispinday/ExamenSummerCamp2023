using Contexto;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class RepositorioPersona : IRepositorioPersona
    {
        private PersonaContexto _context;

        public RepositorioPersona(PersonaContexto context)
        {
            _context = context;
        }
        public void AgregarPersona(Persona persona)
        {
            if (persona == null)
            {
                throw new ArgumentNullException(nameof(persona));
            }
            _context.Persona.Add(persona);
        }

        public async Task<List<Persona>> ObtenerPersonasAsync()
        {
            return await _context.Persona.ToListAsync();
        }

        public async Task<List<Persona>> Obtener10PersonasAsync()
        {
            return await _context.Persona.Where(x => x.Edad >= 21)
                .OrderBy(x => x.Nombre)
                .Take(10)
                .ToListAsync();
        }

        public async Task<bool> PersonaExistsAsync(int id)
        {
            return await _context.Persona.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}

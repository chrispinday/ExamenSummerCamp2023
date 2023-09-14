using Entities;

namespace Repositorios
{
    public interface IRepositorioPersona
    {
        void AgregarPersona(Persona persona);
        Task<List<Persona>> ObtenerPersonasAsync();

        Task<List<Persona>> Obtener10PersonasAsync();
        Task<bool> PersonaExistsAsync(int id);
        Task<bool> SaveAsync();
    }
}

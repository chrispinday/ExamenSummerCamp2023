using AutoMapper;

namespace Perfiles
{
    public class PersonaPerfil : Profile
    {
        public PersonaPerfil() {
            CreateMap<Entities.Persona, DTOs.PersonaDTO>().ReverseMap();

            CreateMap<DTOs.PersonaForCreationDTO, Entities.Persona>();
        }
    }
}

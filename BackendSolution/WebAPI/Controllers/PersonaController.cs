using AutoMapper;
using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositorios;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IRepositorioPersona _repositorioPersona;
        private readonly IMapper _mapper;
        public PersonaController(IRepositorioPersona repositorioPersona, IMapper mapper)
        {
            _repositorioPersona = repositorioPersona;
            _mapper = mapper;
        }

        ////+ GET: api/Persona
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<PersonaDTO>>> GetPersonas()
        //{
        //    var lista = await _repositorioPersona.ObtenerPersonasAsync();
        //    var listaDTO = new List<PersonaDTO>();

        //    foreach (var persona in lista)
        //    {
        //        listaDTO.Add(_mapper.Map<PersonaDTO>(persona));
        //    }

        //    return Ok(listaDTO);
        //}

        //Get 10
        [HttpGet]
        //api/Persona/
        public async Task<ActionResult<IEnumerable<Persona>>> Get10Personas()
        {
            var lista = await _repositorioPersona.Obtener10PersonasAsync();
            var listaDTO = new List<PersonaDTO>();

            foreach (var persona in lista)
            {
                listaDTO.Add(_mapper.Map<PersonaDTO>(persona));
            }

            return Ok(listaDTO);
        }

        [HttpPost]
        public async Task<ActionResult> AddUsuarios([FromBody] PersonaForCreationDTO personaDTO)
        {
            try
            {

                if (personaDTO == null)
                {
                    return BadRequest();
                }

                Persona personaEntidad = _mapper.Map<Persona>(personaDTO);

                _repositorioPersona.AgregarPersona(personaEntidad);

                await _repositorioPersona.SaveAsync();

                PersonaDTO personaReturn = _mapper.Map<PersonaDTO>(personaEntidad);

                return Ok(new Response { Status = "Success", Message = "User created successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.GetType() + " - ERROR DE SERVIDOR " });
            }
        }
    }
}

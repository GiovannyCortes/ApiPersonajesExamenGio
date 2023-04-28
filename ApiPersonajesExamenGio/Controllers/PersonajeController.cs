using ApiPersonajesExamenGio.Models;
using ApiPersonajesExamenGio.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonajesExamenGio.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajeController : ControllerBase {

        private RepositoryPersonajes repo;

        public PersonajeController(RepositoryPersonajes repo) {
            this.repo = repo;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> Get() {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpGet] [Route("{idPersonaje}")]
        public async Task<ActionResult<Personaje?>> FindPersonaje(int idPersonaje) {
            return await this.repo.FindPersonajeAsync(idPersonaje);
        }

        [HttpPost] [Route("[action]")]
        public async Task<ActionResult> InsertPersonaje(Personaje personaje) {
            await this.repo.InsertPersonajeAsync(personaje.Nombre, personaje.Imagen, personaje.IdSerie);
            return Ok();
        }

        [HttpPut] [Route("[action]")]
        public async Task<ActionResult> UpdatePersonaje(Personaje personaje) {
            await this.repo.UpdatePersonajeAsync(personaje.IdPersonaje, personaje.Nombre, personaje.Imagen, personaje.IdSerie);
            return Ok();
        }

        [HttpDelete] [Route("[action]/{idPersonaje}")]
        public async Task<ActionResult> DeletePersonaje(int idPersonaje) {
            await this.repo.DeletePersonajeAsync(idPersonaje);
            return Ok();
        }
        
    }
}

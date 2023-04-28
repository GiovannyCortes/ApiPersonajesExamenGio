using ApiPersonajesExamenGio.Data;
using ApiPersonajesExamenGio.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesExamenGio.Repositories {
    public class RepositoryPersonajes {

        private PersonajesContext context;
        
        public RepositoryPersonajes(PersonajesContext context) {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync() {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<Personaje?> FindPersonajeAsync(int idPersonaje) {
            return await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == idPersonaje);
        }

        public async Task<bool> InsertPersonajeAsync(string nombre, string imagen, int idSerie) {
            int newid = await this.context.Personajes.AnyAsync() ? await this.context.Personajes.MaxAsync(x => x.IdPersonaje) + 1 : 1;
            Personaje personaje = new Personaje {
                IdPersonaje = newid,
                Nombre = nombre,
                Imagen = imagen,
                IdSerie = idSerie
            };

            this.context.Personajes.Add(personaje);
            return await this.context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePersonajeAsync(int idPersonaje, string nombre, string imagen, int idSerie) {
            Personaje? personaje = await this.FindPersonajeAsync(idPersonaje);
            if (personaje != null) {
                personaje.Nombre = nombre;
                personaje.Imagen = imagen;
                personaje.IdSerie = idSerie;
            }

            return await this.context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePersonajeAsync(int idPersonaje) {
            Personaje? personaje = await this.FindPersonajeAsync(idPersonaje);
            if (personaje != null) {
                this.context.Personajes.Remove(personaje);
            }
            return await this.context.SaveChangesAsync() > 0;
        }

    }
}

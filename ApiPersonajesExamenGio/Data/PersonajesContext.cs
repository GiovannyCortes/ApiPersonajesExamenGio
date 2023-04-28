using ApiPersonajesExamenGio.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesExamenGio.Data {
    public class PersonajesContext : DbContext {

        public PersonajesContext(DbContextOptions<PersonajesContext> options) :base(options) { }

        public DbSet<Personaje> Personajes { get; set; }

    }
}

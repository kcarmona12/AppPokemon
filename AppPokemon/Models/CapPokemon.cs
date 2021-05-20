using System;

namespace AppPokemon.Models
{
    public class CapPokemon
    {
        public int Id { get; set; }

        public int PokemonId { get; set; }
        public int UsuarioId { get; set; }

        public Pokemon pokemon { get; set; }
        public Usuario usuario{ get; set; }

    }
}

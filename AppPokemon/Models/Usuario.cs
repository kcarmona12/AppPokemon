using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppPokemon.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<CapPokemon> pokemons { get; set; }
    }

}
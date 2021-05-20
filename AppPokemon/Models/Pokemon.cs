using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppPokemon.Models
{
    public class Pokemon
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Imagen { get; set; }
        public DateTime FechaCaptura { get; set; }

        public List<CapPokemon> usuarios { get; set; }
    }
}

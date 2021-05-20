using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace AppPokemon.BD
{
    public class Pokemon : EntityTypeConfiguration<Pokemon>
    {
        public Pokemon()
        {
            ToTable("Pokemon");

            HasKey(o => o.Id);

        }

        public string Nombre { get; internal set; }
        public string Tipo { get; internal set; }
        public string Imagen { get; internal set; }
        public object Id { get; internal set; }
    }
}

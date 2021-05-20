using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading.Tasks;

namespace AppPokemon.BD
{
    public class CapturaPokemon: EntityTypeConfiguration<CapturaPokemon>
    {
        public CapturaPokemon()
        {
            ToTable("CapturaPokemon");

            HasKey(o => o.Id);
            HasRequired(o => o.pokemon).WithMany(o => o.usuarios).HasForeignKey(o => o.PokemonId);
            HasRequired(o => o.usuario).WithMany(o => o.pokemons).HasForeignKey(o => o.UsuarioId);


        }

        public int UsuarioId { get; internal set; }
        public object PokemonId { get; internal set; }
    }
}
using AppPokemon.BD;
using AppPokemon.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


namespace AppPokemon.BD
{
    public class ConexBD : Controller
    {
        public IDbSet<Pokemon> Pokemons { get; set; }
        public IDbSet<Usuario> Usuarios { get; set; }
        public IDbSet<CapturaPokemon> Capturas { get; set; }


        public ConexBD()
        {
            Database.SetInitializer<ConexBD>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new Pokemon());
            modelBuilder.Configurations.Add(new Usuario());
            modelBuilder.Configurations.Add(new CapturaPokemon());

        }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}

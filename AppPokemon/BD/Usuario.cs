using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;


namespace AppPokemon.BD
{
    public class Usuario : EntityTypeConfiguration<Usuario>
    {
        public Usuario()
        {
            ToTable("Usuario");

            HasKey(o => o.Id);

        }

        public object Username { get; internal set; }
        public object Password { get; internal set; }
    }
}
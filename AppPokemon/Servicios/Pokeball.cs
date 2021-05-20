using System;

namespace AppPokemon.Servicios
{
    internal class Pokeball : Estrategia
    {
        public bool PuedoCapturarlo()
        {
            Random ramdom = new Random();
            return ramdom.Next(1, 6) == 1;
        }
    }
}
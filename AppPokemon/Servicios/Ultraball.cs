using System;

namespace AppPokemon.Servicios
{
    internal class Ultraball : Estrategia
    {
        public bool PuedoCapturarlo()
        {
            Random ramdom = new Random();
            return ramdom.Next(1, 3) == 1;
        }
    }
}
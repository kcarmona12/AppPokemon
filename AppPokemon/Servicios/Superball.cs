﻿using System;

namespace AppPokemon.Servicios
{
    internal class Superball : Estrategia
    {
        public bool PuedoCapturarlo()
        {
            Random ramdom = new Random();
            return ramdom.Next(1, 4) == 1;
        }
    }
}
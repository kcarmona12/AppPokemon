using AppPokemon.BD;
using AppPokemon.Models;
using AppPokemon.Servicios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AppPokemon.Controllers
{
    public class PokemonController : Controller
    {
        private ConexBD entidades = new ConexBD();
        private int idUsuario;

        public object FormsAuthentication { get; private set; }

        public ActionResult Index(int id)
        {
            ViewBag.usuario = id;
            return View(entidades.Pokemons.ToList());
        }

        public ActionResult IndexBus(string nom, int? id)
        {
            ViewBag.usuario = id;
            var buscando = entidades.Pokemons.Where(o => o.Nombre == nom).FirstOrDefault();
            return PartialView(buscando);
        }


        [HttpGet]

        public ActionResult Crear()
        {
            List<string> tipos = new List<string>();
            tipos.Add("Agua");
            tipos.Add("Fuego");
            tipos.Add("Planta");
            tipos.Add("Electrico");
            tipos.Add("Roca");
            tipos.Add("Volador");
            tipos.Add("Hielo");
            tipos.Add("Tierra");
            tipos.Add("Acero");
            tipos.Add("Fantasma");

            ViewBag.usuario = tipos;
            return View(new Pokemon());
        }
        [HttpPost]
        public ActionResult Crear(Pokemon pokemon, HttpPostedFileBase file)
        {
            List<string> tipos = new List<string>();
            tipos.Add("Agua");
            tipos.Add("Fuego");
            tipos.Add("Planta");
            tipos.Add("Electrico");
            tipos.Add("Roca");
            tipos.Add("Volador");
            tipos.Add("Hielo");
            tipos.Add("Tierra");
            tipos.Add("Acero");
            tipos.Add("Fantasma");

            ViewBag.tipos = tipos;


            if (file != null && file.ContentLength > 0)
            {
                string ruta = Path.Combine(Microsoft.AspNetCore.Server.MapPath("~/imagenes"), Path.GetFileName(file.FileName));
                file.SaveAs(ruta);
                pokemon.Imagen = "/imagenes/" + Path.GetFileName(file.FileName);
            }
            Validar(pokemon);
            if (ModelState.IsValid)
            {
                entidades.Pokemons.Add(pokemon);
                entidades.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pokemon);
        }



        [HttpGet]
        public ActionResult Login()
        {
            return View(new Usuario());

        }
        [HttpPost]
        public ActionResult Login(Usuario user)
        {
            var aux = new Usuario();
            aux = entidades.Usuarios.Where(o => o.Username == user.Username).FirstOrDefault();
            if (aux == null)
            {

                ModelState.AddModelError("Username", "Es invalido");
            }
            else
            {
                if (aux.Password != user.Password)
                {
                    ModelState.AddModelError("Password", "Es invalido");
                }
            }
            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(aux.Username, false);
                System.Web.HttpContext.Current.Session["Usuario"] = aux;
                return RedirectToAction("Index", new { id = aux.Id });
            }
        }
            return View(user);
    }

    public ActionResult Salir()
    {
        FormsAuthentication.SignOut();
        return RedirectToAction("Login");

    }
    public ActionResult Capturar(int idPokemon, string nombre, int tipo, DateTime fechaCaptura, int jpg, object ViewBag)
    {
        ProbabilidadCaptura probaCap = new ProbabilidadCaptura();
        switch (tipo)
        {
            case 1:
                probaCap.ConPokeball();
                break;
            case 2:
                probaCap.ConSuperball();
                break;
            case 3:
                probaCap.ConUltraball();
                break;

        }
        if (probaCap.LoCapture())
        {

            var cap = new CapturaPokemon();
            cap.PokemonId = idPokemon;
            cap.UsuarioId = idUsuario;

            ViewBag.captura = "Pokemon capturado";
            entidades.Capturas.Add(cap);
            entidades.SaveChanges();
        }
        else
        {
            ViewBag.captura = "Pokemon se escapo";

        }
        ViewBag.user = nombre;
        return View();

    }

    public ActionResult Pokemon(int id)
    {
        ViewBag.usuario = id;
        var miscap = entidades.Capturas.Where(o => o.UsuarioId == id).ToList();
        List<Pokemon> mispok = new List<Pokemon>();
        foreach (var aux in miscap)
        {
            var ex = entidades.Pokemons.Where(o => o.Id == aux.PokemonId).FirstOrDefault();
            if (ex != null)
            {
                mispok.Add(ex);
            }
        }
        return View(mispok);
    }


    public void Validar(Pokemon p)
    {
        var aux = entidades.Pokemons.Where(o => o.Nombre == p.Nombre).FirstOrDefault();
        if (aux != null)
        {
            ModelState.AddModelError("Nombre", "El Nombre es unico");
        }
        if (string.IsNullOrEmpty(p.Nombre))
        {
            ModelState.AddModelError("Nombre", "El Nombre es obligatorio");
        }
        if (p.Tipo == "no")
        {
            ModelState.AddModelError("Tipo", "El Tipo es obligatorio");
        }
        if (string.IsNullOrEmpty(p.Imagen))
        {
            ModelState.AddModelError("Imagen", "La es obligatoria");
        }
    }


    }


    
using Microsoft.AspNetCore.Mvc;
using RedeSevice.Models;
using System.Diagnostics;
using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace RedeSevice.Controllers
{
    public class HomeController : Controller
    {

        Numeros NumeroModel = new();
        clsTeste clsTeste = new();
        CEP cep = new();
        Bancos bancos = new();
       Imagem img = new Imagem();

        public IActionResult Index()
        {
            ViewBag.numeros = NumeroModel.LerTodos();
            ViewBag.cls = clsTeste.LerTodos();
            return View();
        }

        // EXERCICIO 01 e 02

        [HttpPost]
        public IActionResult ListarNumeros(IFormCollection form)
        {            
            NumeroModel.Criar(int.Parse(form["numero"]));
            return LocalRedirect("~/");
        }

        [HttpPost]
        public IActionResult Limpar(IFormCollection form)
        {
            NumeroModel.Deletar();
            return LocalRedirect("~/");
        }

        // EXERCICIO 03, 04, 05

        [HttpPost]
        public IActionResult CriarLista(IFormCollection form)
        {
            clsTeste.Criar();
            return LocalRedirect("~/");
        }

        [HttpPost]
        public IActionResult Item3(IFormCollection form)
        {
            clsTeste.Criar();
            return LocalRedirect("~/");
        }

        //EXERCICIO 06

        [HttpPost]
        public async Task<IActionResult> ConsultaCEPAsync(IFormCollection form)
        {
            
            ViewBag.cep = await cep.BuscarCep(form["cep"]);
            return View("index");
        }

        // EXERCICIO 07

        [HttpPost]
        public async Task<IActionResult> ListarBancos()
        {

            ViewBag.bancos = await bancos.ListarBancos();
            return View("index");
        }

        // EXERCICIO 08 

        [HttpPost]
        public async Task<IActionResult> Imagem()
        {

            await img.BaixarImagem();
            ViewBag.img = img.EncodarImagem();
            return View("index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Microsoft.SqlServer.Server;
using Validacoes.Models;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace Validacoes.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contato()
        {
            var pessoa = new Pessoa();
            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Contato(Pessoa pessoa)
        {


            //---- Converte a primeira letra da palavra em maiúscula--------
            CultureInfo cInfo = Thread.CurrentThread.CurrentCulture;

            pessoa.Cidade = cInfo.TextInfo.ToTitleCase(pessoa.Cidade);
            pessoa.Nome = cInfo.TextInfo.ToTitleCase(pessoa.Nome);
            pessoa.Sobrenome = cInfo.TextInfo.ToTitleCase(pessoa.Sobrenome);
            //---------------------------------------------------------------

            //------------ Validação da cidade ----------------------------------------------------------------------------
            if (!(pessoa.Cidade.Equals("Ariquemes") || pessoa.Cidade.Equals("Jaru") || pessoa.Cidade.Equals("Vilhena")))
            {
                ModelState.AddModelError("Cidade", "São permitidas somes as cidades Ariquemes, Jaru e Vilhena");
            }
            //-------------------------------------------------------------------------------------------------------------

            return ModelState.IsValid ? View("Dados", pessoa) : View(pessoa); // if model state is valid...
        }

        public ActionResult ValidarCPF(string Cpf) // Implementar código de validação remota
        {
            string ERcpf = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$";

            return Json("");
        }

        public ActionResult Dados(Pessoa pessoa)
        {
            return View(pessoa);
        }

    }
}
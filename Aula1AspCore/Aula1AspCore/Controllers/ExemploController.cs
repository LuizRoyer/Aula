using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Aula1AspCore.Controllers
{
    public class ExemploController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public bool RecebeNome(string nome) => nome.ToLower().Trim() == "luiz" ? true: false;      

       /* 
        Criar Tela de login com usuario e senha
        campo vazio apontar em vermelho
        usuario e senha sao admin

         */
         public bool ValidarLogin(string nome, string senha)
        {
            if (nome.ToLower() == "admin" && senha.ToLower() == "123")
                return true;
            return false;
        }

    }
}
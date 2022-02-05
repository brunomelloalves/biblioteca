using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult ListaDeusuarios()
        {
            
            Autenticacao.CheckLogin(this);
            
            List<Usuario> listagem = new UsuarioService().Listar();
            return View(listagem);
        }

        public IActionResult editarUsuario(int id)
        {
            Usuario user = new UsuarioService().Listar(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult editarUsuario(Usuario usereditado)
        {
            UsuarioService us = new UsuarioService();
            us.editarUsuario(usereditado);

            return RedirectToAction("ListaDeusuarios");

        }

        public IActionResult registrarUsuarios(int id)
        {
            
            return View();
        } 

        [HttpPost]
        public IActionResult registrarUsuarios(Usuario novouser)
        {
            UsuarioService us = new UsuarioService();
            us.incluirUsuario(novouser);
            return RedirectToAction("ListaDeusuarios");
        }

        public IActionResult ExcluirUsuario(int id)
        {
            UsuarioService us = new UsuarioService();
            us.excluirUsuario(id);
            return RedirectToAction("ListaDeusuarios");
        }

        public IActionResult Sair(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult NeddAdmin(){
            
            return View();
        }

    }
}
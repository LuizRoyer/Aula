using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCrud.DAO;
using AspCrud.DAO.Connections;
using AspCrud.Models;
using IBM.Data.DB2.Core;
using Microsoft.AspNetCore.Mvc;

namespace AspCrud.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly DB2Connection _connection;
        public UsuarioController()
        {
            this._connection = Connection.Conn();
            if (!this._connection.IsOpen)
                this._connection.Open();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cadastro()
        { 
            return View();
        }
        public int InserirNovo([FromBody] UsuarioModel usuario)
        {
            var trans = _connection.BeginTransaction();
            try
            {
                var linhas =  new UsuariosDAO(_connection, trans).InserirUsuario(usuario);
                trans.Commit();
                return linhas;
            }
            catch(Exception ex)
            {
                trans.Rollback();
                throw new Exception(ex.Message);
            }
        }
        public List<UsuarioModel> RetornaUsuarios()
        {
            var trans = _connection.BeginTransaction();
            try
            {
                var lista =  new UsuariosDAO(_connection, trans).RetornaUsuarios();
                trans.Commit();
                return lista;
            }
            catch(Exception ex)
            {
                trans.Rollback();
                throw new Exception(ex.Message);
            }
        }
    }
}
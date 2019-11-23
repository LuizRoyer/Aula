using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreCrud2Aula.DAO;
using AspCoreCrud2Aula.DAO.Connections;
using AspCoreCrud2Aula.Models;
using IBM.Data.DB2.Core;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreCrud2Aula.Controllers
{
    public class UsuarioController : Controller
    {
        private DB2Connection _db2Connection;
        public UsuarioController()
        {
            _db2Connection = Connection.ConnDb2();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return Create();
        }

        public List<UsuarioModel> ListaUsuario()
        {
            if (!_db2Connection.IsOpen)
                _db2Connection.Open();

            var trans = _db2Connection.BeginTransaction();
            try
            {
                if (!_db2Connection.IsOpen)
                    _db2Connection.Open();

                List<UsuarioModel> lista= new UsuariosDao(_db2Connection, trans).SelecionarUsuarios(1, "", 178);
                trans.Commit();
                return lista;
            }
            catch (Exception e)
            {
                trans.Rollback();

                if (_db2Connection.IsOpen)
                    _db2Connection.Close();

                throw new Exception(e.Message);
            }
        }
        public void Insert(UsuarioModel usuario)
        {
            if (!_db2Connection.IsOpen)
                _db2Connection.Open();

            var trans = _db2Connection.BeginTransaction();
            try
            {
                if (!_db2Connection.IsOpen)
                    _db2Connection.Open();

                 new UsuariosDao(_db2Connection, trans).InserirUsuario(usuario);
                trans.Commit();
                            }
            catch (Exception e)
            {
                trans.Rollback();

                if (_db2Connection.IsOpen)
                    _db2Connection.Close();

                throw new Exception(e.Message);
            }
        }
        public void Update(UsuarioModel usuario)
        {
            if (!_db2Connection.IsOpen)
                _db2Connection.Open();

            var trans = _db2Connection.BeginTransaction();
            try
            {
                if (!_db2Connection.IsOpen)
                    _db2Connection.Open();

                new UsuariosDao(_db2Connection, trans).UpdateUsuario(usuario);
                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();

                if (_db2Connection.IsOpen)
                    _db2Connection.Close();

                throw new Exception(e.Message);
            }
        }
        public void Delete(double cnemp, string cdusu)
        {
            if (!_db2Connection.IsOpen)
                _db2Connection.Open();

            var trans = _db2Connection.BeginTransaction();
            try
            {
                if (!_db2Connection.IsOpen)
                    _db2Connection.Open();

                new UsuariosDao(_db2Connection, trans).Delete(cnemp , cdusu);
                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();

                if (_db2Connection.IsOpen)
                    _db2Connection.Close();

                throw new Exception(e.Message);
            }
        }

    }
}
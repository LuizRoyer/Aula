using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCRUD.DAO;
using AspCRUD.DAO.Connections;
using AspCRUD.Models;
using IBM.Data.DB2.Core;
using Microsoft.AspNetCore.Mvc;

namespace AspCRUD.Controllers
{
    public class UsuarioController : Controller
    {
        private DB2Connection conexao;

        public UsuarioController()
        {
            conexao = Conexao.Conn();
            if (!conexao.IsOpen)
                conexao.Open();
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<UsuarioModel> BuscarUsuarios()
        {
            DB2Transaction trans = conexao.BeginTransaction();
            try
            {
                var usuarios = new UsuarioDao(conexao, trans).BuscarUsuarios();
                trans.Commit();
                return usuarios;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conexao.IsOpen)
                    conexao.Close();
            }
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public void InserirUsuario(string cdusu, string nmusu, double cncct)
        {
            DB2Transaction trans = conexao.BeginTransaction();
            try
            {
                new UsuarioDao(conexao, trans).InserirUsuario(new UsuarioModel { CDUSU = cdusu, NMUSU = nmusu, CNCCT = cncct});
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conexao.IsOpen)
                    conexao.Close();
            }
        }

        public void ExcluirUsuario(string cdusu, int cnemp)
        {
            DB2Transaction trans = conexao.BeginTransaction();
            try
            {
                new UsuarioDao(conexao, trans).DeletarUsuario(cdusu, cnemp);
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conexao.IsOpen)
                    conexao.Close();
            }
        }

        public void AlterarUsuario(string cdusu, double cnemp, string nmusu, string essitusu)
        {
            DB2Transaction trans = conexao.BeginTransaction();
            try
            {
                new UsuarioDao(conexao, trans).AlterarUsuario(cdusu, cnemp, nmusu, essitusu);
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conexao.IsOpen)
                    conexao.Close();
            }
        }
    }
}
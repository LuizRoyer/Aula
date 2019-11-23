using Aula13_08_DBConnection.DAO;
using Aula13_08_DBConnection.DAO.Connections;
using Aula13_08_DBConnection.Model;
using IBM.Data.DB2;
using System;
using System.Collections.Generic;

namespace FCA001A.Controller
{
    public class CA001Controller : Connection
    {
        DB2Connection conn = new DB2Connection(Connection.connectionDb2);
        Usuarios usuario;
        public CA001Controller()
        {
            if (!conn.IsOpen)
                conn.Open();

            usuario = new Usuarios();
        }

        public List<Usuarios> SelecionarUsuarios()
        {
            List<Usuarios> ListaUsuarios = new List<Usuarios>();
            var trans = conn.BeginTransaction();
            try
            {
                ListaUsuarios = new UsuariosDAO(conn, trans).SelecionarUsuarios();
                trans.Commit();

                return ListaUsuarios;
            }
            catch (System.Exception)
            {
                trans.Rollback();
                throw ;
            }
        }
        public void InserirUsuario(double cnemp, string cdusu, string nmusu, double cncct)
        {
            var trans = conn.BeginTransaction();
            try
            {
                usuario.Cnemp = cnemp;
                usuario.Cdusu = cdusu;
                usuario.Nmusu = nmusu;
                usuario.Cncct = cncct;

                new UsuariosDAO(conn, trans).InserirUsuario(usuario);
                trans.Commit();
            }
            catch (System.Exception)
            {
                trans.Rollback();
                throw;
            }
        }
        public void ExcluirUsuario(double cnemp, string cdusu)
        {
            var trans = conn.BeginTransaction();
            try
            {
                new UsuariosDAO(conn, trans).DeletarUsuario(cnemp, cdusu);
                trans.Commit();
            }
            catch (System.Exception)
            {
                trans.Rollback();
                throw;
            }
        }
        public void UpdateUsuario(double cnemp, string cdusu, string nmusu, double cncct)
        {
            var trans = conn.BeginTransaction();
            try
            {
                usuario.Cnemp = cnemp;
                usuario.Cdusu = cdusu;
                usuario.Nmusu = nmusu;
                usuario.Cncct = cncct;

                new UsuariosDAO(conn, trans).UpdateUsuario(usuario);
                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();
                throw;
            }
        }
    }
}

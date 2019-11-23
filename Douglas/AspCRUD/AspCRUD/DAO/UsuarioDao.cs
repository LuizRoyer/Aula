using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspCRUD.Models;
using IBM.Data.DB2.Core;
using Dapper;

namespace AspCRUD.DAO
{
    public class UsuarioDao
    {
        private readonly DB2Connection _conn;
        private readonly DB2Transaction _trans;

        public UsuarioDao(DB2Connection conn, DB2Transaction trans)
        {
            this._conn = conn;
            if (!this._conn.IsOpen)
                _conn.Open();
            this._trans = trans;
        }

        public List<UsuarioModel> BuscarUsuarios()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@" SELECT CDUSU, NMUSU, CNEMP, ESSITUSU FROM KARSTEN.CA001_USUARIOS
                           WHERE CNEMP = 1");
            sql.AppendLine(@" AND CNCCT = 178");

            return _conn.Query<UsuarioModel>(sql.ToString(), transaction: _trans).ToList();
        }

        public void InserirUsuario(UsuarioModel usuario)
        {
            string sql = @"INSERT INTO KARSTEN.CA001_USUARIOS (CNEMP, CDUSU, NMUSU, CNCCT, ESSITUSU)
                          VALUES (1, @CDUSU, @NMUSU, @CNCCT, 'I')";

            _conn.ExecuteScalar(sql.ToString(), usuario, transaction: _trans);
        }

        public void DeletarUsuario(string cdusu, int cnemp)
        {
            string sql = $@"DELETE FROM KARSTEN.CA001_USUARIOS
                          WHERE CNEMP = @Cnemp
                          AND   CDUSU = @Cdusu";

            _conn.ExecuteScalar(sql.ToString(), new { Cnemp = cnemp, Cdusu = cdusu }, transaction: _trans);
        }

        public void AlterarUsuario(string cdusu, double cnemp, string nmusu, string essitusu)
        {
            string sql = $@"UPDATE KARSTEN.CA001_USUARIOS SET
                          NMUSU = @Nmusu,
                          ESSITUSU = @Essitusu
                          WHERE CNEMP = @Cnemp
                          AND   CDUSU = @Cdusu";

            _conn.ExecuteScalar(sql.ToString(), new 
            { 
                Cnemp = cnemp, 
                Cdusu = cdusu, 
                Nmusu = nmusu, 
                Essitusu = essitusu 
            }, transaction: _trans);
        }
    }
}

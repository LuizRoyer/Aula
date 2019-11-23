using AspCrud.Models;
using IBM.Data.DB2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCrud.DAO
{
    public class UsuariosDAO
    {
        private readonly DB2Connection _conn;
        private readonly DB2Transaction _trans;
        public UsuariosDAO(DB2Connection conn, DB2Transaction trans)
        {
            this._conn = conn;
            if (!this._conn.IsOpen)
                _conn.Open();
            this._trans = trans;
        }
        public List<UsuarioModel> RetornaUsuarios()
        {
            StringBuilder select = new StringBuilder();
            select.AppendLine(@" SELECT
                                 NMUSU,
                                 CNEMP,
                                 ESSITUSU
                                 FROM
                                 KARSTEN.CA001_USUARIOS
                                 WHERE CNEMP = 1 ");
            select.AppendLine(@" AND CNCCT =  178");
            DB2Command cmd = new DB2Command(select.ToString(),this._conn,this._trans);
            using (DB2DataReader reader = cmd.ExecuteReader())
            {
                List<UsuarioModel> lista = new List<UsuarioModel>();
                while (reader.Read())
                {
                    UsuarioModel usuario = new UsuarioModel();//Instaciado o objeto
                                                              //popula o objeto
                    usuario.NMUSU = reader["NMUSU"].ToString();
                    usuario.CNEMP = Convert.ToInt32(reader["CNEMP"]);
                    usuario.ESSITUSU = reader["ESSITUSU"].ToString();
                    lista.Add(usuario);
                }
                return lista;
            }
        }
        public int InserirUsuario(UsuarioModel usuario)
        {
            string sqlInsert = @" INSERT
                                  INTO
                                  KARSTEN.CA001_USUARIOS (CNEMP,CDUSU,NMUSU,CNCCT,DTINC)
                                  VALUES (@cnemp,@cdusu,@nmusu,@cncct, CURRENT TIMESTAMP)";
            DB2Command cmd = new DB2Command(sqlInsert, this._conn,this._trans);
            cmd.Transaction = this._trans;
            cmd.Parameters.Add(new DB2Parameter("@cnemp", 1));
            cmd.Parameters.Add(new DB2Parameter("@cdusu", usuario.CDUSU));
            cmd.Parameters.Add(new DB2Parameter("@nmusu", usuario.NMUSU));
            cmd.Parameters.Add(new DB2Parameter("@cncct", usuario.CNCCT));
           return cmd.ExecuteNonQuery();
        }
    }
}

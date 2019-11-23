using Aula13_08_DBConnection.Model;
using IBM.Data.DB2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aula13_08_DBConnection.DAO
{
    public class UsuariosDAO
    {
        private readonly DB2Connection _conn;
        private readonly DB2Transaction _trans;

        public UsuariosDAO(DB2Connection conn, DB2Transaction trans)
        {
            this._conn = conn;
            this._trans = trans;
        }

        public List<Usuarios> SelecionarUsuarios()
        {
            List<Usuarios> listaUsuarios = new List<Usuarios>();
            StringBuilder sqlSelect = new StringBuilder();

            sqlSelect.Append(@"Select CNEMP,
                                    CDUSU, NMUSU, CDUSURDE
                                    from karsten.CA001_USUARIOS
                                    where CNEMP = 1 and CNCCT=178
                                     with ur ");

            DB2Command cmd = new DB2Command(sqlSelect.ToString(), _conn);
            cmd.Transaction = _trans;
            DB2DataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Usuarios usuario = new Usuarios
                {
                    Cnemp = Convert.ToDouble(reader["CNEMP"].ToString()),
                    Cdusu = reader["CDUSU"].ToString(),
                    Nmusu = reader["NMUSU"].ToString().Trim(),
                    Cdusurde = reader["CDUSURDE"].ToString()
                };

                listaUsuarios.Add(usuario);
            }
            return listaUsuarios;
        }

        public void InserirUsuario(Usuarios obj)
        {
            StringBuilder sqlInsert = new StringBuilder();

            sqlInsert.Append(@"INSERT INTO KARSTEN.CA001_USUARIOS
                             (CNEMP, CDUSU,NMUSU,CNCCT,DTINC)
                                values
                             (@Cnemp, @Cdusu, @Nmusu, @Cncct, CURRENT TIMESTAMP )");

            DB2Command cmd = new DB2Command(sqlInsert.ToString(), _conn);
            cmd.Transaction = _trans;
            cmd.Parameters.Add(new DB2Parameter("@Cnemp", obj.Cnemp));
            cmd.Parameters.Add(new DB2Parameter("@Cdusu", obj.Cdusu));
            cmd.Parameters.Add(new DB2Parameter("@Nmusu", obj.Nmusu.Trim()));
            cmd.Parameters.Add(new DB2Parameter("@Cncct", obj.Cncct));

            cmd.ExecuteNonQuery();
        }
        public void DeletarUsuario(double cnemp, string cdusu)
        {
            StringBuilder sqlDelete = new StringBuilder();

            sqlDelete.Append(@"DELETE FROM KARSTEN.CA001_USUARIOS 
                               where CNEMP = @Cnemp  AND CDUSU = @Cdusu");

            DB2Command cmd = new DB2Command(sqlDelete.ToString(), _conn);
            cmd.Transaction = _trans;
            cmd.Parameters.Add(new DB2Parameter("@Cnemp", cnemp));
            cmd.Parameters.Add(new DB2Parameter("@Cdusu", cdusu));

            int quantidade = cmd.ExecuteNonQuery();
            string retorno = quantidade > 0 ? "Sucesso" : "usuario nao encontrado";

            Console.Write(retorno);
        }
        public void UpdateUsuario(Usuarios obj)
        {
            StringBuilder sqlUpdate = new StringBuilder();

            sqlUpdate.Append(@"Update KARSTEN.CA001_USUARIOS
                                    set  NMUSU = @Nmusu
                                        ,CNCCT=@Cncct
                                  where CNEMP = @Cnemp
                                  and  CDUSU = @Cdusu ");

            DB2Command cmd = new DB2Command(sqlUpdate.ToString(), _conn);
            cmd.Transaction = _trans;
            cmd.Parameters.Add(new DB2Parameter("@Cnemp", obj.Cnemp));
            cmd.Parameters.Add(new DB2Parameter("@Cdusu", obj.Cdusu.Trim()));
            cmd.Parameters.Add(new DB2Parameter("@Nmusu", obj.Nmusu.Trim()));
            cmd.Parameters.Add(new DB2Parameter("@Cncct", obj.Cncct));

            cmd.ExecuteNonQuery();
        }
    }
}

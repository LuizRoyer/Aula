using AspCoreCrud2Aula.Models;
using IBM.Data.DB2.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspCoreCrud2Aula.DAO
{
    public class UsuariosDao
    {
        private readonly DB2Connection _connDb2;
        private readonly DB2Transaction _trans;

        public UsuariosDao(DB2Connection connbd2, DB2Transaction trans)
        {
            this._connDb2 = connbd2;
            this._trans = trans;
        }

        public List<UsuarioModel> SelecionarUsuarios(double cnemp, string cdusu, double cncct)
        {
            List<UsuarioModel> listUsuario = new List<UsuarioModel>();
            StringBuilder sqlSelect = new StringBuilder();

            sqlSelect.Append("Select cnemp, cdusu, nmusu, essitusu,cncct ");
            sqlSelect.Append(" from KARSTEN.CA001_USUARIOS");
            sqlSelect.Append($" where cnemp ={cnemp}");
            //sqlSelect.Append($" and cdusu ='{cdusu.Trim()}'");
            sqlSelect.Append($" and cncct ={cncct}");
            sqlSelect.Append(" WITH UR");

            DB2Command cmd = new DB2Command(sqlSelect.ToString(), _connDb2, _trans);
            using (DB2DataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    UsuarioModel usuario = new UsuarioModel();
                    usuario.Cnemp = Convert.ToDouble(reader["CNEMP"].ToString());
                    usuario.Cdusu = reader["CDUSU"].ToString();
                    usuario.Nmusu = reader["NMUSU"].ToString();
                    usuario.Essitusu = reader["ESSITUSU"].ToString();
                    usuario.Cncct = Convert.ToDouble(reader["CNCCT"].ToString());

                    listUsuario.Add(usuario);
                }
            }
            return listUsuario;
        }
        public int InserirUsuario(UsuarioModel usuario)
        {
            string sqlInsert = string.Format(@" INSERT INTO KARSTEN.CA001_USUARIOS
                                             ( CNEMP ,  CDUSU ,  NMUSU ,  CDUSURDE ,  Essitusu ,  Cncct )
                                      VALUES( @Cnemp,@Cdusu,@Nmusu,@Cdusurde,@Essitusu ,@Cncct)");


            DB2Command cmd = new DB2Command(sqlInsert, _connDb2, _trans);
            cmd.Parameters.Add(new DB2Parameter("@Cnemp", usuario.Cnemp));
            cmd.Parameters.Add(new DB2Parameter("@Cdusu", usuario.Cdusu));
            cmd.Parameters.Add(new DB2Parameter("@Nmusu", usuario.Nmusu));
            cmd.Parameters.Add(new DB2Parameter("@Cdusurde", usuario.Cdusurde));
            cmd.Parameters.Add(new DB2Parameter("@Essitusu", usuario.Essitusu));
            cmd.Parameters.Add(new DB2Parameter("@Cncct", usuario.Cncct));
            
           return cmd.ExecuteNonQuery();

        }
        public int UpdateUsuario(UsuarioModel usuario)
        {
            string sqlUpdate = string.Format($@"  UPDATE  KARSTEN.CA001_USUARIOS 
                                              SET NMUSU = @Nmusu
                                                 , CDUSURDE =@Cdusurde                                               
                                                 , CNCCT = @Cncct                                                
                                        
                                 WHERE CNEMP = @Cnemp
                                    AND CDUSU = @Cdusu");
                       
            DB2Command cmd = new DB2Command(sqlUpdate, _connDb2, _trans);
            cmd.Parameters.Add(new DB2Parameter("@Cnemp", usuario.Cnemp));
            cmd.Parameters.Add(new DB2Parameter("@Cdusu", usuario.Cdusu));
            cmd.Parameters.Add(new DB2Parameter("@Nmusu", usuario.Nmusu));
            cmd.Parameters.Add(new DB2Parameter("@Cdusurde", usuario.Cdusurde));
            cmd.Parameters.Add(new DB2Parameter("@Essitusu", usuario.Essitusu));
            cmd.Parameters.Add(new DB2Parameter("@Cncct", usuario.Cncct));

          return  cmd.ExecuteNonQuery();

        }
        public int Delete(double cnemp , string cdusu)
        {
            string sqlDelete = string.Format($@"  Delete  from  KARSTEN.CA001_USUARIOS                                         
                                 WHERE CNEMP = @Cnemp
                                    AND CDUSU = @Cdusu");
                       
            DB2Command cmd = new DB2Command(sqlDelete, _connDb2, _trans);
            cmd.Parameters.Add(new DB2Parameter("@Cnemp", cnemp));
            cmd.Parameters.Add(new DB2Parameter("@Cdusu", cdusu));
           
           return cmd.ExecuteNonQuery();
        }

    }
}

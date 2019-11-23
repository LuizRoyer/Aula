using IBM.Data.DB2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using estacionamentoDto = Estacionamento.Models.Estacionamento;

namespace Estacionamento.DAO
{
    public class EstacionamentoDao
    {
        private readonly DB2Connection _connDb2;
        private readonly DB2Transaction _trans;

        public EstacionamentoDao(DB2Connection db2connection, DB2Transaction dB2Transaction)
        {
            this._connDb2 = db2connection;
            this._trans = dB2Transaction;
        }

        public List<estacionamentoDto> SelecionarVeiculos()
        {
            List<estacionamentoDto> listVeiculos = new List<estacionamentoDto>();
            StringBuilder sqlSelect = new StringBuilder();

            sqlSelect.Append("SELECT");
            sqlSelect.Append(" NUMERO_REGISTRO, MODELO_VEICULO, PLACA_VEICULO,");
            sqlSelect.Append(" DATA_ENTRADA, DATA_SAIDA, OBSERVACAO_VEICULO");
            sqlSelect.Append(" from KARSTEN.TST001_CONTROLE_ENTRADA_VEICULO;");
            sqlSelect.Append(" with ur");

            DB2Command cmd = new DB2Command(sqlSelect.ToString(), _connDb2, _trans);
            using (DB2DataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    estacionamentoDto estacionamento = new estacionamentoDto();
                    estacionamento.Registro = Convert.ToInt32(reader["NUMERO_REGISTRO"].ToString());
                    estacionamento.ModeloVeiculo = reader["MODELO_VEICULO"].ToString();
                    estacionamento.PlacaVeiculo = reader["PLACA_VEICULO"].ToString();
                    estacionamento.DataEntrada = Convert.ToDateTime(reader["DATA_ENTRADA"]); 
                    estacionamento.DataSaida = reader["DATA_SAIDA"] == DBNull.Value ? new DateTime(0001,01, 01) :Convert.ToDateTime(reader["DATA_SAIDA"]);
                    estacionamento.Observacao = reader["OBSERVACAO_VEICULO"].ToString();

                    listVeiculos.Add(estacionamento);
                }
            }

            return listVeiculos;
        }
        public int EstacionarVeiculo(estacionamentoDto obj)
        {
            StringBuilder sqlInsert = new StringBuilder();
            sqlInsert.Append("INSERT INTO KARSTEN.TST001_CONTROLE_ENTRADA_VEICULO ");
            sqlInsert.Append("( MODELO_VEICULO,PLACA_VEICULO");
            sqlInsert.Append(" ,DATA_ENTRADA,OBSERVACAO_VEICULO ) VALUES");
            sqlInsert.Append("(@modelo ,@placa, @entrada ,@obs) ");

            DB2Command cmd = new DB2Command(sqlInsert.ToString(), _connDb2, _trans);            
            cmd.Parameters.Add(new DB2Parameter("@modelo", obj.ModeloVeiculo));
            cmd.Parameters.Add(new DB2Parameter("@placa", obj.PlacaVeiculo));
            cmd.Parameters.Add(new DB2Parameter("@entrada", obj.DataEntrada));
            cmd.Parameters.Add(new DB2Parameter("@obs", obj.Observacao));

            return cmd.ExecuteNonQuery();
        }

        public int RegistrarSaida(int registro, DateTime dataSaida)
        {
            StringBuilder sqlUpdate = new StringBuilder();
            sqlUpdate.Append("Update KARSTEN.TST001_CONTROLE_ENTRADA_VEICULO");
            sqlUpdate.Append($" set DATA_SAIDA =@data");
            sqlUpdate.Append($" WHERE NUMERO_REGISTRO =@registro");

            DB2Command cmd = new DB2Command(sqlUpdate.ToString(), _connDb2, _trans);
            cmd.Parameters.Add(new DB2Parameter("@data", dataSaida));
            cmd.Parameters.Add(new DB2Parameter("@registro", registro));

            return cmd.ExecuteNonQuery();
        }
    }
}

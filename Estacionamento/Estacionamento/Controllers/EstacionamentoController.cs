using AspCoreCrud2Aula.DAO.Connections;
using Estacionamento.DAO;
using IBM.Data.DB2.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using estacionamentoDto = Estacionamento.Models.Estacionamento;
/* 
 Uma empresa de estacionamento solicitou a você desenvolvedor que crie um aplicação para automatizar o processo de cobrança de estacionamento.

1 - Quando um carro entrar no estacionamento irá informar a placa e o modelo do veiculo 

2- O sistema então mostrará o modelo do veículo a placa e data que ele entrou no estacionamento

3-  Quando ele sair será feito um calculo automático 
a) até 10 minutos não cobra-se estacionamento 
b) passado os 10 minutos e não excedido os 30 cobra-se 2,50
c) passou cobra-se 5 

no final de cada operação o sistema tem que mostrar em tela o valor que será cobrado

para desenvolvimento foi criado uma tabela na base de desenvolvimento 
SELECT
 NUMERO_REGISTRO,
 MODELO_VEICULO,
 PLACA_VEICULO,
 DATA_ENTRADA,
 DATA_SAIDA,
 OBSERVACAO_VEICULO
FROM
KARSTEN.TST001_CONTROLE_ENTRADA_VEICULO;

TECNOLOGIAS PROCURADAS PELAS EMPRESAS
SQL SERVER,
ENTITY FRAMEOWORK CORE,
ANGULAR OU REACT 

url = https://getbootstrap.com/docs/4.0/components/forms/
*/
namespace Estacionamento.Controllers
{
    public class EstacionamentoController : Controller
    {
        private DB2Connection _db2Connection;
        public EstacionamentoController()
        {
            _db2Connection = Connection.ConnDb2();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cadastro()
        {
            return View();
        }
               

        public List<estacionamentoDto> ListarVeiculos()
        {
            if (!_db2Connection.IsOpen)
                _db2Connection.Open();
            DB2Transaction trans = _db2Connection.BeginTransaction();

            try
            {
                List<estacionamentoDto> lista = new EstacionamentoDao(_db2Connection, trans).SelecionarVeiculos();
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
            finally
            {
                if (_db2Connection.IsOpen)
                    _db2Connection.Close();
            }
        }
        public void InserirCarro([FromBody] estacionamentoDto estacionamento)
        {
            if (!_db2Connection.IsOpen)
                _db2Connection.Open();

            DB2Transaction trans = _db2Connection.BeginTransaction();

            try
            {
                estacionamento.DataEntrada = DateTime.Now;

                if (ValidarCampos(estacionamento))
                {
                    new EstacionamentoDao(_db2Connection, trans).EstacionarVeiculo(estacionamento);
                    trans.Commit();
                }
            }
            catch (Exception e)
            {
                trans.Rollback();

                if (_db2Connection.IsOpen)
                    _db2Connection.Close();

                throw new Exception(e.Message);
            }
            finally
            {
                if (_db2Connection.IsOpen)
                    _db2Connection.Close();
            }
        }
        public double SaidaVeiculo(int registro, DateTime dataEntrada)
        {
            if (!_db2Connection.IsOpen)
                _db2Connection.Open();
            var saida = DateTime.Now;

            DB2Transaction trans = _db2Connection.BeginTransaction();

            try
            {
                //
                new EstacionamentoDao(_db2Connection, trans).RegistrarSaida(registro, saida);
                trans.Commit();
                double valor = Convert.ToDouble((saida - dataEntrada).TotalMinutes);

                if (valor <= 10)
                    return 0;

                if (valor > 10 && valor < 30)
                    return 2.5;
                else
                    return 5*(valor/60);

            }
            catch (Exception e)
            {
                
                trans.Rollback();

                if (_db2Connection.IsOpen)
                    _db2Connection.Close();

                throw new Exception(e.Message);
            }
            finally
            {
                if (_db2Connection.IsOpen)
                    _db2Connection.Close();
            }
        }

        private bool ValidarCampos(estacionamentoDto filtro)
        {
            if (string.IsNullOrWhiteSpace(filtro.PlacaVeiculo))
            {
                throw new Exception("Informe a Placa");                
            }
            if (string.IsNullOrWhiteSpace(filtro.ModeloVeiculo))
            {
                throw new Exception("Informe o Modelo do Veiculo");
            }

            return true;
        }
    }
}
using Aula13_08_DBConnection.DAO;
using Aula13_08_DBConnection.DAO.Connections;
using Aula13_08_DBConnection.Model;
using System;

namespace Aula13_08_DBConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = Connection.DB2Connection();
            connection.Open();
            var trans = connection.BeginTransaction();
            UsuariosDAO UsuarioDao = new UsuariosDAO(connection, trans);
            try
            {
                int opcao = 0;
                while (opcao != 4)
                {
                    Console.WriteLine("Informe a opção desejada");
                    Console.WriteLine("1 - Listar Usuarios");
                    Console.WriteLine("2 - Inserir novo Usuario");
                    Console.WriteLine("3 - Deletar  Usuario");
                    Console.WriteLine("4 - Sair");
                    opcao = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("");

                    switch (opcao)
                    {
                        case 1:
                            {
                                ConsultarUsuario(UsuarioDao);
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Informe numero do cracha do usuario ");
                                string cdusu = Console.ReadLine();
                                Console.WriteLine("Informe Nome do usuario ");
                                string nmusu = Console.ReadLine();
                                InserirUsuario(1, 178, cdusu, nmusu, UsuarioDao);
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Informe numero do cracha do usuario ");
                                string cdusu = Console.ReadLine();

                                UsuarioDao.DeletarUsuario(1, cdusu);
                                break;
                            }
                        default:
                            break;
                    }
                }
               
                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();
                throw new Exception("Erro " + e);
            }
            finally
            {
                connection.Close();
            }
        }

        private static void InserirUsuario(double cnemp, double cncct, string cdusu, string nmusu, UsuariosDAO UsuarioDao)
        {
            Usuarios usuario = new Usuarios
            {
                Cnemp = cnemp,
                Cncct = cncct,
                Cdusu = cdusu,
                Nmusu = nmusu
            };

            UsuarioDao.InserirUsuario(usuario);
        }

        private static void ConsultarUsuario(UsuariosDAO UsuarioDao)
        {
            var listaUsuario = UsuarioDao.SelecionarUsuarios();

            for (int i = 0; i < listaUsuario.Count; i++)
            {
                Console.WriteLine(listaUsuario[i].Cdusurde.Trim() + " Nome do usuario " + listaUsuario[i].Nmusu);
            }
        }
    }
}

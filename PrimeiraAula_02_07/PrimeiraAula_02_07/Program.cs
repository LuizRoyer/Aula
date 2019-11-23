using System;
using System.Text;

namespace PrimeiraAula_02_07
{   /// <summary>
    /// Autour: Luiz 
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {  /*
            string texto = "Olá Mundo";

            Console.WriteLine("Hello World! \n" + texto);
            Console.WriteLine(10 % 2); // Saber se é divisivel par ou não

            int a, b, c;
            a = 1; b = 2;
            c = a + b;
            Console.WriteLine(c);

            // ternario
            bool x = a > b ? true : false;
          
                        Console.WriteLine(Nome());
                        Console.WriteLine(NomeCompleto());

                        Console.WriteLine("Escreva um Numero");
                        int n1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Escreva o segundo  Numero");
                        int n2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Resulado da Soma = " +Soma(n1,n2));

           
            // uso do Replace para substituir string por outra 
            string text01 = "Primeira aula de C#  , Fantastico";
            text01 = text01.Replace("C#", "ASP CORE");
            Console.WriteLine(text01);
            */

            // Substring 
            string teste = "teste"; teste.Substring(0, 1);

            teste.ToLower();// letras  Minusculo
            teste.ToUpper(); // letras  Maiusculo


            Math.Pow(10, 2); // podencia de 10 na 2
            Math.Sqrt(100); // raiz quadrado
            Math.Round(1012.12135, 2); // Arredondamento

            PrimeiraAtividade04_07();



            Console.ReadKey();
        }

        #region Atividade
        /// <summary>
        /// Crie um rpograma que receba tres parametros  nome , telefone e idade
        /// </summary>
        private static void PrimeiraAtividade04_07()
        {
            Console.WriteLine("Informe Seu Nome");
            string nome = Console.ReadLine();

            Console.WriteLine("Informe Sua Idade");
            int idade = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe Seu Telefone");
            string telefone = Console.ReadLine();

            telefone = FormatarTelefone(telefone);
            double raiz = CalcularRaizQuadra(idade);
            string nomeSeparado = SepararNome(nome);

            StringBuilder sb = new StringBuilder();
            sb.Append($@"Nome Formatado {nomeSeparado} Raiz da Idade = {raiz}  Telefone Formatado {telefone}");

            Console.WriteLine(sb.ToString());
            Console.ReadKey();

        }
        /// <summary>
        /// Colocar ; no espaço em branco entre o nome e sobrenome 
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        private static string SepararNome(string nome) => nome.Replace(" ", ";");
        private static double CalcularRaizQuadra(int idade) => Math.Sqrt(idade);

        /// <summary>
        /// Formatar Telefone em (xx) 9999-99999
        /// </summary>
        /// <param name="telefone"></param>
        /// <returns></returns>
        private static string FormatarTelefone(string telefone)
        {
            return string.Format("({0}){1}-{2}", telefone.Substring(0, 2), telefone.Substring(2, 4), telefone.Substring(6, 4));
        }
        #endregion

        public static string Nome()
        {
            return "Luiz";
        }
        public static string NomeCompleto() => "Luiz Felipe";
        public static double Soma(int a, int b) => a + b;
    }
}

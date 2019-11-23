using System;

namespace TerceiraAula_09_07
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
           Console.WriteLine("Informe sua Idade");
           int idade = Convert.ToInt32(Console.ReadLine());

           if (idade > 18 && idade <= 60)
           {
               Console.WriteLine("Adulto " + idade + " Anos");
           }
           else if (idade <= 18 && idade > 12)
           {
               Console.WriteLine("Adolecente " + idade + " Anos");
           }
           else if (idade < 12 && idade >= 0)
           {
               Console.WriteLine("Crianças " + idade + " Anos");
           }
           else
           {
               Console.WriteLine("Experiente " + idade + " Anos");
           }

            Console.WriteLine("Bem vindo Ao Banco ");
            Console.WriteLine(" ");
            Console.WriteLine("Informe sua Opção desejada ");
            Console.WriteLine(" ");
            Console.WriteLine(" 1- Extrato ");
            Console.WriteLine(" 2- Pagamento");
            Console.WriteLine(" 3- Saque ");
            Console.WriteLine(" 4- Deposito");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    {
                        Console.WriteLine("Seu Extrato ");
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Informe o Pagamento ");
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine("Quanto Gostaria de Sacar ");
                        break;
                    }
                case "4":
                    {
                        Console.WriteLine("Informe valor de Deposito ");
                        break;
                    }
                default:
                    Console.WriteLine("Opção Invalida ");
                    break;
            }
            
            //QuemGanhouACopa2014();

            //CalculeIMC();
            string time = "";


            while (!time.ToUpper().Equals("ALEMANHA"))
            {
                Console.WriteLine("Informe time que ganhou copa 2014");
                time = Console.ReadLine();
                if(!time.ToUpper().Equals("ALEMANHA"))
                Console.WriteLine("ERRO");
            }

            Console.WriteLine("Acertou");
          
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            */

           
         Console.ReadKey();
            }

            private static void CalculeIMC()
            {
                Console.WriteLine("Informe seu peso");
                string peso = Console.ReadLine();

                Console.WriteLine("Informe sua altura");
                string altura = Console.ReadLine();

                double imc = Convert.ToDouble(peso) / (Math.Pow(Convert.ToDouble(altura), 2));

                if (imc < 19)
                    Console.WriteLine("IMC Magreza");
                else if (imc < 25)
                    Console.WriteLine("IMC Normal");
                else if (imc < 30)
                    Console.WriteLine("IMC Sobrepeso");
                else if (imc < 40)
                    Console.WriteLine("IMC Obesidade I");
                else if (imc > 41)
                    Console.WriteLine("IMC Obesidade II");
                else
                    Console.WriteLine("Verifique suas Informações ");
            }

            /// <summary>
            /// peça ao usuario o time que ganhou a copa em 2014 se acertou diga acertou caso contrario informe que errou
            /// </summary>
            private static void QuemGanhouACopa2014()
            {
                Console.WriteLine("Informe Time ganhou a copa de 2014");
                string time = Console.ReadLine();

                switch (time.ToUpper())
                {
                    case "ALEMANHA":
                        {
                            Console.WriteLine("Errou");
                            break;
                        }
                    case "Portugal":
                        {
                            Console.WriteLine("Errou");
                            break;
                        }
                    case "EUA":
                        {
                            Console.WriteLine("Errou");
                            break;
                        }
                    case "BRASIL":
                        {
                            Console.WriteLine(" Parabéns Acertou");
                            break;
                        }
                    default:
                        Console.WriteLine(" Time não encontrado");
                        break;
                }
            }
        }
    }

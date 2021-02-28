using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        private static List<Conta> newContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = obterOpcaoDeUsuario();
            while (opcaoUsuario.ToUpper() != "S")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        listarContas();
                        break;
                    case "2":
                        inserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        SacarValor();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "S":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario = obterOpcaoDeUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o Id da conta ");
            int indexContaOrigem = int.Parse(Console.ReadLine());
            int indexContaDestino = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor do saque R$: ");
            double valorTransferencia = double.Parse(Console.ReadLine());
            newContas[indexContaOrigem].Transferencia(valorTransferencia, newContas[indexContaDestino]);
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o Id da conta ");
            int numConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor do saque R$: ");
            double valorDeposito = double.Parse(Console.ReadLine());
            newContas[numConta].Depositar(valorDeposito);
        }

        private static void inserirConta()
        {
            Console.WriteLine("Digite 1 para conta física ou 2 para jurídica");
            int entrarOpcao = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o titular da conta");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o numero da conta");
            string nuemeroConta = Console.ReadLine();
            Console.WriteLine("Digite o valor do depósito ");
            double saldo = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor do credito");
            double credito = double.Parse(Console.ReadLine());
            Conta conta = new Conta(tipoConta: (TipoConta)entrarOpcao, nome, nuemeroConta, saldo, credito);
            newContas.Add(conta);


        }
        private static string obterOpcaoDeUsuario()
        {
            Console.WriteLine();
            Console.WriteLine(" DIO.Bank One em que posso ajudar? ");
            Console.WriteLine(" Informe a opção desejada");
            Console.WriteLine(" 1 Listar contas");
            Console.WriteLine(" 2 Inserir nova conta");
            Console.WriteLine(" 3 Transferir ");
            Console.WriteLine(" 4 Sacar ");
            Console.WriteLine(" 5 Depositar ");
            Console.WriteLine(" S Sair");
            Console.WriteLine();
            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }

        private static void listarContas()
        {
            Console.WriteLine("------------Listar Contas-----------");
            if (newContas.Count == 0)
            {
                Console.WriteLine("Não existe contas cadastradas!");
                return;
            }
            for (int i = 0; i < newContas.Count; i++)
            {
                Conta obj = newContas[i];
                Console.Write(" {0}º ---", i);
                Console.WriteLine(obj);
            }

        }
        private static void SacarValor()
        {
            Console.WriteLine("Digite o Id da conta ");
            int numConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor do saque R$: ");
            double valorDeposito = double.Parse(Console.ReadLine());
            newContas[numConta].SacarValor(valorDeposito);
        }
    }
}

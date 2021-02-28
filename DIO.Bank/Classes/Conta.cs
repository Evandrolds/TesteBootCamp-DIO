using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    public class Conta
    {
       
        // Atributos da classe
        private TipoConta tipoConta { get; set; }
        private string titular { get; set; }
        private string conta { get; set; }
        private double saldo { get; set; }
        private double credito { get; set; }

        // Construtos da classe com os atributos
        public Conta(TipoConta tipoConta, string titular, string conta, double saldo, double credito)
        {
            this.tipoConta = tipoConta;
            this.titular = titular;
            this.conta = conta;
            this.saldo = saldo;
            this.credito = credito;
        }
        // Construtor da classe vazio
        public Conta()
        {

        }

        // Método para sacar
        public bool SacarValor(double valor)
        {

            if (saldo - valor < this.credito * -1)
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }
            this.saldo -= valor;
            Console.WriteLine("Saldo atual da conta de {0}  é de R${1} ", this.titular, this.saldo);
            return true;
        }
        // Método pata deposito
        // verifica se o valor de depósito é maior que 0.
        // se for, realiza o depósito, senão, retorna  a mensage a o usuário (valor insuficiente)
        public bool Depositar(double valor)
        {
            if (valor > 0)
            {
                this.saldo += valor;
                Console.WriteLine("Novo saldo R$ {0}", this.saldo);
                return true;
            }
            Console.WriteLine("Valor insuficiente para depósito ");
            return false;
        }

        // Método para realizar transferência, saca o valor de uma conta e deposita na conta de destino.
        //isso se o valor for maior que zero (0)
        public void Transferencia(double valorTranferencia, Conta contaDestino)
        {
            if (SacarValor(valorTranferencia))
            {
                contaDestino.Depositar(valorTranferencia);
                Console.WriteLine("Transferência realizada com susseço!");
                Console.WriteLine("Valor da tranferência para a conta {0 }foi de R${1}", contaDestino.titular, valorTranferencia);
            }


        }
        public override string ToString()
        {
            string retorno = "";
            retorno += " Tipo Conta: " + tipoConta;
            retorno += "\n Nome: " + this.titular;
            retorno += "\n Conta: " + this.conta;
            retorno += "\n Saldo R$ " + this.saldo;
            retorno += "\n Créditos: R$ " +this.credito;
            return retorno;
        }

    }
}
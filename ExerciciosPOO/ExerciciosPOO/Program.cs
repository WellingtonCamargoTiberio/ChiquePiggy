using ExerciciosPOO;
using System;
using System.Security.Cryptography.X509Certificates;


class Program
{
    private readonly Animal _animal;

    public Program( Animal animal)
    {
        _animal = animal;
    }

    
    static void Main(string[] args)
    {
        Carro carro1 = new Carro();
        carro1.Marca = "Fiat";
        carro1.Modelo = "Uno";
        carro1.Ano = 95;

        Carro carro2 = new Carro();
        carro2.Modelo = "Gol";
        carro2.Marca = "VW";
        carro2.Ano = 90;

        Carro carro3 = new Carro();
        carro3.Marca = "GM";
        carro3.Ano = 2000;
        carro3.Modelo = "Corsa";

        carro1.Ligar(carro1.Marca, carro1.Modelo, null);
        carro2.Ligar(null, carro2.Modelo, null);
        carro3.Ligar(carro3.Marca, carro3.Modelo, carro3.Ano);

        ContaPoupanca cb = new ContaPoupanca();
        cb.Depositar(10);
        cb.ExibirSaldo();
        cb.CalcularRendimento();

        Funcionario funcionario = new Funcionario();
        funcionario.Nome = "Wellington";
        funcionario.Idade = 35;
        funcionario.Salario = 5000;

        funcionario.funcionario();

        Cachorro cachorro = new Cachorro();
        cachorro.Falar();

        Gato gato = new Gato();
        gato.Falar(); 

        Vaca vaca = new Vaca();
        vaca.Falar();
    }


  
}

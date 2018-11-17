using System;
using System.Collections.Generic;

namespace FelizSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe um numero");
            string numeroInformado = Console.ReadLine();
            long numero;
            string mensagemFeliz, mensagemFinal;

            if (long.TryParse(numeroInformado, out numero))
            {
                if (IsFeliz(numero))
                    mensagemFeliz = " é feliz";
                else
                    mensagemFeliz = " não é feliz";

                if (IsSortudo(numero))
                    mensagemFinal = " e sortudo";
                else
                    mensagemFinal = " e não é sortudo";

                Console.WriteLine(string.Concat(numero,mensagemFeliz, mensagemFinal));
            }
            else
            {
                Console.WriteLine("Valor restrito para esta operação");
            }
            Console.ReadKey();

        }
        private static bool IsFeliz(long numero)
        {
            int contador  = 0;

            while (contador <= 100) // 100 o valor maxímo prédefinido para interação.
            {
                double resultadoSomaNumeroArray = 0;
                var listaNumeroArray = numero.ToString().ToCharArray();
                foreach (var item in listaNumeroArray) { resultadoSomaNumeroArray += Math.Pow(double.Parse(item.ToString()), 2); }               
                
                if (resultadoSomaNumeroArray == 1)
                    return true;
                else
                    numero = long.Parse(resultadoSomaNumeroArray.ToString());
                contador++;
            }
            return false;
        }
        private static bool IsSortudo(long numero)
        {
            List<long> listaNumeros = new List<long>();
            long auxiliar;
            int p;

            for (int i = 1; i <= numero; i++) { listaNumeros.Add(i);  }//montando uma lista com todos os valores ate chegar o numero informado 

            listaNumeros.RemoveAll(x => (x % 2 == 0)); // Removendo todos os numeros pares

            int t = 0;
            while (t < listaNumeros.Count)
            {
                 auxiliar = listaNumeros[t];
                //Console.WriteLine(listaNumeros[t]);
                 p = 1;
               
                while (1 == 1) // condição para força o loop ate o resultado ser maior que a quantidade de elementos no array.
                {
                    var resultado = Math.Pow(auxiliar, p);

                    if (resultado < listaNumeros.Count)
                    {
                         int index = int.Parse(resultado.ToString()) - 1;
                         listaNumeros.RemoveAt(index);
                         p++;
                    }
                    else
                    {
                        break;
                    }
                }
                t++;
            }

            return listaNumeros.Contains(numero); // Verificando se o número informado existe na lista após a limpeza

        }
    }
}

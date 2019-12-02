using System;
using System.Collections;

namespace ConsoleAppDuplicadosNaLista
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Insira o vetor contendo uma sequência de números inteiros separados por vírgulas (ex: 1,2,3): ");
                var vector = Console.ReadLine().ToString();
                var s = vector.Split(',');
                int[] array = Array.ConvertAll(s, int.Parse);
                var list = new ArrayList();
                var repeated = new ArrayList();

                for (int i = 0; i < array.Length; i++)
                {
                    if (list.Contains(array[i]) == false)
                    {
                        list.Add(array[i]);
                    }
                    else
                    {
                        repeated.Add(i);
                    }
                }

                Console.Clear();

                if (repeated.Count > 0)
                {
                    var result = "Iten(s) repetido(s) nos índice(s): ";
                    for (int i = 0; i < repeated.Count; i++)
                    {
                        result += repeated[i] + ",";
                    }
                    result = result.TrimEnd(',');
                    Console.WriteLine("Itens: " + vector);
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Nenhum item repetido.");
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            Console.ReadKey();
        }
    }
}

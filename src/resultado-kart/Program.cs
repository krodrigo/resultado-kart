using System;
using System.IO;

namespace resultado_kart
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                    throw new ArgumentException("Informe o caminho do arquivo de log");

                var log = new Log(args[0]);
                var linhas = log.ListarLinhasLog();
                var corrida = new Corrida(linhas);
                var resultado = corrida.GerarResultadoCorrida();

                Console.WriteLine(resultado);

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace resultado_kart
{
    /// <summary>
    /// Classe responsável por ler um arquivo de log de corrida,
    /// sanitizar os dados lidos e devolver o resultado 
    /// como uma lista de string
    /// </summary>
    public class Log
    {
        public Log(string caminhoLog)
        {
            Arquivo = caminhoLog;
        }

        private string Arquivo { get; }

        /// <summary>
        /// Método responsável por fazer a leitura de um arquivo de log de uma
        /// corrida de kart e devolver suas linhas em formato de lista
        /// <param name="arquivo">Caminho para o arquivo</param>
        /// <returns>Lista contendo as linhas do arquivo de log</returns>
        /// </summary>
        public IEnumerable<string> ListarLinhasLog()
        {
            using (var reader = new StreamReader(Arquivo))
            {
                var dadostxt = reader.ReadToEnd();
                return LimparTexto(dadostxt);
            }
        }

        /// <summary>
        /// Esse método faz a sanitização dos dados lidos no arquivo de log, pois ao 
        /// analisar os dados fornecidos para o teste notei que haviam TABs e espaços
        /// misturados para fazer a exibição em colunas.
        /// Após a sanitização, o arquivo é quebrado em linhas para ser devolvido ao chamador
        /// <remarks>
        /// Por se tratar de uma corrida de kart, a quantidade de registros não deve ser
        /// muito grande então o uso de expressão regular para tratar a mistura de TABs e espaços
        /// não deve trazer um problema de performance.
        /// A primeira linha do arquivo é desconsiderada.
        /// </remarks>
        /// <param name="dados">Dados lidos do arquivo e que serão sanitizados</param>
        /// <returns>Lista de string contendo as linha do arquivo de log</returns>
        /// </summary>
        public static IEnumerable<string> LimparTexto(string dados)
        {
            const char tab = '\u0009';
            const char space = ' ';
            const char pipe = '|';

            dados = dados.Replace(tab, space);
            dados = dados.Replace(" – ", "|");

            var dadoslimpos = Regex.Replace(dados, "^[ ]+|[ ]+$|([ ](?=[ ]+))", "", RegexOptions.Multiline);
            dadoslimpos = dadoslimpos.Replace(space, pipe);

            var linhas = dadoslimpos.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var linhasValidas = linhas.Take(linhas.Length - 1).Skip(1);

            return linhasValidas;
        }
    }
}

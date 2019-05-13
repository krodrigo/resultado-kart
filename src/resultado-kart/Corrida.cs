using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace resultado_kart
{
    /// <summary>
    /// Classe responsável por gerenciar os dados de uma corrida de kart
    /// </summary>
    public class Corrida
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="caminhoLog">Caminho do arquivo de log que será analisado</param>
        public Corrida(IEnumerable<string> log)
        {
            Voltas = ListarVoltas(log);
            Resultado = DefinirGrid();
        }

        private IEnumerable<Volta> Voltas { get; }
        public IEnumerable<Posicao> Resultado { get; private set; }

        /// <summary>
        /// Método responsável por listar as voltas de uma corrida passada por parâmetro
        /// <param name="dados">Linhas do arquivo de log em formato de lista</param>
        /// <return>Lista de voltas baseada nas linhas do arquivo de log</returns>
        /// </summary>
        private static IEnumerable<Volta> ListarVoltas(IEnumerable<string> dados)
        {
            foreach (var item in dados)
            {
                yield return new Volta(item);
            }
        }

        /// <summary>
        /// Método responsável listar os pilotos que participam da corrida
        /// e suas respectivas voltas
        /// <returns>Lista de pilotos e suas voltas</returns>
        /// </summary>
        private IEnumerable<Piloto> ListarDadosPilotos()
        {
            var pilotos = Voltas.Select(v => new Piloto(v.Piloto.Codigo, v.Piloto.Nome)).Distinct().ToList();

            pilotos.ToList().ForEach(p =>
            {
                p.Voltas = ListarVoltasPorPiloto(p);
            });

            return pilotos;
        }

        /// <summary>
        /// Listar as voltas de um determinado piloto
        /// </summary>
        /// <param name="piloto">Piloto</param>
        /// <returns>Voltas do piloto</returns>
        private IEnumerable<Volta> ListarVoltasPorPiloto(Piloto piloto)
        {
            return Voltas.Where(v => v.Piloto.Codigo == piloto.Codigo);
        }

        /// <summary>
        /// Método responsável por definir o grid de chegada dos participantes da corrida
        /// <remarks>
        /// Os dados fornecidos não estão ordenados por hora de registro da volta,
        /// por conta disso, foi necessário ordená-los para definir a posição de cada piloto
        /// </remarks>
        /// </summary>
        /// <param name="voltas">Voltas da corrida</param>
        /// <returns>Grid de chegada dos pilotos</returns>
        private IEnumerable<Posicao> DefinirGrid()
        {
            var voltaVencedora = ObterVoltaVencedora(Voltas);
            var resultado = new List<Posicao>();
            Posicao resultadoPiloto = null;

            var pilotos = ListarDadosPilotos();

            foreach (var piloto in pilotos)
            {
                resultadoPiloto = ObterResultadoPorPiloto(piloto, voltaVencedora);
                resultado.Add(resultadoPiloto);
            }

            resultado = resultado.OrderBy(o => o.TempoProva).ToList();

            for (var i = 0; i < resultado.Count; i++)
                resultado[i].Numero = i + 1;

            return resultado;
        }

        /// <summary>
        /// Obter a volta vencedora da corrida
        /// </summary>
        /// <param name="voltas">Voltas da corrida</param>
        /// <returns>Volta vencedora</returns>
        private Volta ObterVoltaVencedora(IEnumerable<Volta> voltas)
        {
            var qtdVoltas = voltas.Max(v => v.Numero);
            var vencedora = voltas.First(v => v.Numero == qtdVoltas);
            return vencedora;
        }

        /// <summary>
        /// Obter resultados da corrida por piloto
        /// </summary>
        /// <param name="piloto">Piloto</param>
        /// <param name="voltaVencedora">Volta de referência</param>
        /// <returns>Resultado do piloto na corrida</returns>
        private Posicao ObterResultadoPorPiloto(Piloto piloto, Volta voltaVencedora)
        {
            var ultimaVolta = piloto.Voltas.FirstOrDefault(v => v.Hora >= voltaVencedora.Hora);
            var voltasValidas = piloto.Voltas.Where(v => v.Hora <= ultimaVolta.Hora).ToList();
            var melhorVolta = voltasValidas.First(v => v.Duracao.TimeSpan == voltasValidas.Min(m => m.Duracao.TimeSpan));

            TimeSpan tempoProva = new TimeSpan();

            voltasValidas.ForEach(v =>
            {
                tempoProva = tempoProva.Add(v.Duracao.TimeSpan);
            });

            return new Posicao(piloto, voltasValidas.Count, tempoProva, ultimaVolta, melhorVolta);
        }

        /// <summary>
        /// Gerar o resultado visual da corrida
        /// </summary>
        /// <returns>Resultado da corrida em formato de grid de chegada</returns>
        public string GerarResultadoCorrida()
        {
            var sb = new StringBuilder();
            var titulo = "R E S U L T A D O   D A   C O R R I D A";
            var linha = new string('-', 76);

            titulo = titulo.PadLeft(((linha.Length - titulo.Length) / 2) + titulo.Length, ' ');

            sb.AppendLine(linha);
            sb.AppendLine(titulo);
            sb.AppendLine(linha);
            sb.AppendLine("| POSIÇÃO | PILOTO                     | VOLTAS | TEMPO TOTAL |    DELAY   |");
            sb.AppendLine(linha);

            var primeiraPosicao = Resultado.First();
            TimeSpan delay;

            foreach (var resultado in Resultado)
            {
                delay = resultado.TempoProva.Subtract(primeiraPosicao.TempoProva);
                sb.Append($"| {resultado.Numero.Value.ToString().PadLeft(7, ' ')}");
                sb.Append($" | {resultado.Piloto.Codigo.ToString().PadLeft(3, '0')} - {resultado.Piloto.Nome.PadRight(20, ' ')}");
                sb.Append($" | {resultado.VoltasCompletadas.ToString().PadLeft(6, ' ')}");
                sb.Append($" |   {resultado.TempoProva.Minutes:D2}:{resultado.TempoProva.Seconds:D2}.{resultado.TempoProva.Milliseconds:D3}");
                sb.Append($" | +{delay.Minutes:D2}:{delay.Seconds:D2}.{delay.Milliseconds:D3} |");
                sb.AppendLine();
            }

            sb.AppendLine(linha);

            return sb.ToString();
        }
    }
}
using System.Linq;
using Xunit;

namespace resultado_kart.test
{
    public class CorridaTest
    {
        #region Dados do log para o teste
        string dadosLog = @"Hora                               Piloto             Nº Volta   Tempo Volta       Velocidade média da volta
23:49:08.277      038 – F.MASSA                           1		1:02.852                        44,275
23:49:10.858      033 – R.BARRICHELLO                     1		1:04.352                        43,243
23:49:11.075      002 – K.RAIKKONEN                       1             1:04.108                        43,408
23:49:12.667      023 – M.WEBBER                          1		1:04.414                        43,202
23:49:30.976      015 – F.ALONSO                          1		1:18.456			35,47
23:50:11.447      038 – F.MASSA                           2		1:03.170                        44,053
23:50:14.860      033 – R.BARRICHELLO                     2		1:04.002                        43,48
23:50:15.057      002 – K.RAIKKONEN                       2             1:03.982                        43,493
23:50:17.472      023 – M.WEBBER                          2		1:04.805                        42,941
23:50:37.987      015 – F.ALONSO                          2		1:07.011			41,528
23:51:14.216      038 – F.MASSA                           3		1:02.769                        44,334
23:51:18.576      033 – R.BARRICHELLO		          3		1:03.716                        43,675
23:51:19.044      002 – K.RAIKKONEN                       3		1:03.987                        43,49
23:51:21.759      023 – M.WEBBER                          3		1:04.287                        43,287
23:51:46.691      015 – F.ALONSO                          3		1:08.704			40,504
23:52:01.796      011 – S.VETTEL                          1		3:31.315			13,169
23:52:17.003      038 – F.MASS                            4		1:02.787                        44,321
23:52:22.586      033 – R.BARRICHELLO		          4		1:04.010                        43,474
23:52:22.120      002 – K.RAIKKONEN                       4		1:03.076                        44,118
23:52:25.975      023 – M.WEBBER                          4		1:04.216                        43,335
23:53:06.741      015 – F.ALONSO                          4		1:20.050			34,763
23:53:39.660      011 – S.VETTEL                          2		1:37.864			28,435
23:54:57.757      011 – S.VETTEL                          3		1:18.097			35,633
";
        #endregion

        readonly Corrida Corrida = null;

        public CorridaTest()
        {
            var log = Log.LimparTexto(dadosLog);
            Corrida = new Corrida(log);
        }


        [Fact]
        public void CorridaDeveTerSeisParticipantes()
        {
            Assert.Equal(6, Corrida.Resultado.Count());
        }

        [Fact]
        public void VencedorDeveSerCodigo038()
        {
            Assert.Equal(38, Corrida.Resultado.First().Piloto.Codigo);
        }

        [Fact]
        public void SegundoLugarDeveSerCodigo002()
        {
            Assert.Equal(2, Corrida.Resultado.Skip(1).First().Piloto.Codigo);
        }

        [Fact]
        public void TerceiroLugarDeveSerCodigo033()
        {
            Assert.Equal(33, Corrida.Resultado.Skip(2).First().Piloto.Codigo);
        }

        [Fact]
        public void QuartoLugarDeveSerCodigo023()
        {
            Assert.Equal(23, Corrida.Resultado.Skip(3).First().Piloto.Codigo);
        }

        [Fact]
        public void QuintoLugarDeveSerCodigo015()
        {
            Assert.Equal(15, Corrida.Resultado.Skip(4).First().Piloto.Codigo);
        }

        [Fact]
        public void SextoLugarDeveSerCodigo011()
        {
            Assert.Equal(11, Corrida.Resultado.Skip(5).First().Piloto.Codigo);
        }
    }
}

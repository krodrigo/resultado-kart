# resultado-kart
Aplicação console em .net core 2.2 para listar informações de resultado de uma corrida de kart, dado um arquivo texto de entrada com os dados da corrida.

### Pré requisitos
Para executar o aplicativo é necessário ter o dotnet cli instalado
* [dotnet] Download .NET Core 2.2
* Arquivo de log com formato específico

### Exemplo de um log de corrida de kart
```
Hora                               Piloto             Nº Volta   Tempo Volta       Velocidade média da volta
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

```
# Resturação de pacotes e execução do programa
### Restauração de pacotes nuget
Após baixar o código fonte, é necessário restaurar os pacotes nuget do projeto, para isso executar o comando abaixo no console:
```
dotnet restore <caminho do projeto> <caminho do arquivo de log>
```
Exemplo:
```
dotnet restore c:\prj\src\resultado-kart\resultado-kart.csproj
```

### Execução do programa
No console, executar o comando abaixo no console:
```
dotnet run --project <caminho do projeto> <caminho do arquivo de log>
```
Exemplo:
```
dotnet run --project c:\prj\src\resultado-kart\resultado-kart.csproj c:\logs\corrida.log
```

### Resultado esperado
Para os dados fornecidos como exemplo, o resultado esperado na saída do console será conforme abaixo:
```
----------------------------------------------------------------------------
                  R E S U L T A D O   D A   C O R R I D A
----------------------------------------------------------------------------
| POSIÇÃO | PILOTO                     | VOLTAS | TEMPO TOTAL |    DELAY   |
----------------------------------------------------------------------------
|       1 | 038 - F.MASSA              |      4 |   04:11.578 | +00:00.000 |
|       2 | 002 - K.RAIKKONEN          |      4 |   04:15.153 | +00:03.575 |
|       3 | 033 - R.BARRICHELLO        |      4 |   04:16.080 | +00:04.502 |
|       4 | 023 - M.WEBBER             |      4 |   04:17.722 | +00:06.144 |
|       5 | 015 - F.ALONSO             |      4 |   04:54.221 | +00:42.643 |
|       6 | 011 - S.VETTEL             |      2 |   05:09.179 | +00:57.601 |
----------------------------------------------------------------------------
```
# Testes
### Execução dos testes
Para executar os testes, executar o comando abaixo no console:
```
dotnet test <caminho do projeto>
```
Exemplo:
```
dotnet test c:\prj\src\resultado-kart.test\resultado-kart.test.csproj
```
### Resultado esperado
Ao executar os testes, o resultado esperado na saída do console será conforme abaixo:
```
Build iniciada, aguarde...
Build concluído.

Execução de teste para c:\prj\src\resultado-kart.test\bin\Debug\netcoreapp2.2\resultado-kart.test.dll(.NETCoreApp,Version=v2.2)
Ferramenta de Linha de Comando de Execução de Teste da Microsoft (R) Versão 15.9.0
Copyright (c) Microsoft Corporation. Todos os direitos reservados.

Iniciando execução de teste, espere...

Total de testes: 7. Aprovados: 7. Com falha: 0. Ignorados: 0.
Execução de Teste Bem-sucedida.
Tempo de execução de teste: 1,9757 Segundos
```

### Todos

 - Adicionar mais testes
 - Adicionar suporte ao docker

License
MIT

[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)

[dotnet]: <https://dotnet.microsoft.com/download/dotnet-core/2.2>
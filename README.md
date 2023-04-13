
# A1 - LISTA DE FILMES

Este projeto tem por prop�sito consultar uma api de filmes com mais d e 9 milh�es de t�tulos, o usu�rio ser� capaz de pesquisar entre os titulos, adiciona-los a uma lista de filmes assistidos e adicionar a uma dentre suas listas de filmes para assistir, que poder�o ser separadas por categorias.

O usu�rio tamb�m � capaz de editar sua propria conta e listas.




## Demonstra��o

Insira um gif ou um link de alguma demonstra��o


![Alt Text](https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExNzgzZDRjNjg1OGE1ZjdlZmRjMmM3Mzc0OGViNTQyNGVlODAyOTMzMCZjdD1n/MjmHsjz3D9GFiRkHiy/giphy.gif)
## Vari�veis de Ambiente

Para rodar esse projeto, voc� vai precisar adicionar as seguintes vari�veis de ambiente no seu appsettings.json na raiz do projeto. 
para sua referencia, deixei um arquivo sample que vc pode estar editando para utilizar.

tamb�m � importante que voce v� at� o arquivo utils.cs, na pasta utils do projeto, e na linha 30 atualize o caminho do arquivo settings.json para aquele do computador rodando o projeto, pois o metodo utilizado espera o caminho literal.

`apiKey` : "minha chave";

voc� tamb�m deve providenciar a conex�o com um banco de dados sql, e realizar a configura��o de conex�o dentro do arquivo web.config, na raiz do projeto. 
abrindo o projeto, vc deve localizar a propriedade <connectionStrings> e alter�-la fornecendo os dados de conex�o com o seu servidor e banco de dados SQL.

ap�s isto, abrindo o console do gerenciador de projetos, voc� pode deve executar as migrations do banco de dados, utilizando o comando update-database, este comando tamb�m alimentar� o banco de dados.


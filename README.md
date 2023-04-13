
# A1 - LISTA DE FILMES

Este projeto tem por propósito consultar uma api de filmes com mais d e 9 milhões de títulos, o usuário será capaz de pesquisar entre os titulos, adiciona-los a uma lista de filmes assistidos e adicionar a uma dentre suas listas de filmes para assistir, que poderão ser separadas por categorias.

O usuário também é capaz de editar sua propria conta e listas.




## Demonstração

Insira um gif ou um link de alguma demonstração


![Alt Text](https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExNzgzZDRjNjg1OGE1ZjdlZmRjMmM3Mzc0OGViNTQyNGVlODAyOTMzMCZjdD1n/MjmHsjz3D9GFiRkHiy/giphy.gif)
## Variáveis de Ambiente

Para rodar esse projeto, você vai precisar adicionar as seguintes variáveis de ambiente no seu appsettings.json na raiz do projeto. 
para sua referencia, deixei um arquivo sample que vc pode estar editando para utilizar.

também é importante que voce vá até o arquivo utils.cs, na pasta utils do projeto, e na linha 30 atualize o caminho do arquivo settings.json para aquele do computador rodando o projeto, pois o metodo utilizado espera o caminho literal.

`apiKey` : "minha chave";

você também deve providenciar a conexão com um banco de dados sql, e realizar a configuração de conexão dentro do arquivo web.config, na raiz do projeto. 
abrindo o projeto, vc deve localizar a propriedade <connectionStrings> e alterá-la fornecendo os dados de conexão com o seu servidor e banco de dados SQL.

após isto, abrindo o console do gerenciador de projetos, você pode deve executar as migrations do banco de dados, utilizando o comando update-database, este comando também alimentará o banco de dados.


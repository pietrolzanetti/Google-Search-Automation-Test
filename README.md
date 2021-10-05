# Google-Search-Automation-Test

## Introducao

Realizacao de um desafio proposto pela Concert Technologies durante a sua avaliacao destinada a teste de software.

O desafio teve como objetivo a criacao de um projeto de automacao de testes para a pagina de busca do Google, utilizando o Dornet Core 3.1 e Selenium WebDriver.
  
## Funcoes utilizadas
 ```C#
public void CarregarPagina;
 ```
Carrega a pagina do Google.

 ```C#
public void PrintTela(string caminho);
 ```
Printa a tela atual.

Parametros:
  * ```caminho```: Caminho em que a imagem sera inserida ;
  
 ```C#
public void BuscaGoogle;
 ```
Realiza a busca desejada, no caso "Concert Technologies".

 ```C#
public void TesteOrdenacao;
 ```
Realiza uma filtragem da data de busca.

 ```C#
public void FuncionamentoNavigation;
 ```
Verifica o funcionamento de todas abas de navegacao.

 ```C#
public void FecharPagina;
 ```
Fecha o navegador.

 ```C#
private void ExecutaTesteGoogle(Browser browser);
 ```
Funcao principal, responsavel pela execucao das outras funcoes.

Parametros:
  * ```browser```: Define o browser em que sera testado ;
 
 

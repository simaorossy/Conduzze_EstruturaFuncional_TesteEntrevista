# Conduzze_EstruturaFuncional_TesteEntrevista

1 - Foi criado uma solução com dois projetos:
-Data : responsavel por todo o banco de dados, inclusive as Repository(classes feitas para fazer consulta e retornar exception do DB).
-MVC : responsavel por toda a comunicação cliente Servidor;
-Obs: nao senti nescessidade de criar a camada "services", pois o projeto era um crud simples. Ex:. nao tinha consulta em API's, calculos etc.

2 - toda a parte de comunicação front-end e controller, foi feio no Jquery usando o Ajax, para sanar uma das exigencias do cliente.

3 - Para evitar carregamento de paginas, fiz o cadastro/edição de funcionarios em uma pop-up na propria pagina "index"

4 - para filtrar a listagem de funcionarios, utilizei o database do jquery, para nao ser preciso reload na pagina e nova consulta no DB


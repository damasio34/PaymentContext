# Primitives Obsessioon
    - Obseção por tipos primitivos;
    - Com tipos primitivos perdemos os reusos,
        ex.: tipos number, e-mail, document usados no projeto,
        poderiam ser tipos complexos;
    - Temos a tendência por sempre usarmos tipos primitivos, 
        mas isso não é uma boa prática, o código vai ficando mais rico
        quando utulizamos tipos complexos, 
        o que reduz os pontos de teste e validação no código;
    - Exemplo da aplicação: no cenário onde é necessário validar a quantidade 
        de caracteres de uma string, pode se criar um método para escrever o processo apenas uma vez.
        Código de validação -> if (document.Length > 13)
        Método de validação -> EhMaior(string valor, int quantidade);
    - Cria um código mais maduro e mais testável.
# VO - Value Object
    - Dificilmente há validação de regras de negócio, 
        mas pode conter validações simples de dados, 
        como por exemplo: É vazio? Tem ao menos x caracteres?
    - São objetos de valor que compõem uma entidade;
    - Geralmente são persistidos dentro da entidade,
        ex: não existe uma tabela name.
# Sobre exceptions:
    - É o jeito mais fácil de estorar uma exceção, 
        mas tem um custo auto pro processador, pois uma exceção interrompe a thread.
        Quando uma exceção não é tratada, além de interromper a theread o erro é armazenado no log do windows.
        Não difícil de acontecer é travar o servidor pelo disparo de diversas exceptions nãot tratadas.
    - Qual da diferença de uma validação para uma exceção?
        - Uma exceção é quando ocorre algo que não era pra acontecer e aconteceu, 
            ex.: o banco fora, é algo que não era pra ocorrer, mas ocorreu.
        - Uma validação é algo que você espera que aconteça, algo previsto.
# SPOF - Single Point Of Fail -  Único Ponto de Falha
# CQRS - Comand Query Responsability Segregation 
    - Entenda comandos como escrita e query como leitura;
    - Dividir a escrita da leitura;
    - Em alguns casos há banco de dados distintos;
# Fail Fast Validation
    - Há cenários que são feitos diversos requests no banco ou a recursos do sistema
        em requisições que tendem a falhar, a ideia do fail fast validation e verificar 
        se o comando é válido antes de chegar ao domínio para não consumir recursos da aplicação.
# Repository pattern 
    - Nada mais é que uma abstração da parte de dados, 
        não é implementado persistência nessa camada, essa implementação fica para camada de 
        infraestrutura, onde você implementa os repositórios de acordo com a tecnologia e base
        de dados escolhidos para o projeto.
# Handlers
    - São basicamente a definição de fluxos do sistema.

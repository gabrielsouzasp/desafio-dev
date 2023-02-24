# Sobre o projeto e como executar

O projeto foi feito usando C# como linguagem, .NET 6 como framework, Mysql como banco de dados relacional, Bootstrap para o CSS e o framework AngularJS como front-end.
Foi feito em apenas um projeto (monolito) sem separar em camadas pela pouca complexidade necessária para funcionamento


1. Faça o clone desse repositório
2. Navegue até a pasta do projeto DesafioDev.Web
3. Inicie a pasta pelo prompt de comando
4. Execute o comando docker-compose up
5. Acesse a página entrando em http://localhost:5196/
6. Para fazer o upload do CNAB.txt acesse http://localhost:5196/Upload
7. Tem o swagger implementado na API que segue na url http://localhost:5196/swagger/index.html

# Problemas e confusões durante o desafio

1. Na documentação do CNAB diz que temos o total de 81 caracteres na string mas temos apenas o total de 80 <br />
  1.1 Soma (1 + 8 + 10 +11 + 12 + 6 + 14 + 19) Totaliza 81 mas no exemplo do CNAB temos apenas 80
2. Na documentação do CNAB ele começa o indice para tratamento a partir do 1 e na computação começamos a partir do 0 o que ocasionou uma confusão na hora de recuperar os dados
3. Na documentação sobre os tipos das transações ficou uma confusão no "Débito" pois acho que deveria ser "-" ao invés de "+" em uma transação de débito mas mantive de acordo com a documentação dizia "+"

# Testes unitários

Os testes unitários estão no projeto DesafioDev.UnitTest

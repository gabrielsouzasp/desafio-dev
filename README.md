# Sobre o projeto e como executar

O projeto foi feito usando C# como linguagem, .NET 6 como framework, Mysql como banco de dados relacional, Bootstrap para o CSS e o framework AngularJS como front-end.
Foi feito em apenas um projeto (monolito) sem separar em camadas pela pouca complexidade necessária para funcionamento


1. Faça o clone desse repositório
2. Navegue até a pasta do projeto DesafioDev.Web
3. Inicie a pasta pelo prompt de comando <br />
![image](https://user-images.githubusercontent.com/46653696/221074207-016b5384-f5d0-466c-8658-c7b44631ff29.png)<br />
4. Execute o comando docker-compose up<br />
![image](https://user-images.githubusercontent.com/46653696/221074418-76034493-7eee-46e8-94dc-ab55c9625047.png)<br />
5. Acesse a página entrando em http://localhost:5196/<br />
![image](https://user-images.githubusercontent.com/46653696/221075278-c2dafa37-c602-406c-8501-f321b1dc8e01.png)<br />
6. Para fazer o upload do CNAB.txt acesse http://localhost:5196/Upload<br />
![image](https://user-images.githubusercontent.com/46653696/221074686-669d8b49-c370-464f-8f32-e73104998e0a.png)<br />
7. Tem o swagger implementado na API que segue na url http://localhost:5196/swagger/index.html<br />
![image](https://user-images.githubusercontent.com/46653696/221074586-398c221e-5cc5-4a91-9944-3549d3b2fcb7.png)<br />


# Problemas e confusões durante o desafio

1. Na documentação do CNAB diz que temos o total de 81 caracteres na string mas temos apenas o total de 80 <br />
  1.1 Soma (1 + 8 + 10 +11 + 12 + 6 + 14 + 19) Totaliza 81 mas no exemplo do CNAB temos apenas 80
2. Na documentação do CNAB ele começa o indice para tratamento a partir do 1 e na computação começamos a partir do 0 o que ocasionou uma confusão na hora de recuperar os dados
3. Na documentação sobre os tipos das transações ficou uma confusão no "Débito" pois acho que deveria ser "-" ao invés de "+" em uma transação de débito mas mantive de acordo com a documentação dizia "+"

# Testes unitários

Os testes unitários estão no projeto DesafioDev.UnitTest
